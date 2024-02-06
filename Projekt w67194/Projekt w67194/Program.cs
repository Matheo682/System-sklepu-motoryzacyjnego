namespace Projekt_w67194
{
    internal class Program
    {
        static void Main()
        {
            Admin.BazaAdminów();
            Customer.BazaKlientów();
            Product.BazaProduktów();
            Order.BazaZamówień();
            ZamówieniaDostawców.BazaZamówieńDostawców();
            Dostawcy.BazaDostawców();
            Menu();
        }

        public static void Menu() 
        { 
            
            Console.WriteLine("Witaj w sklepie internetowym!");
            Console.WriteLine("Wybierz opcję:");
            Console.WriteLine("1. Zaloguj się");
            Console.WriteLine("2. Zarejestruj się");
            Console.WriteLine("3. Wyjdź");
            string wybor = Console.ReadLine();
            if (wybor == "1")
            {
                Console.Clear();
                Login();
            }
            else if (wybor == "2")
            {
                Console.Clear();
                Customer.rejestracja();

            }
            else if (wybor == "3")
            {
                Console.Clear();
                Environment.Exit(0);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Podano nieprawidłową wartość.");
                Menu();
            }

        }

        static void Login()
        {
            Console.WriteLine("Wybierz metodę logowania:");
            Console.WriteLine("1. Admin");
            Console.WriteLine("2. Użytkownik");
            Console.WriteLine("3. Wyjdź");
            string method = Console.ReadLine();

            if (method == "1")
            {
                Console.Clear();
                Admin.Logowanie();
            }
            else if (method == "2")
            {
                Console.Clear();
                Customer.Logowanie();
            }
            else if (method == "3")
            {
                Console.Clear();
                Menu();
            }else
            {
                Console.Clear();
                Console.WriteLine("Podano nieprawidłowe dane.");
                Login();
            }
        }

    }

}