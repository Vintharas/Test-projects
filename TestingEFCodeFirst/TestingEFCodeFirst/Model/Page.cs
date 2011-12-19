namespace TestingEFCodeFirst.Model
{
    public class Page
    {
        public int PageId { get; set; }

        public string Head { get; set; }
        public string Header { get; set; }
        public string Body { get; set; }
        public string Footer { get; set; }

        public string Title { get; set; }
        public string Permalink { get; set; }

        public bool IsHomePage { get; set; }
        
        public bool IsNavigatable { get; set; }
        public int NavigationOrder { get; set; }

    }
}