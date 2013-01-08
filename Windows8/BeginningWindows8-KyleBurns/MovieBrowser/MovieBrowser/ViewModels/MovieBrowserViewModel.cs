using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using MovieBrowser.Common;
using MovieBrowser.Data;
using MovieBrowser.Model;

namespace MovieBrowser.ViewModels
{
    public class MovieBrowserViewModel : BindableBase
    {
        private readonly SampleMovieDataSource catalog = new SampleMovieDataSource();
        public ObservableCollection<Genre> Genres
        {
            get { return catalog.Genres; }
        }

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

        public MovieBrowserViewModel()
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