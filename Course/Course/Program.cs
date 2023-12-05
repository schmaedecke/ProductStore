using System;
using System.Globalization;
using System.Collections.Generic;
using Course.Entities;

namespace Course // Note: actual namespace depends on the project name.
{
    internal class Program {
        static void Main(string[] args) {

            List<Product> list = new List<Product>();
            Console.Write("Enter the number of products: ");
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Product #{i+1} data: ");
                Console.Write("Common, used or imported (c/u/i): ");
                char ch = char.Parse(Console.ReadLine());
                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Price: ");
                double price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                if (ch == 'i')
                {
                    Console.Write("Customs fee: ");
                    double customsFee = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    list.Add(new ImportedProduct(name, price, customsFee));
                }else if (ch == 'u') {
                    Console.Write("Manufacture date (DD/MM/YYYY): ");
                    DateTime manufatureDate = DateTime.Parse(Console.ReadLine());
                    list.Add(new UsedProduct(name, price, manufatureDate));
                }else if (ch == 'c') {
                    list.Add(new Product(name, price));
                }
            }
            Console.WriteLine();
            Console.WriteLine("PRICE TAGS");
            foreach(Product product in list) {
                Console.WriteLine(product.PriceTag());
            }
        }
    }
}