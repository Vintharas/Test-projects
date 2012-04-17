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

namespace Chapter15_ViewGrouping
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
                                          new Person {FirstName="Agnes", Age=30, FavoriteColor = "Black", Gender="F"},
                                          new Person {FirstName = "Janne", Age=22, FavoriteColor = "Black", Gender="M"},
                                          new Person {FirstName = "Roy", Age=23, FavoriteColor = "Aquamarine", Gender="M"},
                                          new Person {FirstName = "Kimmel", Age=32, FavoriteColor = "Green", Gender="M"},
                                          new Person {FirstName ="Manuela", Age=20, FavoriteColor = "Green", Gender="F"}
                                      };
            listPeople.ItemsSource = people;
            peopleCollectionView = CollectionViewSource.GetDefaultView(listPeople.ItemsSource) as CollectionView;
            peopleCollectionView.GroupDescriptions.Add(new PropertyGroupDescription(propertyName: "Gender"));
            peopleCollectionView.GroupDescriptions.Add(new PropertyGroupDescription(propertyName: "FavoriteColor"));
        }


    }


    public class Person
    {
        public string FirstName { get; set; }
        public int Age { get; set; }
        public string FavoriteColor { get; set; }
        public string Gender { get; set; }
    }
}
