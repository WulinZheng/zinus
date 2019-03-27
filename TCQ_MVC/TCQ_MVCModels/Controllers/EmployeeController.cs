using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TCQ_MVCModels.Models;

namespace TCQ_MVCModels.Controllers
{
    public class EmployeeController : Controller
    {
        public ActionResult Index(int eid)
        {
            EmployeeContext context = new EmployeeContext();
            List<Employee> employees = context.Employees.Where(emp=>emp.DepartmentId==eid).ToList();
            return View(employees);
        }

        public ActionResult Details(int id)
        {
            EmployeeContext context = new EmployeeContext();
            Employee employee = context.Employees.Single(em => em.EmployeeId==id);
            return View(employee);
        }


    }
}