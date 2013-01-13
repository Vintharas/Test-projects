using System;
using MovieBrowser.Model;

namespace MovieBrowser.Interfaces
{
    public interface IMovieCatalogServiceAgent
    {
        void InitiateGenreRetrieval(Action<Genre> genreAvailableCallback);
    }
}