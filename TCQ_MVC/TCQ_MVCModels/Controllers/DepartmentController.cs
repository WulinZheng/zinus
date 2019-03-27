using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TCQ_MVCModels.Models;

namespace TCQ_MVCModels.Controllers
{
    public class DepartmentController : Controller
    {
        
        public ActionResult Index()
        {
            EmployeeContext context = new EmployeeContext();
            List<Department> departments = context.Departments.ToList();
            return View(departments);
        }
    }
}