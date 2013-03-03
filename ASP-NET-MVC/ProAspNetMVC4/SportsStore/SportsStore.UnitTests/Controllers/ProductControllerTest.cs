using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using SportsStore.WebUI.Controllers;
using SportsStore.WebUI.Models;

namespace SportsStore.UnitTests.Controllers
{
    [TestClass]
    public class ProductControllerTest
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
         public void List_WhenListingASeriesOfProducts_ShouldPaginateThemAndShowOnlyTheFirstFour()
        {
             // Arrange
             ProductController controller = GetProductController();
             controller.PageSize = 4;
             // Act
             ProductsListViewModel viewModel = (ProductsListViewModel)controller.List().Model;
             // Assert
             List<Product> products = viewModel.Products.ToList();
             Assert.IsTrue(products.Count == 4);
             Assert.AreEqual(expected: "P1", actual: products[0].Name);
             Assert.AreEqual(expected: "P2", actual: products[1].Name);
             Assert.AreEqual(expected: "P3", actual: products[2].Name);
             Assert.AreEqual(expected: "P4", actual: products[3].Name);
        }

        [TestMethod]
        public void List_WhenListingTheSecondPageOfASeriesOfProducts_ShouldPaginateThemAndShowOnlyTheOnesInTheSecondPage()
        {
             // Arrange
             ProductController controller = new ProductController(repo.Object);
             controller.PageSize = 4;
             // Act
             ProductsListViewModel viewModel = (ProductsListViewModel)controller.List(page: 2).Model;
             // Assert
             List<Product> products = viewModel.Products.ToList();
             Assert.IsTrue(products.Count == 2);
             Assert.AreEqual(expected: "P5", actual: products[0].Name);
             Assert.AreEqual(expected: "P6", actual: products[1].Name);
        }

        [TestMethod]
        public void List_WhenGivenAPage_ShouldLoadTheCorrectPaginationInformation()
        {
            // Arrange
            ProductController controller = GetProductController();
            controller.PageSize = 4;
            // Act
            ProductsListViewModel viewModel = (ProductsListViewModel)controller.List(page: 2).Model;
            // Assert
            PagingInfo pagingInfo = viewModel.PagingInfo;
            Assert.AreEqual(expected: 2, actual: pagingInfo.CurrentPage);
            Assert.AreEqual(expected: 4, actual: pagingInfo.ItemsPerPage);
            Assert.AreEqual(expected: 6, actual: pagingInfo.TotalItems);
            Assert.AreEqual(expected: 2, actual: pagingInfo.TotalPages);
        }

        [TestMethod]
        public void List_WhenGivenACategory_ShouldLoadOnlyProductsWithThatCategory()
        {
            // Arrange
            ProductController controller = new ProductController(repo.Object);
            controller.PageSize = 4;
            // Act
            ProductsListViewModel viewModel = (ProductsListViewModel)controller.List(category: "C").Model;
            // Assert
            List<Product> products = viewModel.Products.ToList();
            Assert.IsTrue(products.Count == 2);
            Assert.AreEqual(expected: "P4", actual: products[0].Name);
            Assert.AreEqual(expected: "C", actual: products[0].Category);
            Assert.AreEqual(expected: "P5", actual: products[1].Name);
            Assert.AreEqual(expected: "C", actual: products[1].Category);
            Assert.AreEqual(expected: "C", actual: viewModel.CurrentCategory);
        }



        private ProductController GetProductController()
        {
            return new ProductController(repo.Object);
        }
    }
}