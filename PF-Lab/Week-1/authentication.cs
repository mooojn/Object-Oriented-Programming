using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            const int size = 100; // size of array
            // data structs
            string[] user_names = new string[size];
            string[] user_passwords = new string[size];
            int user_count = 0;
            
            // main body
            while (true)
            {
                Console.Clear(); // to clear the screen
                string choice = menu();
                
                if (choice == "1")
                {
                    sign_in(user_names, user_passwords, user_count);
                }
                else if (choice == "2") 
                {
                    sign_up(user_names, user_passwords, ref user_count);
                }
                else if (choice == "3")
                    return; // exit from program
                else
                    Console.WriteLine("Invalid Choice...");
            }
            Console.Read(); // for program to display output
        }
        static void sign_in(string[] user_names, string[] user_passwords, int user_count)
        {
            Console.Write("Enter your name: ");
            string name = Console.ReadLine();

            Console.Write("Set password: ");
            string pass = Console.ReadLine();

            if (!unique_user(user_names, user_count, name) && pass_validated(user_names, user_passwords, user_count, name, pass))
            {
                Console.WriteLine("You are signed in...");
                press_any_key();
            }
            else
                error("Incorrect Password");
        }
        static bool pass_validated(string[] user_names, string[] user_passwords, int user_count, string name, string pass)
        {
            for (int i = 0; i < user_count; ++i)
                if (user_names[i] == name && user_passwords[i] == pass)
                    return true;
            return false;
        }
        static void sign_up(string[] user_names, string[] user_passwords, ref int user_count)
        {
            Console.Write("Enter your name: ");
            string name = Console.ReadLine();

            Console.Write("Set password: ");
            string pass = Console.ReadLine();

            if (unique_user(user_names, user_count, name)) // checking if user is unique
            {
                user_names[user_count] = name;
                user_passwords[user_count] = pass;
                user_count++; // user added
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
        static void press_any_key()
        {
            Console.Write("Press any key to continue...");
            Console.Read();
        }
        static void error(string type)
        {
            Console.WriteLine(type);
            press_any_key();
        }
    }
}