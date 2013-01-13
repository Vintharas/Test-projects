using System;
using MovieBrowser.Data;
using MovieBrowser.Interfaces;
using MovieBrowser.Model;

namespace MovieBrowser.ServiceAgents
{
    public class SampleDataMovieCatalogServiceAgent : IMovieCatalogServiceAgent
    {
        public void InitiateGenreRetrieval(Action<Genre> genreAvailableCallback)
        {
            var catalog = new SampleMovieDataSource();
            foreach (var genre in catalog.Genres)
                genreAvailableCallback(genre);
        }
    }
}