using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TCQ_EmployeeService.Controllers
{
    [Authorize]
    public class EmployeeController : ApiController
    {
        public IEnumerable<Employee> Get()
        {
            using (EmployeeDBEntities db=new EmployeeDBEntities())
            {
                return db.Employees.ToList();
            }
        }
    }
}
