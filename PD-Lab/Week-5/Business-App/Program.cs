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
            UserCrud.LoadUsersFromFile();
            
            // admin password
            string admin_pass = "admin";

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
                if (choice == "1")
                {
                    string pass = UserUi.GetPass();

                    allow_login_admin = AdminCrud.Validate(pass, admin_pass);
                    
                    if (allow_login_admin)
                        break;
                }
                else if (choice == "2")
                {
                    // func checks if we need to allow to login
                    // getting input
                    string name = UserUi.GetName();
                    string pass = UserUi.GetPass();

                    allow_login_user = UserCrud.SignIn(name, pass);
                    
                    if (allow_login_user)
                        break;
                }
                else if (choice == "3")
                {
                    // getting input
                    string name = UserUi.GetName();
                    string pass = UserUi.GetPass();

                    // validating
                    UserCrud.SignUp(name, pass);
                }
                else if (choice == "4")
                {
                    UserCrud.StoreUsersDataToFile();
                    return; // exit from program
                }
                else
                    UtilUi.InvalidChoice();
            }
            if (allow_login_user)
            {
                string user_choice = "";
                while (true)
                {
                    Console.Clear();

                    user_choice = MainUi.user_menu();

                    Console.Clear();
                    User CurrentUser = UserCrud.Users[current_user_index];
                    if (user_choice == "1")
                    {
                        // displays the cash holdings of current-user
                        
                        CurrentUser.ShowCash();
                        UtilUi.PressAnyKey();
                    }
                    else if (user_choice == "2")
                    {
                        // used to deposit cash
                        if (!transactions_blocked)  // not blocked calling the func 
                        {
                            // input
                            int deposit_amount = UserUi.GetDepositAmount();
                            // validation
                            bool deposit_status = CurrentUser.AddCash(deposit_amount);

                            UtilUi.ShowMSG(deposit_status);
                        }
                        else
                            UtilUi.Error("Transactions are Blocked");
                    }
                    else if (user_choice == "3")
                    {
                        if (!transactions_blocked)    // not blocked calling the func
                        {
                            // input
                            int withdraw_amount = UserUi.GetWithdrawAmount();

                            // used to withdraw cash
                            bool withdraw_status = CurrentUser.WithdrawCash(withdraw_amount);

                            UtilUi.ShowMSG(withdraw_status);
                        }
                        else
                            UtilUi.Error("Transactions are Blocked");
                    }
                    else if (user_choice == "4")
                    {
                        // func checks if we need to block or unblock
                        transactions_blocked = UtilCrud.BlockTransactions(transactions_blocked);
                    }
                    else if (user_choice == "5")
                    {
                        // permenantly deletes the user from array
                        UserCrud.DeleteUserFromIndex(current_user_index);
                        goto logout;
                    }
                    else if (user_choice == "6")
                        goto logout; // logging out
                }
            }
            else if (allow_login_admin)
            {
                string admin_choice = "";
                while (true)
                {
                    Console.Clear();
                    admin_choice = MainUi.admin_menu();

                    Console.Clear();
                    if (admin_choice == "1")
                    {
                        string name = UserUi.GetName();
                        string pass = UserUi.GetPass();

                        UserCrud.SignUp(name, pass);
                    }
                    else if (admin_choice == "2")
                    {
                        UserCrud.ViewAllUsers();
                        UtilUi.PressAnyKey();
                    }
                    else if (admin_choice == "3")
                    {
                        UserCrud.ViewAllUsers();
                        // getting the index to change
                        int index = AdminUi.GetIndex();
                        // getting the new name
                        string name = UserUi.GetName();
                        // changing the name
                        UserCrud.Users[index].user_names = name;

                        UtilUi.Success("Changed successfully...");
                    }
                    else if (admin_choice == "4")
                    {
                        UserCrud.ViewAllUsers();
                        // getting the index to remove
                        int index = AdminUi.GetIndex();
                        // removing the user from that index
                        UserCrud.DeleteUserFromIndex(index);
                        
                        UtilUi.Success("Removed successfully...");
                    }
                    else if (admin_choice == "5")
                    {
                        goto logout;
                    }
                }
            }
            Console.Read(); // for program to display output
        }
    }
}