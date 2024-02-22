using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chlng_2_new_pf
{
    internal class UserCrud
    {
        public static List<User> Users = new List<User>();
        public static void AddUser(User newUser)
        {
            Users.Add(newUser);
        }
        public static bool Validate(User user)
        {
            int i = 0;
            foreach (User U in Users)
            {
                if (user.Name == U.Name && U.Pass == user.Pass)
                {
                    Program.index = i;
                    return true;
                }
                i++;
            }
            return false;
        }
        public static bool Login()
        {
            User User = UserUi.TakeInput();

            if (Validate(User))
            {
                Console.WriteLine("Logged in");
                return true;
            }
            else
            {
                Console.WriteLine("Invalid user or password");
                return false;
            }
        }
    }
}
