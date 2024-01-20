using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_w67194
{
    public class Admin : Person
    {
        

        public string Username { get; set; }
        public string Password { get; set; }

        public Admin(int id, string name, string email, string username, string password)
            : base(id, name, email)
        {
            Username = username;
            Password = password;
        }

        static List<Admin> admins = new List<Admin>
        {
            new Admin(1, "Admin User", "admin@example.com", "adminUser", "adminPassword"),
            // Dodaj więcej administratorów
        };

        static public void Logowanie()
        {
            Console.WriteLine("Podaj login: ");
            string login = Console.ReadLine();
            Console.WriteLine("Podaj hasło: ");
            string hasło = Console.ReadLine();

            Admin authenticatedAdmin = Authentication.AuthenticateAdmin(login, hasło, admins);
            if (authenticatedAdmin != null)
            {
                Console.WriteLine($"Zalogowano administratora: {authenticatedAdmin.Name}");
            }
            else
            {
                Console.WriteLine("Błąd logowania administratora");
            }
        }


    }


}
