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

namespace Chapter8_BindingToPOCOs
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
                               FirstName= "John",
                               Age = 20,
                               FavoriteColor = "Blue"
                           };
            // Add bindings programmatically
            Binding nameBinding = new Binding(path: "FirstName");
            nameBinding.Source = person;
            lblFirstName.SetBinding(ContentProperty, nameBinding);  //Binds content of the label to the name of the person

            Binding ageBinding = new Binding(path: "Age");
            ageBinding.Source = person;
            lblAge.SetBinding(ContentProperty, ageBinding);  //Binds content of the label to the age of the person

            Binding colorBinding = new Binding(path: "FavoriteColor");
            colorBinding.Source = person;
            lblColor.SetBinding(ContentProperty, colorBinding); // Binds content of the label to the person's favorite color
        }
    }

    public class Person
    {
        public string FirstName { get; set; }
        public int Age { get; set; }
        public string FavoriteColor { get; set; }

    }
}
