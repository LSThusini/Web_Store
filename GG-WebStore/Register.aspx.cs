using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GG_WebStore.ServiceReference1;

namespace GG_WebStore
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();
        protected void Button1_Click(object sender, EventArgs e)
        {
            //If the user is not logged in and is not an admin. Register user as Customer.
            if ((Session["LoggedIn"] == null) || !(bool)Session["LoggedIn"] ||
                (Session["IsCustomer"] == null))
            {


                if (!string.IsNullOrEmpty(txtUserName.Value) &&
                !string.IsNullOrEmpty(txtUserEmail.Value) &&
                !string.IsNullOrEmpty(txtUserPass.Value) &&
                !string.IsNullOrEmpty(txtconfirmPass.Value))
                {

                    User u = new User();
                    u.UserEmail = txtUserEmail.Value;
                    u.UserName = txtUserName.Value;
                    u.UserPass = txtUserPass.Value;
                    u.UserType = "C";

                    if (txtUserPass.Value.Equals(txtconfirmPass.Value))
                    {
                        bool r = client.UserRegister(u);
                        if (r)
                        {
                            response.InnerText = "Successfully Registered";
                            Response.Redirect("Login.aspx");
                        }
                        else
                        {
                            response.InnerText = "Email already exits!";
                        }

                    }
                    else
                    {
                        response.InnerText = "Password doesn't match";
                    }
                }
                else
                {
                    response.InnerText = "Fill in all the required fields.";
                }

            }
            else if((bool)Session["LoggedIn"] && !(bool)Session["IsCustomer"])
            {


                if (!string.IsNullOrEmpty(txtUserName.Value) &&
                !string.IsNullOrEmpty(txtUserEmail.Value) &&
                !string.IsNullOrEmpty(txtUserPass.Value) &&
                !string.IsNullOrEmpty(txtconfirmPass.Value))
                {

                    User u = new User();
                    u.UserEmail = txtUserEmail.Value;
                    u.UserName = txtUserName.Value;
                    u.UserPass = txtUserPass.Value;
                    u.UserType = "A";

                    if (txtUserPass.Value.Equals(txtconfirmPass.Value))
                    {
                        bool r = client.UserRegister(u);
                        if (r)
                        {
                            response.InnerText = "Successfully registered new admin";
                            
                        }
                        else
                        {
                            response.InnerText = "Email already exits!";
                        }

                    }
                    else
                    {
                        response.InnerText = "Password doesn't match";
                    }
                }
                else
                {
                    response.InnerText = "Fill in all the required fields.";
                }
            }



        }
    }
}