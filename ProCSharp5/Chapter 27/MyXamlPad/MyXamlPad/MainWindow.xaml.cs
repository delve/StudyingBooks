namespace MyXamlPad
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Markup;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // when the main window loads we'll load the xaml from the last execution or some
            // basic starter xaml
            if (File.Exists("YourXaml.xaml"))
            {
                txtXamlData.Text = File.ReadAllText("YourXaml.xaml");
            }
            else
            {
                txtXamlData.Text =
                    "<Window xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\"\n" +
                    "    xmlns:x=\"http://schemas.microsoft.com/winfx/2006/xaml\"\n" +
                    "    Height=\"400\" Width=\"500\" WindowStartupLocation=\"CenterScreen\">\n" +
                    "  <StackPanel>\n  </StackPanel>\n" +
                    "</Window>";
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            // save the input
            File.WriteAllText("YourXaml.xaml", txtXamlData.Text);
            Application.Current.Shutdown();
        }

        private void BtnViewXaml_Click(object sender, RoutedEventArgs e)
        {
            // serialize the user input
            File.WriteAllText("YourXaml.xaml", txtXamlData.Text);

            // target window for the serializewd XAML
            Window myWindow = null;
            try
            {
                using (Stream sr = File.Open("YourXaml.xaml", FileMode.Open))
                {
                    // connect the XAML to the window
                    myWindow = (Window)XamlReader.Load(sr);

                    // show as a modal dialog
                    myWindow.ShowDialog();
                    myWindow.Close();
                    myWindow = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
