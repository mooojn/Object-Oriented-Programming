using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game_conv
{
    internal class enemy_class
    {
        // data struct for enemy
        public char enemy_symbol;
        public int enemy_x;
        public int enemy_y;
        // initializing vals
        public enemy_class(char symbol, int x_axis, int y_axis)
        {
            enemy_symbol = symbol;
            enemy_x = x_axis;
            enemy_y = y_axis;
        }
    }
}
