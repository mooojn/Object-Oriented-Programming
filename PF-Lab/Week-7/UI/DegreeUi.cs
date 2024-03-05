using chlng4_new.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chlng4_new
{
    internal class DegreeUi
    {
        public static Degree GetInput()
        {
            // input for degree
            Console.Write("Enter Degree Name: ");
            string title = Console.ReadLine();

            Console.Write("Enter Duration: ");
            float duration = float.Parse(Console.ReadLine());

            Console.Write("Enter Seats: ");
            int seats = int.Parse(Console.ReadLine());

            // input for subjects
            Console.Write("Enter Number of Subjects: ");
            int count = int.Parse(Console.ReadLine());

            List<Subject> Subjects = new List<Subject>();
            for (int i = 0; i < count; i++)
            {
                Subject S = SubjectUi.TakeSubjectInput();
                SubjectCrud.Subjects.Add(S);
                Subjects.Add(S);
            }

            return new Degree(title, duration, seats, Subjects);
        }
    }
}
