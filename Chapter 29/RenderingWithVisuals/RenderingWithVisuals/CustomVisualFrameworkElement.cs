namespace RenderingWithVisuals
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Input;
    using System.Windows.Media;

    public class CustomVisualFrameworkElement : FrameworkElement
    {
        private VisualCollection theVisuals;

        public CustomVisualFrameworkElement()
        {
            // Fill the VisualCollection with a few DrawingVisual objects
            // The CTOR arg represents the owner of the visuals
            this.theVisuals = new VisualCollection(this);
            this.theVisuals.Add(this.AddRect());
            this.theVisuals.Add(this.AddCircle());

            // Events
            this.MouseDown += this.MyVisualHost_MouseDown;
        }

        protected override int VisualChildrenCount
        {
            get
            {
                return this.theVisuals.Count;
            }
        }

        protected override Visual GetVisualChild(int index)
        {
            // value must be greater than 0 so a quick sanity check is in order
            if (index < 0 || index >= this.theVisuals.Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            return this.theVisuals[index];
        }

        private void MyVisualHost_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // determine where the user clicked
            Point p = e.GetPosition((UIElement)sender);

            // Call helper function via delegaete to see if we clicked on a visual.
            VisualTreeHelper.HitTest(this, null, new HitTestResultCallback(this.MyCallback), new PointHitTestParameters(p));
        }

        private HitTestResultBehavior MyCallback(HitTestResult result)
        {
            // Toggle between skew transform and normal rendering if a visual is clicked
            if (null == ((DrawingVisual)result.VisualHit).Transform)
            {
                ((DrawingVisual)result.VisualHit).Transform = new SkewTransform(7, 7);
            }
            else
            {
                ((DrawingVisual)result.VisualHit).Transform = null;
            }

            // tell HitTest() to stop drilling deeper into the Visual tree
            return HitTestResultBehavior.Stop;
        }

        private Visual AddCircle()
        {
            DrawingVisual drawingVisual = new DrawingVisual();

            // Retrieve the DrawingContext in order to create new drawing content
            using (DrawingContext drawingContext = drawingVisual.RenderOpen())
            {
                // create a circle and draw it in the DrawingContext
                drawingContext.DrawEllipse(
                    Brushes.DarkBlue, 
                    null, 
                    new Point(70, 90), 
                    40, 
                    50);
            }

            return drawingVisual;
        }

        private Visual AddRect()
        {
            DrawingVisual drawingVisual = new DrawingVisual();

            // get a context to for the visual object to draw into
            using (DrawingContext drawingContext = drawingVisual.RenderOpen())
            {
                Rect rect = new Rect(
                    new Point(160, 100), 
                    new Size(320, 80));
                drawingContext.DrawRectangle(Brushes.Tomato, null, rect);
            }

            return drawingVisual;
        }
    }
}
