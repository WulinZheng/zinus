using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TCQ_MVCEF.Models
{

    public class DepartmentTotals
    {
        [Key]
        public string Name { get; set; }
        public int Total { get; set; }
    }
}