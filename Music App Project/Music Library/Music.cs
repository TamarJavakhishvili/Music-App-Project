using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_App_Project
{
    public class Music
    {
        public string SongTitle { get; set; }
        public string Artist { get; set; }
        public string Genre { get; set; }
        public string Country { get; set; }
        public DateTime IssueDate { get; set; }
        public double Rating { get; set; }

        public override string ToString()
        {
           
            return $"Song name: {SongTitle}, Artist: {Artist}, Genre: {Genre}, Country: {Country}, Issue Date: {IssueDate.ToShortDateString()}, Rating: {Rating}";
        }

    }
}
