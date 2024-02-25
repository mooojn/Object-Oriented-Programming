using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game_comp_conv
{
    internal class EnemyCrud
    {

        public static List<Enemy> Enemies = new List<Enemy>();
        public static string enemyMove = "down";  // enemy direction
        public static void AddEnemy(Enemy E)
        {
            Enemies.Add(E);
        }
        public static void PrintEnemies()
        {
            foreach (Enemy E in Enemies)
                E.PrintEnemy();
        }
        public static void MoveEnemies(int mazeHeight)
        {
            foreach (Enemy E in Enemies)
            {
                E.EraseEnemy();
                E.MoveEnemy(ref enemyMove, mazeHeight);
                E.PrintEnemy();
            }
        }
    }
}
