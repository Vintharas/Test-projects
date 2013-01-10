/* Beginning Windows 8 App Dev C# and XAML - Kyle Burns
 * Chapter 13 - Asynchronous Programming Model
 * Exercise: Using async and await to retrieve an atom feed and 
 *           display it in a listview while maintaining a responsive
 *           user interface.
 */

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Linq;
using Chapter13_AsyncProgrammingModel.Model;
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

namespace Chapter13_AsyncProgrammingModel
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private ObservableCollection<FeedItem> feedItems = new ObservableCollection<FeedItem>();
        public ObservableCollection<FeedItem> FeedItems { get { return feedItems; } }

        public MainPage()
        {
            this.InitializeComponent();
            FeedList.ItemsSource = FeedItems;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private async void OnRetrieveButtonClicked(object sender, RoutedEventArgs e)
        {
            feedItems.Clear();
            var feedResults = await DownloadFeedAsync();
            foreach (var item in feedResults)
                feedItems.Add(item);
        }

        public async Task<List<FeedItem>> DownloadFeedAsync()
        {
            const string feedUrl = "http://meta.stackoverflow.com/feeds";
            HttpClient client = new HttpClient();
            client.MaxResponseContentBufferSize = int.MaxValue;
            // asynchronolously retrieve the feed from server
            var response = await client.GetStringAsync(feedUrl);
            // load the result into an XML document we can process
            var doc = XDocument.Parse(response);
            var atomNamespace = XNamespace.Get("http://www.w3.org/2005/Atom");
            var entryNodeName = atomNamespace.GetName("entry");
            var titleNodeName = atomNamespace.GetName("title");

            return doc.Descendants(entryNodeName).Select(item => new FeedItem
                {
                    Title = item.Element(titleNodeName).Value
                }).ToList();
        }



    }
}
