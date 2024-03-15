using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GG_WebStore
{
    public partial class Login : System.Web.UI.Page
    {
        // Create an instance of the WCF service client
        ServiceReference1.Service1Client serviceClient = new ServiceReference1.Service1Client();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string userEmail = txtUserEmail.Value.Trim();
            string password = txtPassword.Value;

            //Store the userType 
            char result = serviceClient.UserLogin(userEmail, password);

            //redirect the user to the appropriate page based on the authentication result
            if (result == 'C')
            {
                Session["LoggedIn"] = true;
                Session["IsCustomer"] = true;
                Session["Id"] = serviceClient.getUser(userEmail).UserId;
                Response.Redirect("Index.aspx");
            }
            else if (result == 'A')
            {
                Session["LoggedIn"] = true;
                Session["IsCustomer"] = false;
                Session["Id"] = serviceClient.getUser(userEmail).UserId;
                Response.Redirect("AdminDash.aspx");
            }
            else if (result == 'E')
            {
                lblResult.InnerText = "Incorrect Email or password!";
            }
            else
            {
                // Handle failed login, e.g., display an error message
                lblResult.InnerText = "Incorrect Email or password!";
            }

            // Close the service client
            serviceClient.Close();
        }
    }
}