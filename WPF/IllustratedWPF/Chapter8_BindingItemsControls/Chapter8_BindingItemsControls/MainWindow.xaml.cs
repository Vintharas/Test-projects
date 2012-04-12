using System.Windows;

namespace Chapter8_BindingItemsControls
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Person[] people = {
                                  new Person {FirstName = "Shirley", Age = 34, FavoriteColor = "Green"},
                                  new Person {FirstName = "Roy", Age = 36, FavoriteColor = "Blue"},
                                  new Person {FirstName = "Isabel", Age = 25, FavoriteColor = "Orange"},
                                  new Person {FirstName = "Manuel", Age = 27, FavoriteColor = "Red"}
                              };
            comboPeople.ItemsSource = people;
            // If you want you can bind the labels to the item selected in the combo box in code
            /*
               Binding nameBinding = new Binding( "FirstName" ); 
               lblFirstName.SetBinding( ContentProperty, nameBinding ); 
 
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
