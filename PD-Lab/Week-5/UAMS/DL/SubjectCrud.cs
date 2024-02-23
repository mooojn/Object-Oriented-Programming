using System;
using System.Collections.Generic;
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
    }
}
