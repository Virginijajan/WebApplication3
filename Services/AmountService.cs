using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Dtos;

namespace WebApplication3.Services
{
    public class AmountService
    {
        private readonly DiscountService _discountService;

        public AmountService(DiscountService discountService)
        {
            _discountService = discountService;
        }
        public DishwareDto CalculateAmount(DishwareDto item)
        {
           


            item.Amount = (item.Price.Value- _discountService.CalculateDiscount(item)) * item.Quantity;

            return item;
        }
    }
}
