using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Dtos;
using WebApplication3.Entities;

namespace WebApplication3.Mappings
{
    public class MappingsProfile:Profile
    {
        public MappingsProfile()
        {
            CreateMap<DishwareDto, Dishware>().ReverseMap();
            CreateMap<VegetableDto, Vegetable>().ReverseMap();
            CreateMap<FruitDto, Fruit>().ReverseMap();
            CreateMap<ShopDto, Shop>().ReverseMap();
        }
    }
}
