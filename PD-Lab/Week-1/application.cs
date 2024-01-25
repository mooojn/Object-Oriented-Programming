using System;
using System.Threading;
using System.IO; // for file handling

namespace business
{
    class Program
    {
        // global vars
        public static string file_path = "D:\\c# files\\business\\data.txt";   // path where data stored
        static void Main(string[] args)
        {
            const int size = 100; // size of array
            // data structs
            string[] user_names = new string[size];
            string[] user_passwords = new string[size];
            int[] cash_holdings = new int[size];
            // vars for handling array
            int user_count = 0;
            load_data(user_names , user_passwords, cash_holdings, ref user_count);

            int current_user_index = 0;  // index of the logged-in user

            bool transactions_blocked = false; // for blocking transactions 

        logout: // for logging out
            bool allow_login = false;
            // main body
            while (true)
            {
                Console.Clear(); // to clear the screen
                string choice = menu();

                if (choice == "1")
                {
                    // func checks if we need to allow to login
                    allow_login = sign_in(user_names, user_passwords, user_count, ref current_user_index);
                    if (allow_login)
                        break;
                }
                else if (choice == "2")
                {
                    // validates if user does'nt exist it creates one
                    sign_up(user_names, user_passwords, ref user_count);
                }
                else if (choice == "3")
                {
                    store_data(user_names, user_passwords, cash_holdings, user_count);  
                    return; // exit from program
                }
                else
                    invalid_choice();
            }
            if (allow_login)
            {
                string user_choice = "";
                while (true)
                {
                    Console.Clear();

                    user_choice = user_menu();
                    if (user_choice == "1")
                    {
                        // displays the cash holdings of current-user
                        check_portfolio(cash_holdings, current_user_index);
                    }
                    else if (user_choice == "2")
                    {
                        Console.Clear();
                        // used to deposit cash
                        if (!transactions_blocked)  // not blocked calling the func
                            deposit_cash(cash_holdings, current_user_index);
                        else
                            error("Transactions are Blocked");
                    }
                    else if (user_choice == "3")
                    {
                        Console.Clear();
                        // used to withdraw cash
                        if (!transactions_blocked)  // not blocked calling the func
                            withdraw_cash(cash_holdings, current_user_index);
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
                        delete_account(user_names, user_passwords, cash_holdings, current_user_index, ref user_count);
                        goto logout;
                    }
                    else if (user_choice == "6")
                        goto logout; // logging out
                }
            }
            Console.Read(); // for program to display output
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
        static void check_portfolio(int[] cash_holdings, int current_user_index)
        {
            Console.Clear();
            Console.Write($"Your total cash holdings holding: ${cash_holdings[current_user_index]}");
            press_any_key();
        }
        static void deposit_cash(int[] cash_holdings, int current_user_index)
        {
            Console.Clear();
            // input
            Console.Write("Enter amount you want to deposit: $");
            int deposit_amount = int.Parse(Console.ReadLine());

            process();
            // error case
            if (deposit_amount < 0)
            {
                error("Invalid amount");
                return;  // error encountered so returning
            }
            // adding cash to the user's acc if no error encountered
            cash_holdings[current_user_index] += deposit_amount;
            success("Cash Deposit was successful...");
        }
        static void withdraw_cash(int[] cash_holdings, int current_user_index)
        {
            Console.Write("Enter the amount you want to withdraw: $");
            int withdraw_amount = int.Parse(Console.ReadLine());
            
            process();
            if (withdraw_amount < 0 || withdraw_amount > cash_holdings[current_user_index])
            {
                error("Invalid Amount");
                return;  // error encountered so returning
            }
            // removing cash to the user's acc if no error encountered
            cash_holdings[current_user_index] -= withdraw_amount;
            success("Cash withdrawal was successful.");
        }
        static bool block_transactions(bool transactions_blocked)
        {
            process();
            string status = transactions_blocked? "Un" : "";  // ternary operator to check if we need to add Un or not
            success($"Your transactions have been successfully {status}blocked");
            return !transactions_blocked;  // reversing the value   :}
        }
        static void delete_account(string[] user_names, string[] user_passwords, int[] cash_holdings, int current_user_index, ref int user_count)
        {
            Console.Clear();
            process();
            // shifting all the elements by one to right
            for (int i = current_user_index; i < user_count; ++i)
            {
                // moving elements
                user_names[i] = user_names[i + 1];
                user_passwords[i] = user_passwords[i + 1];
                cash_holdings[i] = cash_holdings[i + 1];
            }
            user_count--; // decrementing as we have deleted the user
            success("Your account has been removed...");
        }
        static bool sign_in(string[] user_names, string[] user_passwords, int user_count, ref int current_user_index)
        {
            Console.Clear();
            // getting input
            Console.Write("Enter your name: ");
            string name = Console.ReadLine();
            Console.Write("Set password: ");
            string pass = Console.ReadLine();

            // validating
            process();
            if (!unique_user(user_names, user_count, name) && pass_validated(user_names, user_passwords, user_count, name, pass, ref current_user_index))
            {
                Console.WriteLine("You are signed in...");
                press_any_key();
                return true;
            }
            else
                error("Incorrect Password");
            return false;
        }
        static bool pass_validated(string[] user_names, string[] user_passwords, int user_count, string name, string pass, ref int current_user_index)
        {
            for (int i = 0; i < user_count; ++i)
                if (user_names[i] == name && user_passwords[i] == pass)
                {
                    current_user_index = i;
                    return true;
                }
            return false;
        }
        static void sign_up(string[] user_names, string[] user_passwords, ref int user_count)
        {
            Console.Clear();
            // getting input
            Console.Write("Enter your name: ");
            string name = Console.ReadLine();
            Console.Write("Set password: ");
            string pass = Console.ReadLine();

            // validating
            if (unique_user(user_names, user_count, name)) // checking if user is unique
            {
                user_names[user_count] = name;
                user_passwords[user_count] = pass;
                user_count++; // user added
                success("You have successfully signed up");
            }
            else
                error("User already exists.");
        }
        static bool unique_user(string[] user_names, int user_count, string name)
        {
            for (int i = 0; i < user_count; ++i)
                if (user_names[i] == name)
                    return false;
            return true;
        }
        static string menu()
        {
            Console.WriteLine("1. Sign In...");
            Console.WriteLine("2. Sign Up...");
            Console.WriteLine("3. Exit......");

            Console.Write("Enter your choice: ");
            return Console.ReadLine();
        }
        static void store_data(string[] user_names, string[] user_passwords, int[] cash_holdings, int user_count)
        {
            StreamWriter file = new StreamWriter(file_path);   // obj of file

            // storing relevant information
            file.WriteLine("Name,Password,Cash");
            for (int i = 0; i < user_count; ++i)
            {
                file.Write($"{user_names[i]},{user_passwords[i]},{cash_holdings[i]}");
                if (i < user_count - 1)
                    file.Write("\n");  // for last iteration no space
            }
            file.Close();
        }
        static void load_data(string[] user_names, string[] user_passwords, int[] cash_holdings, ref int user_count)
        {
            // file object
            StreamReader file = new StreamReader(file_path);
            
            file.ReadLine();  // skipping header

            string line = "";
            while ((line = file.ReadLine()) != null)  // until reaching end of file
            {
                string[] parts = line.Split(',');   // creating an array of all the elements
                // loading data
                user_names[user_count] = parts[0];
                user_passwords[user_count] = parts[1];
                cash_holdings[user_count] = int.Parse(parts[2]);
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