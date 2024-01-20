namespace Projekt_w67194
{
    internal class Program
    {
        static void Main()
        {
            Menu();
        }

        static void Menu() 
        { 
            Console.WriteLine("Witaj w sklepie internetowym!");
            Console.WriteLine("Wybierz opcję:");
            Console.WriteLine("1. Zaloguj się");
            Console.WriteLine("2. Zarejestruj się");
            Console.WriteLine("3. Wyjdź");
            string wybor = Console.ReadLine();
            if (wybor == "1")
            {
                Login();
            }
            else if (wybor == "2")
            {
                Customer.rejestracja();
            }
            else if (wybor == "3")
            {
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Podano nieprawidłową wartość.");
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
                Admin.Logowanie();
            }
            else if (method == "2")
            {
                Customer.Logowanie();
            }
            else if (method == "3")
            {
                Menu();
            }
            else
            {
                Console.WriteLine("Podano nieprawidłowe dane.");
            }
        }

    }
}