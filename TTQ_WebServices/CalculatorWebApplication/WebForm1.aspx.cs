using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CalculatorWebApplication
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            CalculatorService.TCQ_CalculatorWebServiceSoapClient client 
                = new CalculatorService.TCQ_CalculatorWebServiceSoapClient();
            int result=client.TCQ_Add(Convert.ToInt32(txtFirstNumber.Text), Convert.ToInt32(txtSecondNumber.Text));
            lblResult.Text = result.ToString();

            gvCalculations.DataSource = client.TCQ_GetCalculations();
            gvCalculations.DataBind();
            gvCalculations.HeaderRow.Cells[0].Text = "Recent Calculations";

        }
    }
}