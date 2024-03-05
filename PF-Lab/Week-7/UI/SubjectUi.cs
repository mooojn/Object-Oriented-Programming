using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chlng4_new
{
    internal class SubjectUi
    {
        public static Subject TakeSubjectInput()
        {
            Console.Write("Enter Subject Code: ");
            string code = Console.ReadLine();
            Console.Write("Enter Credit Hours: ");
            int ch = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Subject Type: ");
            string type = Console.ReadLine();
            Console.Write("Enter Fees: ");
            int fees = Convert.ToInt32(Console.ReadLine());
            return new Subject(code, ch, type, fees);
        }
    }
}
