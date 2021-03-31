using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Controllers.Base;
using WebApplication3.Dtos;
using WebApplication3.Entities;
using WebApplication3.Repositories;
using WebApplication3.Services;

namespace WebApplication3
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController:GenericControllerBase<OrderDto, Order>
    {
        private IMapper _mapper;
        // private GenericRepository<Order> _repository;
        private OrderRepository _repository;
        private PriceCalculationService _priceCalculationService;
        private DiscountService _discountService;
        private AmountService _amountService;

        public OrderController(IMapper mapper, OrderRepository repository, PriceCalculationService priceCalculationService,
            DiscountService discountService, AmountService amountService) : base(repository, mapper)
        {
            _mapper = mapper;
            _repository = repository;
            _priceCalculationService = priceCalculationService;
            _discountService = discountService;
            _amountService = amountService;
        }

        [HttpGet]
        public async override Task<List<OrderDto>> GetAll()
        {
            var entities = await _repository.GetAll();


            var dtos = _mapper.Map<List<OrderDto>>(entities);

            var item = new List<OrderDto>();

            foreach (OrderDto dto in dtos)
            {
                dto.Category = dto.Item.Category;

                dto.ItemId = dto.Item.Id;

                dto.ItemName = dto.Item.Name;

                dto.Price = dto.Item.Price;

                dto.Discount = _discountService.CalculateDiscount(dto) * dto.Quantity;

                dto.Amount=(_amountService.CalculateAmount(dto));

                item.Add(dto);

            }

            //var updatedDtos = dtos.Select(d => _priceCalculationService.ApplyDiscount(d));

            return item;
        }


        [HttpGet("{id}")]
        public override OrderDto GetById(int id)
        {
            var entity = _repository.FindById(id);

            var dto = _mapper.Map<OrderDto>(entity);

            dto.Category = dto.Item.Category;

            dto.ItemId = dto.Item.Id;

            dto.ItemName = dto.Item.Name;
            
            dto.Price = dto.Item.Price;

            dto.Discount = _discountService.CalculateDiscount(dto) * dto.Quantity;

            dto.Amount = _amountService.CalculateAmount(dto);


            return dto;

        }

        [HttpPost]
        public async override Task Upsert(OrderDto dto)
        {
                
                var entity = _mapper.Map<Order>(dto);

                await _repository.Upsert(entity);

           
        }



        [HttpDelete("{id}")]
        public async override Task Delete(int id)
        {
            await _repository.Delete(id);
        }
    }
}
