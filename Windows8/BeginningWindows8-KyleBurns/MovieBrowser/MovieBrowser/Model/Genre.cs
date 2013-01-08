using System.Collections.ObjectModel;
using MovieBrowser.Common;

namespace MovieBrowser.Model
{
    public class Genre : BindableBase
    {
        private string name;
        public string Name 
        { 
            get { return name; } 
            set { SetProperty(ref name, value); }
        }

        private ObservableCollection<Title> titles;
        public ObservableCollection<Title> Titles 
        { 
            get { return titles; } 
            set { SetProperty(ref titles, value); }
        }

    

    }
}