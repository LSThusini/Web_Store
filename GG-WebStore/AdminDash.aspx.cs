using GG_WebStore.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GG_WebStore
{
    public partial class AdminDash : System.Web.UI.Page
    {
        ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();
        protected void Page_Load(object sender, EventArgs e)
        {

            dynamic productsList = client.getAllProducts();
            string display = "";
            int count = 0;
            foreach(Product p in productsList)
            {
                if(count == 3)
                {
                    break;
                }
                //Display each of the products in the products table.
                display += "<tr>";
                display += "<td><a href='ShoppingCart.aspx?command=delete_item&ID=" + p.ProductId + "' ><i class='far fa-times-circle'></i></a></td>";
                display += "<td><img src='" + p.ProImage + "' alt=''></td>";
                display += "<td>" + p.ProName + "</td>";
                display += "<td class='product-price'>R" + p.ProPrice.ToString("0.00") + "</td>";  
                display += "<td class='product-total'>" + p.ProStock+ "</td>";
                display += "<td><a>Edit</a></td>";
                display += "</tr>";
                count++;
            }
            numProducts.InnerText = client.countProducts().ToString();

            idTableData.InnerHtml = display;

            // Attach the click event handler to the anchor tag.
            logoutLink.ServerClick += new EventHandler(LogoutLink_Click);

        }

        protected void LogoutLink_Click(object sender, EventArgs e)
        {
            // Clear the user's session to log them out.
            Session.Clear();
            Session.Abandon();

            // Redirect the user to the login page or any other desired page after logout.
            Response.Redirect("Login.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (UsersDatefilter != null)
            {
                string newDate = UsersDatefilter.Value;
                DateTime date = DateTime.Parse(newDate);

                int number = client.GenerateUserRegReport(date);
                numUsers.InnerText = number.ToString();
            }
        }
    }
}