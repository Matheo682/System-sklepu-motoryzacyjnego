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
    }
}
