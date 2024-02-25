using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game_comp_conv
{
    internal class PlayerCrud
    {
        public static Player Plyr;  // init plyr start pos
        public static string playerMove = "";  // player direction
        public static void AddPlayer(Player P)
        {
            Plyr = P;
        }
        public static void PrintPlayer()
        {
            Plyr.PrintPlayer();
        }
        public static void MoveLeft(int mazeWidth)
        {
            Plyr.ErasePlayer();
            Plyr.MovePlayerHorizontally("left", mazeWidth);
            Plyr.PrintPlayer();
        }
        public static void MoveRight(int mazeWidth)
        {
            Plyr.ErasePlayer();
            Plyr.MovePlayerHorizontally("right", mazeWidth);
            Plyr.PrintPlayer();
        }
        public static void MoveUp(int mazeHeight)
        {
            Plyr.ErasePlayer();
            playerMove = "up";
            Plyr.MovePlayerVertically(ref playerMove, mazeHeight);
            Plyr.PrintPlayer();
        }
        public static void MoveDown(int mazeHeight)
        {
            Plyr.ErasePlayer();
            playerMove = "down";
            Plyr.MovePlayerVertically(ref playerMove, mazeHeight);
            Plyr.PrintPlayer();
        }
    }
}
