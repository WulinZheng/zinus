using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TCQ_MVCEF.Models
{
    public class Company
    {
        [Key]
        public string SelectDepartment { get; set; }
        public List<Department> Departments
        {
            get
            {
                EmployeeEntities db = new EmployeeEntities();
                return db.Departments.ToList();
            }
        }
    }
}