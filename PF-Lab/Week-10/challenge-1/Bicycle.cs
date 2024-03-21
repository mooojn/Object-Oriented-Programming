using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Bicycle
    {
        protected int cadence;
        protected int gear;
        protected int speed;
        public Bicycle(int startCadence, int startSpeed, int startGear)
        {
            gear = startGear;
            cadence = startCadence;
            speed = startSpeed;
        }
        public void SetCadence(int newValue)
        {
            cadence = newValue;
        }
        public void SetGear(int newValue)
        {
            gear = newValue;
        }
        public void ApplyBrake(int decrement)
        {
            speed -= decrement;
        }
        public void SpeedUp(int increment)
        {
            speed += increment;
        }
        public string getBikeInfo()
        {
            return "Cadence: " + cadence + " Speed: " + speed + " Gear: " + gear;
        }
    }
}
