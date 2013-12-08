using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportStore.Domain.Interfaces;
using SportStore.WebUI.Models;

namespace SportStore.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository repository;
        public int PageSize { get; set; }

        public ProductController(IProductRepository repository)
        {
            this.repository = repository;
            PageSize = 4;
        }
        
        /// <summary>
        /// List products
        /// </summary>
        /// <returns></returns>
        public ViewResult List(int page = 1)
        {
            // Get the elements within the selected page
            ProductListViewModel viewModel = new ProductListViewModel
                                                 {
                                                     Products = repository.Products
                                                         .OrderBy(x => x.ProductID)
                                                         .Skip((page - 1)*PageSize)
                                                         .Take(PageSize),
                                                     PagingInfo = new PagingInfo
                                                         {
                                                             CurrentPage = page,
                                                             ItemsPerPage = PageSize,
                                                             TotalItems = repository.Products.Count()
                                                         }
                                                 };
            return View(viewModel);
        }

    }
}
