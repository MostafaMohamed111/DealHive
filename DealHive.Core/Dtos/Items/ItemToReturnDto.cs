using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hive.Core.Entities;

namespace Hive.Core.Dtos.Items
{
    public class ItemToReturnDto
    {
        public int Id { get; set; }
        public string UserId { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public int AvailableQuantity { get; set; }
        public string Seller { get; set; } = null!;
        public DateTime TimeAdded { get; set; } 

        //public IEnumerable<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
