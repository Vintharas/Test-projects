using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcMusicStore.Models;

namespace MvcMusicStore.Controllers
{
    public class HomeController : Controller
    {

        private MusicStoreDB db = new MusicStoreDB();

        public ActionResult Index()
        {
            ViewBag.Message = "I like Cake!";

            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Search(string q)
        {
            var albums = db.Albums
                .Include("Artist")
                .Where(a => a.Title.Contains(q) || q == null)
                .Take(10);
            return View(albums);
        }
    }
}
