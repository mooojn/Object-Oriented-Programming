using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chlg1
{
    internal class Student
    {
        // objects
        public string stdName;
        public float matric;
        public float fsc;
        public float ecat;
        public float aggregate;
        // constructor to intialize values
        public Student(string name, float mat, float inter, float ecat)
        {
            stdName = name;
            matric = mat;
            fsc = inter;
            this.ecat = ecat;
            aggregate = 0;   // default value
        }
        public void showData()
        {
            Console.WriteLine($"{stdName}\t{matric}\t{fsc}\t{ecat}");
        }
        // funcs
        public void aggregateCalculator()
        {
            // total marks
            const float matricFull = 1100;
            const float fscFull = 1100;
            const float ecatFull = 1100;
            // calculations
            float calculatedValue = ((matric / matricFull) * (30 / 100)) + ((fsc / fscFull) * (60 / 100)) + ((ecat / ecatFull) * (10 / 100));
            aggregate = calculatedValue;  // storing after complete caculation   
        }
    }
}
