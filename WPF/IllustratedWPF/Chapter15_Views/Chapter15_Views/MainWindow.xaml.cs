using System.Collections.Generic;
using System.Windows;
using System.Windows.Data;

namespace Chapter15_ViewFiltering
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly CollectionView peopleCollectionView;

        public MainWindow()
        {
            InitializeComponent();

            // Preparing some fake data
            List<Person> people = new List<Person>
                                      {
                                          new Person {FirstName="Agnes", Age=30, FavoriteColor = "Black"},
                                          new Person {FirstName = "Janne", Age=22, FavoriteColor = "Magenta"},
                                          new Person {FirstName = "Kimmel", Age=32, FavoriteColor = "Green"},
                                          new Person {FirstName ="Manuel", Age=20, FavoriteColor = "Blue"},
                                          new Person {FirstName = "Roy", Age=23, FavoriteColor = "Aquamarine"}
                                      };
            listPeople.ItemsSource = people;
            peopleCollectionView = CollectionViewSource.GetDefaultView(listPeople.ItemsSource) as CollectionView;
        }

        private bool IsLessThan30(object item)
        {
            return (item as Person).Age < 30;
        }

        private void RemoveFilters(object sender, RoutedEventArgs e)
        {
            peopleCollectionView.Filter = null;
        }

        private void FilterLessThanThirty(object sender, RoutedEventArgs e)
        {
            peopleCollectionView.Filter = IsLessThan30;
        }

        private void FilterGreaterThan30(object sender, RoutedEventArgs e)
        {
            peopleCollectionView.Filter = (item) => !IsLessThan30(item);
        }
    }


    public class Person
    {
        public string FirstName { get; set; }
        public int Age { get; set; }
        public string FavoriteColor { get; set; }
    }
}
