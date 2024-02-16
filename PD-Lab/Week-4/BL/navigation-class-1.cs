using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace task_1
{
    internal class Angle
    {
        public int Degree;
        public float Minutes;
        public char Direction;

        public Angle(int deg, float min, char dir)
        {
            Degree = deg;
            Minutes = min;
            Direction = dir;
        }
        public string Display()
        {
            // formatted output
            return $"{Degree}\u00b0 {Minutes}` {Direction}";
        }
        public bool Check(Angle ang)
        {
            if (ang.Degree == Degree && ang.Minutes == Minutes && ang.Direction == Direction)
                return true;
            return false;
        }
    }
}
