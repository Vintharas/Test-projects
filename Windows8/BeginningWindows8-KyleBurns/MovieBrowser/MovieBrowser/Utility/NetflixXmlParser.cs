using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Linq;
using MovieBrowser.Model;

namespace MovieBrowser.Utility
{
    public class NetflixXmlParser
    {

        private static readonly XNamespace atomNamespace = XNamespace.Get("http://www.w3.org/2005/Atom");
        private static readonly XNamespace dataServiceNamespace =
            XNamespace.Get("http://schemas.microsoft.com/ado/2007/08/dataservices");
        private static readonly XNamespace metadataNamespace =
            XNamespace.Get("http://schemas.microsoft.com/ado/2007/08/dataservices/metadata");

        public static class AtomNodeNames
        {
            public static readonly XName Entry = atomNamespace.GetName("entry");
            public static readonly XName Title = atomNamespace.GetName("title");
            public static readonly XName Id = atomNamespace.GetName("id");
        }

        public static class MetadataNodeNames
        {
            public static readonly XName Properties = metadataNamespace.GetName("properties");
        }

        public static class DataServiceNodeNames
        {
            public static readonly XName Name = dataServiceNamespace.GetName("Name");
            public static readonly XName ShortName = dataServiceNamespace.GetName("ShortName");
            public static readonly XName Synopsis = dataServiceNamespace.GetName("Synopsis");
            public static readonly XName ShortSynopsis = dataServiceNamespace.GetName("ShortSynopsis");
            public static readonly XName BoxArt = dataServiceNamespace.GetName("BoxArt");
            public static readonly XName SmallUrl = dataServiceNamespace.GetName("SmallUrl");
            public static readonly XName MediumUrl = dataServiceNamespace.GetName("MediumUrl");
            public static readonly XName LargeUrl = dataServiceNamespace.GetName("LargeUrl");
        }

        public static Title ParseTitle(XElement titleElement)
        {
            Title title = new Title();
            XElement propertiesElement =
                titleElement.Element(MetadataNodeNames.Properties);
            title.Name = propertiesElement.Element(DataServiceNodeNames.Name).Value;
            title.ShortName = propertiesElement.Element(DataServiceNodeNames.ShortName).Value;
            title.Synopsis = propertiesElement.Element(DataServiceNodeNames.Synopsis).Value;
            title.ShortSynopsis = propertiesElement.Element(DataServiceNodeNames.ShortSynopsis).Value;
            
            BoxArt boxArt = new BoxArt();
            XElement boxArtElement = propertiesElement.Element(DataServiceNodeNames.BoxArt);
            boxArt.SmallUrl = new Uri(boxArtElement.Element(DataServiceNodeNames.SmallUrl).Value);
            boxArt.MediumUrl = new Uri(boxArtElement.Element(DataServiceNodeNames.MediumUrl).Value);
            boxArt.LargeUrl = new Uri(boxArtElement.Element(DataServiceNodeNames.LargeUrl).Value);
            title.BoxArt = boxArt;
            return title;
        }

        public static async Task<XDocument> GetGenresXml()
        {
            using (var webClient = new HttpClient())
            {
                var response = await webClient.GetStringAsync(
                    "http://odata.netflix.com/v2/catalog/Genres?$select=Name&$top=10");
                return XDocument.Parse(response);
            }
        }
        



    }
}