using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_App_Project
{
    public interface IMusicService
    {
        void ViewMusicList();
        void AddSong(Music music);
        void RemoveSong(string songtitle);
        List<Music> FilterBySongTitle(string songTitle);
        List<Music> FilterByArtist(string artist);
        List<Music> FilterByGenre(string genre);
        void UpdateMusic(string songtitle, Music music);
    }
}
