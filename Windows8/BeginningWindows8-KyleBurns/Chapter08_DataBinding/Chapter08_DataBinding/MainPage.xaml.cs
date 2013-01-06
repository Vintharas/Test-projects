using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Chapter08_DataBinding.Entities;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Chapter08_DataBinding
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private SearchResult searchResult; 

        public MainPage()
        {
            this.InitializeComponent();
            searchResult = new SearchResult();
            DataContext = searchResult;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            searchResult.SearchResultItems.Clear();
            var results = DoSearch(txtCriteria.Text);
            foreach (var result in results)
            {
                searchResult.SearchResultItems.Add(result);
            }           
        }

        private IEnumerable<SearchResultItem> DoSearch(string criteria)
        {
            return new List<SearchResultItem>
                {
                    new SearchResultItem
                        {
                            Title = "Bread",
                            Summary = "Good for sandwiches"
                        },
                    new SearchResultItem
                        {
                            Title = "Potion",
                            Summary = "+5 HP"
                        }
                };
        }
    }
}
