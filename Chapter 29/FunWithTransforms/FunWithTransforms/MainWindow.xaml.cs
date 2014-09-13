namespace FunWithTransforms
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
        public MainWindow()
        {
            this.InitializeComponent();
        }

        private void BtnFlip_Click(object sender, RoutedEventArgs e)
        {
            ScaleTransform transform = new ScaleTransform(-1, 1);
            this.myCanvas.LayoutTransform = transform;
        }

        private void BtnRotate_Click(object sender, RoutedEventArgs e)
        {
            RotateTransform transform = new RotateTransform(20);
            this.myCanvas.LayoutTransform = transform;
        }

        private void BtnSkew_Click(object sender, RoutedEventArgs e)
        {
            SkewTransform transform = new SkewTransform(20, 10);
            this.myCanvas.LayoutTransform = transform;
        }
    }
}
