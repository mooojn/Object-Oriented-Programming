using System;
using System.Threading;
using EZInput;
using game_conv;

namespace ConsoleApp5
{
    class Program
    {
        // maze dimensions
        static int maze_width = 52;
        static int maze_height = 19;

        static void Main(string[] args)
        {
            player_class Player = new player_class('P', 10, 2);  // init plyr start pos

            const int enemy_count = 3;   // enemy count
            enemy_class[] enemys = new enemy_class[3];
            enemys[0] = new enemy_class('A', 15, 10);
            enemys[1] = new enemy_class('B', 25, 10);
            enemys[2] = new enemy_class('C', 35, 10);

            // printing objects on screen
            maze();
            print_object(Player.player_symbol, Player.player_x, Player.player_y);
            for (int i = 0; i < enemy_count; i++)
                print_object(enemys[i].enemy_symbol, enemys[i].enemy_x, enemys[i].enemy_y);
            // main game loop
            while (true)
            {
                if (Keyboard.IsKeyPressed(Key.LeftArrow))
                {
                    erase_object(Player.player_x, Player.player_y);
                    move_player_horizontally("left", ref Player.player_x);
                    print_object(Player.player_symbol, Player.player_x, Player.player_y);
                }
                else if (Keyboard.IsKeyPressed(Key.RightArrow))
                {
                    erase_object(Player.player_x, Player.player_y);
                    move_player_horizontally("right", ref Player.player_x);
                    print_object(Player.player_symbol, Player.player_x, Player.player_y);
                }
                else if (Keyboard.IsKeyPressed(Key.UpArrow))
                {
                    erase_object(Player.player_x, Player.player_y);
                    move_player_vertically("up", ref Player.player_y);
                    print_object(Player.player_symbol, Player.player_x, Player.player_y);
                }
                else if (Keyboard.IsKeyPressed(Key.DownArrow))
                {
                    erase_object(Player.player_x, Player.player_y);
                    move_player_vertically("down", ref Player.player_y);
                    print_object(Player.player_symbol, Player.player_x, Player.player_y);
                }
                // Random rand = new Random();  // creating object of random number
                // int movePos = rand.Next(0, 2);  // b/w 0, 1
                // if (movePos == 0)
                // {
                //     erase_object(eX, eY);
                //     move_enemy_horizontally("left", ref eX);
                //     print_enemy(eX, eY);
                // }
                // else if (movePos == 1)
                // {
                //     erase_object(eX, eY);
                //     move_enemy_horizontally("right", ref eX);
                //     print_enemy(eX, eY);
                // }

                Thread.Sleep(100);
            }
        }
        static void move_enemy_horizontally(string dir, ref int eX)
        {
            if (dir == "left" && eX > 1)  // collision from left
            {
                eX--;
            }
            else if (dir == "right" && eX < maze_width)  // collision from right
            {
                eX++;
            }
        }
        static void erase_enemy(int eX, int eY)
        {
            Console.SetCursorPosition(eX, eY);
            Console.Write(" ");
        }
        static void print_enemy(int eX, int eY)
        {
            Console.SetCursorPosition(eX, eY);
            Console.Write("E");
        }
        static void move_player_horizontally(string direction, ref int x)
        {
            if (direction == "left" && x > 1) // Check if moving left stays within the boundary
                x--;
            else if (direction == "right" && x < maze_width)
                x++;
            else return;  // error case
        }
        static void move_player_vertically(string direction, ref int y)
        {
            if (direction == "up" && y > 1)
                y--;
            else if (direction == "down" && y < maze_height)
                y++;
            else return;  // error case
        }
        static void erase_object(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(" ");
        }

        static void print_object(char symbol, int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(symbol);
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
