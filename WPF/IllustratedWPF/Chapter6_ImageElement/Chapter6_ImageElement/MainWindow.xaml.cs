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

namespace Chapter6_ImageElement
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Adding an image element in code
            // with bare XAML definiton i.e. <Window ....> </Window>
            //Uri uri = new Uri("Pictures/8bitjaime_bigger.png", UriKind.Relative);
            //BitmapImage bitmap = new BitmapImage(uri);
            //Image image = new Image();
            //image.Source = bitmap;

            //Grid grid = new Grid();
            //grid.Children.Add(image);
            //Grid.SetRow(image, 0);
            //Grid.SetColumn(image, 0);
            //Content = grid;
        }
    }
}
