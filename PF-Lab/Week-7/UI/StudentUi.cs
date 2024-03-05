using chlng4_new.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chlng4_new
{
    internal class StudentUi
    {
        public static Student GetInput()
        {
            // input
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Age: ");
            int age = int.Parse(Console.ReadLine());

            Console.Write("Enter Fsc Marks: ");
            float fsc = float.Parse(Console.ReadLine());

            Console.Write("Enter Ecat Marks: ");
            float ecat = float.Parse(Console.ReadLine());
            
            DegreeCrud.ShowDegrees();

            Console.Write("How many Preferences you want to choose: ");
            int count = int.Parse(Console.ReadLine());
            
            List<Degree> Pref = new List<Degree>();
            for (int i = 0; i < count; i++)
            {
                Console.Write("Enter Index Number of Degree: ");
                int indexOfDegree = int.Parse(Console.ReadLine());

                Degree PrefDegree = DegreeCrud.Degrees[indexOfDegree];
                
                Pref.Add(PrefDegree);
            }

            // return
            return new Student(name, age, fsc, ecat, Pref);
        }
        public static string GetStudentName()
        {
            Console.Write("Enter Student Name: ");
            return Console.ReadLine();
        }
        public static string GetSubjectCode()
        {
            Console.Write("Enter Subject Code: ");
            return Console.ReadLine();
        }
    }
}
