using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Controllers.Base;
using WebApplication3.Dtos;
using WebApplication3.Entities;
using WebApplication3.Entities.Base;
using WebApplication3.Repositories;

namespace WebApplication3.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShopItemController: GenericControllerBase<ShopItemDto, ShopItem>
    {


        public ShopItemController(IMapper mapper, GenericRepository<ShopItem> repository) : base(repository, mapper)
        {

        }



    }
}
