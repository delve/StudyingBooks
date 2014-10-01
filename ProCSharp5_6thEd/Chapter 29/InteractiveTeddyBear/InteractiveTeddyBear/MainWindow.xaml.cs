namespace InteractiveTeddyBear
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

        private void LeftEye_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // change color when clicked
            leftEye.Fill = new SolidColorBrush(Colors.Red);
        }

        private void RightEar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // blur the ear when clicked
            System.Windows.Media.Effects.BlurEffect blur = new System.Windows.Media.Effects.BlurEffect();
            blur.Radius = 10;
            rightEar.Effect = blur;
        }
    }
}
