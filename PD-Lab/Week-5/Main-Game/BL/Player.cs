using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game_comp_conv
{
    internal class Player
    {
        // data strut for player
        public char Symbol;
        public int X;
        public int Y;
        // initializing vals
        public Player(char symbol, int x, int y)
        {
            Symbol = symbol;
            X = x;
            Y = y;
        }
        // functions
        public void PrintPlayer()
        {
            // prints the object on the screen
            Console.SetCursorPosition(X, Y);
            Console.Write(Symbol);
        }
        public void ErasePlayer()
        {
            // removes the object from the screen
            Console.SetCursorPosition(X, Y);
            Console.Write(" ");
        }
        public void MovePlayerHorizontally(string direction, int mazeWidth)
        {
            if (direction == "left" && X > 1) // Check if moving left stays within the boundary
                X--;
            else if (direction == "right" && X < mazeWidth)
                X++;
            else return;  // error case
        }
        public void MovePlayerVertically(ref string direction, int mazeHeight)
        {
            if (direction == "up" && Y > 1)
                Y--;
            else if (direction == "down" && Y < mazeHeight)
                Y++;
            // reversing dir as collision 
            else if (Y == mazeHeight)
            {
                direction = "up";
                Y--;
            }
            // reversing dir as collision 
            else if (Y == 1)
            {
                direction = "down";
                Y++;
            }
            else return;  // error case
        }
    }
}
