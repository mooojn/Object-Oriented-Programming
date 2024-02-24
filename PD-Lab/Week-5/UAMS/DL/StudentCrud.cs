using chlng4_new.DL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace chlng4_new
{
    internal class StudentCrud
    {
        public static List<Student> Students = new List<Student>();
        public static void LoadStudentsFrom(string path)
        {
            StreamReader F = new StreamReader(path);
            string record;
            if (File.Exists(path))
            {
                while ((record = F.ReadLine()) != null)
                {
                    string[] data = record.Split(',');
                    string name = data[0];
                    int age = int.Parse(data[1]);
                    double fsc = double.Parse(data[2]);
                    double ecat = double.Parse(data[3]);

                    string[] pref = data[4].Split(';');

                    List<Degree> Pref = new List<Degree>();

                    for (int i = 0; i < pref.Length; ++i)
                    {
                        Degree D = DegreeCrud.IsDegreeExist(pref[i]); 
                        if (D != null)
                        {
                            Pref.Add(D);
                        }
                    }
                    Student S = new Student(name, age, fsc, ecat, Pref);
                    
                    Students.Add(S);
                }
                F.Close();
            }
        }
        public static void StoreStudentsTo(string path)
        {
            StreamWriter F = new StreamWriter(path);
            foreach (Student S in Students)
            {
                string preferences = string.Join(";", S.Preferences.Select(o => o.Title));     // getting all the titles of degrees
                F.WriteLine($"{S.Name},{S.Age},{S.FscMarks},{S.EcatMarks},{preferences}");
            }
            F.Close();
        }
        public static void AddStudent(Student NewStudent)
        {
            Students.Add(NewStudent);
        }
        public static void ViewRegisteredStudent()
        {
            // header for data
            Console.WriteLine("Name, Age, Fsc, Ecat");
            // loop through all students
            //Console.WriteLine(S.RegisteredDegree);
            foreach (Student S in Students)
            {
                if (S.RegisteredDegree != null)
                {
                    // data to display
                    Console.WriteLine(S.GetInfo());
                    // new line
                    Console.WriteLine();
                }
            }
        }
        public static void GenerateMerit()
        {   
            List<Student> SortedStdByMerit = Students.OrderByDescending(x => x.Merit).ToList();

            foreach (Student S in SortedStdByMerit)
            {
                bool registered = false;  // to check if std gets registered to any degree
                string degree = "";
                
                // checking which degree std can get admission
                foreach (Degree PrefDegree in S.Preferences)
                {
                    if (PrefDegree.IsSeatAvailable())
                    {
                        // assign degree and its subjects to std
                        S.RegisteredDegree = PrefDegree;
                        PrefDegree.Students.Add(S);

                        PrefDegree.Seats--;

                        registered = true;
                        degree = PrefDegree.Title;
                        break;  // as we have registered student to degree now this student can't be registered to another degree
                    }
                }

                // result after checking
                if (registered)
                {
                    Console.WriteLine($"{S.Name} got admission in {degree}");
                }
                else
                {
                    Utility.ErrorMessage($"{S.Name} did not get admission");
                }
            }
        }
        public static void GenerateFees()
        {
            foreach(Student S in Students)
            {
                if (S.RegisteredDegree != null)
                {
                    Console.WriteLine($"{S.Name} has to pay {S.CalculateFee()}");
                }
            }
        }
        public static void RegisterSubject(string stdName, string subCode)
        {
            foreach(Student S in Students)
            {
                if (stdName == S.Name)
                {
                    List<Subject> SubOfDegree = S.RegisteredDegree.Subjects;  // getting the subjects of degree in which std is registered
                    foreach (Subject Sub in SubOfDegree)
                    {
                        if (subCode == Sub.Code)
                        {
                            S.RegisterSubject(Sub);
                        }
                    }
                }
            }
        }

    }
}
