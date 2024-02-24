using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chlg3
{
    internal class AdminUi
    {
        public static int GetIndex()
        {
            Console.Write("Enter the index of User: ");
            return int.Parse(Console.ReadLine());
        }
    }
}
