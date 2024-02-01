using System;
using System.Threading;
using EZInput;

namespace game_comp_conv
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
            player_class[] enemys = new player_class[enemy_count];

            enemys[0] = new player_class('A', 15, 3);
            enemys[1] = new player_class('B', 25, 3);
            enemys[2] = new player_class('C', 35, 3);

            string enemy_move = "down";  // enemy direction
            
            // printing objects on screen
            maze();
            Player.print_object();
            
            // displaying 3 enemies
            for (int i = 0; i < enemy_count; i++)
                enemys[i].print_object();
            
            // main game loop
            while (true)
            {
                if (Keyboard.IsKeyPressed(Key.LeftArrow))
                {
                    Player.erase_object();
                    Player.move_object_horizontally("left", maze_width);
                    Player.print_object();
                }
                else if (Keyboard.IsKeyPressed(Key.RightArrow))
                {
                    Player.erase_object();
                    Player.move_object_horizontally("right", maze_width);
                    Player.print_object();
                }
                else if (Keyboard.IsKeyPressed(Key.UpArrow))
                {
                    Player.erase_object();
                    player_move = "up";
                    Player.move_object_vertically(ref player_move, maze_width);
                    Player.print_object();
                }
                else if (Keyboard.IsKeyPressed(Key.DownArrow))
                {
                    Player.erase_object();
                    player_move = "down";
                    Player.move_object_vertically(ref player_move, maze_height);
                    Player.print_object();
                }
                // enemy movements
                for (int i = 0; i < enemy_count; i++)
                {
                    enemys[i].erase_object();
                    enemys[i].move_object_vertically(ref enemy_move, maze_height);
                    enemys[i].print_object();
                }
                Thread.Sleep(100);
            }
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
