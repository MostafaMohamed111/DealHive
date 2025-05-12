using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hive.Core.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }= null!;
        public IEnumerable<Item> Items { get; set; } = new List<Item>();
    }
}
