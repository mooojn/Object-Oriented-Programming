using System;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Threading;
using EZInput;

namespace ConsoleApp5
{
    class Program
    {
        static int maze_width = 52;
        static int maze_height = 19;

        static void Main(string[] args)
        {
            int pX = 10, pY = 2;
            maze();
            print_player(pX, pY);

            while (true)
            {
                if (Keyboard.IsKeyPressed(Key.LeftArrow))
                {
                    erase_player(pX, pY);
                    move_player_horizontally("left", ref pX);
                    print_player(pX, pY);
                }
                else if (Keyboard.IsKeyPressed(Key.RightArrow))
                {
                    erase_player(pX, pY);
                    move_player_horizontally("right", ref pX);
                    print_player(pX, pY);
                }
                else if (Keyboard.IsKeyPressed(Key.UpArrow))
                {
                    erase_player(pX, pY);
                    move_player_vertically("up", ref pY);
                    print_player(pX, pY);
                }
                else if (Keyboard.IsKeyPressed(Key.DownArrow))
                {
                    erase_player(pX, pY);
                    move_player_vertically("down", ref pY);
                    print_player(pX, pY);
                }
                Thread.Sleep(100);
            }
        }
        static void move_player_horizontally(string direction, ref int pX)
        {
            if (direction == "left" && pX > 1) // Check if moving left stays within the boundary
                pX--;
            else if (direction == "right" && pX < maze_width)
                pX++;
            else return;  // error case
        }
        static void move_player_vertically(string direction, ref int pY)
        {
            if (direction == "up" && pY > 1)
                pY--;
            else if (direction == "down" && pY < maze_height)
                pY++;
            else return;  // error case
        }
        static void erase_player(int pX, int pY)
        {
            Console.SetCursorPosition(pX, pY);
            Console.Write(" ");
        }

        static void print_player(int pX, int pY)
        {
            Console.SetCursorPosition(pX, pY);
            Console.Write("P");
        }

        static void maze()
        {
            Console.Clear();
            Console.WriteLine("######################################################");
            Console.WriteLine("#                                                    #");
            Console.WriteLine("#                                                    #");
            Console.WriteLine("#                                                    #");
            Console.WriteLine("#                                                    #");
            Console.WriteLine("#                                                    #");
            Console.WriteLine("#                                                    #");
            Console.WriteLine("#                                                    #");
            Console.WriteLine("#                                                    #");
            Console.WriteLine("#                                                    #");
            Console.WriteLine("#                                                    #");
            Console.WriteLine("#                                                    #");
            Console.WriteLine("#                                                    #");
            Console.WriteLine("#                                                    #");
            Console.WriteLine("#                                                    #");
            Console.WriteLine("#                                                    #");
            Console.WriteLine("#                                                    #");
            Console.WriteLine("#                                                    #");
            Console.WriteLine("#                                                    #");
            Console.WriteLine("#                                                    #");
            Console.WriteLine("######################################################");
        }
    }
}
