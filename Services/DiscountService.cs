using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Dtos;

namespace WebApplication3.Services
{
    public class DiscountService
    {
       
        decimal discount;

        public decimal CalculateDiscount(OrderItemDto item)
        {
            if (item.Quantity > 5)
            {
                discount = item.Price.Value / 100 * 20;
            }
            else
            {
                discount = item.Price.Value / 100 * 10;
            }

            return discount;
        }
    }
}
