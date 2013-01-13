using System;
using System.Collections.ObjectModel;
using MovieBrowser.Model;

namespace MovieBrowser.Data
{

    // This class represents a dummy data source that could represent any sort of persistence layer
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
                                            Name = "Pain & Gain",
                                            ShortName = "P&G",
                                            Synopsis = "Daniel Lugo (Mark Wahlberg) is a regular bodybuilder who works at the Sun Gym along with his friend Adrian Doorbal (Anthony Mackie). Sick of living the poor life Lugo concocts a plan to kidnap Victor Kershaw (Tony Shalhoub), a regular at the gym and a rich spoiled business man, and extort him by means of torture. With the help of recently released criminal Paul Doyle (Dwayne Johnson), the 'Sun Gym Gang' successfully get Kershaw to sign over all his finances, but when Kershaw survives an attempted murder from the gang, he hires Detective Ed Du Bois (Ed Harris) to catch the criminals after the Miami Police Department fail to do so.",
                                            ShortSynopsis = "A trio of bodybuilders in Florida get caught up in an extortion ring and a kidnapping scheme that goes terribly wrong.",
                                            BoxArt = new BoxArt
                                                {
                                                    SmallUrl = new Uri("ms-appx:Assets/MediumGray.png"),
                                                    MediumUrl = new Uri("ms-appx:Assets/MediumGray.png"),
                                                    LargeUrl = new Uri("ms-appx:Assets/MediumGray.png")
                                                }
                                        },
                                    new Title
                                        {
                                            Name = "Gangster Squad",
                                            ShortName = "GS",
                                            Synopsis = "A chronicle of the LAPD's fight to keep East Coast Mafia types out of Los Angeles in the 1940s and 50s as six police officers and detectives must protect the law by breaking it, taking on Mickey Cohen and his gang.",
                                            ShortSynopsis = "A chronicle of the LAPD's fight to keep East Coast Mafia types out of Los Angeles in the 1940s and 50s.",
                                            BoxArt = new BoxArt
                                                {
                                                    SmallUrl = new Uri("ms-appx:Assets/MediumGray.png"),
                                                    MediumUrl = new Uri("ms-appx:Assets/MediumGray.png"),
                                                    LargeUrl = new Uri("ms-appx:Assets/MediumGray.png")
                                                }
                                        }
                                }
                        },
                        new Genre
                        {
                            Name = "Adventure",
                            Titles = new ObservableCollection<Title>
                                {
                                    new Title
                                        {
                                            Name = "The Hobbit",
                                            ShortName = "TH",
                                            Synopsis = "On his 111th birthday, the hobbit Bilbo Baggins decides to write down the full story of the adventure he had 60 years prior for his nephew Frodo./n Long before Bilbo's involvement, the Dwarf Thrór becomes King of the Lonely Mountain and brings an era of prosperity to his kin until the arrival of Smaug the dragon. Smaug destroys the nearby town of Dale before driving the Dwarves out of the mountain and taking their hoard of gold. Thrór's grandson, Thorin, sees King Thranduil and his Wood-elves on a nearby hillside and is dismayed when they take their leave rather than aid his people, resulting in Thorin's everlasting hatred of Elves.",
                                            ShortSynopsis = "A younger and more reluctant Hobbit, Bilbo Baggins, sets out on a 'unexpected journey' to the Lonely Mountain with a spirited group of Dwarves to reclaim a their stolen mountain home from a dragon named Smaug.",
                                            BoxArt = new BoxArt
                                                {
                                                    SmallUrl = new Uri("ms-appx:Assets/MediumGray.png"),
                                                    MediumUrl = new Uri("ms-appx:Assets/MediumGray.png"),
                                                    LargeUrl = new Uri("ms-appx:Assets/MediumGray.png")
                                                }
                                        },
                                    new Title
                                        {
                                            Name = "The Lord Of The Rings",
                                            ShortName = "LOTR",
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