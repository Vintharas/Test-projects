using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Linq;
using MovieBrowser.Interfaces;
using MovieBrowser.Model;
using MovieBrowser.Utility;
using Windows.ApplicationModel.Core;
using Windows.UI.Core;

namespace MovieBrowser.ServiceAgents
{
    public class NetflixMovieCatalogServiceAgent : IMovieCatalogServiceAgent
    {
        private const string TITLE_URL_FORMAT =
            "{0}/Titles?$top=20&$expand=BoxArt&$select=Name,ShortName,Synopsis,ShortSynopsis,BoxArt";


        public async void InitiateGenreRetrieval(Action<Genre> genreAvailableCallback)
        {
            var genreDoc = await NetflixXmlParser.GetGenresXml();

            foreach (var entryNode in genreDoc.Descendants(NetflixXmlParser.AtomNodeNames.Entry))
                await ProcessGenre(entryNode, genreAvailableCallback);
        }

        private async Task ProcessGenre(XElement genreElement,
                                        Action<Genre> genreAvailableCallback)
        {
            string titleResponse;
            string titleListingUrl = string.Format(
                TITLE_URL_FORMAT,
                genreElement.Element(NetflixXmlParser.AtomNodeNames.Id).Value);
            using (var titleClient = new HttpClient())
            {
                titleClient.MaxResponseContentBufferSize = int.MaxValue;
                titleResponse = await titleClient.GetStringAsync(titleListingUrl);
            }
            var titleDoc = XDocument.Parse(titleResponse);
            var titleObjects =
                titleDoc.Descendants(NetflixXmlParser.AtomNodeNames.Entry).Select(e => NetflixXmlParser.ParseTitle(e));
            var genre = new Genre
                {
                    Name = genreElement.Element(NetflixXmlParser.AtomNodeNames.Title).Value,
                    Titles = new ObservableCollection<Title>()
                };
            foreach (var title in titleObjects)
                genre.Titles.Add(title);

            CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(
                CoreDispatcherPriority.Normal,
                (() => genreAvailableCallback(genre)));
        }

    }
}