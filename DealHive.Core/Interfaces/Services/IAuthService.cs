using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hive.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Hive.Application.Dtos.Item;

namespace Hive.Core.Interfaces.AuthService
{
    public interface IAuthService
    {
        string GenerateToken(AppUser user); 
    }
}
