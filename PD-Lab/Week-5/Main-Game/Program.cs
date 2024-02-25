using System;
using System.Threading;
using EZInput;

namespace game_comp_conv
{
    class Program
    {
        static void Main(string[] args)
        {
            Maze GameMaze = new Maze();
            // maze dimensions
            int width = GameMaze.mazeWidth;
            int height = GameMaze.mazeHeight;
            
            // init player obj
            PlayerCrud.AddPlayer(new Player('P', 3, 18));
            
            // init enemy objs
            EnemyCrud.AddEnemy(new Enemy('A', 15, 3));
            EnemyCrud.AddEnemy(new Enemy('B', 25, 3));
            EnemyCrud.AddEnemy(new Enemy('C', 35, 3));

            // print objs on screen
            GameMaze.PrintMaze();
            PlayerCrud.PrintPlayer();
            EnemyCrud.PrintEnemies();
            
            // main game loop
            while (true)
            {
                if (Keyboard.IsKeyPressed(Key.LeftArrow))
                {
                    PlayerCrud.MoveLeft(width);
                }
                else if (Keyboard.IsKeyPressed(Key.RightArrow))
                {
                    PlayerCrud.MoveRight(width);
                }
                else if (Keyboard.IsKeyPressed(Key.UpArrow))
                {
                    PlayerCrud.MoveUp(height);
                }
                else if (Keyboard.IsKeyPressed(Key.DownArrow))
                {
                    PlayerCrud.MoveDown(height);
                }
                // enemy movement
                EnemyCrud.MoveEnemies(height);
                Thread.Sleep(100);
            }
        }
    }
}