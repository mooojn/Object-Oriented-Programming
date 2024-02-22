using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace chlng_2_new_pf
{
    internal class TwitterUi
    {
        public static string Operations()
        {
            Console.Clear();

            Console.WriteLine("1.Add Twitter User");
            Console.WriteLine("2.View Tweets for a Specific User");
            Console.WriteLine("3.Post Tweet for a Specific User");
            Console.WriteLine("4.Back to main menu");

            Console.Write("Enter choice: ");
            return Console.ReadLine();
        }
    }
}
