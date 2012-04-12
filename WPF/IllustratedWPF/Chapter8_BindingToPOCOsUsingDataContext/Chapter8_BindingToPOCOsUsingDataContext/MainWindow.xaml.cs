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

namespace Chapter8_BindingToPOCOsUsingDataContext
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Person person = new Person
                                {
                                    FirstName = "Mr. Awesome",
                                    Age = 22,
                                    FavoriteColor = "Magenta"
                                };

            theStackPanel.DataContext = person;

            // If you want to do it in code
            /*
               Binding nameBinding = new Binding( "FirstName" ); 
               lblFName.SetBinding( ContentProperty, nameBinding ); 
 
               Binding ageBinding = new Binding( "Age" ); 
               lblAge.SetBinding( ContentProperty, ageBinding ); 
 
               Binding colorBinding = new Binding( "FavoriteColor" ); 
               lblColor.SetBinding( ContentProperty, colorBinding );
            */
        }
    }

    public class Person
    {
        public string FirstName { get; set; }
        public int Age { get; set; }
        public string FavoriteColor { get; set; }
    }
}
