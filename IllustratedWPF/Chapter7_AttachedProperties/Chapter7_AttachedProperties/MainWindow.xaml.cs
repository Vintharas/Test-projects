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

namespace Chapter7_AttachedProperties
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // This is the attached property
        public static readonly DependencyProperty CountProperty;

        static MainWindow() // Static constructor
        {
            // Notice the use of the "RegisterAttached" method instead of the
            // "Register" method used with regular dependency properties
            CountProperty = DependencyProperty.RegisterAttached("Count", typeof (int), typeof (MainWindow));
        }

        public static int GetCount(IntStorage ints)
        {
            return (int) ints.GetValue(CountProperty);
        }

        public static void SetCount(IntStorage ints, int value)
        {
            ints.SetValue(CountProperty, value);
        }


        public MainWindow()
        {
            InitializeComponent();

            // Create targets programmatically and
            // see how they store/retrieve a value for an attached proprerty
            IntStorage is1 = new IntStorage();
            IntStorage is2 = new IntStorage();
            // Store values
            SetCount(is1, 28);
            SetCount(is2, 500);
            // Retrieve the values
            int i1 = GetCount(is1);
            int i2 = GetCount(is2);
            // Display the values
            txt1.Text = i1.ToString();
            txt2.Text = i2.ToString();
        }

    }
}
