using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game_conv
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
    }
}
