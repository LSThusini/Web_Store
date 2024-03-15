using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GG_WebStore
{
    public partial class Master1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if ((Session["LoggedIn"] == null) || !(bool)Session["LoggedIn"] || (Session["IsCustomer"] == null))
            {
                UserProfile.Visible = false;
                Logout.Visible = false;
                Inventory.Visible = false;
                Customers.Visible = false;
                Cart.Visible = false;
                Reports.Visible = false;
                Log.Visible = true;
                Reg.Visible = true;

            }
            else
            {
                if ((bool)Session["IsCustomer"])
                {
                    UserProfile.Visible = true;
                    Logout.Visible = true;
                    Cart.Visible = true;
                    Inventory.Visible = false;
                    Customers.Visible = false;
                    Reports.Visible = false;
                    Reg.Visible = false;
                    Log.Visible = false;
                    Reg.Visible = false;
                }
                else
                {
                    UserProfile.Visible = false;
                    Logout.Visible = true;
                    Cart.Visible = false;
                    UserShop.Visible = false;
                    Inventory.Visible = true;
                    Customers.Visible = false;
                    Reports.Visible = false;
                    Log.Visible = false;
                    Reg.Visible = false;
                }
            }

            if(Session["cartItems"] != null)
            {
                string cartItems = Session["cartItems"].ToString();
                cart_items.InnerText = cartItems;
            }

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
    }
}