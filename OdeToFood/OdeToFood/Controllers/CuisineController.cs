﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeToFood.Controllers
{
    public class CuisineController : Controller
    {
        // GET: Cuisine
        public ActionResult Search(string name = "sin valor")
        {
            var message = Server.HtmlEncode(name);
            //return Content(message);
            return Json(new {message = "hola", name = "PMG"}, JsonRequestBehavior.AllowGet);
        }

    }
}