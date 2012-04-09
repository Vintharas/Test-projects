using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Chapter6_ChildWindows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window independentWindow = new Window
                                        {
                                            Background = Brushes.AliceBlue,
                                            Title = "Window 1",
                                            Height = 120,
                                            Width = 170,
                                            Content = "Independent Window"
                                        };
            independentWindow.Show();

            Window childWindow = new Window
                                {
                                    Background = Brushes.PaleVioletRed,
                                    Title = "Window 2",
                                    Content = "Child Window",
                                    Height = 120,
                                    Width = 170,
                                    Owner = this // Make this a child window
                                };
            childWindow.Show();
        }
    }
}
