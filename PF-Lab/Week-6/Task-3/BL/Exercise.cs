using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3
{
    internal class Exercise
    {
        private string Name;
        private List<Set> Sets;
        public Exercise(string name)
        {
            Name = name;
            Sets = new List<Set>();
        }

        public string GetName()
        {
            return Name;
        }

        public void SetName(string name)
        {
            Name = name;
        }

        public List<Set> GetSets()
        {
            return Sets;
        }

        public void AddSet(Set S)
        {
            Sets.Add(S);
        }

    }
}
