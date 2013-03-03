using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportsStore.Domain.Abstract;
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
            PageSize = 4;
        }

        public ViewResult List(int page = 1)
        {
            var productsListViewModel = new ProductsListViewModel
                {
                    Products = repository.Products.OrderBy(p => p.ProductID).Skip((page - 1)*PageSize).Take(PageSize),
                    PagingInfo = new PagingInfo
                        {
                            CurrentPage = page,
                            ItemsPerPage = PageSize,
                            TotalItems = repository.Products.Count()
                        }
                };
            return View(productsListViewModel);
        }
    }
}
