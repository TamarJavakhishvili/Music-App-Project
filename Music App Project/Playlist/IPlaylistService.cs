using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_App_Project
{
    public interface IPlaylistService
    {
        void CreatePlaylist(string playlistName);
        void AddSongToPlaylist(string songTitle);
        void ViewPlaylist();
        void RemoveSongFromPlaylist(string songTitle);
        void SortByRating();
        void SortByDate(); 
        void PrintPlaylist(string filePath);
        
    }
}

