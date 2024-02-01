using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game_comp_conv
{
    internal class player_class
    {
        // data strut for player
        public char player_symbol;
        public int player_x;
        public int player_y;
        // initializing vals
        public player_class(char symbol, int x_axis, int y_axis)
        {
            player_symbol = symbol;
            player_x = x_axis;
            player_y = y_axis;
        }
        // functions
        public void print_object()
        {
            // prints the object on the screen
            Console.SetCursorPosition(player_x, player_y);
            Console.Write(player_symbol);
        }
        public void erase_object()
        {
            // removes the object from the screen
            Console.SetCursorPosition(player_x, player_y);
            Console.Write(" ");
        }
        public void move_object_horizontally(string direction, int maze_width)
        {
            if (direction == "left" && player_x > 1) // Check if moving left stays within the boundary
                player_x--;
            else if (direction == "right" && player_x < maze_width)
                player_x++;
            else return;  // error case
        }
        public void move_object_vertically(ref string direction, int maze_height)
        {
            if (direction == "up" && player_y > 1)
                player_y--;
            else if (direction == "down" && player_y < maze_height)
                player_y++;
            // reversing dir as collision 
            else if (player_y == maze_height)
            {
                direction = "up";
                player_y--;
            }
            // reversing dir as collision 
            else if (player_y == 1)
            {
                direction = "down";
                player_y++;
            }
            else return;  // error case
        }

    }
}
