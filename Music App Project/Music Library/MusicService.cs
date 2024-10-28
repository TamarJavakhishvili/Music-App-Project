using Music_App_Project.Registration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_App_Project
{
    public class MusicService : Music, IMusicService
    {

        private List<Music>songs = new List<Music>();


        public MusicService()
        {
            songs.Add(new Music
            {
                SongTitle = "Creep",
                Artist = "Radiohead",
                Genre = "Alternative Rock",
                Country = "England",
                IssueDate = new DateTime(1992, 9, 21),
                Rating = 9.2,

            });

            songs.Add(new Music
            {
                SongTitle = "Nothing Else Matters",
                Artist = "Metallica",
                Genre = "Heavy Metal",
                Country = "USA",
                IssueDate = new DateTime(1992, 4, 20),
                Rating = 9.5,

            });

            songs.Add(new Music
            {
                SongTitle = "Loose Yourself",
                Artist = "Eminem",
                Genre = "Rap",
                Country = "USA",
                IssueDate = new DateTime(2002, 10, 28),
                Rating = 8.9,

            });

            songs.Add(new Music
            {
                SongTitle = "The Wall",
                Artist = "Pink Floyd",
                Genre = "Rock",
                Country = "England",
                IssueDate = new DateTime(1979, 11, 30),
                Rating = 9.4,

            });

            songs.Add(new Music
            {
                SongTitle = "Yesterday",
                Artist = "The Beatles",
                Genre = "Pop",
                Country = "England",
                IssueDate = new DateTime(1965, 9, 13),
                Rating = 9.7,

            });

            songs.Add(new Music
            {
                SongTitle = "Fragile",
                Artist = "Sting",
                Genre = "Jazz",
                Country = "England",
                IssueDate = new DateTime(1988, 4, 15),
                Rating = 9.3,

            });

            songs.Add(new Music
            {
                SongTitle = "Uprising",
                Artist = "Muse",
                Genre = "Rock",
                Country = "England",
                IssueDate = new DateTime(2009, 8, 4),
                Rating = 9.5,

            });
        }

        public void ViewMusicList()
        {
            Console.WriteLine("Music Catalogue: ");

            try
            {
                foreach (Music song in songs)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine(song);
                    Console.ResetColor();

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);

            }

        }

        public void AddSong(Music music)
        {
            try
            {
                string trimmedSongTitle = music.SongTitle.Trim();

                if (songs.Any(x => x.SongTitle.Trim().Equals(trimmedSongTitle, StringComparison.OrdinalIgnoreCase) ))  
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("The song already exists!");
                    Console.ResetColor();
                }
                else
                {
                    songs.Add(music); 
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine($"Song '{music.SongTitle}' added to music library.");
                    Console.ResetColor();
                    Console.WriteLine("           ");
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine("Error: " + ex.Message);
            }
        }

        public void RemoveSong(string songtitle)  
        {
            try
            {
                Music songToRemove = songs.Find(x => x.SongTitle.Equals(songtitle, StringComparison.OrdinalIgnoreCase) );
                if (songToRemove != null)
                {
                    songs.Remove(songToRemove);
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine($"The song '{songtitle}' has been removed from catalogue.");
                    Console.ResetColor();
                    Console.WriteLine("             ");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("The song not found!");
                    Console.ResetColor();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                
            }
        }

       
        public List<Music> FilterBySongTitle(string filterbySongTitle)  
        {
            try
            {
                var filteredSongs = songs.Where(x => x.SongTitle.Contains(filterbySongTitle, StringComparison.OrdinalIgnoreCase))
                    .ToList();

                if (filteredSongs.Count == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"No songs found containing the text '{filterbySongTitle}'.");
                    Console.ResetColor();
                }

                return filteredSongs;

            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public List<Music> FilterByArtist(string filterbyArtist)
        {
            try
            {
                var filteredArtists = songs.Where(x => x.Artist.Contains(filterbyArtist, StringComparison.OrdinalIgnoreCase))
                    .ToList();

                if (filteredArtists.Count == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Artist name '{filterbyArtist}' not found.");
                    Console.ResetColor();
                }

                return filteredArtists;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Music> FilterByGenre(string filterbyGenre)
        {
            try
            {
                var filteredGenres = songs.Where(x => x.Genre.Contains(filterbyGenre, StringComparison.OrdinalIgnoreCase))
                    .ToList();

                if (filteredGenres.Count == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Genre '{filterbyGenre}' not found.");
                    Console.ResetColor();
                }

                return filteredGenres;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void UpdateMusic(string songtitle, Music updatedMusic)
        {
            try
            {
                Music musicToUpdate = songs.FirstOrDefault(x => x.SongTitle.Equals(songtitle, StringComparison.OrdinalIgnoreCase));
                if (musicToUpdate == null)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Song not found");
                    Console.ResetColor();
                    return;
                }
                else
                {
                    musicToUpdate.SongTitle = updatedMusic.SongTitle;
                    musicToUpdate.Artist = updatedMusic.Artist;
                    musicToUpdate.Genre = updatedMusic.Genre;
                    musicToUpdate.Country = updatedMusic.Country;
                    musicToUpdate.IssueDate = updatedMusic.IssueDate;
                    musicToUpdate.Rating = updatedMusic.Rating;

                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("Music Updated successfully.");
                    Console.ResetColor();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : " + ex.Message);
                
            }
                

        }
    }
}
