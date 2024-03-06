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
        public static int index = 0;
        public static List<Degree> LoadPreferences(string path, string id)
        {
            List<Degree> Degree = new List<Degree>();

            string query = $"select * from StudentDegreePreferences where degreeName = '{id}'";
            SqlConnection Conn = new SqlConnection(path);

            Conn.Open();
            SqlCommand Cmd = new SqlCommand(query, Conn);

            SqlDataReader reader = Cmd.ExecuteReader();

            while (reader.Read())
            {
                string degreeCode = reader["degreeName"].ToString();

                
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

                List<Subject> Sub = new List<Subject>();

                int idOfDegree = Convert.ToInt32(reader["id"]);

                Sub = LoadSubjectsForDegree(path, idOfDegree);

                Degree degree = new Degree(name, duration, seats, Sub);

                Degrees.Add(degree);
                index++;
            }
            Conn.Close();
        }
        public static void StoreDegreeDB(string path)
        {
            SqlConnection con = new SqlConnection(path);

            con.Open();
            for (int i = index; i < Degrees.Count; i++)
            {
                Degree D = Degrees[i];
                string query = $"Insert into Degrees values('{D.Title}',{D.Duration},{D.Seats})";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
            }
            con.Close();
        }
        public static List<Subject> LoadSubjectsForDegree(string path, int id)
        {
            List<Subject> subjects = new List<Subject>();
            SqlConnection con = new SqlConnection(path);
            con.Open();
            
            string query = $"select * from DegreeSubjects where degreeId = {id}";
            
            SqlCommand cmd = new SqlCommand(query, con);

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string subjectCode = reader["subjectCode"].ToString();

                Subject S = SubjectCrud.IsSubjectExist(subjectCode);
                
                subjects.Add(S);
            }
            con.Close();

            return subjects;
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
