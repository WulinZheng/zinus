using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TCQ_Authorize1.Controllers
{
    
    public class HomeController : Controller
    {
        
        public ActionResult SecureMethod()
        {
            throw new Exception("Something went wrong");
        }

        [AllowAnonymous]
        public ActionResult NonSecureMethod()
        {

            return View();
        }

        
    }
}