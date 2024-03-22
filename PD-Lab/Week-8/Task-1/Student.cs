using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chl3
{
    internal class Student : Person
    {
        private string program;
        private int year;
        private double fee;
        
        public Student(string name, string address, string program, int year, double fee) : base(name, address)
        {
            this.program = program;
            this.year = year;
            this.fee = fee;
        }
        public string getProgram()
        {
            return program;
        }
        public void setProgram(string val)
        {
            program = val;
        }
        public int getYear()
        {
            return year;
        }
        public void setYear(int val)
        {
            year = val;
        }
        public double getFee()
        {
            return fee;
        }
        public void setFee(double val)
        {
            fee = val;
        }
        public new string toString()
        {
            return $"Student[Person[name={getName()}, address={getAddress()}], program={program}, year={year}, fee={fee}]";
        }

    }
}
