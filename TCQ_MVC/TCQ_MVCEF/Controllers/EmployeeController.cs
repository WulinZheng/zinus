using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TCQ_MVCEF.Models;
using System.Text;
using PagedList;
using PagedList.Mvc;
using TCQ_MVCEF.Common;

namespace TCQ_MVCEF.Controllers
{
    public class EmployeeController : Controller
    {
        private EmployeeEntities db = new EmployeeEntities();

        [TrackExecutionTime]
        public ActionResult Index(string searchBy,string search,int ? page,string sortBy)
        {

            System.Threading.Thread.Sleep(3000);
            ViewBag.SortName = string.IsNullOrEmpty(sortBy) ? "Name desc" : "";
            ViewBag.SortGender = sortBy=="Gender" ? "Gender desc" : "Gender";

            var employees = db.Employees.AsQueryable();

            if (searchBy == "Gender")
            {
                employees = employees.Where(x => x.Gender == search||search==null);
            }
            else
            {
                employees = employees.Where(x=>x.Name.StartsWith(search)||search==null);

            }

            switch (sortBy)
            {
                case "Name desc":
                    employees = employees.OrderByDescending(x=>x.Name);
                    break;
                case "Gender desc":
                    employees = employees.OrderByDescending(x => x.Gender);
                    break;
                case "desc":
                    employees = employees.OrderBy(x => x.Name);
                    break;
                default:
                    employees = employees.OrderBy(x=>x.Name);
                    break;
            }

            return View(employees.ToPagedList(page ?? 1, 3));

        }

        [ChildActionOnly]
        [PartialCache("1MinuteCache")]
        public string GetEmployeeCount()
        {
            return "Employee Count = " + db.Employees.Count().ToString()
                + "@ " + DateTime.Now.ToString();
        }

        public ActionResult PartialIndex()
        {

            var employees = db.Employees.Include(e => e.Department);
            return View(employees.ToList()); 
            
        }

        [HttpGet]
        public ActionResult Company()//radiobutton
        {

            Company company = new Company();
            return View(company);
        }

        [HttpPost]
        public string Company(Company company)
        {
            if (string.IsNullOrEmpty(company.SelectDepartment))
            {
                return "You did not select any department";
            }
            else
            {
                return "You selected department with ID = " + company.SelectDepartment;
            }
        }
        [HttpGet]
        public ActionResult Cities()
        {
            EmployeeEntities employeeEntities = new EmployeeEntities();
            return View(employeeEntities.Cities);
        }

        [HttpPost]
        public string Cities(IEnumerable<City> cities)
        {
            if (cities.Count(x => x.IsSelected) == 0)
            {
                return "You didn't select any city";
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("You select - ");
                foreach (City city in cities)
                {
                    if (city.IsSelected)
                    {
                        sb.Append(city.Name+", ");
                    }
                }
                sb.Remove(sb.ToString().LastIndexOf(","), 1);
                return sb.ToString();
            }
        }

        public ActionResult TCQ_Part40(int id)
        {
            EmployeeEntities employeeEntities = new EmployeeEntities();
            Employee employee= employeeEntities.Employees.Single(em=>em.EmployeeId==id);
            return View(employee);
        }
        
        

        public ActionResult EmployeeByDepartment()
        {
            var employees = db.Employees.Include(e => e.Department).GroupBy(x => x.Department.Name)
                .Select(y => new DepartmentTotals
                {
                    Name = y.Key,
                    Total = y.Count()
                }).ToList().OrderByDescending(y=>y.Total) ;
            return View(employees);
        }

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "Name");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeId,Name,Gender,City,DepartmentId")] Employee employee)
        {
            if (string.IsNullOrEmpty(employee.Name))
            {
                ModelState.AddModelError("Name","The Name field is required");
            }
            if (ModelState.IsValid)
            {
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "Name", employee.DepartmentId);
            //List<SelectListItem> selectListItems = new List<SelectListItem>();

            //foreach (Department department in db.Departments)
            //{
            //    SelectListItem selectListItem = new SelectListItem
            //    {
            //        Text = department.Name,
            //        Value = department.Id.ToString(),
            //        Selected = department.IsSelected.HasValue ? department.IsSelected.Value : false
            //    };
            //    selectListItems.Add(selectListItem);
            //}

            //ViewBag.DepartmentId = selectListItems;

            return View(employee);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "Name", employee.DepartmentId);
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Exclude="Name" /*Include = "EmployeeId,Name,Gender,City,DepartmentId"*/)] Employee employee)
        {
            Employee employeefromDB = db.Employees.Single(em=>em.EmployeeId==employee.EmployeeId);
            employeefromDB.Gender = employee.Gender;
            employeefromDB.City = employee.City;
            employeefromDB.DepartmentId = employee.DepartmentId;
            employee.Name = employeefromDB.Name;
            employeefromDB.HireDate = employee.HireDate;

            if (ModelState.IsValid)
            {
                db.Entry(employeefromDB).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "Name", employee.DepartmentId);
            return View(employee);
        }

        // GET: Employees/Delete/5
        [HttpPost]
        public ActionResult Delete(IEnumerable<int> employeeIdToDelete)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //Employee employee = db.Employees.Find(id);
            //if (employee == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(employee);

            List<Employee> listToDelete = new List<Employee>();
            listToDelete = db.Employees.Where(x => employeeIdToDelete.Contains(x.EmployeeId)).ToList();
            foreach (var itemDel in listToDelete)
            {
                foreach (var item in db.Employees)
                {
                    if (itemDel.EmployeeId == item.EmployeeId)
                        db.Employees.Remove(item);
                }
            }
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        // POST: Employees/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Employee employee = db.Employees.Find(id);
        //    db.Employees.Remove(employee);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
