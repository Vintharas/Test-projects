using System;
using MovieBrowser.Common;

namespace MovieBrowser.Model
{
    public class BoxArt : BindableBase
    {
        private Uri largeUrl;
        public Uri LargeUrl 
        { 
            get { return largeUrl; } 
            set { SetProperty(ref largeUrl, value); }
        }

        private Uri smallUrl;
        public Uri SmallUrl 
        { 
            get { return smallUrl; } 
            set { SetProperty(ref smallUrl, value); }
        }

        private Uri mediumUrl;
        public Uri MediumUrl 
        { 
            get { return mediumUrl; } 
            set { SetProperty(ref mediumUrl, value); }
        }

    }
}