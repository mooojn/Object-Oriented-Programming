using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator_t1
{
    class Calculator
    {
        // vars
        public float num1;
        public float num2;
        // constructor
        public Calculator(float n1, float n2)
        {
            num1 = n1;
            num2 = n2;
        }
        // behaviours
        public float Sum()
        {
            return num1 + num2;
        }
        public float Sub()
        {
            return num1 - num2;
        }
        public float Mul()
        {
            return num1 * num2;
        }
        public float Div()
        {
            return num1 / num2;
        }
    }
}
