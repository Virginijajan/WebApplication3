using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Dtos;
using WebApplication3.Entities;
using WebApplication3.Entities.Base;

namespace WebApplication3.Mappings
{
    public class MappingsProfile:Profile
    {
        public MappingsProfile()
        {  
            CreateMap<ShopDto, Shop>().ReverseMap();
            CreateMap<OrderItemDto, Order>().ReverseMap();
            CreateMap<ShopItemDto, ShopItem>().ReverseMap();
        }
    }
}
