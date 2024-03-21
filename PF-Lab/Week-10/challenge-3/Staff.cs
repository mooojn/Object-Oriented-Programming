using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chl3
{
    internal class Staff : Person
    {
        private string school;
        private double pay;
        public Staff(string name, string address, string school, double pay) : base(name, address)
        {
            this.school = school;
            this.pay = pay;
        }
        public string getSchool()
        {
            return school;
        }
        public void setSchool(string val)
        {
            school = val;
        }
        public double getPay()
        {
            return pay;
        }
        public void setPay(double val)
        {
            pay = val;
        }
    }
}
