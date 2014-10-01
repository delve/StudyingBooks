namespace WpfAppAllCode
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;

    public class Program : Application
    {
        [STAThread]
        public static void Main(string[] args)
        {
            // instansiate the program
            Program app = new Program();

            // Register for startup and exit events
            app.Startup += AppStartUp;
            app.Exit += AppExit;

            // Fires the startup event
            app.Run();
        }

        public static void AppExit(object sender, ExitEventArgs e)
        {
            MessageBox.Show("App has exited");
        }

        public static void AppStartUp(object sender, StartupEventArgs e)
        {
            // look for incoming command-line args and handle '/GODMODE'. heh. heheh.
            Application.Current.Properties["GodMode"] = false;
            foreach (string arg in e.Args)
            {
                if (arg.ToLower() == "/godmode")
                {
                    Application.Current.Properties["GodMode"] = true;
                    break;
                }
            }

            // create a Window object and set some basic props
            Window wnd = new MainWindow("My better firs WPF app!", 200, 300);

            /* playing around 
            MessageBox.Show("Shrink-ify");
            foreach (Window win in Current.Windows)
            {
                wnd.WindowState = WindowState.Minimized;
            }

            MessageBox.Show("Mini-me-ed");
            foreach (Window win in Current.Windows)
            {
                wnd.WindowState = WindowState.Normal;
            }
            */
        }
    }
}
