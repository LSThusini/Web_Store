using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GG_WebStore
{
    public partial class Checkout : System.Web.UI.Page
    {

        ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["vat"] != null && Session["total"] != null && Session["subtotal"] != null)
            {
                idVat.InnerText = "R" + Session["vat"].ToString();
                idTotal.InnerText = "R" + Session["total"].ToString();
                idsubtotal.InnerText = "R" + Session["subtotal"].ToString();
            }


        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(name.Value) &&
             !string.IsNullOrEmpty(email.Value) &&
             !string.IsNullOrEmpty(address.Value) &&
             !string.IsNullOrEmpty(city.Value) &&
             !string.IsNullOrEmpty(zipCode.Value))
            {

                if (Session["Id"] != null)
                {
                    string id = Session["Id"].ToString();
                    int invoiceId = client.getUncheackedInvoice(int.Parse(id));
                    bool isChecked = client.checkout(invoiceId);
                    if (isChecked)
                    {
                        Response.Redirect("PaymentConf.aspx");
                    }
                    else
                    {
                        Response.Redirect("ShoppingCart.aspx");
                    }

                }

            }
            else
            {
                results.InnerText = "Enter all fields!";
            }
        }
    }
}