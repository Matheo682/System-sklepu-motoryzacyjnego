using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
        static public List<Admin> admins = new List<Admin>();

        static public void ListaAdminów()
        {
            
            foreach (var admin in admins)
            {
                Console.WriteLine($"{admin.Id}, {admin.Name}, {admin.Email}, {admin.Username}, {admin.Password}");
            }
        }

        static public void BazaAdminów()
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\mathe\OneDrive\Pulpit\Programowanie obiektowe\Projekt w67194\Projekt w67194\Admins.txt");
            foreach (var line in lines)
            {
                string[] parts = line.Split(',');
                if (parts.Length == 5)
                {
                    int id = int.Parse(parts[0]);
                    string name = parts[1];
                    string email = parts[2];
                    string username = parts[3];
                    string password = parts[4];
                    Admin admin = new Admin(id, name, email, username, password);
                    admins.Add(admin);
                }
            }
            //Console.WriteLine("Załadowano bazę administratorów");

        }

        static public void Logowanie()
        {
            Console.WriteLine("Podaj login: ");
            string login = Console.ReadLine();
            Console.WriteLine("Podaj hasło: ");
            string hasło = Console.ReadLine();
            //BazaAdminów();
            Admin authenticatedAdmin = Authentication.AuthenticateAdmin(login, hasło, admins);
            if (authenticatedAdmin != null)
            {
                Console.WriteLine($"Zalogowano administratora: {authenticatedAdmin.Name}");
                Console.Clear();
                MenuAdmina();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Błąd logowania administratora");

                Program.Menu();
            }
        }

        public static void MenuAdmina()
        {
            Console.WriteLine("Witaj w panelu administratora!");
            Console.WriteLine("Co chcesz zrobić?");
            Console.WriteLine("1. Zarządzaj produktami");
            Console.WriteLine("2. Zarządzaj klientami");
            Console.WriteLine("3. Zarządzaj zamówieniami klientów");
            Console.WriteLine("4. Zarządzaj dostawcami");
            Console.WriteLine("0. Wyloguj się");
            string wybor = Console.ReadLine();
            switch (wybor)
            {
                case "1":
                    Console.Clear();
                    MenuProduktów();
                    break;
                case "2":
                    Console.Clear();
                    MenuKlientów();
                    break;
                case "3":
                    Console.Clear();
                    MenuZamówieńKlientów();
                    break;
                case "4":
                    Console.Clear();
                    MenuDostawców();
                    break;
                case "0":
                    Console.WriteLine("Wylogowano");
                    Console.Clear();
                    Program.Menu();
                    break;
                default:

                    Console.WriteLine("Podano nieprawidłową wartość.");
                    Console.Clear();
                    MenuAdmina();
                    break;
            }
        }

        public static void MenuProduktów()
        {
            Console.WriteLine("Co chcesz zrobić?");
            Console.WriteLine("1. Dodaj produkt");
            Console.WriteLine("2. Usuń produkt");
            Console.WriteLine("3. Wyświetl listę produktów");
            Console.WriteLine("0. Wróć do menu administratora");
            string wybor = Console.ReadLine();
            switch (wybor)
            {
                case "1":
                    Product.DodajProdukt();
                    Console.WriteLine("Dodano produkt");
                    Console.WriteLine("Naciśnij dowolny klawisz, aby kontynuować");
                    Console.ReadKey();
                    Console.Clear();
                    MenuProduktów();
                    break;
                case "2":
                    Console.WriteLine("Podaj kod produktu do usunięcia: ");
                    Product.UsuńProdukt();
                    Console.WriteLine("Usunięto produkt");
                    Console.WriteLine("Naciśnij dowolny klawisz, aby kontynuować");
                    Console.ReadKey();
                    Console.Clear();
                    MenuProduktów();
                    break;
                case "3":
                    Console.WriteLine("Lista produktów: ");
                    Product.listaProduktów();
                    Console.WriteLine("Naciśnij dowolny klawisz, aby kontynuować");
                    Console.ReadKey();
                    Console.Clear();
                    MenuProduktów();
                    break;
                case "0":
                    Console.Clear();
                    MenuAdmina();
                    break;
                default:
                    Console.WriteLine("Podano nieprawidłową wartość.");
                    Console.Clear();
                    MenuProduktów();
                    break;
            }

        }

        public static void MenuKlientów()
        {
            Console.WriteLine("Co chcesz zrobić?");
            Console.WriteLine("1. Wyświetl listę klientów");
            Console.WriteLine("2. Dodaj klienta");
            Console.WriteLine("3. Usuń klienta");
            Console.WriteLine("0. Wróć do menu administratora");
            string wybor = Console.ReadLine();
            switch (wybor)
            {
                case "1":
                    Console.WriteLine("Lista klientów: ");
                    Customer.ListaKlientów();
                    Console.WriteLine("Naciśnij dowolny klawisz, aby kontynuować");
                    Console.ReadKey();
                    Console.Clear();
                    MenuKlientów();
                    break;
                case "2":
                    Customer.rejestracja();
                    Console.WriteLine("Dodano klienta");
                    Console.WriteLine("Naciśnij dowolny klawisz, aby kontynuować");
                    Console.ReadKey();
                    Console.Clear();
                    MenuKlientów();
                    break;
                case "3":
                    Console.WriteLine("Podaj Id klienta do usunięcia: ");
                    Customer.UsuńKlienta();
                    Console.WriteLine("Usunięto klienta");
                    Console.WriteLine("Naciśnij dowolny klawisz, aby kontynuować");
                    Console.ReadKey();
                    Console.Clear();
                    MenuKlientów();
                    break;
                case "0":
                    Console.Clear();
                    MenuAdmina();
                    break;
                default:
                    Console.WriteLine("Podano nieprawidłową wartość.");
                    Console.Clear();
                    MenuKlientów();
                    break;
            }
        }

        public static void MenuZamówieńKlientów()
        {
               Console.WriteLine("Co chcesz zrobić?");
            Console.WriteLine("1. Wyświetl listę zamówień");
            Console.WriteLine("2. Złóż zamówienie dla klienta");
            Console.WriteLine("0. Wróć do menu administratora");
            string wybor = Console.ReadLine();
            switch (wybor)
            {
                case "1":
                    Console.WriteLine("Lista zamówień: ");
                    Order.ListaZamówień();
                    Console.WriteLine("Naciśnij dowolny klawisz, aby kontynuować");
                    Console.ReadKey();
                    Console.Clear();
                    MenuZamówieńKlientów();
                    break;
                case "2":
                    Console.WriteLine("Złóż zamówienie dla klienta");
                    Order.DodajZamówienie();
                    Console.WriteLine("Dodano zamówienie");
                    Console.WriteLine("Naciśnij dowolny klawisz, aby kontynuować");
                    Console.ReadKey();
                    Console.Clear();
                    MenuZamówieńKlientów();
                    break;
                case "0":
                    Console.Clear();
                    MenuAdmina();
                    break;
                default:
                    Console.WriteLine("Podano nieprawidłową wartość.");
                    Console.Clear();
                    MenuZamówieńKlientów();
                    break;
            }
        }

        public static void MenuDostawców()
        {
            Console.WriteLine("Co chcesz zrobić?");
            Console.WriteLine("1. Wyświetl listę dostawców");
            Console.WriteLine("2. Złóż zamówienie u dostawcy");
            Console.WriteLine("3. Wyświetl listę zamówień");
            Console.WriteLine("4. Dodaj dostawcę");
            Console.WriteLine("5. Usuń dostawcę");
            Console.WriteLine("0. Wróć do menu administratora");
            string wybor = Console.ReadLine();
            switch (wybor)
            {
                case "1":
                    Console.WriteLine("Lista zamówień u dostawców: ");
                    Dostawcy.ListaDostawców();
                    Console.WriteLine("Naciśnij dowolny klawisz, aby kontynuować");
                    Console.ReadKey();
                    Console.Clear();
                    MenuDostawców();
                    break;
                case "2":
                    Console.WriteLine("Złóż zamówienie u dostawcy");
                    ZamówieniaDostawców.DodajZamówienieDostawcy();
                    Console.WriteLine("Dodano zamówienie");
                    Console.WriteLine("Naciśnij dowolny klawisz, aby kontynuować");
                    Console.ReadKey();
                    Console.Clear();
                    MenuDostawców();
                    break;
                case "3":
                    Console.WriteLine("Lista zamówień: ");
                    ZamówieniaDostawców.ListaZamówieńDostawców();
                    Console.WriteLine("Naciśnij dowolny klawisz, aby kontynuować");
                    Console.ReadKey();
                    Console.Clear();
                    MenuDostawców();
                    break;
                case "4":
                    Dostawcy.DodajDostawcę();
                    Console.WriteLine("Dodano dostawcę");
                    Console.WriteLine("Naciśnij dowolny klawisz, aby kontynuować");
                    Console.ReadKey();
                    Console.Clear();
                    MenuDostawców();
                    break;
                case "5":
                    Console.WriteLine("Podaj Id dostawcy do usunięcia: ");
                    Dostawcy.UsuńDostawcę();
                    Console.WriteLine("Usunięto dostawcę");
                    Console.WriteLine("Naciśnij dowolny klawisz, aby kontynuować");
                    Console.ReadKey();
                    Console.Clear();
                    MenuDostawców();
                    break;
                case "0":
                    Console.Clear();
                    MenuAdmina();
                    break;
                default:
                    Console.WriteLine("Podano nieprawidłową wartość.");
                    Console.Clear();
                    MenuDostawców();
                    break;
            }
        }

            public static void DodajAdmina()
        {
            Console.WriteLine("Podaj id administratora: ");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Podaj imię: ");
            string name = Console.ReadLine();
            Console.WriteLine("Podaj e-mail: ");
            string email = Console.ReadLine();
            Console.WriteLine("Podaj login: ");
            string username = Console.ReadLine();
            Console.WriteLine("Podaj hasło: ");
            string password = Console.ReadLine();
            Admin admin = new Admin(id,name,email,username,password);
            admins.Add(admin);
            Console.WriteLine(admin);
            Console.WriteLine("Dodano administratora");
        }

        
    }


}
