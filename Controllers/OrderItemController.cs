using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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

namespace WebApplication3
{
    [ApiController]
    [Route("[controller]")]
    public class OrderItemController:GenericControllerBase<OrderItemDto, Order>
    {
        private IMapper _mapper;
        private OrderRepository _repository;
        private DiscountService _discountService;
        private AmountService _amountService;
      

        public OrderItemController(IMapper mapper, OrderRepository repository, DiscountService discountService,
            AmountService amountService):base(repository, mapper)
        {
            _mapper = mapper;
            _repository = repository;
            _discountService = discountService;
            _amountService = amountService;
        }


        [HttpPost("/Buy")]
        public async Task<OrderItemDto> Buy(BuyItemDto buyItemDto)
        {
            var order = new OrderItemDto();
            var item = _repository.GetShopItem(buyItemDto.Name);

            if (item.Quantity >= buyItemDto.Quantity)
            {
                order.Category = item.Category;
                order.ItemName = item.Name;
                order.Price = item.Price;
                order.Quantity = buyItemDto.Quantity;
                order.Discount = _discountService.CalculateDiscount(order) * order.Quantity;
                order.Amount = _amountService.CalculateAmount(order);
                order.ItemId = item.Id;

                var entity = _mapper.Map<Order>(order);

                await _repository.Upsert(entity);

                item.Quantity = item.Quantity - buyItemDto.Quantity;

                await _repository.UpdateShopItem(item);
            }
            return order;
        }


        [HttpPost]
        public async override Task Upsert(OrderItemDto dto)
        {
            
        }
    }
}
