using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
    internal class Program
    {
        // structs 
        public static List<Player> Players = new List<Player>();
        public static List<Stats> Statistics = new List<Stats>();
        static void Main(string[] args)
        {
            string choice = "";
            // main loop
            while (true)
            {
                Console.Clear();
                choice = menu();
                Console.Clear();
                // choices
                if (choice == "1")
                {
                    // Adding a new player
                    Player plyr = getPlayerInput();
                    Players.Add(plyr);
                }
                else if (choice == "2")
                {
                    // Adding a new skill
                    Stats stat = getStatInput();
                    Statistics.Add(stat);
                }
                else if (choice == "3")
                {
                    // getting the last stored player information
                    Players.Last().DisplayInfo();
                }
                else if (choice == "4")
                {
                    // player name
                    Console.Write("Enter Player Name: ");
                    string plyrName = Console.ReadLine();
                    
                    // choices of all skills availabe
                    displayAllSkills();

                    // skill to learn   
                    Console.Write("Enter Skill name to Learn: ");
                    string skillToLearn = Console.ReadLine();
                    
                    // learning the skill
                    learnSkill(plyrName, skillToLearn);
                }
                else if (choice == "5")
                {
                    // displaying the players
                    displayPlayers();

                    // attacker's index
                    Console.Write("Enter Player's Index who will attack: ");
                    int attackerIndex = int.Parse(Console.ReadLine());
                    // defender's index
                    Console.WriteLine("Enter Player's Index who will defend: ");
                    int defenderIndex = int.Parse(Console.ReadLine());

                    // getting the player object's
                    Player Attacker = Players[attackerIndex];
                    Player Defender = Players[defenderIndex];

                    string msg = Attacker.Attack(Defender);
                    Console.WriteLine(msg);
                }
                else if (choice == "6")
                {
                    return;  // program ends
                }
                pressAnyKey();
            }
        }
        static void displayPlayers()
        {
            int index = 0;
            // header
            Console.WriteLine("Index, Player's Name:");
            // displaying the players
            foreach (Player plyr in Players)
            {
                Console.WriteLine($" {index} {plyr.Name}");
                index++;
            }
        }
        static void learnSkill(string plyrName, string skillToLearn)
        {
            foreach (Player P in Players)
            {
                if (P.Name == plyrName)
                {
                    foreach (Stats S in Statistics)
                    {
                        if (S.SkillName == skillToLearn)
                            P.LearnSkill(S);
                    }
                }
            }
        }
        static Stats getStatInput()
        {
            // header
            Console.WriteLine("...Stat Information...");
            // getting the input
            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Discription: ");
            string des = Console.ReadLine();

            Console.Write("Damage: ");
            int dmg = int.Parse(Console.ReadLine());

            Console.Write("Penetration: ");
            int pen = int.Parse(Console.ReadLine());

            Console.Write("Heal: ");
            int heal = int.Parse(Console.ReadLine());

            Console.Write("Cost: ");
            int cost = int.Parse(Console.ReadLine());
            // returning the stats with the input vals
            return new Stats(name, des, dmg, pen, heal, cost);
        }
        static Player getPlayerInput()
        {
            // header
            Console.WriteLine("...Player Information...");
            // getting the input
            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Health: ");
            int hp = int.Parse(Console.ReadLine());

            Console.Write("Max Health: ");
            int maxHp = int.Parse(Console.ReadLine());

            Console.Write("Energy: ");
            int energy = int.Parse(Console.ReadLine());

            Console.Write("Max Energy: ");
            int maxEnergy = int.Parse(Console.ReadLine());

            Console.Write("Armor: ");
            int armor = int.Parse(Console.ReadLine());
            // returning the player with the input vals
            return new Player(name, hp, maxHp, energy, maxEnergy, armor);
        }
        static void displayAllSkills()
        {
            Console.WriteLine("Name, Damage, Penetration, Heal, Cost");
            foreach (Stats S in Statistics)
            {
                Console.WriteLine(S.DisplayInfo());
            }
        }
        static string menu()
        {
            // menu options
            Console.WriteLine("1. Add Player");
            Console.WriteLine("2. Add Skill Stats");
            Console.WriteLine("3. Display Player Info");
            Console.WriteLine("4. Learn A Skill");
            Console.WriteLine("5. Attack");
            Console.WriteLine("6. Exit");

            // getting user input
            Console.Write("Enter choice: ");
            return Console.ReadLine();
        }
        static void pressAnyKey() 
        {
            Console.Write("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
