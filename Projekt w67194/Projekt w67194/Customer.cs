using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Projekt_w67194
{
    public class Customer : Person
    {
        public string Password { get; set; }

        public Customer(int id, string name, string email, string password)
            : base(id, name, email)
        {
            Password = password;
        }

        public static List<Customer> customers = new List<Customer>();


        static public void ListaKlientów()
        {
            
            foreach (var customer in customers)
            {
                
                Console.WriteLine($"{customer.Id}, {customer.Name}, {customer.Email}, {customer.Password}");
            }
        }
        public static void BazaKlientów()
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\mathe\OneDrive\Pulpit\Programowanie obiektowe\Projekt w67194\Projekt w67194\Customers.txt");
            foreach (var line in lines)
            {
                string[] parts = line.Split(',');
                if (parts.Length == 4)
                {
                    int id = int.Parse(parts[0]);
                    string name = parts[1];
                    string email = parts[2];
                    string password = parts[3];
                    Customer customer = new Customer(id, name, email, password);
                    customers.Add(customer);
                }
            }
        }

        static public void Logowanie()
        {
            Console.WriteLine("Podaj e-mail: ");
            string login = Console.ReadLine();
            Console.WriteLine("Podaj hasło: ");
            string hasło = Console.ReadLine();

            Customer authenticatedCustomer = Authentication.AuthenticateCustomer(login, hasło, customers);
            if (authenticatedCustomer != null)
            {
                Console.Clear();
                Console.WriteLine($"Zalogowano użytkownika: {authenticatedCustomer.Name}");

                MenuKlienta();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Błąd logowania użytkownika");

                Program.Menu();
            }
        }

      

        static public void AddCustomer(Customer nowy)
        {
            customers.Add(nowy);
            Console.WriteLine("Zarejestrowano użytkownika: " + nowy.Name);
        }

        static public void rejestracja()
        {
            Console.WriteLine("Podaj imię: ");
            string imie = Console.ReadLine();
            Console.WriteLine("Podaj nazwisko: ");
            string nazwisko = Console.ReadLine();
            Console.WriteLine("Podaj e-mail: ");
            string email = Console.ReadLine();
            Console.WriteLine("Podaj hasło: ");
            string hasło = Console.ReadLine();

            Customer nowy = new Customer(Customer.customers.Count + 1, imie + " " + nazwisko, email, hasło);
            AddCustomer(nowy);
            string path = @"C:\Users\mathe\OneDrive\Pulpit\Programowanie obiektowe\Projekt w67194\Projekt w67194\Customers.txt";
            string DaneDoZapisu = $"{nowy.Id},{nowy.Name},{nowy.Email},{nowy.Password}";
            string appendText = DaneDoZapisu + Environment.NewLine;
            File.AppendAllText(path, appendText);
            Console.WriteLine("Naciśnij dowolny klawisz, aby wrócić do menu");
            Console.ReadKey();
            Console.Clear();
            Program.Menu();
        }

        static public void UsuńKlienta()
        {
            Console.WriteLine("Podaj id klienta do usunięcia: ");
            int id = int.Parse(Console.ReadLine());
            Customer customer = customers.FirstOrDefault(c => c.Id == id - 1);
            customers.Remove(customer);
            Console.WriteLine("Usunięto klienta");
            string path = @"C:\Users\mathe\OneDrive\Pulpit\Programowanie obiektowe\Projekt w67194\Projekt w67194\Customers.txt";
            string text = File.ReadAllText(path);
            text = text.Replace($"{customer.Id},{customer.Name},{customer.Email},{customer.Password}", "");
            File.WriteAllText(path, text);
        }

        static public void MenuKlienta()
        {
            Console.WriteLine("Witaj w panelu klienta!");
            Console.WriteLine("Co chcesz zrobić?");
            Console.WriteLine("1. Wyświetl listę produktów");
            Console.WriteLine("2. Wyświetl listę zamówień");
            Console.WriteLine("3. Złóż zamówienie");
            Console.WriteLine("4. Wyloguj się");
            string wybor = Console.ReadLine();
            switch (wybor)
            {
                case "1":
                    Console.WriteLine("Lista produktów: ");
                    Product.listaProduktów();
                    Console.WriteLine("Naciśnij dowolny klawisz, aby wrócić do menu klienta");
                    Console.ReadKey();
                    Console.Clear();
                    MenuKlienta();
                    break;
                case "2":
                    Console.WriteLine("Lista zamówień: ");
                    Order.ListaZamówień();
                    Console.WriteLine("Naciśnij dowolny klawisz, aby wrócić do menu klienta");
                    Console.ReadKey();
                    Console.Clear();
                    MenuKlienta();
                    break;
                case "3":
                    Console.WriteLine("Złóż zamówienie");
                    Order.DodajZamówienie();
                    Console.WriteLine("Naciśnij dowolny klawisz, aby wrócić do menu klienta");
                    Console.ReadKey();
                    Console.Clear();
                    MenuKlienta();
                    break;
                
                case "4":
                    Console.Clear();
                    Console.WriteLine("Wylogowano");
                    Program.Menu();
                    break;
                default:
                    Console.WriteLine("Podano nieprawidłową wartość.");
                    Console.Clear();
                    MenuKlienta();
                    break;
            }
        }


    }
}
