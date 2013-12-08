using System;
using Chapter06_EssentialTools.Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Chapter06_EssentialTools.Tests
{
    [TestClass]
    public class MinimumDiscoutHelperTests
    {
        [TestMethod]
        public void ApplyDiscount_WhenTotalIsAbove100_ThenDiscountShouldBeTenPercent()
        {
            // Arrange
            var discountHelper = GetDiscountHelper();
            decimal total = 200;
            // Act
            var discountedTotal = discountHelper.ApplyDiscount(total);
            // Assert
            Assert.AreEqual(expected: 180, actual: discountedTotal);
        }
        
        [TestMethod]
        public void ApplyDiscount_WhenTotalIsBetween100And10Inclusive_ThenDiscountFiveDollars()
        {
            // Arrange
            var discountHelper = GetDiscountHelper();
            decimal total = 50;
            // Act
            var discountedTotal = discountHelper.ApplyDiscount(total);
            // Assert
            Assert.AreEqual(expected: 45, actual: discountedTotal);
        }

        [TestMethod]
        public void ApplyDiscount_WhenTotalIsSmallerThan10Dollars_ThenNoDiscountWillBeApplied()
        {
            // Arrange
            var discountHelper = GetDiscountHelper();
            decimal total = 5;
            // Act
            var discountedTotal = discountHelper.ApplyDiscount(total);
            // Assert
            Assert.AreEqual(expected: total, actual: discountedTotal);
        }

        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [TestMethod]
        public void ApplyDiscount_WhenTotalIsNegative_ThenShouldThrowException()
        {
            // Arrange
            var discountHelper = GetDiscountHelper();
            // Act, Assert
            var discountedTotal = discountHelper.ApplyDiscount(-1);
        }





        private MinimumDiscountHelper GetDiscountHelper()
        {
            return new MinimumDiscountHelper();
        }
    }
}
