using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TCQ_MVCEF.Models;

namespace TCQ_MVCEF.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        EmployeeEntities db = new EmployeeEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AutoComplete()
        {

            return View(db.Students);
        }

        [HttpPost]
        public ActionResult AutoComplete(string searchTerm)
        {
            List<Student> students;
            if (string.IsNullOrEmpty(searchTerm))
            {
                students = db.Students.ToList();
            }
            else
            {
                students = db.Students.Where(x=>x.Name.StartsWith(searchTerm)).ToList();
            }
            return View(students);
        }

        
        public JsonResult GetStudents(string term)
        {
            List<string> students = db.Students.Where(s => s.Name.StartsWith(term))
                .Select(x => x.Name).ToList();
            return Json(students, JsonRequestBehavior.AllowGet);
        }

        //Student/Index
        public PartialViewResult All()
        {
            System.Threading.Thread.Sleep(1000);
            List<Student> model = db.Students.ToList();
            return PartialView("_Student",model);
        }

        public PartialViewResult Top3()
        {
            System.Threading.Thread.Sleep(1000);
            List<Student> model = db.Students.OrderByDescending(x => x.TotalMarks).Take(3).ToList();
            return PartialView("_Student", model);
        }

        public PartialViewResult Bottom3()
        {
            System.Threading.Thread.Sleep(1000);
            List<Student> model = db.Students.OrderBy(x => x.TotalMarks).Take(3).ToList();
            return PartialView("_Student", model);
        }

        public ActionResult TCQ_Part98()
        {
            return View();
        }


    }
}