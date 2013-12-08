using Chapter06_EssentialTools.Interfaces;

namespace Chapter06_EssentialTools.Infrastructure
{
    /// <summary>
    /// This discount helper admits configuration parameters via
    /// a property
    /// </summary>
    public class DefaultDiscountHelper : IDiscountHelper
    {
        private const decimal DefaultDiscountSize = 10m;
        public decimal DiscountSize { get; set; }

        public DefaultDiscountHelper()
        {
            DiscountSize = DefaultDiscountSize;
        }

        public decimal ApplyDiscount(decimal total)
        {
            return (total - (DiscountSize/100m*total));
        }
    }

    /// <summary>
    /// This discount helper admits configuration parameters via 
    /// the constructor
    /// </summary>
    public class AnotherDefaultDiscountHelper : IDiscountHelper
    {
        private readonly decimal discountSize = 10m;

        public AnotherDefaultDiscountHelper(decimal discountSize)
        {
            this.discountSize = discountSize;
        }

        public decimal ApplyDiscount(decimal total)
        {
            return (total - (discountSize/100m * total));
        }
    }
}