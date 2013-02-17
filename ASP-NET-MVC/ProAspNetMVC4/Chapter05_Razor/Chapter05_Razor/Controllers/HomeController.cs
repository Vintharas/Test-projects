using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Chapter05_Razor.Models;

namespace Chapter05_Razor.Controllers
{
    public class HomeController : Controller
    {
        private readonly Barbarian barbarian = new Barbarian
        {
            BarbarianId = 1,
            Name = "Conan",
            Description =
                "black-haired, sullen-eyed, sword in hand, a thief, a reaver, a slayer, with gigantic melancholies and gigantic mirth",
            Race = "Cimmerian",
            Weapon = "Two-handed sword",
            Armor = "Hard leather armor"
        };

        private readonly IList<Barbarian> barbarians = new List<Barbarian>
            {
                new Barbarian {Name = "Conan"},
                new Barbarian {Name = "Krull"},
                new Barbarian {Name = "Logen"},
                new Barbarian {Name = "Shivers"}
            };

        public ActionResult Index()
        {
            return View(barbarian);
        }

        public ActionResult WeaponAndArmor()
        {
            return View(barbarian);
        }

        public ActionResult PlayerProfile()
        {
            return View(barbarian);
        }

        public ActionResult List()
        {
            return View(barbarians);
        }

    }
}
