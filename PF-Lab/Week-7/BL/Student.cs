using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chlng4_new
{
    internal class Student
    {
        // vars
        public string Name;
        public int Age;
        public double FscMarks;
        public double EcatMarks;
        public double Merit;
        
        // relations
        public List<Degree> Preferences= new List<Degree>();
        public List<Subject> RegisteredSubjects = new List<Subject>();
        public Degree RegisteredDegree;
        
        // construct for values init
        public Student(string name, int age, double fsc, double ecat, List<Degree> Pref)
        {
            Name = name;
            Age = age;
            FscMarks = fsc;
            EcatMarks = ecat;
            Preferences = Pref;

            Merit = CalculateMerit();
        }
        public Student(string name, int age, double fsc, double ecat, List<Degree> Pref, Degree Regd_Degree)
        {
            Name = name;
            Age = age;
            FscMarks = fsc;
            EcatMarks = ecat;
            Preferences = Pref;
            RegisteredDegree = Regd_Degree;

            Merit = CalculateMerit();
        }
        public Student(string name, int age, double fsc, double ecat, List<Subject> subjects)
        {
            Name = name;
            Age = age;
            FscMarks = fsc;
            EcatMarks = ecat;
            RegisteredSubjects = subjects;

            Merit= CalculateMerit();
        }
        public double CalculateMerit()
        {
            // 70% FscMarks + 30% EcatMarks
            return (FscMarks * 0.7) + (EcatMarks * 0.3);
        }
        public int GetCreditHours()
        {
            int totalCreditHours = 0;
            foreach (Subject S in RegisteredSubjects)
            {
                totalCreditHours += S.CreditHours;
            }
            return totalCreditHours;
        }
        public float CalculateFee()
        {
            float totalFee = 0;
            foreach (Subject S in RegisteredSubjects)
            {
                totalFee += S.Fees;
            }
            return totalFee;
        }
        public void RegisterSubject(Subject Sub)
        {
            // move this Console.log to main
            int stCh = GetCreditHours();
            if (RegisteredDegree != null && RegisteredDegree.IsSubjectExists(Sub) && stCh + Sub.CreditHours <= 9)
            {
                RegisteredSubjects.Add(Sub);
            }
            else
            {
                Utility.ErrorMessage("Subject can't be registered");
            }
        }
        public string GetInfo()
        {
            return $"{Name}, {Age}, {FscMarks}, {EcatMarks}";
        } 
    }
}
