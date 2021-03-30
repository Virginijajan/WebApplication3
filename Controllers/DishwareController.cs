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
using WebApplication3.Services;

namespace WebApplication3.Controllers
{
    [ApiController]
    [Route("[controller]")]
   
    public class DishwareController : GenericControllerBase<DishwareDto, Dishware>

    {
        private IMapper _mapper;
        private GenericRepository<Dishware> _repository;
        private PriceCalculationService _priceCalculationService;
        private DiscountService _discountService;
        private AmountService _amountService;

        public DishwareController(IMapper mapper, GenericRepository<Dishware> repository, PriceCalculationService priceCalculationService, 
            DiscountService discountService, AmountService amountService) : base(repository, mapper)
        {
            _mapper = mapper;
            _repository = repository;
           _priceCalculationService = priceCalculationService;
           _discountService = discountService;
           _amountService = amountService;


        }

        [HttpGet]
        public async override Task<List<DishwareDto>> GetAll()
        {
           var entities = await _repository.GetAll();

           
           var dtos= _mapper.Map<List<DishwareDto>>(entities);

            var item = new List<DishwareDto>();

            foreach(DishwareDto dto in dtos)
            {
                dto.Discount = _discountService.CalculateDiscount(dto) * dto.Quantity;

                item.Add( _amountService.CalculateAmount(dto));
                
            }

            //var updatedDtos = dtos.Select(d => _priceCalculationService.ApplyDiscount(d));

           return item;
        }


        [HttpGet("{id}")]
        public override DishwareDto GetById(int id)
        {
            var entity = _repository.FindById(id);

            var dto= _mapper.Map<DishwareDto>(entity);

            
            dto.Discount =_discountService.CalculateDiscount(dto)*dto.Quantity;

           dto = _amountService.CalculateAmount(dto);


            return dto;

        }
    }
}
