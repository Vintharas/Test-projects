using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Chapter06_EssentialTools.Interfaces;
using Chapter06_EssentialTools.Models;
using Ninject;

namespace Chapter06_EssentialTools.Controllers
{
    public class HomeController : Controller
    {
        private IValueCalculator calculator;

        public HomeController(IValueCalculator calculator)
        {
            this.calculator = calculator;
        }

        private IEnumerable<Product> products = new List<Product>
            {
                new Product { Name = "Kayak", Category = "Watersports", Price = 275M},
                new Product { Name = "Lifejacket", Category = "Watersports", Price = 49.98M},
                new Product { Name = "Soccer ball", Category = "Soccer", Price = 19.50M},
                new Product { Name = "Corner flag", Category = "Soccer", Price = 34.55M}
            }; 

        public ActionResult Index()
        {
           
            ShoppingCart cart = new ShoppingCart(calculator) {Products = products};
            decimal totalValue = cart.CalculateProductTotal();
            return View(totalValue);
        }

    }
}
