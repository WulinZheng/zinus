using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TCQ_MVCEF.Common
{
    public class DataRangeAttribute:RangeAttribute
    {
        public DataRangeAttribute(string minimunValue)
            :base(typeof(DateTime), minimunValue, DateTime.Now.ToShortDateString())
        {

        }
    }
}