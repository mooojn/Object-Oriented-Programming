using System;
using System.Threading;
using System.IO;
using System.ComponentModel.Design;
using System.CodeDom;
using buscompe_conv.UI; // for file handling

namespace chlg3
{
    class Program
    {
        // global vars
        public static string file_path = "data.txt";   // path where data stored
        public static int current_user_index = 0;  // index of the logged-in user
        static void Main(string[] args)
        {   
            UserCrud.LoadUsersFromFile(file_path);

            bool transactions_blocked = false; // for blocking transactions 

        logout: // for logging out
            bool allow_login_user = false;
            bool allow_login_admin = false;
            // main body
            while (true)
            {
                Console.Clear(); // to clear the screen
                string choice = MainUi.Menu();

                Console.Clear();
                switch (choice)
                {
                    case "1":
                        string adminPass = UserUi.GetPass();
                        allow_login_admin = AdminCrud.Validate(adminPass);
                        if (allow_login_admin)
                            goto endLoop;
                        break;
                    case "2":
                        string userName = UserUi.GetName();
                        string userPass = UserUi.GetPass();
                        allow_login_user = UserCrud.SignIn(userName, userPass);
                        if (allow_login_user)
                            goto endLoop;
                        break;
                    case "3":
                        string newName = UserUi.GetName();
                        string newPass = UserUi.GetPass();
                        UserCrud.SignUp(newName, newPass);
                        break;
                    case "4":
                        UserCrud.StoreUsersDataToFile();
                        return; // exit from program
                    default:
                        UtilUi.InvalidChoice();
                        break;
                }
            }
        endLoop:;
            if (allow_login_user)
            {
                string user_choice = "";
                while (true)
                {
                    Console.Clear();

                    user_choice = MainUi.user_menu();

                    Console.Clear();
                    User CurrentUser = UserCrud.Users[current_user_index];
                    switch (user_choice)
                    {
                        case "1":
                            CurrentUser.ShowCash();
                            UtilUi.PressAnyKey();
                            break;
                        case "2":
                            if (!transactions_blocked)
                            {
                                int deposit_amount = UserUi.GetDepositAmount();
                                bool deposit_status = CurrentUser.AddCash(deposit_amount);
                                UtilUi.ShowMSG(deposit_status);
                            }
                            else
                                UtilUi.Error("Transactions are Blocked");
                            break;
                        case "3":
                            if (!transactions_blocked)
                            {
                                int withdraw_amount = UserUi.GetWithdrawAmount();
                                bool withdraw_status = CurrentUser.WithdrawCash(withdraw_amount);
                                UtilUi.ShowMSG(withdraw_status);
                            }
                            else
                                UtilUi.Error("Transactions are Blocked");
                            break;
                        case "4":
                            transactions_blocked = UtilCrud.BlockTransactions(transactions_blocked);
                            break;
                        case "5":
                            UserCrud.DeleteUserFromIndex(current_user_index);
                            goto logout;
                        case "6":
                            goto logout;
                        default:
                            // Handle other cases
                            break;
                    }
                }
            }
            if (allow_login_admin)
            {
                string admin_choice = "";
                while (true)
                {
                    Console.Clear();
                    admin_choice = MainUi.admin_menu();

                    Console.Clear();
                    switch (admin_choice)
                    {
                        case "1":
                            string name = UserUi.GetName();
                            string pass = UserUi.GetPass();
                            UserCrud.SignUp(name, pass);
                            break;
                        case "2":
                            UserCrud.ViewAllUsers();
                            UtilUi.PressAnyKey();
                            break;
                        case "3":
                        case "4":
                            UserCrud.ViewAllUsers();
                            int index = AdminUi.GetIndex();
                            if (UserCrud.ValidateIndex(index))  // if index is valid then proceed
                            {
                                UtilUi.Error("Invalid index...");
                                continue;
                            }
                            else if (admin_choice == "3")
                            {
                                string newName = UserUi.GetName();
                                UserCrud.Users[index].user_names = newName;
                                UtilUi.Success("Changed successfully...");
                            }
                            else
                            {
                                UserCrud.DeleteUserFromIndex(index);
                            }
                            break;
                        case "5":
                            goto logout;
                        default:
                            // Handle other cases
                            break;
                    }
                }
            }
            Console.Read(); // for program to display output
        }
    }
}