using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Hive.Application.Dtos.Item;
using Hive.Application.Services_Specs;
using Hive.Core.Entities;
using Hive.Core.Interfaces;
using Hive.Core.Interfaces.Services;

namespace Hive.Application.Services.Items
{
    public class ItemService : IItemService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ItemService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Item?> CreateItemAsync(ClaimsPrincipal User, ItemToCreateDto itemDto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
                throw new Exception("UnAuthorized!");
            var userSpec = new UserIdSpecification(userId);

            var user = await _unitOfWork.Repository<AppUser>().GetAsync(userSpec);

            if (user == null)
                throw new Exception("There is no such user");

            var item = new Item()
            {
                UserId = userId,
                Seller = user,
                Name = itemDto.Name,
                Description = itemDto.Description,
                Price = itemDto.Price,
                AvailableQuantity = itemDto.AvailableQuantity
            };

            _unitOfWork.Repository<Item>().Add(item);

            if(await _unitOfWork.Commit() > 0)
                return item;
            return null;
        }
    }
}
