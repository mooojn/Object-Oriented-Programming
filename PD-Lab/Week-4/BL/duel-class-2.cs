using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace task2
{
    internal class Stats
    {
        public string SkillName;
        public string Description;
        public int Damage;
        public int Penetration;
        public int Cost;
        public int Heal;

        public Stats(string name, string description, int damage, int penetration, int heal, int cost)
        {
            SkillName = name;
            Description = description;
            Damage = damage;
            Penetration = penetration;
            Cost = cost;
            Heal = heal;
        }
        public string DisplayInfo()
        {
            return $"{SkillName}, {Damage}, {Penetration}, {Heal}, {Cost}";
        }
    }
}
