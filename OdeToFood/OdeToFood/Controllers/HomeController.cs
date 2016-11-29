using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OdeToFood.Models;

namespace OdeToFood.Controllers
{
    public class HomeController : Controller
    {
        OdeToFoodDb _db = new OdeToFoodDb();

        public ActionResult Index()
        {
            var model = _db.Restaurants.ToList();
            return View(model);
        }

        public ActionResult About()
        {
            var model = new AboutModel()
            {
                Name = "PMG",
                Location = "Tenerife, Canary Islands, Spain"
            };

            return View(model);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Rating(int id)
        {
            var model = _db.Restaurants.Single(r => r.Id == id);
            return View(model);
        }

        protected override void Dispose(bool disposing)
        {
            _db?.Dispose();
            base.Dispose(disposing);
        }
    }
}