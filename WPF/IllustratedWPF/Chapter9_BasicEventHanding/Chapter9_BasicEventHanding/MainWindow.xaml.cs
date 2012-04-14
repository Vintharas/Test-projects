using System.Windows;
using System.Windows.Input;

namespace Chapter9_BasicEventHanding
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

        private void theButton_Click(object sender, RoutedEventArgs e)
        {
            string c = theButton.Content.ToString();
            theButton.Content = (c == "Clicked" || c == "Clicked Again") ? "Clicked Again" : "Clicked";
        }

        private void theButton_MouseEnter(object sender, MouseEventArgs e)
        {
            theButton.Content = "Mouse Over";
        }

        private void theButton_MouseLeave(object sender, MouseEventArgs e)
        {
            theButton.Content = "Click Me";
        }
    }
}
