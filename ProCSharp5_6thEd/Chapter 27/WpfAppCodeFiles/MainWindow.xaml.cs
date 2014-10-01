// MainWindows.xaml.cs
using System;
using System.Windows;
using System.Windows.Controls;

namespace WpfAppAllXaml
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            //InitializeComponent is defined in the MainWindow.g.cs file
            InitializeComponent();
        }

        private void btnExitApp_Clicked(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}