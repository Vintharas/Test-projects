using System.Windows;
using System.Windows.Input;

namespace Chapter9_TunnelingRoutedEvents
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

        private void TheBorder_OnMouseUp(object sender, MouseButtonEventArgs e)
        {
            tbEventInformation.Text += "Bubbling: Border sees it.\r\n"; 
        }

        private void jaime_MouseUp(object sender, MouseButtonEventArgs e)
        {
            tbEventInformation.Text += "Bubbling: Jaime sees it.\r\n"; 
        }

        private void theLabel_MouseUp(object sender, MouseButtonEventArgs e)
        {
            tbEventInformation.Text += "Bubbling: Label sees it.\r\n"; 
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            tbEventInformation.Text = "";
        }

        private void theBorder_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            tbEventInformation.Text += "Tunneling: Border sees it.\r\n"; 
        }

        private void theLabel_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            tbEventInformation.Text += "Tunneling: Label sees it.\r\n"; 
        }

        private void jaime_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            tbEventInformation.Text += "Tunneling: Jaime sees it.\r\n"; 
        }
    }
}
