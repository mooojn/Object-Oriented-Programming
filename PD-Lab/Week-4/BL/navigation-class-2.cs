using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_1
{
    internal class Ship
    {
        public string SerialNumber;
        public Angle Longitude;
        public Angle Latitude;
        public Ship(string serial, Angle longitude, Angle latitude)
        {
            SerialNumber = serial;
            Longitude = longitude;
            Latitude = latitude;
        }
        public bool LocationCheck(Angle angle, string type)
        {
            if (type == "Longitude")
                return angle.Check(Longitude);
            return angle.Check(Latitude);
        }
        public void Location()
        {
            Console.WriteLine($"Longitude: {Longitude.Display()}");
            Console.WriteLine($"Latitude: {Latitude.Display()}");
        }
        public void DisplaySerial()
        {
            Console.WriteLine($"Serial Number: {SerialNumber}");
        }
    }
}
