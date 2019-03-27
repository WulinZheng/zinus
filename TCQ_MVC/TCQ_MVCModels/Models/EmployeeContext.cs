using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace TCQ_MVCModels.Models
{
    public class EmployeeContext : DbContext
    {
        // Replace square brackets, with angular brackets
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}