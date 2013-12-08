using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportStore.Domain.Entities;
using SportStore.Domain.Interfaces;
using SportStore.WebUI.Controllers;
using System.Web.Mvc;
using System.Web;
using SportStore.WebUI.Models;

namespace SportStore.WebUI.UnitTests.Controllers
{
    [TestClass]
    public class ProductControllerTest
    {
        private Mock<IProductRepository> productRepo;

        [TestInitialize]
        public void TestInitialize()
        {
            productRepo = new Mock<IProductRepository>();
            productRepo.Setup(x => x.Products).Returns(new Product[]
                                                    {
                                                        new Product {ProductID = 1, Name = "P1"},
                                                        new Product {ProductID = 2, Name = "P2"},
                                                        new Product {ProductID = 3, Name = "P3"},
                                                        new Product {ProductID = 4, Name = "P4"},
                                                        new Product {ProductID = 5, Name = "P5"}
                                                    }.AsQueryable());
        }

        [TestMethod]
        public void List_WhenPassedAPageNumber_ShouldPaginate()
        {
            // Arrange
            var controller = new ProductController(productRepo.Object) {PageSize = 3};
            // Act
            var result = (ProductListViewModel) controller.List(page: 2).Model;
            // Assert
            Product[] prodArray = result.Products.ToArray();
            Assert.IsTrue(prodArray.Length == 2);
            Assert.AreEqual(expected: prodArray[0].Name, actual: "P4");
            Assert.AreEqual(expected: prodArray[1].Name, actual: "P5");
        }

        [TestMethod]
        public void List_WhenPassedAPageNumber_ShouldSendTheCorrectPagingInfoToTheView()
        {
            // Arrange
            var controller = new ProductController(productRepo.Object) { PageSize = 3 };
            // Act
            var result = (ProductListViewModel)controller.List(page: 2).Model;
            // Assert
            PagingInfo pagingInfo = result.PagingInfo;
            Assert.AreEqual(expected: 2, actual: pagingInfo.CurrentPage);
            Assert.AreEqual(expected: 3, actual: pagingInfo.ItemsPerPage);
            Assert.AreEqual(expected: 5, actual: pagingInfo.TotalItems);
            Assert.AreEqual(expected: 2, actual: pagingInfo.TotalPages);
        }
    }
}
