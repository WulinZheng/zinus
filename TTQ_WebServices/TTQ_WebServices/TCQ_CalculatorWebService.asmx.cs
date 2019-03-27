using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace TTQ_WebServices
{
    /// <summary>
    /// Summary description for TCQ_CalculatorWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class TCQ_CalculatorWebService : System.Web.Services.WebService
    {

        [WebMethod(EnableSession =true, Description ="This method adds 2 numbers",CacheDuration =20)]
        public int TCQ_Add(int firstNumber,int secondNumber)
        {
            List<string> calculations;
            if (Session["CALCULATIONS"] == null)
            {
                calculations = new List<string>();
            }
            else
            {
                calculations = (List<string>)Session["CALCULATIONS"];
            }
            string strRecentCal = firstNumber.ToString() + "+" + secondNumber.ToString() + 
                "=" + (firstNumber + secondNumber).ToString();
            calculations.Add(strRecentCal);
            Session["CALCULATIONS"] = calculations;

            return firstNumber + secondNumber;
        }

        [WebMethod(EnableSession =true)]
        public List<string> TCQ_GetCalculations()
        {
            if (Session["CALCULATIONS"] == null)
            {

                List<string> calculations = new List<string>();
                calculations.Add("You have not performed any calculations");
                return calculations;
            }
            else
            {
                return (List<string>)Session["CALCULATIONS"];
            }
        }

    }
}
