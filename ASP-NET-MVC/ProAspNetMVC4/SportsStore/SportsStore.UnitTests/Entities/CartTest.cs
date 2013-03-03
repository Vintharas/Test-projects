using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SportsStore.Domain.Entities;

namespace SportsStore.UnitTests.Entities
{
    [TestClass]
    public class CartTest
    {

        [TestMethod]
        public void AddLine_WhenAProductIsAddedToTheCartInCertainQuantity_ThenItShouldBecomeOneOfTheCartLines()
        {
            // Arrange
            var cart = GetCart();
            var product = new Product {ProductID = 1, Name = "Light Saber"};
            var quantity = 2;
            // Act
            cart.AddItem(product, quantity);
            // Assert
            var line = cart.Lines.First();
            Assert.AreEqual(expected: product, actual: line.Product);
            Assert.AreEqual(expected: quantity, actual: line.Quantity);
        }

        [TestMethod]
        public void AddLine_WhenAProductIsAddedToTheCartInCertainQuantityAndThatProductAlreadyExistedInTheCart_ThenTheQuantityShouldBeAddedToTheSameCartLine()
        {
            // Arrange
            var cart = GetCart();
            var product = new Product { ProductID = 1, Name = "Light Saber" };
            var quantity = 2;
            cart.AddItem(product, quantity);
            var quantityExtra = 3;
            // Act
            cart.AddItem(product, quantityExtra);
            // Assert
            var line = cart.Lines.First();
            Assert.AreEqual(expected: product, actual: line.Product);
            Assert.AreEqual(expected: 5, actual: line.Quantity);
        }

        [TestMethod]
        public void RemoveLine_WhenGivenAProductThatExistInTheCart_ShouldRemoveTheLineAssociatedToThatProduct()
        {
            // Arrange
            var cart = GetCart();
            var productA = new Product { ProductID = 1, Name = "Light Saber" };
            var productB = new Product {ProductID = 2, Name = "Voodoo Mask"};
            cart.AddItem(productA, quantity: 2);
            cart.AddItem(productB, quantity: 1);
            // Act
            cart.RemoveLine(productA);
            // Assert
            Assert.IsTrue(cart.Lines.Count() == 1);
            Assert.AreEqual(expected: productB, actual: cart.Lines.First().Product);
        }

        [TestMethod]
        public void ComputeTotalValue_WhenHavingANumberOfLinesInTheCart_ShouldReturnTheTotalValueOfTheCart()
        {
            // Arrange
            var cart = GetCart();
            var productA = new Product { ProductID = 1, Name = "Light Saber" , Price = 10};
            var productB = new Product { ProductID = 2, Name = "Voodoo Mask" , Price = 1};
            cart.AddItem(productA, quantity: 2);
            cart.AddItem(productB, quantity: 1);
            // Act
            var totalValue = cart.ComputeTotalValue();
            // Assert
            Assert.AreEqual(expected: 21m, actual: totalValue);
        }

        [TestMethod]
        public void Clear_WhenHavingANumberOfLinesInTheCart_ShouldClearAllLines()
        {
            // Arrange
            var cart = GetCart();
            var productA = new Product { ProductID = 1, Name = "Light Saber", Price = 10 };
            var productB = new Product { ProductID = 2, Name = "Voodoo Mask", Price = 1 };
            cart.AddItem(productA, quantity: 2);
            cart.AddItem(productB, quantity: 1);
            // Act
            cart.Clear();
            // Assert
            Assert.IsFalse(cart.Lines.Any());
        }

        private static Cart GetCart()
        {
            return new Cart();
        }
    }
}