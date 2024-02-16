using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
    internal class Player
    {
        public string Name;
        public int HP;
        public int MaxHP;
        public int Energy;
        public int MaxEnergy;
        public int Armor;
        public List<Stats> Skills;
        public Player(string name, int health, int maxHealth, int energy, int maxEnergy, int armor)
        {
            Name = name;
            HP = health;
            MaxHP = maxHealth;
            Energy = energy;
            MaxEnergy = maxEnergy;
            Armor = armor;

            Skills = new List<Stats>();
        }
        public void LearnSkill(Stats newSkill)
        {
            Skills.Add(newSkill);
        }
        public void DisplayInfo()
        {
            Console.WriteLine($"Health: {HP}");
            Console.WriteLine($"Energy: {Energy}");
            Console.WriteLine($"Armor: {Armor}");
        }
        public string Attack(Player plyrToAttack)
        {
            Stats SkillToUse = Skills.Last();  // last added skill
            
            if (Energy >= SkillToUse.Cost)
            {
                Energy -= SkillToUse.Cost;
                int damage = SkillToUse.Damage;

                if (plyrToAttack.Armor > 0)
                {
                    // if armor is greater than damage
                    if (plyrToAttack.Armor >= damage)
                    {
                        plyrToAttack.Armor -= damage;
                    }
                    // armor is less than health so setting armor to 0 and reducing health
                    else
                    {
                        damage -= plyrToAttack.Armor;
                        plyrToAttack.Armor = 0;
                        plyrToAttack.HP -= damage;
                    }
                    // if the the amount of heal is less than maxHP we can heal
                    if (HP + SkillToUse.Heal <= MaxHP)
                        HP += SkillToUse.Heal;
                }
                // no armor so reducing health
                else
                {
                    plyrToAttack.HP -= damage;
                }
                // messages to display
                string s1 = $"{Name} used {SkillToUse.SkillName} against {plyrToAttack.Name}";
                string s2 = $"{damage} damage! {plyrToAttack.Name} is at {plyrToAttack.HP}% Health";
                string s3 = $"{Name} is at {HP}% Health and {Energy}% Energy";
                
                // returning the string to display the attack
                return $"{s1}\n{s2}\n{s3}";
            }
            else
            {
                return $"{Name} does not have enough energy to use {SkillToUse.SkillName}";
            }
        }
    }
}
