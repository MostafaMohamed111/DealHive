using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Hive.Core.Entities
{
    public class User : IdentityUser
    {
        public string Name { get; set; } = null!;
        public IEnumerable<Item> Items { get; set; } = new List<Item>();

        public IEnumerable<Order> Orders { get; set; } = new List<Order>();


    }
}
