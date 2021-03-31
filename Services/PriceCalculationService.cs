using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Dtos;
using WebApplication3.Entities;

namespace WebApplication3.Services
{
    public class PriceCalculationService
    {
        private readonly DiscountService _discountService;

        public PriceCalculationService(DiscountService discountService)
        {
            _discountService = discountService;
        }

        public OrderDto ApplyDiscount(OrderDto item)
        {
            if (item.Price.HasValue)
            {
                item.Price = item.Price - _discountService.CalculateDiscount(item);
            }
            return item;
        }
    }
}
