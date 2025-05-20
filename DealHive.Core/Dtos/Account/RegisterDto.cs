using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hive.Application.Dtos.Account
{
    public class RegisterDto
    {
        [Required]
        public string Email { get; set; } = null!;

        [Required]
        public string Password { get; set; }= null!;

        [Required]
        public string UserName { get; set; } = null!;
        [Required]
        public string PhoneNumber { get; set; } = null!;

    }
}

