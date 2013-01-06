using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Chapter08_DataBinding.Annotations;

namespace Chapter08_DataBinding.Entities
{
    public class SearchResult : INotifyPropertyChanged
    {
        public SearchResult()
        {
            SearchResultItems = new ObservableCollection<SearchResultItem>();
        }

        public ObservableCollection<SearchResultItem> SearchResultItems { get; set; }
        
        
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
}
}