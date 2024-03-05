using buscompe_conv.UI;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace chlg3
{
    internal class UserCrud
    {
        public static List<User> Users = new List<User>();
        public static void StoreUsersDataToFile()
        {
            StreamWriter F = new StreamWriter(Program.file_path);   // obj of file
            
            // storing relevant information
            F.WriteLine("Name,Password,Cash");
            foreach (User Usr in Users)
            {
                F.WriteLine($"{Usr.user_names},{Usr.user_passwords},{Usr.cash_holdings}");
            }
            F.Close();
        }
        public static void LoadUsersFromFile()
        {
            // file object
            StreamReader file = null;
            try
            {
                file = new StreamReader(Program.file_path);
            }
            catch (FileNotFoundException)
            {
                return;
            }
            file.ReadLine();  // skipping header

            string line = "";
            while ((line = file.ReadLine()) != null)  // until reaching end of file
            {
                string[] parts = line.Split(',');   // creating an array of all the elements
                // loading data
                // storing data and converting to obj
                string name = parts[0];
                string pass = parts[1];
                int cash = int.Parse(parts[2]);
                User Usr = new User(name, pass);   // creating an obj
                Usr.cash_holdings = cash;  // setting cash holdings

                Users.Add(Usr);
            }
            file.Close();
        }
        public static void AddUser(User U)
        {
            Users.Add(U);
        }
        public static bool SignIn(string name, string pass)
        {
            // validating
            UtilUi.Process();
            if (!UniqueUser(name) && pass_validated(name, pass))
            {
                Console.WriteLine("You are signed in...");
                UtilUi.PressAnyKey();
                return true;
            }
            else
                UtilUi.Error("Incorrect Password");
            return false;
        }
        public static void SignUp(string name, string pass)
        {
            if (UniqueUser(name)) // checking if user is unique
            {
                UtilUi.Success("You have successfully signed up");

                User Usr = new User(name, pass);
                Users.Add(Usr);
            }
            else
                UtilUi.Error("User already exists.");
        }
        public static void ViewAllUsers()
        {
            int i = 0;

            Console.WriteLine("Index\tName\tCash");
            foreach(User Usr in Users)
            {
                Console.WriteLine($"{i}\t{Usr.user_names}\t{Usr.cash_holdings}");
                i++;
            }
        }
        public static bool pass_validated(string name, string pass)
        {
            int i = 0;
            foreach(User Usr in Users)
            {
                if (Usr.user_names == name && Usr.user_passwords == pass)
                {
                    Program.current_user_index = i;
                    return true;
                }
                i++;
            }
            return false;
        }
        public static bool UniqueUser(string name)
        {
            foreach (User Usr in Users)
            {
                if (Usr.user_names == name)
                {
                    return false;
                }
            }
            return true;
        }
        public static void DeleteUserFromIndex(int index_to_remove)
        {
            UtilUi.Process();
            
            Users.RemoveAt(index_to_remove);
            
            UtilUi.Success("Account has been removed...");
        }
        public static bool ValidateIndex(int indexToValidate)
        {
            return indexToValidate + 1 > Users.Count;
        }
    }
}
