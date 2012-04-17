using System.Collections.Generic;
using System.Windows;

namespace Chapter15_DataTemplates
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Preparing some fake data
            List<Person> people = new List<Person>
                                      {
                                          new Person {FirstName="Agnes", Age=30, FavoriteColor = "Black"},
                                          new Person {FirstName = "Janne", Age=22, FavoriteColor = "Magenta"},
                                          new Person {FirstName = "Kimmel", Age=32, FavoriteColor = "Green"}
                                      };
            listPeople.ItemsSource = people;
        }
    }


    public class Person
    {
        public string FirstName { get; set; }
        public int Age { get; set; }
        public string FavoriteColor { get; set; }
    }
}
