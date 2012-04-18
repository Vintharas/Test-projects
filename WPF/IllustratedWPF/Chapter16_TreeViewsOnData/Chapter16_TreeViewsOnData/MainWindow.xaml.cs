using System;
using System.Collections.Generic;
using System.Windows;

namespace Chapter16_TreeViewsOnData
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            oldMaps.ItemsSource = WorldRegion.GetFakeMapRegions();
        }

    }

    public class WorldRegion
    {
        public string RegionName { get; set; }
        public List<MapInfo> Maps { get; set; }

        public WorldRegion(string name)
        {
            Maps = new List<MapInfo>();
            RegionName = name;
        }

        public static List<WorldRegion> GetFakeMapRegions()
        {
            List<WorldRegion> mapRegions = new List<WorldRegion>();

            WorldRegion region = new WorldRegion("Double Hemisphere");
            region.Maps.Add(new MapInfo("Seutter", "Mattheus", "Diversi Globi Terr-Aquei", "c. 1730", "Double Hemisphere", "map1.jpeg"));
            region.Maps.Add(new MapInfo("Seutter2", "Mattheus2", "Diversi Globi Terr-Aquei 2", "c. 1731", "Double Hemisphere 2", "map2.jpg"));
            mapRegions.Add(region);

            region = new WorldRegion("Western Hemisphere");
            region.Maps.Add(new MapInfo("Sanson", "Nicholas", "California as an island", "c. 1657", "Western Hemisphere", "map3.jpg"));
            region.Maps.Add(new MapInfo("Sanson2", "Nicholas2", "California as an island 2", "c. 1657", "Western Hemisphere", "map4.jpg"));
            mapRegions.Add(region);

            return mapRegions;
        }
    }

    public class MapInfo
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Title { get; set; }
        public string Year { get; set; }
        public string Description { get; set; }
        public Uri Picture { get; set; }

        public MapInfo(string firstName, string secondName, string title, string year, string description, string pictureName)
        {
            FirstName = firstName;
            SecondName = secondName;
            Title = title;
            Year = year;
            Description = description;
            string uriString = string.Format("Images/{0}", pictureName);
            Picture = new Uri(uriString, UriKind.Relative);
        }
    }
}
