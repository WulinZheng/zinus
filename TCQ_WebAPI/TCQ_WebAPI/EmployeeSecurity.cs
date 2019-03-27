using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TCQ_EmployeeDataAccess;

namespace TCQ_WebAPI
{
    public class EmployeeSecurity
    {
        public static bool Login(string username,string password)
        {
            using (EmployeeDBEntities db=new EmployeeDBEntities())
            {
                return db.Users.Any(x=>x.Username.Equals(username,StringComparison.OrdinalIgnoreCase) &&
                 x.Password==password);

            }
        }
    }
}