using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hive.Core.Entities
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }
        public int OrderId { get; set; }  // Foreign key to Order
        public int ItemId { get; set; }  // Foreign key to Item
        public int Quantity { get; set; }
        public decimal PriceAtPurchase { get; set; }

        // Navigation properties
        public virtual Order Order { get; set; } = null!;
        public virtual Item Item { get; set; } = null!;
    }
}
