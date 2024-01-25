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
    }
}
