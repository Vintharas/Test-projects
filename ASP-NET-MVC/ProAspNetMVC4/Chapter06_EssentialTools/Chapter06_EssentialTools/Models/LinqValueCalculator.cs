using System.Collections.Generic;
using System.Linq;
using Chapter06_EssentialTools.Interfaces;

namespace Chapter06_EssentialTools.Models
{
    public class LinqValueCalculator : IValueCalculator
    {
        private IDiscountHelper discountHelper;

        public LinqValueCalculator(IDiscountHelper discountHelper)
        {
            this.discountHelper = discountHelper;
        }

        public decimal ValueProducts(IEnumerable<Product> products)
        {
            return discountHelper.ApplyDiscount(products.Sum(p => p.Price));
        }
    }
}