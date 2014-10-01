namespace WpfControlsAndAPIs
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Annotations;
    using System.Windows.Annotations.Storage;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Ink;
    using System.Windows.Input;
    using System.Windows.Markup;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    using AutoLotDAL;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();

            // Ink API tab defaults
            this.radioInk.IsChecked = true;
            this.myInkCanvas.EditingMode = InkCanvasEditingMode.Ink;
            this.comboColors.SelectedIndex = 0;

            // setup the document tab
            this.PopulateDocument();

            // allow annotation
            this.EnableAnnotations();

            // rig up click handlers for the save/load doc buttons
            btnSaveDoc.Click += (o, s) =>
                {
                    using (FileStream fs = File.Open("documentData.xaml", FileMode.Create))
                    {
                        XamlWriter.Save(this.myDocumentReader.Document, fs);
                    }
                };
            btnLoadDoc.Click += (o, s) =>
                {
                    using (FileStream fs = File.Open("documentData.xaml", FileMode.Open))
                    {
                        try
                        {
                            FlowDocument doc = XamlReader.Load(fs) as FlowDocument;
                            this.myDocumentReader.Document = doc;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Error Loading Doc");
                        }
                    }
                };
            
            // setup data binding with the IValueConverter object
            this.SetBindings();

            // setup the data grid
            this.ConfigureGrid();
        }

        private void ConfigureGrid()
        {
            using (AutoLotEntities context = new AutoLotEntities())
            {
                // Build a LINQ query that gets back some data from the inventory table 
                // (which I don't really grok since I skipped those chapters >.<  I'll come back to them later)
                // this actually causes failures because SQLExpress doesn't answer the request (obv). so, commenting out
                ////var dataToShow = from c in context.Inventories
                ////                 select new { c.CarID, c.Make, c.Color, c.PetName };
                ////this.gridInventory.ItemsSource = dataToShow;
            }
        }

        private void SetBindings()
        {
            // Create a binding object
            Binding b = new Binding();

            // register the converter, source, and path
            b.Converter = new MyDoubleConverter();
            b.Source = this.mySB;
            b.Path = new PropertyPath("Value");

            // set the new binding object on the label
            this.labelSBThumb.SetBinding(Label.ContentProperty, b);
        }

        private void RadioButtonClicked(object sender, RoutedEventArgs e)
        {
            RadioButton selected = sender as RadioButton;
            if (null != selected)
            {
                switch (selected.Name)
                {
                    case "radioInk":
                        this.myInkCanvas.EditingMode = InkCanvasEditingMode.Ink;
                        break;
                    case "radioErase":
                        this.myInkCanvas.EditingMode = InkCanvasEditingMode.EraseByStroke;
                        break;
                    case "radioSelect":
                        this.myInkCanvas.EditingMode = InkCanvasEditingMode.Select;
                        break;
                    default:
                        break;
                }                
            }
        }

        private void ColorChanged(object sender, SelectionChangedEventArgs e)
        {
            // get the color from the selected combobox item
            string colorToUse = (this.comboColors.SelectedItem as StackPanel).Tag.ToString();

            // change the active drawing color
            this.myInkCanvas.DefaultDrawingAttributes.Color = (Color)ColorConverter.ConvertFromString(colorToUse);
        }

        private void SaveData(object sender, RoutedEventArgs e)
        {
            // save the strokes on the canvas
            using (FileStream fs = new FileStream("StrokeData.bin", FileMode.Create))
            {
                this.myInkCanvas.Strokes.Save(fs);
                fs.Close();
            }
        }

        private void LoadData(object sender, RoutedEventArgs e)
        {
            // load pre-existing strokes file
            using (FileStream fs = new FileStream("StrokeData.bin", FileMode.Open, FileAccess.Read))
            {
                StrokeCollection strokes = new StrokeCollection(fs);
                this.myInkCanvas.Strokes = strokes;
            }
        }

        private void Clear(object sender, RoutedEventArgs e)
        {
            // clear the canvas
            this.myInkCanvas.Strokes.Clear();
        }

        private void PopulateDocument()
        {
            // configure the list
            List thisList = this.listOfFunFacts;
            thisList.FontSize = 14;
            thisList.MarkerStyle = TextMarkerStyle.Circle;

            // populate the list
            thisList.ListItems.Add(new ListItem(new Paragraph(new Run("Fixed documents are for WYSIWYG print ready docs"))));
            thisList.ListItems.Add(new ListItem(new Paragraph(new Run("The API supports tables and embedded figures"))));
            thisList.ListItems.Add(new ListItem(new Paragraph(new Run("Flow documents are read only"))));
            thisList.ListItems.Add(new ListItem(new Paragraph(new Run("BlockUIContainer allows you to embed WPF controls in the document"))));

            // add text to the paragraph
            // first sentence fragment
            Run prefix = new Run("This paragraphwas generated ");

            // middle part of the paragraph
            Bold b = new Bold();
            Run infix = new Run("dynamically");
            infix.Foreground = Brushes.Red;
            infix.FontSize = 30;
            b.Inlines.Add(infix);

            // the last part of the paragraph
            Run suffix = new Run(" at runtime");

            // put it all in the paragraph
            this.paraBodyText.Inlines.Add(prefix);
            this.paraBodyText.Inlines.Add(infix);
            this.paraBodyText.Inlines.Add(suffix);
        }

        private void EnableAnnotations()
        {
            // Create the AnnotationService object for the FlowDocumentReader
            AnnotationService annoService = new AnnotationService(myDocumentReader);

            // Create the MemoryStream to hold the annotations
            MemoryStream annoMem = new MemoryStream();

            // Create an XML based store interpreter into the MemoryStream
            // This object would be used to programmatically add, delete, or find annotations
            AnnotationStore store = new XmlStreamStore(annoMem);

            // Enable annotation with the XML store
            annoService.Enable(store);
        }
    }
}
