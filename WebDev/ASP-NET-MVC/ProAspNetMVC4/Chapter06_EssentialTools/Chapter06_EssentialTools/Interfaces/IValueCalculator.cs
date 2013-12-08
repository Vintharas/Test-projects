using System.Collections.Generic;
using Chapter06_EssentialTools.Models;

namespace Chapter06_EssentialTools.Interfaces
{
    public interface IValueCalculator
    {
        decimal ValueProducts(IEnumerable<Product> products);
    }
}