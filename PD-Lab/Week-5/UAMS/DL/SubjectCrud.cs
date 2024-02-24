using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chlng4_new.DL
{
    internal class SubjectCrud
    {
        public static List<Subject> Subjects = new List<Subject>();
        public static void AddSubject(Subject NewSubject)
        {
            Subjects.Add(NewSubject);
        }
        public static void LoadSubjectsFrom(string path)
        {
            StreamReader F = new StreamReader(path);
            string record;
            if (File.Exists(path))
            {
                while ((record = F.ReadLine()) != null)
                {
                    string[] data = record.Split(',');
                    string code = data[0];
                    string type = data[1];
                    int credit = int.Parse(data[2]);
                    int fees = int.Parse(data[3]);
                    Subject S = new Subject(code, credit, type, fees);

                    Subjects.Add(S);
                }
                F.Close();
            }
        }
        public static void StoreSubjectsTo(string path)
        {
            StreamWriter F = new StreamWriter(path);
            foreach (Subject S in Subjects)
            {
                F.WriteLine($"{S.Code},{S.Type},{S.CreditHours},{S.Fees}");
            }
            F.Close();
        }
        public static Subject IsSubjectExist(string code)
        {
            foreach(Subject S in Subjects)
            {
                if (S.Code == code)
                {
                    return S;
                }
            }
            return null;  // not found
        }
    }
}
