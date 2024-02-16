

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // structs
            List<Ship> Ships = new List<Ship>();

            string choice = "";
            
            while (true)
            {
                Console.Clear();
                
                choice = menu();

                Console.Clear();
                if (choice == "1")
                {
                    Ship ship = getInputForShip();
                    Ships.Add(ship);
                }
                else if (choice == "2")
                {
                    Console.Write("Enter Serial no. to find Ship: ");
                    string serial = Console.ReadLine();

                    foreach (Ship S in Ships)
                    {
                        if (S.SerialNumber == serial)
                        {
                            S.Location();
                            break;
                        }
                    }
                }
                else if (choice == "3")
                {
                    Console.WriteLine("Enter Ship Latitude: ");
                    Angle lat = getAngleInput("Latitude");

                    Console.WriteLine("Enter Ship Longitude: ");
                    Angle lon = getAngleInput("Longitude");
                    
                    foreach(Ship S in Ships)
                    {
                        if (S.LocationCheck(lat, "Latitude") && S.LocationCheck(lon, "Longitude"))
                        {
                            S.DisplaySerial();
                            break;
                        }
                    }
                }
                else if (choice == "4")
                {
                    Console.Write("Enter Serial no. to change direction: ");
                    string serial = Console.ReadLine();

                    foreach (Ship S in Ships)
                    {
                        if (S.SerialNumber == serial)
                        {
                            Console.WriteLine("Latitude: ");
                            S.Latitude = getAngleInput("Latitude");
                            
                            Console.WriteLine("Longitude: ");
                            S.Longitude = getAngleInput("Longitude");

                            break;
                        }
                    }
                }
                else if (choice == "5")
                {
                    break;
                }
                pressAnyKey();
            }
        }
        static Ship getInputForShip()
        {
            Console.Write("Serial No.: ");
            string serial = Console.ReadLine();

            Console.WriteLine("Ship's Latitude: ");
            Angle longAngle = getAngleInput("Latitude");

            Console.WriteLine("Ship's Longitude: ");
            Angle latAngle = getAngleInput("Longitude");

            return new Ship(serial, longAngle, latAngle);
        }
        static Angle getAngleInput(string type)
        {

            Console.Write($"{type} Degree: ");
            int deg = int.Parse(Console.ReadLine());

            Console.Write($"{type} Minutes: ");
            float min = float.Parse(Console.ReadLine());

            Console.Write($"{type} Direction: ");
            char dir = char.Parse(Console.ReadLine());

            return new Angle(deg, min, dir);
        }
        static string menu()
        {
            Console.WriteLine("1. Add Ship");
            Console.WriteLine("2. View Ship Position");
            Console.WriteLine("3. View Ship Serial Number");
            Console.WriteLine("4. Change Ship Position");
            Console.WriteLine("5. Exit");

            Console.Write("Enter Choice: ");
            return Console.ReadLine();
        }
        static void pressAnyKey()
        {
            Console.Write("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
