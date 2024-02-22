using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chlng_2_new_pf
{
    internal class Twitter
    {
        public List<User> Users;
        public Twitter()
        {
            Users = new List<User>();
        }
        public void AddUser(User user)
        {
            Users.Add(user);
        }
        public void ViewTweets(String nameToSearch)
        {
            foreach (User U in Users)
            {
                if (U.Name == nameToSearch)
                {
                    foreach (string msg in U.Msgs)
                    {
                        Console.WriteLine(msg);
                    }
                }
            }
        }
        public void PostTweet(string name, string msg)
        {
            foreach (User U in Users)
            {
                if (U.Name == name)
                {
                    U.Msgs.Add(msg);
                }
            }
        }

    }
}
