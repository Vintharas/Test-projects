using System;
using System.Windows;

using Microsoft.Phone.Controls;

namespace WP7HomeInventory
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        private void btnCategories_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Categories.xaml", UriKind.Relative));
        }
    }
}