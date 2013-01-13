using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using MovieBrowser.Common;
using MovieBrowser.Data;
using MovieBrowser.Interfaces;
using MovieBrowser.Model;
using MovieBrowser.ServiceAgents;

namespace MovieBrowser.ViewModels
{
    public class MovieBrowserViewModel : BindableBase
    {
        public ObservableCollection<Genre> Genres{ get; private set; }

        private Genre selectedGenre;
        public Genre SelectedGenre
        {
            get { return selectedGenre; }
            set { SetProperty(ref selectedGenre, value); }
        }

        private Title selectedTitle;
        public Title SelectedTitle
        {
            get { return selectedTitle; }
            set { SetProperty(ref selectedTitle, value); }
        }

        public ICommand SelectTitleCommand { get; private set; }
        public ICommand SelectGenreCommand { get; private set; }
        public event EventHandler<ViewTitleEventArgs> ViewTitle;
        public event EventHandler<ViewGenreEventArgs> ViewGenre;

        public void RaiseViewTitle(Title title)
        {
            if (ViewTitle != null)
                ViewTitle(this, new ViewTitleEventArgs(title));
        }

        public void RaiseViewGenre(Genre genre)
        {
            if (ViewGenre != null)
                ViewGenre(this, new ViewGenreEventArgs(genre));
        }

        // constructor that fakes a DI container
        public MovieBrowserViewModel() : this (new SampleDataMovieCatalogServiceAgent()) { }

        public MovieBrowserViewModel(IMovieCatalogServiceAgent catalogServiceAgent)
        {
            LoadGenres(catalogServiceAgent);
            DefineNavigationCommands();
        }

        private void LoadGenres(IMovieCatalogServiceAgent catalogServiceAgent)
        {
            Genres = new ObservableCollection<Genre>();
            catalogServiceAgent.InitiateGenreRetrieval(Genres.Add);
        }

        private void DefineNavigationCommands()
        {
            SelectGenreCommand = new DelegateCommand(
                execute: arg =>
                    {
                        var genre = (Genre) arg;
                        SelectedGenre = genre;
                        RaiseViewGenre(genre);
                    },
                canExecute: arg => arg is Genre
                );
            SelectTitleCommand = new DelegateCommand
                (
                arg =>
                    {
                        var title = (Title) arg;
                        SelectedTitle = title;
                        SelectedGenre = Genres.Where(g => g.Titles.Contains(title)).FirstOrDefault();
                        RaiseViewTitle(title);
                    },
                arg => arg is Title
                );
        }
    }
}