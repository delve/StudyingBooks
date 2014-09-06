namespace WpfAppAllCode
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;

    public class MainWindow : Window
    {
        private Button exitAppBtn = new Button();
        private string baseButtonText = "Exit Application";
        private string baseTitle;

        public MainWindow(string windowTitle, int height, int width)
        {
            // Configure the button and set the child control
            this.exitAppBtn.Click += new RoutedEventHandler(this.ExitAppBtn_Clicked);
            this.exitAppBtn.Content = this.baseButtonText;
            this.exitAppBtn.Height = 25;
            this.exitAppBtn.Width = 150;
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.Show();

            // set window content to this single button
            this.Content = this.exitAppBtn;
            
            // configure the window
            this.baseTitle = windowTitle;
            this.Title = this.baseTitle;
            this.Height = height;
            this.Width = width;

            // prevent unintended closing
            this.Closing += this.MainWindow_Closing;
            this.Closed += this.MainWindow_Closed;

            // Mouse input routines
            this.MouseMove += this.MainWindow_MouseMove;

            // Keyboard input routines
            this.KeyDown += this.MainWindow_KeyDown;
        }

        private void MainWindow_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            this.exitAppBtn.Content = string.Format("{0} - Key: {1}", this.baseButtonText, e.Key.ToString());
        }

        private void MainWindow_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            this.Title = string.Format("{0} : Your mouse is at {1}", this.baseTitle, e.GetPosition(this).ToString());
        }

        private void MainWindow_Closed(object sender, EventArgs e)
        {
            MessageBox.Show("Buhbye");
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // does the user really want to quit?
            string msg = "Do you really really really wanna quit?\nTime for quiche?";
            MessageBoxResult result = MessageBox.Show(msg, "My App", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (MessageBoxResult.No == result)
            {
                // cancel crash
                e.Cancel = true;
            }
        }

        // button click handler
        private void ExitAppBtn_Clicked(object sender, RoutedEventArgs e)
        {
            // were we cheating? <gasp>
            if ((bool)Application.Current.Properties["GodMode"])
            {
                MessageBox.Show("Cheatin' eh? You must be busy.");
            }

            // close the window
            this.Close();
        }
    }
}
