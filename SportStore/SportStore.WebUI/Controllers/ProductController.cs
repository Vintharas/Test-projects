using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportStore.Domain.Interfaces;

namespace SportStore.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository repository;

        public ProductController(IProductRepository repository)
        {
            this.repository = repository;
        }
        
        /// <summary>
        /// List products
        /// </summary>
        /// <returns></returns>
        public ActionResult List()
        {
            return View(repository.Products);
        }

    }
}
