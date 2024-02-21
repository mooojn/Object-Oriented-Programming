using chlng4_new;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace chlng4_new
{
    internal class Degree
    {
        // vars
        public string Title;
        public float Duration;
        public int Seats;

        // relations
        public List<Subject> Subjects = new List<Subject>();
        public List<Student> Students = new List<Student>();  // std that are enrolled in this degree
        // construct for values init
        public Degree(string title, float duration ,int seats, List<Subject> Sub)
        {
            Title = title;
            Duration = duration;
            Seats = seats;
            Subjects = Sub;
        }
        public void Registered()
        {
            Console.WriteLine("Name, Age, FscMarks, EcatMarks");
            foreach (Student S in Students)
            {
                Console.WriteLine(S.GetInfo());
            }
        }
        public int CalculateCreditHours()
        {
            int totalCreditHours = 0;
            foreach (Subject S in Subjects)
            {
                totalCreditHours += S.CreditHours;
            }
            return totalCreditHours;
        }
        public bool IsSubjectExists(Subject Sub)
        {
            foreach (Subject S in Subjects)
            {
                if (S.Code == Sub.Code)
                    return true;
            }
            return false;
        }
        public void AddSubject(Subject S)
        {
            int creditHours = CalculateCreditHours();
            if (creditHours + S.CreditHours <= 20)
            {
                Subjects.Add(S);
            }
            else
            {
                Console.WriteLine("Credit hours limit reached");
            }
        }
        public bool IsSeatAvailable()
        {
            return Seats > 0;
        }
        public string ShowInfo()
        {
            return $"{Title}, {Duration}, {Seats}";
        }
    }
}
