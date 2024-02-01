using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chlg2
{
    internal class Products
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Category { get; set; }
        public string BrandName { get; set; }
        public string Country { get; set; }
        public int Quantity { get; set; }

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
    }
}
