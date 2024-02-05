using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Shiritori game = new Shiritori();
            List<string> outcome = new List<string>();
            string option = ""; 
            bool check = false;
            while (game.gameOver == false)
            {
                Console.Clear();
                option = gameMenu();
                if (option == "1") 
                {
                    string word = getWord();   
                    game.Play(word, check);
                    check = true;
                    if (game.gameOver == true)
                    {
                        Console.WriteLine("Game has ended..");
                        Console.ReadKey();
                        break;
                    }
                    foreach(string _ in outcome)
                    {
                        Console.Write($"{_}, ");
                    }
                }
                else if (option == "2")
                {
                    game.Restart();
                }
                else if (option == "3")
                {
                    break;
                }
                else
                {
                    error("Invalid Choice...");
                }
            }
        }
        static string getWord()
        {
            Console.WriteLine("Enter a word");
            return Console.ReadLine();
        }
        static string gameMenu()
        {
            Console.WriteLine("1. Add word");
            Console.WriteLine("2. Restart");
            Console.WriteLine("3. Exit");
            
            // input
            Console.WriteLine("Enter your choice");
            return Console.ReadLine();
        }
        static void error(string msg)
        {
            Console.WriteLine(msg);
            Thread.Sleep(700);
        }
    }
}
