using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace chlng_4_new_PD
{
    internal class GameObject
    {
        char[,] Shape;
        Point Pos;
        Boundary Premises;
        string Direction;
        public GameObject()
        { 
            Shape = new char[4, 4];
            Pos = new Point();
            Premises = new Boundary();
            Direction = "LeftToRight";
        }
        public GameObject(char[,] shape, Point startingPoint)
        {
            Shape = shape;
            Pos = startingPoint;
            Premises = new Boundary();
            Direction = "LeftToRight";
        }
        public GameObject(char[,] shape, Point startingPoint, Boundary premises)
        {
            Shape = shape;
            Pos = startingPoint;
            Premises = premises;
            Direction = "LeftToRight";
        }
        public void Move()
        {
            if (Direction == "LeftToRight")
            {
                Pos.X++;
            }
            else if (Direction == "RightToLeft")
            {
                Pos.X--;
            }
            else if (Direction == "Patrol")
            {
                if (Pos.X < Premises.BottomLeft.X)
                    Direction = "RightToLeft";
                else if (Pos.X > Premises.BottomRight.X)
                    Direction = "LeftToRight";
                
                if (Direction == "LeftToRight")
                    Pos.X++;
                else
                    Pos.X--;
            }
            else if (Direction == "Projectile")
            {
                Pos.X += 5;
                Pos.Y -= 5;
            }
            else if (Direction == "Diagnol")
            {
                Pos.X++;
                Pos.Y++;
            }
        }
        public void Erase()
        {
            for (int i = 0; i < Shape.GetLength(0); i++)
            {
                Console.SetCursorPosition(Pos.X, Pos.Y + i);
                for (int j = 0; j < Shape.GetLength(1); j++)
                {
                    Console.Write(' ');
                }
                Console.WriteLine();
            }
        }
        public void Draw()
        {
            for (int i = 0; i < Shape.GetLength(0); i++)
            {
                Console.SetCursorPosition(Pos.X, Pos.Y + i);
                for (int j = 0; j < Shape.GetLength(1); j++)
                {
                    Console.Write(Shape[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
