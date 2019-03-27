using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TCQ_MVCDemo.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            ViewData["Contries"] = new List<string>
            {
                "India",
                "US",
                "UK",
                "Canada",
            };
            return View();
        }
        


    }
}