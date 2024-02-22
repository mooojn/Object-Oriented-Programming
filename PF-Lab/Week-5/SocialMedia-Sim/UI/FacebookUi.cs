using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chlng_2_new_pf
{
    internal class FacebookUi
    {
        public static string Operations()
        {
            Console.Clear();

            Console.WriteLine("1.Add Facebook User");
            Console.WriteLine("2.View Posts for a Specific User");
            Console.WriteLine("3.Add a Post for a Specific User");
            Console.WriteLine("4.Back to main menu");

            Console.Write("Enter choice: ");
            return Console.ReadLine();
        }
    }
}
