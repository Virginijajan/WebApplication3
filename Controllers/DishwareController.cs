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
   
    public class DishwareController : GenericControllerBase<DishwareDto, Dishware>

    {
        public DishwareController(DataContext context, IMapper mapper, GenericRepository<Dishware> repository) : base(repository, mapper)
        {
           
        }     
    }
}
