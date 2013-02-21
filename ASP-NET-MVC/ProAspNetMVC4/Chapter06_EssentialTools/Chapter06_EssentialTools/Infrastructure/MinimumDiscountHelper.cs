using System;
using Chapter06_EssentialTools.Interfaces;

namespace Chapter06_EssentialTools.Infrastructure
{
    public class MinimumDiscountHelper : IDiscountHelper
    {
        public decimal ApplyDiscount(decimal total)
        {
            if (total < 0)
                throw new ArgumentOutOfRangeException(paramName: "total", message: "Oh no!");
            if (total > 100)
                return total - (0.1m* total);
            if (total >= 10 && total <= 100)
                return total - 5;
            return total;
        }
    }
}