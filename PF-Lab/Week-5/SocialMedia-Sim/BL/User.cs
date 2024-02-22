using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chlng_2_new_pf
{
    internal class User
    {
        public string Name;
        public string Pass;
        public List<string> Msgs;
        public User(string name, string pass)
        {
            Name = name;
            Pass = pass;
                
            Msgs = new List<string>();
        }
        public void ViewProfile()
        {
            Console.WriteLine("Name: " + Name);
        }
        public bool CheckPassword(string pass)
        {
            return Pass == pass;  // check if provided password is correct
        }
        public void ChangePassword(string newPass)
        {
            Pass = newPass;  // change
        }
        public string GetPassword()
        {
            string encryptedPass = "";
            foreach (char c in Pass)
            {
                encryptedPass += "*";         // according to size of pass return a string of *
            } 
            return encryptedPass;
        }
        public string EncryptPassword(string enc)
        {
            // Add '#' to the end of str until its length is divisible by 3
            while (enc.Length % 3 != 0)
            {
                enc += "#";
            }

            // Divide str into 3 equal parts
            int partLength = enc.Length / 3;
            string part1 = enc.Substring(0, partLength);
            string part2 = enc.Substring(partLength, partLength);
            string part3 = enc.Substring(partLength * 2);

            // Concatenate the parts with the password
            string encryptedPassword = part1 + Pass[0] + part2 + Pass[1] + part3 + Pass[2];

            return encryptedPassword;
        }
    }
}
