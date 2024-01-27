using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_w67194
{
    internal class Dostawcy
    {
        public int DostawcaId { get; set; }
        public string Nazwa { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }

        public Dostawcy(int dostawcaId, string nazwa, string email, string telefon)
        {
            DostawcaId = dostawcaId;
            Nazwa = nazwa;
            Email = email;
            Telefon = telefon;
        }

        public static List<Dostawcy> dostawcy = new List<Dostawcy>();

        public static void ListaDostawców()
        {
            foreach (var dostawca in dostawcy)
            {
                Console.WriteLine($"{dostawca.DostawcaId}, {dostawca.Nazwa}, {dostawca.Email}, {dostawca.Telefon}");
            }
        }

        public static void BazaDostawców()
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\mathe\OneDrive\Pulpit\Programowanie obiektowe\Projekt w67194\Projekt w67194\Dostawcy.txt");
            foreach (var line in lines)
            {
                string[] parts = line.Split(',');
                if (parts.Length == 4)
                {
                    int dostawcaId = int.Parse(parts[0]);
                    string nazwa = parts[1];
                    string email = parts[2];
                    string telefon = parts[3];
                    Dostawcy dostawca = new Dostawcy(dostawcaId, nazwa, email, telefon);
                    dostawcy.Add(dostawca);
                }
            }
        }

        

        public static void DodajDostawcę()
        {
            Console.WriteLine("Podaj id dostawcy: ");
            int dostawcaId = int.Parse(Console.ReadLine());
            Console.WriteLine("Podaj nazwę dostawcy: ");
            string nazwa = Console.ReadLine();
            Console.WriteLine("Podaj e-mail dostawcy: ");
            string email = Console.ReadLine();
            Console.WriteLine("Podaj telefon dostawcy: ");
            string telefon = Console.ReadLine();
            Dostawcy dostawca = new Dostawcy(dostawcaId, nazwa, email, telefon);
            dostawcy.Add(dostawca);
            Console.WriteLine("Dodano dostawcę");
            string path = @"C:\Users\mathe\OneDrive\Pulpit\Programowanie obiektowe\Projekt w67194\Projekt w67194\Dostawcy.txt";
            string appendText = dostawcaId + "," + nazwa + "," + email + "," + telefon + Environment.NewLine;
            File.AppendAllText(path, appendText);
        }

        public static void UsuńDostawcę()
        {
            Console.WriteLine("Podaj id dostawcy do usunięcia: ");
            int dostawcaId = int.Parse(Console.ReadLine());
            Dostawcy dostawca = dostawcy.FirstOrDefault(x => x.DostawcaId == dostawcaId);
            dostawcy.Remove(dostawca);
            Console.WriteLine("Usunięto dostawcę");
            string path = @"C:\Users\mathe\OneDrive\Pulpit\Programowanie obiektowe\Projekt w67194\Projekt w67194\Dostawcy.txt";
            string text = File.ReadAllText(path);
            text = text.Replace(dostawcaId + "," + dostawca.Nazwa + "," + dostawca.Email + "," + dostawca.Telefon + Environment.NewLine, "");
            File.WriteAllText(path, text);
        }
        
    }
}
