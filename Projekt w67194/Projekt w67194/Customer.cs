using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        static List<Customer> customers = new List<Customer>
        {
            new Customer(1, "John Doe", "john@example.com", "customerPassword"),
            
        };

        static public void Logowanie()
        {
            Console.WriteLine("Podaj e-mail: ");
            string login = Console.ReadLine();
            Console.WriteLine("Podaj hasło: ");
            string hasło = Console.ReadLine();

            Customer authenticatedCustomer = Authentication.AuthenticateCustomer(login, hasło, customers);
            if (authenticatedCustomer != null)
            {
                Console.WriteLine($"Zalogowano użytkownika: {authenticatedCustomer.Name}");
            }
            else
            {
                Console.WriteLine("Błąd logowania użytkownika");
            }
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

            Customer nowy = new Customer(2, imie + " " + nazwisko, email, hasło);
            customers.Add(nowy);
            Console.WriteLine("Zarejestrowano użytkownika: " + nowy.Name);
        }
    }
}
