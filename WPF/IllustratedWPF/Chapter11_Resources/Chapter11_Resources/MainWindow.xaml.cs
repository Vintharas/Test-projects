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

namespace Chapter11_Resources
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            /* 
            // #### Adding resources in code-behind ####
            
            Brush silverBrush = Brushes.Silver;
            // The resources can be stored in an element up in the tree
            theStackPanel.Resources.Add(key: "background", value: silverBrush);
            // or in the application level
            // App application = (App) Application.Current;
            // application.Resources.Add(key: "background", silverBrush);


            // Setting the background of the button using a resource
            // Note that the FindResource starts in the button element and goes up the tree looking
            // for a resource with a key == "background"
            theButton.Background = (Brush) theButton.FindResource("background");
            // FindResource throws an exception if it can't find the resource
            // You have the option to use TryFindResource instead which returns null if it doesn't find the resource
            theButton.Background = (Brush) theButton.TryFindResource("background");
            if (theButton.Background == null)
                theButton.Background = Brushes.AliceBlue;
            
             
            */
        }
    }
}
