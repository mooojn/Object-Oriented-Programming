using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chlng4_new
{
    internal class Subject
    {
        // vars
        public string Code;
        public int CreditHours;
        public string Type;
        public int Fees;
        
        // construct for values init
        public Subject(string code, int ch, string type, int fees)
        {
            Code = code;
            CreditHours = ch;
            Type = type;
            Fees = fees;
        }
    }
}
