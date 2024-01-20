using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_w67194
{
    public class Authentication
    {
        public static Customer AuthenticateCustomer(string email, string password, List<Customer> customers)
        {
            return customers.FirstOrDefault(c => c.Email == email && c.Password == password);
        }

        public static Admin AuthenticateAdmin(string username, string password, List<Admin> admins)
        {
            return admins.FirstOrDefault(a => a.Username == username && a.Password == password);
        }
    }
}
