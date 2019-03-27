using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TCQ_MVCEF.Models
{
    public class CitiesViewModel
    {
        [Key]
        public IEnumerable<string> SelectedCities { get; set; }
        public IEnumerable<SelectListItem> Cities { get; set; }
    }
}