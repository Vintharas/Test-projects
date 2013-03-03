using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using SportsStore.WebUI.Controllers;

namespace SportsStore.UnitTests.Controllers
{
    [TestClass]
    public class NavControllerTest
    {
        private IQueryable<Product> products;
        private Mock<IProductRepository> repo;

        [TestInitialize]
        public void TestInitialize()
        {
            products = new List<Product>
                {
                    new Product {ProductID = 1, Name = "P1", Category = "A"},
                    new Product {ProductID = 1, Name = "P2", Category = "A"},
                    new Product {ProductID = 1, Name = "P3", Category = "B"},
                    new Product {ProductID = 1, Name = "P4", Category = "C"},
                    new Product {ProductID = 1, Name = "P5", Category = "C"},
                    new Product {ProductID = 1, Name = "P6", Category = "D"}
                }.AsQueryable();
            repo = new Mock<IProductRepository>();
            repo.Setup(m => m.Products).Returns(products);
        }

        [TestMethod]
        public void Menu_WhenHavingASeriesOfProductsOrganizedWithCategories_ShouldPassTheseCategoriesToTheView()
        {
            // Arrange
            var controller = GetNavController();
            // Act
            var result = controller.Menu();
            // Assert
            var categories = ((IEnumerable<string>) result.Model).ToList();
            Assert.IsTrue(categories.Count() == 4);
            Assert.AreEqual(expected: "A", actual: categories[0]);
            Assert.AreEqual(expected: "B", actual: categories[1]);
            Assert.AreEqual(expected: "C", actual: categories[2]);
            Assert.AreEqual(expected: "D", actual: categories[3]);
        }


        private NavController GetNavController()
        {
            return new NavController(repo.Object);
        }
    }
}