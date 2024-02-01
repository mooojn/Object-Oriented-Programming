using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chlg2_b
{
    internal class Products
    {
        public int Id;
        public string Name;
        public double Price;
        public string Category;
        public string BrandName;
        public string Country;
        public int Quantity;

        public Products(int id, string name, double price, string category, string brandName, string country, int quantity)
        {
            Id = id;
            Name = name;
            Price = price;
            Category = category;
            BrandName = brandName;
            Country = country;
            Quantity = quantity;
        }
        public void displayProducts()
        {
            Console.WriteLine($"{Id}\t{Name}\t{Price}\t{Category}\t\t{BrandName}\t\t{Country}\t{Quantity}");
        }
        public double totalWorth()
        {
            double total = 0;
            return total += Price * Quantity;
        }
    }
}
