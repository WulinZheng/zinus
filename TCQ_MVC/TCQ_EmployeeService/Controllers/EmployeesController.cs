using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EmployeeDataAccess;

namespace TCQ_EmployeeService.Controllers
{
    public class EmployeesController : ApiController
    {
        public IEnumerable<Employee> Get()
        {
            using (EmployeeDBEntities context=new EmployeeDBEntities())
            {
                return context.Employees.ToList();
            }
        }

        public Employee Get(int id)
        {
            using (EmployeeDBEntities context = new EmployeeDBEntities())
            {
                return context.Employees.FirstOrDefault(em => em.ID == id);
            }
        }

    }
}
