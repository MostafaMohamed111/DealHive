using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hive.Core.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public string BuyerId { get; set; } = null!;
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;

        public User Buyer { get; set; } = null!;

        public IEnumerable<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    }
}
