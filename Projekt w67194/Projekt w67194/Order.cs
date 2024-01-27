using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_w67194
{
    public class Order : Product
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }

        public Order(int orderId, int customerId, int productId1, string name, decimal price, string description) : base(productId1, name, price, description)
        {
            OrderId = orderId;
            CustomerId = customerId;
        }
        public static List<Order> orders = new List<Order>();

        public static void BazaZamówień()
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\mathe\OneDrive\Pulpit\Programowanie obiektowe\Projekt w67194\Projekt w67194\Orders.txt");
            foreach (var line in lines)
            {
                string[] parts = line.Split(',');
                if (parts.Length == 6)
                {
                    int orderId = int.Parse(parts[0]);
                    int customerId = int.Parse(parts[1]);
                    int productId1 = int.Parse(parts[2]);
                    string name = parts[3];
                    decimal price = decimal.Parse(parts[4]);
                    string description = parts[5];
                    Order order = new Order(orderId, customerId, productId1, name, price, description);
                    orders.Add(order);
                }
            }
            //Console.WriteLine("Załadowano bazę zamówień");

        }

        public static void ListaZamówień()
        {
            foreach (var order in orders)
            {
                Console.WriteLine($"{order.OrderId}, {order.CustomerId}, {order.ProductId}, {order.Name}, {order.Price}, {order.Description}");
            }
        }

        public static void DodajZamówienie()
        {
            Console.WriteLine("Podaj id klienta: ");
            int customerId = int.Parse(Console.ReadLine());
            Console.WriteLine("Podaj id produktu: ");
            int productId1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Podaj nazwę produktu: ");
            string name = Console.ReadLine();
            Console.WriteLine("Podaj cenę produktu: ");
            decimal price = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Podaj opis produktu: ");
            string description = Console.ReadLine();
            Order order = new Order(Order.orders.Count + 1, customerId, productId1, name, price, description);
            orders.Add(order);
            string path = @"C:\Users\mathe\OneDrive\Pulpit\Programowanie obiektowe\Projekt w67194\Projekt w67194\Orders.txt";
            string DaneDoZapisu = $"{order.OrderId},{order.CustomerId},{order.ProductId},{order.Name},{order.Price},{order.Description}";
            string appendText = DaneDoZapisu + Environment.NewLine;
            File.AppendAllText(path, appendText);
            Console.WriteLine("Dodano zamówienie");
        }

        
    }

}
