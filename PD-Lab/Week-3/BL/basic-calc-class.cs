using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Task_1
{
    class Calculator
    {
        public int num1;
        public int num2;
        // default construct
        public Calculator()
        {
            num1 = 10;
            num2 = 10;
        }
        // parameterized constructor
        public Calculator(int a, int b)
        {
            num1 = a;
            num2 = b;
        }
        public int Add()
        {
            return num1 + num2;
        }
        public int Subtract()
        {
            return num1 - num2;
        }
        public int Multiply()
        {
            return num1 * num2;
        }
        public int Divide()
        {
            return num1 / num2;
        }
        public int Modulus()
        {
            return num1 % num2;
        }
    }
}
