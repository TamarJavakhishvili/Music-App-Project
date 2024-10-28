using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_App_Project
{
    public class PlaylistService : Playlist, IPlaylistService
    {
       private List<Music> playlist = new List<Music>(); 

        private readonly IMusicService _musicService;  

        public PlaylistService(IMusicService musicService)
        {
            _musicService = musicService;
        }

        
        public void CreatePlaylist(string playlistName)
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine($"Playlist '{playlistName}' created successfully.");
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

       
        public void AddSongToPlaylist(string songTitle) 
        {
            try
            {
                var songToAdd = _musicService.FilterBySongTitle(songTitle).FirstOrDefault();
                if (songToAdd != null)
                {
                    playlist.Add(songToAdd);
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine($"Song '{songTitle}' added to your playlist.");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Song not found in the music library!");
                    Console.ResetColor();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

       
        public void ViewPlaylist()
        {
            try
            {
                if (playlist.Count == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Playlist is empty!");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine($"Your playlist: ");

                    foreach (var song in playlist)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine(song);
                        Console.ResetColor();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

       
        public void RemoveSongFromPlaylist(string songTitle) 
        {
            try
            {
                var songToRemove = playlist.FirstOrDefault(x => x.SongTitle.Equals(songTitle, StringComparison.OrdinalIgnoreCase));

                if (songToRemove != null)
                {
                    playlist.Remove(songToRemove);
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine($"Song '{songTitle}' removed from playlist.");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Song not found in the playlist!");
                    Console.ResetColor();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

      
        public void SortByRating()
        {
            try
            {
                if (playlist.Count != 0)
                {
                    playlist = playlist.OrderByDescending(x => x.Rating).ToList();
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("Playlist sorted by rating: ");
                    Console.ResetColor();
                    foreach (var song in playlist)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine(song);
                        Console.ResetColor();
                    }
                }
                else 
                {
                    Console.ForegroundColor= ConsoleColor.Red;
                    Console.WriteLine("Playlist is empty. Please add songs.");
                    Console.ResetColor();
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        
        public void SortByDate()
        {
            try
            {
                if (playlist.Count != 0)
                {
                    playlist = playlist.OrderByDescending(x => x.IssueDate).ToList();
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("Playlist sorted by date newest to oldest: ");
                    Console.ResetColor();
                    foreach (var song in playlist)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine(song);
                        Console.ResetColor();
                    }
                }
                else 
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Playlist is empty. Please add songs.");
                    Console.ResetColor();
                }
               
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


       
        public void PrintPlaylist(string filePath) 

        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    foreach (var song in playlist)
                    {
                        writer.WriteLine(song.ToString());
                    }
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine($"Playlist printed to file {filePath}");
                    Console.ResetColor();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                
            }
        }

    }
}
