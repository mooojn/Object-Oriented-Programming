using chlng4_new.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chlng4_new
{
    internal class Program
    {
        // main method
        static void Main(string[] args)
        {
            string option = "";
            // main loop
            while (true)
            {
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
                    return;   // closing program
                }
                Utility.PressAnyKey();
            }
        }
    }
}
