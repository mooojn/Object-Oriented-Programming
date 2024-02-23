using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chlng_4_new_PD
{
    internal class GameUi
    {
        public static char[,] GetShape()
        {
            char[,] triangle = new char[5, 3]
            {
                {'@',' ',' '},
                {'@','@',' '},
                {'@','@','@'},
                {'@','@',' '},
                {'@',' ',' '},
            };
            return triangle;
        }
    }
}
