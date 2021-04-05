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
        public decimal CalculateAmount(OrderItemDto item)
        {

            decimal amount = (item.Price.Value- _discountService.CalculateDiscount(item)) * item.Quantity;

            return amount;
        }
    }
}
