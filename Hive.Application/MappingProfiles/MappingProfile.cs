using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Hive.Core.Dtos.Account;
using Hive.Core.Dtos.Items;
using Hive.Core.Entities;


namespace Hive.Application.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AppUser, UserDto>();

            CreateMap<Item, ItemToReturnDto>()
                .ForMember(d => d.Seller, opt => opt.MapFrom(s => s.Seller.Name));
        }

    }
}
