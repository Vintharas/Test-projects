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

namespace Chapter9_BubblingRoutedEvents
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

        private void jaime_MouseUp(object sender, MouseButtonEventArgs e)
        {
            tbEventInformation.Text += "Jaime sees it\r\n";

        }

        private void theLabel_MouseUp(object sender, MouseButtonEventArgs e)
        {
            tbEventInformation.Text += "Label sees it.\r\n";
        }

        private void TheBorder_OnMouseUp(object sender, MouseButtonEventArgs e)
        {
            tbEventInformation.Text += "Border sees it.\r\n";
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            tbEventInformation.Text = "";
        }
    }
}
