using chlng4_new.DL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chlng4_new
{
    internal class Program
    {
        // SQL server path
        public static string path = "server=DESKTOP-AJHCE58\\MOOOJN;Database=UAMS;Trusted_Connection=True;";
        // main method
        static void Main(string[] args)
        {
            // loading data
            SubjectCrud.LoadSubjectsFrom(path);
            DegreeCrud.LoadDegreeDB(path);
            StudentCrud.LoadStudent(path);

            string option = "";
            // main loop
            while (true)
            {
                // prev
                option = Utility.MainMenu();

                Console.Clear();
                if (option == "1")
                {
                    if (DegreeCrud.Degrees.Count > 0)    // degree program exist so std can register
                    {
                        Student StdRecord = StudentUi.GetInput();
                        StudentCrud.AddStudent(StdRecord);
                    }
                    else
                    {
                        Utility.ErrorMessage("No Degree Program Exist");
                    }
                }
                else if (option == "2")
                {
                    Degree DegreeRecord = DegreeUi.GetInput();
                    DegreeCrud.AddDegree(DegreeRecord);
                }
                else if (option == "3")
                {
                    StudentCrud.GenerateMerit();
                }
                else if (option == "4")
                {
                    StudentCrud.ViewRegisteredStudent();
                }
                else if (option == "5")
                {
                    DegreeCrud.ShowDegrees();

                    Console.Write("Enter Index Number of Degree: ");
                    int indexOfDegree = int.Parse(Console.ReadLine());

                    DegreeCrud.RegisteredStd(indexOfDegree);  // getting the info of stds that have registered for this degree
                }
                else if (option == "6")
                {
                    string stdName = StudentUi.GetStudentName();
                    string subCode = StudentUi.GetSubjectCode();

                    StudentCrud.RegisterSubject(stdName, subCode);
                }
                else if (option == "7")
                {
                    StudentCrud.GenerateFees();
                }
                else if (option == "8")
                {
                    // save to SQL database
                    SubjectCrud.StoreSubjectsTo(path);
                    DegreeCrud.StoreDegreeDB(path);
                    StudentCrud.StoreStudentDB(path);
                    return;   // closing program
                }
                Utility.PressAnyKey();
            }
        }
    }
}
