using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace Chapter15_ViewSorting
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
                                          new Person {FirstName = "Roy", Age=23, FavoriteColor = "Aquamarine"},
                                          new Person {FirstName = "Kimmel", Age=32, FavoriteColor = "Green"},
                                          new Person {FirstName ="Manuel", Age=20, FavoriteColor = "Blue"}
                                      };
            listPeople.ItemsSource = people;
            peopleCollectionView = CollectionViewSource.GetDefaultView(listPeople.ItemsSource) as CollectionView;
        }

        private void RemoveSorting(object sender, RoutedEventArgs e)
        {
            RemoveSortingFromView();
        }

        private void RemoveSortingFromView()
        {
            peopleCollectionView.SortDescriptions.Clear();
        }

        private void SortByName(object sender, RoutedEventArgs e)
        {
            RemoveSortingFromView();
            SortViewByName();
        }

        private void SortViewByName()
        {
            peopleCollectionView.SortDescriptions.Add(new SortDescription{PropertyName = "FirstName", Direction = ListSortDirection.Ascending});
        }

        private void SortByAge(object sender, RoutedEventArgs e)
        {
            RemoveSortingFromView();
            SortViewByAge();
        }

        private void SortViewByAge()
        {
            peopleCollectionView.SortDescriptions.Add(new SortDescription
                                                          {PropertyName = "Age", Direction = ListSortDirection.Ascending});
        }

        private void SortByNameAndAge(object sender, RoutedEventArgs e)
        {
            RemoveSortingFromView();
            SortViewByName();
            SortViewByAge();
        }
    }


    public class Person
    {
        public string FirstName { get; set; }
        public int Age { get; set; }
        public string FavoriteColor { get; set; }
    }
 }
