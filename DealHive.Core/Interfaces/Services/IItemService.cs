using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Hive.Application.Dtos.Item;
using Hive.Core.Entities;

namespace Hive.Core.Interfaces.Services
{
    public interface IItemService
    {
        Task<Item?> CreateItemAsync(ClaimsPrincipal User, ItemToCreateDto itemDto);

    }
}
