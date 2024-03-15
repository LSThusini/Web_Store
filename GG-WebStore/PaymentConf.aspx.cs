using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GG_WebStore
{
    public partial class PaymentConf : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void viewInvoices_Click(object sender, EventArgs e)
        {
            Response.Redirect("Invoices.aspx");
        }

        protected void shop_Click(object sender, EventArgs e)
        {
            Response.Redirect("Shop.aspx");
        }
    }
}