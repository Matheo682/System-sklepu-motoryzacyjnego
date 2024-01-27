using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_w67194
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }

        
        public Product(int productId, string name, decimal price, string description)
        {
            ProductId = productId;
            Name = name;
            Price = price;
            Description = description;
        }

        public static List<Product> products = new List<Product>();
        public static void BazaProduktów()
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\mathe\OneDrive\Pulpit\Programowanie obiektowe\Projekt w67194\Projekt w67194\Products.txt");
            foreach (var line in lines)
            {
                string[] parts = line.Split(',');
                if (parts.Length == 4)
                {
                    int productId = int.Parse(parts[0]);
                    string name = parts[1];
                    decimal price = decimal.Parse(parts[2]);
                    string description = parts[3];
                    Product product = new Product(productId, name, price, description);
                    products.Add(product);
                }
            }
            //Console.WriteLine("Załadowano bazę produktów");
        }

        public static void DodajProdukt()
        {
            Console.WriteLine("Podaj id produktu: ");
            int productId = int.Parse(Console.ReadLine());
            Console.WriteLine("Podaj nazwę produktu: ");
            string name = Console.ReadLine();
            Console.WriteLine("Podaj cenę produktu: ");
            decimal price = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Podaj opis produktu: ");
            string description = Console.ReadLine();
            Product product = new Product(productId, name, price, description);
            products.Add(product);
            Console.WriteLine("Dodano produkt");
            string path = @"C:\Users\mathe\OneDrive\Pulpit\Programowanie obiektowe\Projekt w67194\Projekt w67194\Products.txt";
            string appendText = productId + "," + name + "," + price + "," + description + Environment.NewLine;
            File.AppendAllText(path, appendText);
        }

        public static void UsuńProdukt()
        {
            Console.WriteLine("Podaj id produktu do usunięcia: ");
            int productId = int.Parse(Console.ReadLine());
            Product product = products.FirstOrDefault(p => p.ProductId == productId - 1);
            products.Remove(product);
            Console.WriteLine("Usunięto produkt");
            string path = @"C:\Users\mathe\OneDrive\Pulpit\Programowanie obiektowe\Projekt w67194\Projekt w67194\Products.txt";
            string text = File.ReadAllText(path);
            text = text.Replace(productId + "," + product.Name + "," + product.Price + "," + product.Description + Environment.NewLine, "");
            File.WriteAllText(path, text);
        }
        public static void listaProduktów()
        {
            foreach (var product in products)
            {
                Console.WriteLine($"{product.ProductId}, {product.Name}, {product.Price}, {product.Description}");
            }
        }
    }
}
