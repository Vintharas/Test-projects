using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportsStore.Domain.Abstract;

namespace SportsStore.WebUI.Controllers
{
    public class NavController : Controller
    {
        private IProductRepository repo;

        public NavController(IProductRepository repo)
        {
            this.repo = repo;
        }

        public PartialViewResult Menu(string category = null)
        {
            ViewBag.SelectedCategory = category; // TODO: Refactor into a ViewModel
            IEnumerable<string> categories = repo.Products.Select(x => x.Category).Distinct().OrderBy(x => x);
            return PartialView(categories);
        }

    }
}
