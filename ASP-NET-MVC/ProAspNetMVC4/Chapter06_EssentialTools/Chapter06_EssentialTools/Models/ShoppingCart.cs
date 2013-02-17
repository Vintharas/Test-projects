using System.Collections.Generic;
using Chapter06_EssentialTools.Interfaces;

namespace Chapter06_EssentialTools.Models
{
    public class ShoppingCart
    {
        private readonly IValueCalculator calculator;

        public ShoppingCart(IValueCalculator calculator)
        {
            this.calculator = calculator;
        }

        public IEnumerable<Product> Products { get; set; }

        public decimal CalculateProductTotal()
        {
            return calculator.ValueProducts(Products);
        }
    }
}