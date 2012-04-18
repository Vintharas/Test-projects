using System.Collections.Generic;
using System.Windows;

namespace Chapter16_DataGrid
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Adding a datasource to the grid
            List<Person> people = new List<Person>();
            people.Add(new Person{FirstName = "Sherlock", LastName = "Holmes", Age=54});
            people.Add(new Person{FirstName= "Nancy", LastName = "Drew", Age=16, HasRoadster = true});
            theDataGrid.ItemsSource = people;
        }
    }


    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public bool HasRoadster { get; set; }
    }
}
