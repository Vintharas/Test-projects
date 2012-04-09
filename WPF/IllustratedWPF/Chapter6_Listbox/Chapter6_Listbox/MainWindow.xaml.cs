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

namespace Chapter6_Listbox
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

        private void OnClick(object sender, RoutedEventArgs e)
        {
            ListBoxItem selectedItem = theListbox.SelectedItem as ListBoxItem;
            string item = selectedItem == null ? "No item" : selectedItem.Content as string;
            MessageBox.Show(item + " selected");
        }

        private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MessageBox.Show("Selection changed!");
        }
    }
}
