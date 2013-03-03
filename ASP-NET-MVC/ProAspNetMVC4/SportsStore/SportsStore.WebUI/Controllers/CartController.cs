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
    public class CartController : Controller
    {
        private readonly IProductRepository repo;

        public CartController(IProductRepository repo)
        {
            this.repo = repo;
        }

        public ViewResult Index(string returnUrl)
        {
            return View(new CartIndexViewModel
                {
                    Cart = GetCart(),
                    ReturnUrl = returnUrl
                });
        }

        public RedirectToRouteResult AddToCart(int productId, string returnUrl)
        {
            Product product = GetProductById(productId);
            if (product != null)
                GetCart().AddItem(product, 1);
            return RedirectToAction("Index", new {returnUrl});
        }

        private Product GetProductById(int productId)
        {
            return repo.Products
                       .FirstOrDefault(p => p.ProductID == productId);
        }

        public RedirectToRouteResult RemoveFromCart(int productId, string returnUrl)
        {
            Product product = GetProductById(productId);
            if (product != null)
                GetCart().RemoveLine(product);
            return RedirectToAction("Index", new {returnUrl});

        }

        private Cart GetCart()
        {
            Cart cart = (Cart) Session["Cart"];
            if (cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }
    }
}
