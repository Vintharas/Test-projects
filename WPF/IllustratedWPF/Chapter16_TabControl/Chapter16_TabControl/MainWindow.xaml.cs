using System.Windows;
using System.Windows.Controls;

namespace Chapter16_TabControl
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // new tabs can be added dynamically
            TabItem ti = new TabItem();
            ti.Header = "Dynamic Tab";
            ti.Content = "This tab was added dynamically";
            simpleTabs.Items.Add(ti);
        }
    }
}
