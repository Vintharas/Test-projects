using System;
using MovieBrowser.Model;

namespace MovieBrowser.Data
{
    public class ViewGenreEventArgs :EventArgs
    {
        public Genre Genre { get; private set; }

        public ViewGenreEventArgs(Genre genre)
        {
            Genre = genre;
        }
         
    }
}