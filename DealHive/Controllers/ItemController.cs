using System.Security.Claims;
using AutoMapper;
using Hive.Application.Dtos.Item;
using Hive.Application.Services_Specs;
using Hive.Core.Dtos.Items;
using Hive.Core.Entities;
using Hive.Core.Interfaces;
using Hive.Core.Interfaces.Services;
using Hive.Core.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;

namespace DealHive.Controllers
{

    public class ItemController : BaseApiController
    {
        private readonly IItemService _itemService;
        private readonly IMapper _mapper;

        public ItemController(IItemService itemService, IMapper mapper)
        {
            _itemService = itemService;
            _mapper = mapper;
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost("create")]
        public async Task<ActionResult> PostItem(ItemToCreateDto itemDto)
        {
            var item = await _itemService.CreateItemAsync(User, itemDto);

            if (item == null)
                return NewResult(ResponseHandler<Item>.BadRequest("There has been an issue"));
            var itemToReturn = _mapper.Map<Item, ItemToReturnDto>(item);

            return NewResult(ResponseHandler<ItemToReturnDto>.Success(itemToReturn));
        }

    }
}
