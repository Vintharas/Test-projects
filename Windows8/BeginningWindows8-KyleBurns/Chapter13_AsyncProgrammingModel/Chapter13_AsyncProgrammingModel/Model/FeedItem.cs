using System;

namespace Chapter13_AsyncProgrammingModel.Model
{
    public class FeedItem
    {
        public string Title { get; set; }
        public Uri Link { get; set; }
        public DateTime PublicationDate { get; set; }
        public string Description { get; set; }

    }
}