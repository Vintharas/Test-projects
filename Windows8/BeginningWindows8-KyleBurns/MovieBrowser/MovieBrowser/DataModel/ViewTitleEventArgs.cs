using System;
using MovieBrowser.Model;

namespace MovieBrowser.Data
{
    public class ViewTitleEventArgs : EventArgs
    {
        public Title Title { get; private set; }

        public ViewTitleEventArgs(Title title)
        {
            Title = title;
        }
         
    }
}