using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3
{
    internal class Set
    {
        private int Repetitions;
        private double Weight;

        public int GetRepetitions()
        {
            return Repetitions;
        }

        public void SetRepetitions(int repetitions)
        {
            Repetitions = repetitions;
        }

        public double GetWeight()
        {
            return Weight;
        }

        public void SetWeight(double weight)
        {
            Weight = weight;
        }

        public Set(int repetitions, double weight)
        {
            SetRepetitions(repetitions);
            SetWeight(weight);
        }
    }
}
