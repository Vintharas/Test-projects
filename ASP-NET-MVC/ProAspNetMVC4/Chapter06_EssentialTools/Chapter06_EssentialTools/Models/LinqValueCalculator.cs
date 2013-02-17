using System.Collections.Generic;
using System.Linq;
using Chapter06_EssentialTools.Interfaces;

namespace Chapter06_EssentialTools.Models
{
    public class LinqValueCalculator : IValueCalculator
    {
        public decimal ValueProducts(IEnumerable<Product> products)
        {
            return products.Sum(p => p.Price);
        }
    }
}