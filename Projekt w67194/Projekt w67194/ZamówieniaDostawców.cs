using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_w67194
{
    internal class ZamówieniaDostawców
    {
        public int OrderId { get; set; }
        public int DostawcaId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }

        public ZamówieniaDostawców(int orderId, int dostawcaId, int productId, int quantity, DateTime orderDate, string status)
        {
            OrderId = orderId;
            DostawcaId = dostawcaId;
            ProductId = productId;
            Quantity = quantity;
            OrderDate = orderDate;
            Status = status;
        }

        public static List<ZamówieniaDostawców> zamówieniaDostawców = new List<ZamówieniaDostawców>();

        public static void ListaZamówieńDostawców()
        {
            foreach (var zamówienieDostawcy in zamówieniaDostawców)
            {
                Console.WriteLine($"{zamówienieDostawcy.OrderId}, {zamówienieDostawcy.DostawcaId}, {zamówienieDostawcy.ProductId}, {zamówienieDostawcy.Quantity}, {zamówienieDostawcy.OrderDate}, {zamówienieDostawcy.Status}");
            }
        }

        public static void BazaZamówieńDostawców()
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\mathe\OneDrive\Pulpit\Programowanie obiektowe\Projekt w67194\Projekt w67194\SupplierOrders.txt");
            foreach (var line in lines)
            {
                string[] parts = line.Split(',');
                if (parts.Length == 6)
                {
                    int orderId = int.Parse(parts[0]);
                    int dostawcaId = int.Parse(parts[1]);
                    int productId = int.Parse(parts[2]);
                    int quantity = int.Parse(parts[3]);
                    DateTime orderDate = DateTime.Parse(parts[4]);
                    string status = parts[5];
                    ZamówieniaDostawców zamówienieDostawcy = new ZamówieniaDostawców(orderId, dostawcaId, productId, quantity, orderDate, status);
                    zamówieniaDostawców.Add(zamówienieDostawcy);

                }
            }

        }

        public static void DodajZamówienieDostawcy()
        {
            Console.WriteLine("Podaj id zamówienia: ");
            int orderId = int.Parse(Console.ReadLine());
            Console.WriteLine("Podaj id dostawcy: ");
            int dostawcaId = int.Parse(Console.ReadLine());
            Console.WriteLine("Podaj id produktu: ");
            int productId = int.Parse(Console.ReadLine());
            Console.WriteLine("Podaj ilość: ");
            int quantity = int.Parse(Console.ReadLine());
            DateTime orderDate = DateTime.Now;
            string status = "W trakcie realizacji";
            ZamówieniaDostawców zamówienieDostawcy = new ZamówieniaDostawców(orderId, dostawcaId, productId, quantity, orderDate, status);
            zamówieniaDostawców.Add(zamówienieDostawcy);
            Console.WriteLine("Dodano zamówienie");
            string path = @"C:\Users\mathe\OneDrive\Pulpit\Programowanie obiektowe\Projekt w67194\Projekt w67194\SupplierOrders.txt";
            string appendText = orderId + "," + dostawcaId + "," + productId + "," + quantity + "," + orderDate + "," + status + Environment.NewLine;
            File.AppendAllText(path, appendText);
        }
    }
}
