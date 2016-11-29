using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Identity.Controllers
{
    public class SecretController : Controller
    {
        [Authorize]
        public ContentResult Secret()
        {
            return Content("this is a secret");
        }

        public ContentResult Overt()
        {
            return Content("This is NOT a secret");
        }
    }
}