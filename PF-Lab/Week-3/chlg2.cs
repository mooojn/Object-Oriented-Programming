using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace chlg2_b
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int size = 5;
            // structs
            Products[] products = new Products[size];
            int count = 0; // number of products added              
            // program loop
            while (true)
            {
                Console.Clear();
                string option = menu();
                if (option == "1")
                {
                    Console.Clear();
                    products[count] = input();
                    count++;
                }
                else if (option == "2")
                {
                    Console.Clear();
                    display(products, count);
                }
                else if (option == "3")
                {
                    Console.Clear();
                    totalWor(products, count);
                }
                else if (option == "4")
                {
                    Console.Clear();
                    return;
                }
            }
        }
        static void totalWor(Products[] prods, int count)
        {
            double total = 0;
            for (int i = 0; i < count; ++i)
            {
                total += prods[i].totalWorth();
            }
            Console.WriteLine($"Total Worth: {total}");
            pressAnyKey();
        }
        static void display(Products[] prods, int count)
        {
            // headers
            Console.WriteLine("ID\tName\tPrice\tCategory\tBrand Name\tCountry\tQuantity");
            for (int i = 0; i < count; ++i)
            {
                // print simple \t sep
                prods[i].displayProducts();
            }
            pressAnyKey();
        }
        static Products input()
        {

            Console.Write("Enter Product ID: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Product Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Product Price: ");
            double price = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter Product Category: ");
            string ctegory = Console.ReadLine();

            Console.Write("Enter Product Brand Name: ");
            string brandName = Console.ReadLine();

            Console.Write("Enter Product Country: ");
            string country = Console.ReadLine();

            Console.Write("Enter Product Quantity: ");
            int quantity = Convert.ToInt32(Console.ReadLine());
            return new Products(id, name, price, ctegory, brandName, country, quantity);
        }
        static string menu()
        {
            Console.WriteLine("1. Add Products");
            Console.WriteLine("1. Show Products");
            Console.WriteLine("3. Total Store Worth");
            Console.WriteLine("4. End");

            Console.Write("Enter your choice: ");
            return Console.ReadLine();
        }
        static void pressAnyKey()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
