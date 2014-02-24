using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using PetSounds.Resources;

namespace PetSounds
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Just to illustrate that XAML just provides
            // a declarative way to instantiate/configure controls
            // We can easily see how we can create controls in the code behing
            // in a imperative fashion (as opposed to declaratively like in XAML)
            Button myButton = new Button();
            myButton.Name = "MeowButton";
            myButton.Width = 200;
            myButton.Height = 200;
            myButton.VerticalAlignment = VerticalAlignment.Top;
            myButton.HorizontalAlignment = HorizontalAlignment.Left;
            myButton.Background = new SolidColorBrush(Colors.Red);
            myButton.Content = "Meow";
            ContentPanel.Children.Add(myButton);

            myButton.Margin = new Thickness(210, 0, 0, 0);
            myButton.Click += PlayRadioButton_OnClick;
        }

        private void PlayRadioButton_OnClick(object sender, RoutedEventArgs e)
        {
            QuackMediaElement.Play();
        }
    }
}