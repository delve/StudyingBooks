namespace MyWordPad
{
    using Microsoft.Win32;
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
            SetBindingF1CommandBinding();
        }

        private void SetBindingF1CommandBinding()
        {
            CommandBinding helpBinding = new CommandBinding(ApplicationCommands.Help);
            helpBinding.CanExecute += CanHelpExecute;
            helpBinding.Executed += HelpExecuted;
            this.CommandBindings.Add(helpBinding);
        }

        private void HelpExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("Really? <sigh>");
        }

        void CanHelpExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            // here you'd set CanExecute to false to prevent execution when it doesn't make sense (like, copy when no text is highlighted)
            e.CanExecute = true;
        }

        private void MouseEnterExitArea(object sender, MouseEventArgs e)
        {
            this.StatBarText.Text = "Exit the application";
        }

        private void MouseLeaveArea(object sender, MouseEventArgs e)
        {
            this.StatBarText.Text = "Ready!";
        }

        private void FileExit_Click(object sender, RoutedEventArgs e)
        {
            // close the app
            this.Close();
        }

        private void ToolsSpellingHints_Click(object sender, RoutedEventArgs e)
        {
            string spellingHints = string.Empty;

            // look for spelling errors at the current caret location
            SpellingError error = txtData.GetSpellingError(txtData.CaretIndex);
            if (error != null)
            {
                foreach (string s in error.Suggestions)
                {
                    spellingHints += string.Format("{0}\n", s);
                }

                // show suggestions and expand the expander
                lblSpellingHints.Content = spellingHints;
                ExpanderSpelling.IsExpanded = true;
            }
        }

        private void MouseEnterToolsHintsArea(object sender, MouseEventArgs e)
        {
            this.StatBarText.Text = "Get spelling tips from Microsoft!";
        }

        private void OpenCmdCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void SaveCmdCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void OpenCmdExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            OpenFileDialog openDlg = new OpenFileDialog();
            openDlg.Filter = "Text Files (*.txt)|*.txt|All files (*.*)|*.*";

            // if they clicked OK
            if (true == openDlg.ShowDialog())
            {
                // load the file
                string dataFromFile = File.ReadAllText(openDlg.FileName);

                // and display the data
                txtData.Text = dataFromFile;
            }
        }

        private void SaveCmdExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            SaveFileDialog saveDlg = new SaveFileDialog();
            saveDlg.Filter = "Text files (*.txt)|*.txt";

            // save the data to the selected file
            File.WriteAllText(saveDlg.FileName, txtData.Text);
        }
    }
}
