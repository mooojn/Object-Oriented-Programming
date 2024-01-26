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
            player_class Player = new player_class('P', 3, 18);  // init plyr start pos
            string player_move = "";  // player direction

            const int enemy_count = 3;   // enemy count
            enemy_class[] enemys = new enemy_class[enemy_count];

            enemys[0] = new enemy_class('A', 15, 3);
            enemys[1] = new enemy_class('B', 25, 3);
            enemys[2] = new enemy_class('C', 35, 3);

            string enemy_move = "down";  // enemy direction
            // printing objects on screen
            maze();
            print_object(Player.player_symbol, Player.player_x, Player.player_y);
            // displaying 3 enemies
            for (int i = 0; i < enemy_count; i++)
                print_object(enemys[i].enemy_symbol, enemys[i].enemy_x, enemys[i].enemy_y);
            // main game loop
            while (true)
            {
                if (Keyboard.IsKeyPressed(Key.LeftArrow))
                {
                    erase_object(Player.player_x, Player.player_y);
                    move_object_horizontally("left", ref Player.player_x);
                    print_object(Player.player_symbol, Player.player_x, Player.player_y);
                }
                else if (Keyboard.IsKeyPressed(Key.RightArrow))
                {
                    erase_object(Player.player_x, Player.player_y);
                    move_object_horizontally("right", ref Player.player_x);
                    print_object(Player.player_symbol, Player.player_x, Player.player_y);
                }
                else if (Keyboard.IsKeyPressed(Key.UpArrow))
                {
                    erase_object(Player.player_x, Player.player_y);
                    player_move = "up";
                    move_object_vertically(ref player_move, ref Player.player_y);
                    print_object(Player.player_symbol, Player.player_x, Player.player_y);
                }
                else if (Keyboard.IsKeyPressed(Key.DownArrow))
                {
                    erase_object(Player.player_x, Player.player_y);
                    player_move = "down";
                    move_object_vertically(ref player_move, ref Player.player_y);
                    print_object(Player.player_symbol, Player.player_x, Player.player_y);
                }
                // enemy movements
                for (int i = 0; i < enemy_count; i++)
                {
                    erase_object(enemys[i].enemy_x, enemys[i].enemy_y);
                    move_object_vertically(ref enemy_move, ref enemys[i].enemy_y);
                    print_object(enemys[i].enemy_symbol, enemys[i].enemy_x, enemys[i].enemy_y);
                }
                Thread.Sleep(100);
            }
        }
        static void move_object_horizontally(string direction, ref int x)
        {
            if (direction == "left" && x > 1) // Check if moving left stays within the boundary
                x--;
            else if (direction == "right" && x < maze_width)
                x++;
            else return;  // error case
        }
        static void move_object_vertically(ref string direction, ref int y)
        {
            if (direction == "up" && y > 1)
                y--;
            else if (direction == "down" && y < maze_height)
                y++;
            // reversing dir as collision 
            else if (y == maze_height)
            {
                direction = "up";
                y--;
            }
            // reversing dir as collision 
            else if (y == 1)
            {
                direction = "down";
                y++;
            }
            else return;  // error case
        }
        static void erase_object(int x, int y)
        {
            // removes the object from the screen
            Console.SetCursorPosition(x, y);
            Console.Write(" ");
        }
        static void print_object(char symbol, int x, int y)
        {
            // prints the object on the screen
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