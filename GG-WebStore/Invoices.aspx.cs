using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GG_WebStore.ServiceReference1;

namespace GG_WebStore
{
    public partial class Invoices : System.Web.UI.Page
    {
        Service1Client sr = new Service1Client();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Id"] != null)
            {
                string html = "";
                string Id = Session["Id"].ToString();
                var invoices = sr.GetInvoices(int.Parse(Id));
                int i = 1;
                if (invoices != null)
                {
                    foreach (Invoice inv in invoices)
                    {
                        if (inv.Checked == 1)
                        {
                            html += "<div class='inv-content'>";
                            html += "<h3>Invoice " + i + "</h3>";
                            html += "<div class='ic'><table style='width: 100%'><tr><th>Product</th><th>Quantity</th><th>VAT</th><th>Total</th></tr>";
                            var lines = sr.GetInvoiceLines(inv.InvoiceId);
                            decimal total = Math.Round(sr.getInvoiceTotalPrice(inv.InvoiceId), 2);
                            foreach (InvoiceLineStruct ils in lines)
                            {
                                int i2 = 0;
                                foreach (InvoiceLine il in ils.ILS_InvoiceLine)
                                {
                                    html += "<tr><td>" + ils.ILS_Prod[i2].ProName + "</td><td>"
                                        + il.Quantity + "</td><td>" + "15%</td>"
                                        + "<td>R" + Math.Round(il.Quantity * ils.ILS_Prod[i2].ProPrice, 2) + "</td></tr>";
                                    i2++;
                                }
                            }
                            if (total > 1000)
                            {
                                html += "</table></div><p>10% Discount   </p><p>Total: R" + total + "</p>";
                            }
                            else if (total > 500 && total <= 1000)
                            {
                                html += "</table></div><p>Free Shipping   </p><p>Total: R" + total + "</p>";
                            }
                            else
                            {
                                html += "</table></div><p>Total: R" + total + "</p>";
                            }
                            html += "</div>";
                            i++;
                        }
                    }

                    invoices_container.InnerHtml = html;
                }
            }
        }
    }
}