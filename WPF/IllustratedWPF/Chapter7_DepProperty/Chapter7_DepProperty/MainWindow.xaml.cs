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

namespace Chapter7_DepProperty
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window  // Window derives from DependencyObject, so MainWindow is already set up to handle dependency properties
    {
        public static readonly DependencyProperty SidesProperty;  // By convention, add the suffix Property to your dependency properties
        public int Sides  // CLR property that acts as a wrapper of the dependency property, by convention, same names as dep. property but without "Property" suffix
        {
            get { return (int) GetValue(SidesProperty); }
            set { SetValue(SidesProperty, value); }
        }

        static MainWindow()
        {
            // Create a FrameworkPropertyMetadata object that will contain information
            // regarding how the WPF property system should handle SidesProperty dependency property
            FrameworkPropertyMetadata metadata = new FrameworkPropertyMetadata();
            metadata.PropertyChangedCallback = OnSidesChange;
            // Register SidesProperty in the WPF property system
            // When a dependency property is registered in WPF property system via Register, it returns a property identifier
            SidesProperty = DependencyProperty.Register("Sides", // Dependency property
                                                        typeof (int), // Type of the Property
                                                        typeof (MainWindow), // Owner of the Property
                                                        metadata);  // Reference to metadata

        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Input_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                int numberOfSides = 0;
                numberOfSides = Convert.ToInt32(Input.Text);
                if (numberOfSides > 2)
                    Sides = numberOfSides;
            }
            catch (Exception)
            {
                // Supressing conversion errors
            }
        }

        private static void OnSidesChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            MainWindow win = d as MainWindow;
            if (win == null || win.polygon == null) return;

            const int xCenter = 65;
            const int yCenter = 50;
            const int radius = 40;
            double rads = Math.PI/win.Sides*2;
            win.polygon.Points.Clear();
            win.polygon.Points.Add(new Point(xCenter + radius, yCenter));
            for (double i = 0; i <= win.Sides - 1; i++)
            {
                double x = (Math.Cos(rads*i)*radius) + xCenter;
                double y = (Math.Sin(rads*i)*radius) + yCenter;
                win.polygon.Points.Add(new Point(x, y));
            }
        }
    }
}
