using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using SportsStore.WebUI.Models;

namespace SportsStore.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository repository;
        public int PageSize { get; set; }

        public ProductController(IProductRepository repository)
        {
            this.repository = repository;
            PageSize = 3;
        }

        public ViewResult List(string category = null, int page = 1)
        {
            IQueryable<Product> productsWithCategory = GetProductsWithCategory(category);
            IQueryable<Product> productsForCategoryAndPage = GetProductsWithCategoryAndPage(productsWithCategory, page);
            var productsListViewModel = new ProductsListViewModel
                {
                    Products = productsForCategoryAndPage,
                    PagingInfo = new PagingInfo
                        {
                            CurrentPage = page,
                            ItemsPerPage = PageSize,
                            TotalItems = productsWithCategory.Count()
                        },
                    CurrentCategory = category
                };
            return View(productsListViewModel);
        }

        private IQueryable<Product> GetProductsWithCategory(string category)
        {
            return repository.Products
                             .Where(p => category == null || p.Category == category);
        }

        private IQueryable<Product> GetProductsWithCategoryAndPage(IQueryable<Product> productsWithCatergory, int page)
        {
            return productsWithCatergory
                             .OrderBy(p => p.ProductID)
                             .Skip((page - 1)*PageSize)
                             .Take(PageSize);
        }
    }
}
