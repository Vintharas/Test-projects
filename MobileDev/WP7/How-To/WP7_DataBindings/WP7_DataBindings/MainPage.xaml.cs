using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;

namespace WP7_DataBindings
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }
    }

    public class EllipsePOCO
    {
        public Brush Fill { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }

    public class Car
    {
        public EllipsePOCO SteeringWheel { get; set; }
    }

}