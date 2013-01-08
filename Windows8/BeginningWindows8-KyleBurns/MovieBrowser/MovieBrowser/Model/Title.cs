using MovieBrowser.Common;

namespace MovieBrowser.Model
{
    public class Title : BindableBase
    {
        private string name;
        public string Name
        {
            get { return name; } 
            set { SetProperty(ref name, value); }
        }

        private string shortName;
        public string ShortName
        {
            get { return shortName; } 
            set { SetProperty(ref shortName, value); }
        }

        private string shortSynopsis;
        public string ShortSynopsis
        {
            get { return shortSynopsis; }
            set { SetProperty(ref shortSynopsis, value); }
        }

        private string synopsis;
        public string Synopsis
        {
            get { return synopsis; }
            set { SetProperty(ref synopsis, value); }
        }
        
        private BoxArt boxArt;
        public BoxArt BoxArt 
        { 
            get { return boxArt; } 
            set { SetProperty(ref boxArt, value); }
        }


    }
}