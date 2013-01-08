using System;
using System.Collections.ObjectModel;
using MovieBrowser.Model;

namespace MovieBrowser.Data
{
    public class SampleMovieDataSource
    {
        private static readonly ObservableCollection<Genre> genres =
            new ObservableCollection<Genre>
                {
                    new Genre
                        {
                            Name = "Action",
                            Titles = new ObservableCollection<Title>
                                {
                                    new Title
                                        {
                                            Name = "Action Movie 1",
                                            ShortName = "AM1",
                                            Synopsis = "This is the longer bit of text...",
                                            ShortSynopsis = "Short synopsis",
                                            BoxArt = new BoxArt
                                                {
                                                    SmallUrl = new Uri("ms-appx:Assets/MediumGray.png"),
                                                    MediumUrl = new Uri("ms-appx:Assets/MediumGray.png"),
                                                    LargeUrl = new Uri("ms-appx:Assets/MediumGray.png")
                                                }
                                        },
                                    new Title
                                        {
                                            Name = "Action Movie 2",
                                            ShortName = "AM2",
                                            Synopsis = "This is the longer bit of text...",
                                            ShortSynopsis = "Short synopsis",
                                            BoxArt = new BoxArt
                                                {
                                                    SmallUrl = new Uri("ms-appx:Assets/MediumGray.png"),
                                                    MediumUrl = new Uri("ms-appx:Assets/MediumGray.png"),
                                                    LargeUrl = new Uri("ms-appx:Assets/MediumGray.png")
                                                }
                                        }
                                }
                        }
                };
        public ObservableCollection<Genre> Genres { get { return genres; } } 
    }
}