using System;
using System.Threading;
using System.IO;
using System.ComponentModel.Design;
using System.CodeDom; // for file handling

namespace chlg3
{
    class Program
    {
        // global vars
        public static string file_path = "D:\\c# files\\busComplete\\data.txt";   // path where data stored
        static void Main(string[] args)
        {
            const int size = 100; // size of array
            // user data struct
            userData[] user_data = new userData[size];
            // vars for handling array
            int user_count = 0;
            load_data(user_data, ref user_count);
            // admin password
            string admin_pass = "admin";
            int current_user_index = 0;  // index of the logged-in user

            bool transactions_blocked = false; // for blocking transactions 

        logout: // for logging out
            bool allow_login_user = false;
            bool allow_login_admin = false;
            // main body
            while (true)
            {
                Console.Clear(); // to clear the screen
                string choice = menu();
                if (choice == "1")
                {
                    allow_login_admin = sign_in_admin(admin_pass);
                    if (allow_login_admin)
                        break;
                }
                else if (choice == "2")
                {
                    // func checks if we need to allow to login
                    allow_login_user = sign_in(user_data, user_count, ref current_user_index);
                    if (allow_login_user)
                        break;
                }
                else if (choice == "3")
                {
                    // validates if user does'nt exist it creates one
                    sign_up(user_data, ref user_count);
                }
                else if (choice == "4")
                {
                    store_data(user_data, user_count);
                    return; // exit from program
                }
                else
                    invalid_choice();
            }
            if (allow_login_user)
            {
                string user_choice = "";
                while (true)
                {
                    Console.Clear();

                    user_choice = user_menu();
                    if (user_choice == "1")
                    {
                        // displays the cash holdings of current-user
                        Console.Clear();
                        user_data[current_user_index].showCash();
                        press_any_key();
                    }
                    else if (user_choice == "2")
                    {
                        // used to deposit cash
                        if (!transactions_blocked)  // not blocked calling the func 
                        {
                            Console.Clear();
                            // input
                            Console.Write("Enter amount you want to deposit: $");
                            int deposit_amount = int.Parse(Console.ReadLine());

                            // validation
                            bool deposit_status = deposit_cash_validation(deposit_amount, user_data[current_user_index].cash_holdings);
                            if (deposit_status)
                                user_data[current_user_index].addCash(deposit_amount);
                        }
                        else
                            error("Transactions are Blocked");
                    }
                    else if (user_choice == "3")
                    {
                        if (!transactions_blocked)    // not blocked calling the func
                        {
                            Console.Clear();
                            // input
                            Console.Write("Enter the amount you want to withdraw: $");
                            int withdraw_amount = int.Parse(Console.ReadLine());

                            // used to withdraw cash
                            bool withdraw_status = withdraw_cash_validation(withdraw_amount, user_data[current_user_index].cash_holdings);
                            if (withdraw_status)
                                user_data[current_user_index].withdrawCash(withdraw_amount);
                        }
                        else
                            error("Transactions are Blocked");
                    }
                    else if (user_choice == "4")
                    {
                        Console.Clear();
                        // func checks if we need to block or unblock
                        transactions_blocked = block_transactions(transactions_blocked);
                    }
                    else if (user_choice == "5")
                    {
                        // permenantly deletes the user from array
                        delete_account(user_data, current_user_index, ref user_count);
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
                    admin_choice = admin_menu();
                    if (admin_choice == "1")
                    {
                        sign_up(user_data, ref user_count);
                    }
                    else if (admin_choice == "2")
                    {
                        Console.Clear();
                        view_users(user_data, user_count);
                        press_any_key();
                    }
                    else if (admin_choice == "3")
                    {
                        Console.Clear();
                        view_users(user_data, user_count);
                        // getting the index to change
                        Console.Write("Enter the index you want to change: ");
                        int index = int.Parse(Console.ReadLine());
                        // getting the new name
                        Console.Write("Enter the new name: ");
                        // changing the name
                        user_data[index].user_names = Console.ReadLine();
                        success("Changed successfully...");
                    }
                    else if (admin_choice == "4")
                    {
                        Console.Clear();
                        view_users(user_data, user_count);
                        // getting the index to remove
                        Console.Write("Enter the index you want to remove: ");
                        int index = int.Parse(Console.ReadLine());
                        // removing the user from that index
                        remove_user_from_index(user_data, ref user_count, index);
                        success("Removed successfully...");
                    }
                    else if (admin_choice == "5")
                    {
                        goto logout;
                    }
                }
            }
            Console.Read(); // for program to display output
        }
        static bool sign_in_admin(string admin_pass)
        {
            Console.Clear();
            Console.Write("Enter admin password: ");
            string pass = Console.ReadLine();

            if (pass == admin_pass)
            {
                success("You are signed in as admin...");
                return true;
            }
            error("Incorrect Password");
            return false;
        }
        static void view_users(userData[] data, int count)
        {
            Console.WriteLine("Index\tName\tCash");
            for (int i = 0; i < count; ++i)
            {
                Console.WriteLine($"{i}\t{data[i].user_names}\t{data[i].cash_holdings}");
            }
        }
        static void remove_user_from_index(userData[] data, ref int count, int index_to_remove)
        {
            for (int i = index_to_remove; i < count - 1; ++i)
            {
                // shifting elements
                //Console.WriteLine($"{data[i].user_names} {data[i].user_passwords}");
                data[i].user_names = data[i + 1].user_names;
                data[i].user_passwords = data[i + 1].user_passwords;
                data[i].cash_holdings = data[i + 1].cash_holdings;
            }
            count--; // decrementing as we have removed a user
        }
        static string admin_menu()
        {
            // menu
            Console.WriteLine("1. Add New User");
            Console.WriteLine("2. View Users");
            Console.WriteLine("3. Change User Name");
            Console.WriteLine("4. Delete User");
            Console.WriteLine("5. Logout");

            // getting input
            Console.Write("Enter your choice: ");
            return Console.ReadLine();
        }
        static string user_menu()
        {
            // menu
            Console.WriteLine("1. Check Portfolio");
            Console.WriteLine("2. Deposit Cash");
            Console.WriteLine("3. Withdraw Cash");
            Console.WriteLine("4. Block Transactions");
            Console.WriteLine("5. Delete Account");

            Console.WriteLine("6. Logout");

            // getting input
            Console.Write("Enter your choice: ");
            return Console.ReadLine();
        }
        static bool deposit_cash_validation(int deposit_amount, int cash_holdings)
        {
            process();
            // error case
            if (deposit_amount < 0)
            {
                error("Invalid amount");
                return false;  // error encountered so returning
            }
            // adding cash to the user's acc if no error encountered
            success("Cash Deposit was successful...");
            return true;
        }
        static bool withdraw_cash_validation(int withdraw_amount, int cash_holdings)
        {
            process();
            if (withdraw_amount < 0 || withdraw_amount > cash_holdings)
            {
                error("Invalid Amount");
                return false;  // error encountered so returning
            }
            // removing cash to the user's acc if no error encountered
            success("Cash withdrawal was successful.");
            return true;
        }
        static bool block_transactions(bool transactions_blocked)
        {
            process();
            string status = transactions_blocked ? "Un" : "";  // ternary operator to check if we need to add Un or not
            success($"Your transactions have been successfully {status}blocked");
            return !transactions_blocked;  // reversing the value   :}
        }
        static void delete_account(userData[] data, int current_user_index, ref int user_count)
        {
            Console.Clear();
            process();
            // shifting all the elements by one to right
            for (int i = current_user_index; i < user_count-1; ++i)
            {
                // moving elements
                data[i].user_names = data[i + 1].user_names;
                data[i].user_passwords = data[i + 1].user_passwords;
                data[i].cash_holdings = data[i + 1].cash_holdings;
            }
            user_count--; // decrementing as we have deleted the user
            success("Your account has been removed...");
        }
        static bool sign_in(userData[] user_data, int user_count, ref int current_user_index)
        {
            Console.Clear();
            // getting input
            Console.Write("Enter your name: ");
            string name = Console.ReadLine();
            Console.Write("Set password: ");
            string pass = Console.ReadLine();

            // validating
            process();
            if (!unique_user(user_data, user_count, name) && pass_validated(user_data, user_count, name, pass, ref current_user_index))
            {
                Console.WriteLine("You are signed in...");
                press_any_key();
                return true;
            }
            else
                error("Incorrect Password");
            return false;
        }
        static bool pass_validated(userData[] data, int user_count, string name, string pass, ref int current_user_index)
        {
            for (int i = 0; i < user_count; ++i)
                if (data[i].user_names == name && data[i].user_passwords == pass)
                {
                    current_user_index = i;
                    return true;
                }
            return false;
        }
        static void sign_up(userData[] user_data, ref int user_count)
        {
            Console.Clear();
            // getting input
            Console.Write("Enter your name: ");
            string name = Console.ReadLine();
            Console.Write("Set password: ");
            string pass = Console.ReadLine();

            // validating
            if (unique_user(user_data, user_count, name)) // checking if user is unique
            {
                success("You have successfully signed up");
                user_data[user_count] = new userData(name, pass);
                user_count++; // incrementing as we have added a user
            }
            else
                error("User already exists.");
        }
        static bool unique_user(userData[] data, int user_count, string name)
        {
            for (int i = 0; i < user_count; ++i)
                if (data[i].user_names == name)
                    return false;
            return true;
        }
        static string menu()
        {
            Console.WriteLine("1. Sign In As Admin...");
            Console.WriteLine("2. Sign In As User...");
            Console.WriteLine("3. Sign Up...");
            Console.WriteLine("4. Exit......");

            Console.Write("Enter your choice: ");
            return Console.ReadLine();
        }
        static void store_data(userData[] data, int user_count)
        {
            StreamWriter file = new StreamWriter(file_path);   // obj of file

            // storing relevant information
            file.WriteLine("Name,Password,Cash");
            for (int i = 0; i < user_count; ++i)
            {
                file.Write($"{data[i].user_names},{data[i].user_passwords},{data[i].cash_holdings}");
                if (i < user_count - 1)
                    file.Write("\n");  // for last iteration no space
            }
            file.Close();
        }
        static void load_data(userData[] data, ref int user_count)
        {
            // file object
            StreamReader file = null;
            try
            {
                file = new StreamReader(file_path);
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
                userData obs = new userData(name, pass);   // creating an obj
                obs.cash_holdings = cash;  // setting cash holdings

                data[user_count] = obs;  // adding obj to array
                user_count++;
            }
            file.Close();
        }
        // functions 
        static void press_any_key()
        {
            Console.Write("\nPress any key to continue...");
            Console.ReadKey();
        }
        static void error(string type)
        {
            Console.WriteLine(type);
            press_any_key();
        }
        static void success(string msg)
        {
            Console.WriteLine(msg);
            press_any_key();
        }
        static void invalid_choice()
        {
            Console.WriteLine("Invalid Choice...");
            Thread.Sleep(500);
        }
        static void process()
        {
            Console.WriteLine("Processing please wait...");
            Thread.Sleep(800);
        }
    }
}