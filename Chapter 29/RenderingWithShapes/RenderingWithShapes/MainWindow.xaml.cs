namespace RenderingWithShapes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SelectedShape currentShape;

        public MainWindow()
        {
            this.InitializeComponent();
        }

        private enum SelectedShape
        {
            Circle, Rectangle, Line
        }

        private void CircleOption_Click(object sender, RoutedEventArgs e)
        {
            this.currentShape = SelectedShape.Circle;
        }

        private void RectOption_Click(object sender, RoutedEventArgs e)
        {
            this.currentShape = SelectedShape.Rectangle;
        }

        private void LineOption_Click(object sender, RoutedEventArgs e)
        {
            this.currentShape = SelectedShape.Line;
        }

        private void CanvasDrawingArea_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Shape shapeToRender = null;

            // Configure the shape
            switch (this.currentShape)
            {
                case SelectedShape.Circle:
                    shapeToRender = new Ellipse() { Height = 35, Width = 35 };

                    RadialGradientBrush brush = new RadialGradientBrush();
                    brush.GradientStops.Add(new GradientStop((Color)ColorConverter.ConvertFromString("#FF254025"), 0.124));
                    brush.GradientStops.Add(new GradientStop((Color)ColorConverter.ConvertFromString("#FFAFF0AF"), 0.427));
                    brush.GradientStops.Add(new GradientStop(Colors.Green, 0.901));
                    shapeToRender.Fill = brush;
                    break;
                case SelectedShape.Rectangle:
                    shapeToRender = new Rectangle() { Fill = Brushes.Red, Height = 35, Width = 35, RadiusX = 5, RadiusY = 5 };
                    break;
                case SelectedShape.Line:
                    shapeToRender = new Line() 
                    { 
                        Stroke = Brushes.Blue, 
                        StrokeThickness = 10, 
                        X1 = 0, X2 = 50, Y1 = 0, Y2 = 50, 
                        StrokeStartLineCap = PenLineCap.Triangle, 
                        StrokeEndLineCap = PenLineCap.Round 
                    };
                    break;
                default:
                    return;
            }

            if (true == this.flipCanvas.IsChecked)
            {
                this.TransformObject(shapeToRender);
            }

            // set position feom mouse (anchored in top left)
            Canvas.SetLeft(shapeToRender, e.GetPosition(canvasDrawingArea).X);
            Canvas.SetTop(shapeToRender, e.GetPosition(canvasDrawingArea).Y);

            // Draw the shaaaape
            canvasDrawingArea.Children.Add(shapeToRender);
        }

        private void TransformObject(FrameworkElement transMe)
        {
            transMe.LayoutTransform = new RotateTransform(-180);
        }

        private void CanvasDrawingArea_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            // get the X,Y of the click event
            Point pt = e.GetPosition((Canvas)sender);

            // use HitTest() in VisualTreeHelper to see if the use clicked on an item
            HitTestResult result = VisualTreeHelper.HitTest(canvasDrawingArea, pt);

            // non-null result means they clicked on something
            if (null != result)
            {
                // get the shape and remove it from the canvas
                canvasDrawingArea.Children.Remove(result.VisualHit as Shape);
            }
        }

        private void FlipCanvas_Click(object sender, RoutedEventArgs e)
        {
            if (true == this.flipCanvas.IsChecked)
            {
                ////RotateTransform rotate = new RotateTransform(-180);
                ////canvasDrawingArea.LayoutTransform = rotate;
                this.TransformObject(this.canvasDrawingArea);
            }
            else
            {
                this.canvasDrawingArea.LayoutTransform = null;
            }
        }
    }
}
