using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chlng4_new.DL
{
    internal class SubjectCrud
    {
        public static List<Subject> Subjects = new List<Subject>();
        public static int index = 0;
        
        
        public static List<Subject> LoadRegSub(string path, int id)
        {
            List<Subject> Sub = new List<Subject>();

            string query = $"select * from RegisteredSubjects where subjectId = {id}";
            SqlConnection Conn = new SqlConnection(path);

            Conn.Open();
            SqlCommand Cmd = new SqlCommand(query,Conn);

            SqlDataReader reader = Cmd.ExecuteReader();

            while(reader.Read())
            {
                string subCode = reader["subjectId"].ToString();
                
                
                Sub.Add(IsSubjectExist(subCode));
            }

            Conn.Close();
            
            return Sub;
        }
        public static void AddSubject(Subject NewSubject)
        {
            Subjects.Add(NewSubject);
        }

        public static void LoadSubjectsFrom(string path)
        {
            SqlConnection Connection = new SqlConnection(path);
            
            Connection.Open();
            
            string query = "select * from Subjects";
            
            SqlCommand Command = new SqlCommand(query, Connection);

            SqlDataReader data = Command.ExecuteReader();

            while (data.Read())
            {
                string code = Convert.ToString(data["code"]);
                int creditHours = Convert.ToInt32(data["creditHours"]); ;
                string type = Convert.ToString(data["type"]);
                int fees = Convert.ToInt32(data["fees"]);

                Subject S = new Subject(code, creditHours, type, fees);
               
                Subjects.Add(S);
                index++;
            }
            Connection.Close();
        }
        public static void StoreSubjectsTo(string path)
        {
            SqlConnection Connection = new SqlConnection(path);
            Connection.Open();
            for (int i = index; i < Subjects.Count; i++)
            {
                Subject S = Subjects[i];
                string query = $"insert into Subjects values ('{S.Code}',{S.CreditHours},'{S.Type}',{S.Fees})";
                SqlCommand Command = new SqlCommand (query, Connection);
                Command.ExecuteNonQuery();                
            }
            Connection.Close();
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
