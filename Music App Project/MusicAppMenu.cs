using Music_App_Project.Registration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Music_App_Project
{
   public class MusicAppMenu
    {
        private static IUserService userService = new UserService();
        
        //method 1 user registration and log in:

        public static void RegisterAndLogin()
        {
           
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("╔════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                    Welcome to Music App                    ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════════╝");
            Console.WriteLine("                          ");
            Console.ResetColor();


            bool loggedin = false;

            while (!loggedin)
            {
                Thread.Sleep(1000);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("╔════════════════════════════════════════════════════╗");
                Console.WriteLine("║            User Registration and Login:            ║");
                Console.WriteLine("╚════════════════════════════════════════════════════╝");
                Console.WriteLine("         ");
                Console.ResetColor();

                Console.WriteLine("1. User Registration.");
                Console.WriteLine("2. Log in.");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Choose an option 1 or 2: ");
                Console.ResetColor();

                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Write("Enter firstname: ");
                        string name = Console.ReadLine();
                        Console.Write("Enter lastname: ");
                        string lastname = Console.ReadLine();
                        Console.Write("Enter username: ");
                        string username = Console.ReadLine();
                        Console.Write("Enter password: ");
                        string password = Console.ReadLine();
                        //string pattern = @"(\w+)@(\w+)(\.\w+)";
                        string pattern = @"\b[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}\b";

                        Console.Write("Enter email: ");
                        string email = Console.ReadLine();

                        while (!Regex.IsMatch(email, pattern))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Incorrect email! Please try again: ");
                            Console.ResetColor();
                            email = Console.ReadLine();
                        }

                        userService.RegisterUser(name, lastname, username, password, email);

                        break;
                    case "2":
                                                
                        int attemptCount = 0;
                        int maxAttempts = 3;

                        while (!loggedin && attemptCount < maxAttempts)
                        {
                            Console.Write("Enter username: ");
                            string loginUsername = Console.ReadLine();
                            Console.Write("Enter password: ");
                            string loginPassword = Console.ReadLine();

                            if (userService.Login(loginUsername, loginPassword))
                            {
                                loggedin = true;

                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.WriteLine($"Welcome '{loginUsername}' you have logged in successfully.");
                                Console.ResetColor();
                            }
                            else
                            {
                                attemptCount++;
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"Invalid username or password! You have {maxAttempts - attemptCount} attempts remaining.");
                                Console.ResetColor();

                                if (attemptCount >= maxAttempts)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("You have exceeded the maximum number of login attempts. Please try again later.");
                                    Console.ResetColor();
                                }
                            }
                        }

                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid option! Please choose 1 or 2.");
                        Console.ResetColor();
                        break;

                }
            }
        }


        //method 2 ManageMusic (Music service, user service and playlist): 

        public static void ManageMusic() 
        {

            IMusicService musicService = new MusicService();
            IPlaylistService playlistService = new PlaylistService(musicService);

            Thread.Sleep(1000);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("                          ");
            Console.WriteLine("╔════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                  Welcome to Music Library:                 ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════════╝");
            Console.WriteLine("                          ");
            Console.ResetColor();

            bool running = true;

            while (running)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Music Info:");
                Console.ResetColor();
                Console.WriteLine("1. View Music Catalogue");
                Console.WriteLine("2. Add song");
                Console.WriteLine("3. Remove song");
                Console.WriteLine("4. Filter music by song name");
                Console.WriteLine("5. Filter music by artist");
                Console.WriteLine("6. Filter music by genre");
                Console.WriteLine("7. Update music");
                Console.WriteLine("              ");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("User Info:");
                Console.ResetColor();
                Console.WriteLine("8. View all users");  
                Console.WriteLine("9. Delete user");
                Console.WriteLine("10. Check User Balance"); 
                Console.WriteLine("11. Fill User Balance");
                Console.WriteLine("12. Make a monthly payment");
                Console.WriteLine("              ");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Playlist Info:");
                Console.ResetColor();
                Console.WriteLine("13. Create Playlist");
                Console.WriteLine("14. Add song to Playlist"); 
                Console.WriteLine("15. View Playlist");
                Console.WriteLine("16. Remove song from Playlist");
                Console.WriteLine("17. Sort songs by rating");
                Console.WriteLine("18. Sort songs by date"); 
                Console.WriteLine("19. Print Playlist to a file");
                Console.WriteLine("20. Exit Music App");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Choose an option 1 - 20: "); 
                Console.ResetColor();

                switch (Console.ReadLine())
                {
                    //Music Info:
                    case "1":
                        musicService.ViewMusicList();
                        Console.WriteLine("       ");
                        break;
                    case "2":
                        Music newMusic = new Music();
                        Console.Write("Enter song title: ");
                        newMusic.SongTitle = Console.ReadLine();
                        Console.Write("Enter artist or band name: ");
                        newMusic.Artist = Console.ReadLine();
                        Console.Write("Enter genre: ");
                        newMusic.Genre = Console.ReadLine();
                        Console.Write("Enter country: ");
                        newMusic.Country = Console.ReadLine();
                        Console.Write("Enter song issue date (yyyy, mm, dd): ");
                        newMusic.IssueDate = DateTime.Parse( Console.ReadLine());
                        Console.Write("Enter song rating: ");
                        newMusic.Rating = Double.Parse(Console.ReadLine());
                        musicService.AddSong(newMusic);
                        break;
                    case "3":
                        Console.Write("Enter song title to remove: ");
                        string songToRemove = Console.ReadLine();
                        musicService.RemoveSong(songToRemove);
                        break;
                    case "4":
                        Console.Write("Enter song title to search: ");
                        string songToSearch = Console.ReadLine();
                        var songSearchResult = musicService.FilterBySongTitle(songToSearch);
                        foreach (var item in songSearchResult)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine(item);
                            Console.ResetColor();
                        }
                        break;
                    case "5":
                        Console.Write("Enter artist or music band name to search: ");
                        string artistToSearch = Console.ReadLine();
                        var artistSearchResult = musicService.FilterByArtist(artistToSearch);
                        foreach (var item in artistSearchResult)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine(item);
                            Console.ResetColor();
                        }
                        break;
                    case "6":
                        Console.Write("Enter genre to filter by: ");
                        string genreToSearch = Console.ReadLine();
                        var genreSearchResult = musicService.FilterByGenre(genreToSearch);
                        foreach (var item in genreSearchResult)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine(item);
                            Console.ResetColor();
                        }
                        break;
                    case "7":
                        Console.Write("Enter song title you need to update: ");
                        string songToUpdate = Console.ReadLine();
                        Music existingSong = musicService.FilterBySongTitle(songToUpdate).FirstOrDefault();
                        if (existingSong == null)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Song not found! Please try again.");
                            Console.ResetColor();
                            break;
                        }
                        Music musicUpdate = new Music();
                        Console.Write("Enter new song title: ");
                        musicUpdate.SongTitle = Console.ReadLine();
                        Console.Write("Enter artist name: ");
                        musicUpdate.Artist = Console.ReadLine();
                        Console.Write("Enter genre: ");
                        musicUpdate.Genre = Console.ReadLine();
                        Console.Write("Enter country of origin: ");
                        musicUpdate.Country = Console.ReadLine();
                        Console.Write("Enter issue date (yyyy, mm, dd): ");
                        musicUpdate.IssueDate = DateTime.Parse( Console.ReadLine());
                        Console.Write("Enter rating: ");
                        musicUpdate.Rating = Double.Parse(Console.ReadLine());

                        musicService.UpdateMusic(songToUpdate, musicUpdate);
                        break;
                    //User Info:
                    case "8":
                        userService.ViewAllUsers();
                        Console.WriteLine("      ");
                        break;
                    case "9":
                        Console.Write("Enter user Id to delete: ");
                        int userIdToDelete = int.Parse( Console.ReadLine());
                        userService.DeleteUser(userIdToDelete);
                        break;
                    case "10":
                        Console.Write("Enter your username to check balance: ");
                        string checkBalanceUsername = Console.ReadLine();
                        userService.CheckBalance(checkBalanceUsername);
                        break;
                    case "11":
                        Console.Write("Enter your username to fill balance: ");
                        string fillBalanceUsername = Console.ReadLine();
                        userService.FillBalance(fillBalanceUsername);
                        break;
                    case "12":
                        Console.Write("Enter your username to make payment: ");
                        string paymentUsername = Console.ReadLine();
                        userService.MakePayment(paymentUsername);
                        break;
                    //Playlist Info:
                    case "13":
                        Console.Write("Name your playlist: "); 
                        string playlistName = Console.ReadLine();
                        playlistService.CreatePlaylist(playlistName);
                        break;
                    case "14":
                        Console.Write("Enter song title to add to your playlist: "); 
                        string songToAdd = Console.ReadLine();
                        playlistService.AddSongToPlaylist(songToAdd);
                        break;
                    case "15":
                        playlistService.ViewPlaylist();
                        break;
                    case "16":
                        Console.Write("Enter song title to remove from playlist: ");
                        string songToBeRemoved = Console.ReadLine();
                        playlistService.RemoveSongFromPlaylist(songToBeRemoved);
                        break;
                    case "17":
                        playlistService.SortByRating();
                        break;
                    case "18": 
                        playlistService.SortByDate();
                        break;
                    case "19":
                        Console.Write("Enter file path to save the playlist: ");
                        string filePath = Console.ReadLine();
                        playlistService.PrintPlaylist(filePath);
                        break;
                    case "20":
                        running = false;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Exiting the application... Thank you, we hope you enjoyed the Music!");
                        Console.ResetColor();
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid option! Please choose a valid option.");
                        Console.ResetColor();
                        break;

                }

            }
        }

    }
}
