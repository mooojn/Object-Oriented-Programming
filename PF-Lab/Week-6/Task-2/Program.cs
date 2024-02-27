using _2.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Song Song1 = new Song("S1");
            Song Song2 = new Song("S2");
            Song Song3 = new Song("S3");
            Playlist Playlist1 = new Playlist();
            Playlist1.SetSong(Song1);
            Playlist1.SetSong(Song2);
            Playlist1.SetSong(Song3);
                              
            Playlist1.GetSongs();
            Console.ReadKey();
        }
    }
}
