using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chlng4_new.DL
{
    internal class DegreeCrud
    {
        public static List<Degree> Degrees = new List<Degree>();
        public static void AddDegree(Degree NewDegree)
        {
            Degrees.Add(NewDegree);
        }
        public static void ShowDegrees()
        {
            int index = 0;
            Console.WriteLine("Available Degrees");
            Console.WriteLine("Index, Title, Duration, Seat");
            foreach (Degree D in Degrees)
            {
                Console.WriteLine($"{index}, {D.ShowInfo()}");
                index++;
            }
        }
        public static void RegisteredStd(int index)
        {
            Degrees[index].Registered();
        }
        public static void LoaDegreesFrom(string path)
        {
            StreamReader F = new StreamReader(path);
            string record;
            if (File.Exists(path))
            {
                while ((record = F.ReadLine()) != null)
                {
                    string[] data = record.Split(',');
                    string name = data[0];
                    float duration = float.Parse(data[1]);
                    int seats = int.Parse(data[2]);
                    
                    string[] subjectsCode = data[3].Split(';');
                    
                    List<Subject> Sub = new List<Subject>();
                    
                    for(int i = 0; i < subjectsCode.Length; ++i)
                    {
                        Subject S = SubjectCrud.IsSubjectExist(subjectsCode[i]);
                        if (S != null)
                        {
                            Sub.Add(S);
                        }
                    }
                    Degree degree = new Degree(name, duration, seats, Sub);
                    
                    Degrees.Add(degree);
                }
                F.Close();
            }
        }
        public static void StoreDegreesTo(string path)
        {
            StreamWriter F = new StreamWriter(path);
            foreach (Degree D in Degrees)
            {
                string subjectCodes = string.Join(";", D.Subjects.Select(o => o.Code));     // getting all the codes of subjects
                F.WriteLine($"{D.Title},{D.Duration},{D.Seats},{subjectCodes}");
            }
            F.Close();
        }
        public static Degree IsDegreeExist(string name)
        {
            foreach(Degree D in Degrees)
            {
                if (D.Title == name)
                {
                    return D;
                }
            }
            return null;
        }
    }
}
