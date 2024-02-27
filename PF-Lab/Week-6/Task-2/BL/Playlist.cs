using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.BL
{
    internal class Playlist
    {
        private List<Song> Songs;
        public Playlist()
        {
            Songs = new List<Song>();
        }
        public void SetSong(Song song)
        {
            Songs.Add(song);
        }
        public void GetSongs()
        {
            foreach (Song song in Songs)
            {
                Console.WriteLine(song.GetName());
            }
        }
}
}
