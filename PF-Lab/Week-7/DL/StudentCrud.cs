using chlng4_new.DL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace chlng4_new
{
    internal class StudentCrud
    {
        public static List<Student> Students = new List<Student>();
        public static int index = 0;


        public static void LoadStudent(string path)
        {
            SqlConnection Conn = new SqlConnection(path);
            Conn.Open();
            string query = "Select * from Students";

            SqlCommand Cmd = new SqlCommand(query, Conn);

            SqlDataReader reader = Cmd.ExecuteReader();

            while(reader.Read())
            {
                string name = reader["name"].ToString();
                int age = Convert.ToInt32(reader["age"]);
                int fsc = Convert.ToInt32(reader["fsc"]);
                int ecat = Convert.ToInt32(reader["ecat"]);
                string degreeName = reader["degreeName"].ToString();


                List<Degree> Pref = DegreeCrud.LoadPreferences(path, degreeName);
                
                Degree RegisteredDegree = DegreeCrud.IsDegreeExist(degreeName);
                
                Student Std = new Student(name, age, fsc, ecat, Pref, RegisteredDegree);

                Students.Add(Std);
                index++;
            }
        }
        public static void StoreStudentDB(string path)
        {
            SqlConnection con = new SqlConnection(path);

            con.Open();
            for(int i = index; i < Students.Count; i++)
            {
                Student S = Students[i];
                string query = $"Insert into Students values('{S.Name}', {S.Age}, {S.EcatMarks}, {S.FscMarks}, '{S.RegisteredDegree.Title}')";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
            }
            con.Close();
        }
        // DB xtras
        public static void AddStudentDB(string path)
        {
            SqlConnection Con = new SqlConnection(path);

            Con.Open();
            string name = "moon";
            int age = 20;
            int fsc = 900;
            int ecat = 200;

            string query = $"Insert into Students values('{name}',{age},{fsc},{ecat})";

            SqlCommand Cmd = new SqlCommand(query, Con);

            Cmd.ExecuteNonQuery();

            Con.Close();
        }
        public static void DeleteStudentDB(string path)
        {
            SqlConnection Con = new SqlConnection(path);
            Con.Open();

            string name = "moon";

            string query = $"Delete from Students where name = '{name}'";

            SqlCommand Cmd = new SqlCommand(query, Con);

            Cmd.ExecuteNonQuery();

            Con.Close();
        }
        public static void ViewStudentDB(string path)
        {
            SqlConnection Con = new SqlConnection(path);
            Con.Open();

            string name = "saliq";

            string query = $"Select * from Students where name = '{name}'";

            SqlCommand Cmd = new SqlCommand(query, Con);

            SqlDataReader reader = Cmd.ExecuteReader();

            if (reader.Read())
            {
                Console.WriteLine(reader["fsc"]);
                Console.ReadKey();
            }

            Con.Close();
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
