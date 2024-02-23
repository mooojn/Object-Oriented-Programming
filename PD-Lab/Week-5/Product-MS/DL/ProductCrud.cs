using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace chlng1_new_pf
{
    internal class ProductCrud
    {
        public static List<Product> Products = new List<Product>();
        public static void AddProduct(Product Prod)
        {
            Products.Add(Prod);
        }
        public static void ViewProducts()
        {
            ProductUi.HeaderForProduct();

            foreach (Product Prod in Products)
            {
                Console.WriteLine(Prod.GetInfo());
            }
        }
        public static string FindProductWithHighPrice()
        {
            List<Product> SortedProduct = Products.OrderByDescending(p => p.Price).ToList();
            return SortedProduct[0].GetInfo();  // as highest price product is at 0 index we return its info
        }
        public static int ViewSalesTax()
        {
            int totalSalesTax = 0;
            foreach(Product P in Products)
            {
                totalSalesTax += P.SalesTax();        // adding sales tax of each product
            }
            return totalSalesTax;
        }
        public static string ViewProductsToBeReordered()
        {
            string productsToBeReordered = "";
            foreach (Product P in Products)
            {
                if (P.IsReorderNeeded())
                {
                    productsToBeReordered += P.GetInfo();  // adding info of products which needs to be reordered
                    productsToBeReordered += "\n";         // adding new line
                }
            }
            return productsToBeReordered;
        }
        public static int FindProductByName(string name)
        {
            int i = 0;
            foreach (Product P in Products)
            {
                if (P.Name == name)
                {
                    return i;
                }
                i++;
            }
            return -1;    // if product not found
        }
    }
}
