using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcMusicStore.Controllers
{
    public class StoreController : Controller
    {
        //
        // GET: /Store/

        public string Index()
        {
            return "Hello from Store.Index()";
        }

        /// <summary>
        /// GET: /Store/Browse?genre=?Disco
        /// </summary>
        /// <returns></returns>
        public string Browse(string genre)
        {
            string result = HttpUtility.HtmlEncode("Store.Browse(), Genre = " + genre);
            return result;
        }

        /// <summary>
        /// GET: /Store/Details/id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string Details(int id)
        {
            return HttpUtility.HtmlEncode("Store.Details(), Id = " + id);
        }

        public ActionResult List()
        {
            var albums = new List<string> {"lalala", "lalalA", "lalalla"};
            return View(albums);
        }

        public ActionResult Edit(int id)
        {
            return View();
        }

    }
}
