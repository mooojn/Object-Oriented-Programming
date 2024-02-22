using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chlng_2_new_pf
{
    internal class Program
    {
        public static int index;
        public static Twitter TwitterUser = new Twitter();
        public static Facebook FacebookUser = new Facebook();
        static void Main(string[] args)
        {
        LogOut:
            index = 0;
            string mainChoice;
            while (true)
            {
                mainChoice = UtilUi.MainMenu();
                if (mainChoice == "1")
                {
                    string uChoice;
                    while (true)
                    {
                        uChoice = UserUi.Operations();
                        if (uChoice == "1")
                        {
                            User newUser = UserUi.TakeInput();
                            UserCrud.AddUser(newUser);
                        }
                        else if (uChoice == "2")
                        {
                            bool flag = UserCrud.Login();
                            if (flag)
                            {
                                goto Login;
                            }
                        }
                        else if (uChoice == "3")
                        {
                            break;  // back to main menu
                        }
                        UtilUi.PressAnyKey();
                    }
                }
                else if (mainChoice == "2")
                {
                    TwitterUi.Operations();
                    while (true)
                    {
                        string tChoice = TwitterUi.Operations();
                        if (tChoice == "1")
                        {
                            User newUser = UserUi.TakeInput();
                            TwitterUser.AddUser(newUser);
                        }
                        else if (tChoice == "2")
                        {
                            string name = UtilUi.GetNameToSearch();
                            TwitterUser.ViewTweets(name);
                        }
                        else if (tChoice == "3")
                        {
                            string name = UtilUi.GetNameToSearch();
                            string msg = UtilUi.GetMessageToSend("Tweet");
                            TwitterUser.PostTweet(name, msg);
                        }
                        else if (tChoice == "4")
                        {
                            break;  // back to main menu
                        }
                        UtilUi.PressAnyKey();
                    }
                }
                else if (mainChoice == "3")
                {
                    FacebookUi.Operations();
                    while (true)
                    {
                        string tChoice = FacebookUi.Operations();
                        if (tChoice == "1")
                        {
                            User newUser = UserUi.TakeInput();
                            FacebookUser.AddUser(newUser);
                        }
                        else if (tChoice == "2")
                        {
                            string name = UtilUi.GetNameToSearch();
                            FacebookUser.ViewPosts(name);
                        }
                        else if (tChoice == "3")
                        {
                            string name = UtilUi.GetNameToSearch();
                            string msg = UtilUi.GetMessageToSend("Post");
                            FacebookUser.PostPost(name, msg);
                        }
                        else if (tChoice == "4")
                        {
                            break;  // back to main menu
                        }
                        UtilUi.PressAnyKey();
                    }
                }
                else if (mainChoice == "4")
                {
                    return;  // end
                }
            }
        Login:
            string choice;
            while (true)
            {
                choice = UserUi.Menu();
                if (choice == "1")
                {
                    UserCrud.Users[index].ViewProfile();
                }
                else if (choice == "2")
                {
                    string enc = UtilUi.GetEncryptor();
                    string msg = UserCrud.Users[index].EncryptPassword(enc);
                    Console.WriteLine(msg);
                }
                else if (choice == "3")
                {
                    string pass = UtilUi.GetPass();
                    bool flag = UserCrud.Users[index].CheckPassword(pass);

                    string msg = flag ? "Password is correct" : "Password is incorrect";
                    Console.WriteLine(msg);
                }
                else if (choice == "4")
                {
                    string pass = UtilUi.GetPass();
                    UserCrud.Users[Program.index].ChangePassword(pass);
                    Console.WriteLine("Password changed");
                }
                else if (choice == "5")
                {
                    string pass = UserCrud.Users[Program.index].GetPassword();
                    Console.WriteLine(pass);
                }
                else if (choice == "6")
                {
                    goto LogOut;  // logOut
                }
                UtilUi.PressAnyKey();
            }
        }
    }
}
