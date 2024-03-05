using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chlng4_new.DL
{
    internal class DegreeCrud
    {
        public static List<Degree> Degrees = new List<Degree>();
        public static List<Degree> LoadRegDeg(string path, string id)
        {
            List<Degree> Degree = new List<Degree>();

            string query = $"select * from RegisteredDegrees where degreeId = '{id}'";
            SqlConnection Conn = new SqlConnection(path);

            Conn.Open();
            SqlCommand Cmd = new SqlCommand(query, Conn);

            SqlDataReader reader = Cmd.ExecuteReader();

            while (reader.Read())
            {
                string degreeCode = reader["degreeId"].ToString();

                
                Degree.Add(IsDegreeExist(degreeCode));
            }

            Conn.Close();
            
            return Degree;
        }
        public static void LoadDegreeDB(string path)
        {
            SqlConnection Conn = new SqlConnection(path);
            
            Conn.Open();
            
            string query = $"select * from Degrees";
            
            SqlCommand Command = new SqlCommand(query, Conn);

            SqlDataReader reader = Command.ExecuteReader();

            while (reader.Read())
            {
                string name = reader["title"].ToString();
                float duration = Convert.ToInt64(reader["duration"]);
                int seats = Convert.ToInt32(reader["seats"].ToString());
                string subjectCode = reader["subjectId"].ToString();

                List<Subject> Sub = new List<Subject>();

                Subject S = SubjectCrud.IsSubjectExist(subjectCode);

                Sub.Add(S);

                Degree degree = new Degree(name, duration, seats, Sub);

                Degrees.Add(degree);
            }
            Conn.Close();
        }
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
