using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Controllers.Base;
using WebApplication3.Data;
using WebApplication3.Dtos;
using WebApplication3.Entities;
using WebApplication3.Repositories;

namespace WebApplication3.Controllers
{

    [ApiController]
    [Route("[controller]")]

        public class ShopController : GenericControllerBase<ShopDto, Shop>

        {
            public ShopController(IMapper mapper, GenericRepository<Shop> repository) : base(repository, mapper)
            {

            }
        }  
 }

