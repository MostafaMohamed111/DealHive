using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace Hive.Core.Entities
{
    public class Item
    {
        public int Id { get; set; }
        public string UserId { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public int AvailableQuantity { get; set; }
        public User Seller { get; set; } = null!;
        public DateTime TimeAdded { get; set; } = DateTime.UtcNow;

        public IEnumerable<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
