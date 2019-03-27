using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TCQ_Authorize.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult SercureMethod()
        {
            return View();
        }
        public ActionResult NonSercureMethod()
        {
            return View();
        }
    }
}