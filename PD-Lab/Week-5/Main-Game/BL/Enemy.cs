using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game_comp_conv
{
    internal class Enemy
    {
        public char Symbol;
        public int X;
        public int Y;
        public Enemy(char symbol, int x, int y)
        {
            Symbol = symbol;
            X = x;
            Y = y;
        }
        public void PrintEnemy()
        {
            // prints the object on the screen
            Console.SetCursorPosition(X, Y);
            Console.Write(Symbol);
        }
        public void EraseEnemy()
        {
            // removes the object from the screen
            Console.SetCursorPosition(X, Y);
            Console.Write(" ");
        }
        public void MoveEnemy(ref string direction, int mazeHeight)
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
