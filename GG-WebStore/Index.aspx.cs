using GG_WebStore.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GG_WebStore
{
    public partial class Index : System.Web.UI.Page
    {

        ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();
        protected void Page_Load(object sender, EventArgs e)
        {

            //Handle the command parsed.
            if (Request.QueryString["command"] != null)
            {
                string command = Request.QueryString["command"];
                switch (command)
                {
                    case "add_to_cart":
                        string proToAddId = Request.QueryString["ID"].ToString();
                        Debug.WriteLine("We found the product Id: " + proToAddId);
                        int product1 = Convert.ToInt32(proToAddId);
                        addToCart(product1);
                        break;
                }
            }


            dynamic ListProducts = client.getFeaturedProducts();
            string display = "";

            foreach (Product p in ListProducts)
            {
                display += "<div class='pro'>";
                display += "<a href='SingleProduct.aspx?ID=" + p.ProductId + "' > <img src='" + p.ProImage + "'> </a>";
                display += "<div class='des'>";
                display += "<h5 onclick='window.location.href='SingleProduct.aspx?ID=" + p.ProductId + "';>" + p.ProName + "</h5>";
                display += "<h4>R" + p.ProPrice.ToString("0.00") + "</h4>";
                display += "</div>";
                display += "<a href='Shop.aspx?command=add_to_cart&ID=" + p.ProductId + "'><i class='fas fa-shopping-cart cart'></i></a>";
                display += "</div>";

            }

            featured.InnerHtml = display;

            dynamic newArrivals = client.getNewArrivalProducts();
            string displayNew = "";

            foreach (Product p in newArrivals)
            {
                displayNew += "<div class='pro'>";
                displayNew += "<a href='SingleProduct.aspx?ID=" + p.ProductId + "' > <img src='" + p.ProImage + "'> </a>";
                displayNew += "<div class='des'>";
                displayNew += "<h5 onclick='window.location.href='SingleProduct.aspx?ID=" + p.ProductId + "';>" + p.ProName + "</h5>";
                displayNew += "<h4>R" + p.ProPrice.ToString("0.00") + "</h4>";
                displayNew += "</div>";
                displayNew += "<a href='Shop.aspx?command=add_to_cart&ID=" + p.ProductId + "'><i class='fas fa-shopping-cart cart'></i></a>";
                displayNew += "</div>";

            }

            IdnewArrivals.InnerHtml = displayNew;

        }

        private void addToCart(int proToAddId)
        {

            //Check if the user is logged in.
            if ((Session["LoggedIn"] == null) || !(bool)Session["LoggedIn"] || (Session["IsCustomer"] == null))
            {
                Response.Redirect("Login.aspx");
            }
            else
            {

                int userId = (int)Session["Id"];
                int productId = proToAddId;
                int quantity = 1;

                bool added = client.addProductToCart(userId, productId, quantity);
                if (added)
                {
                    //Must be changes, this is for testing
                    if (Session["cartItems"] == null)
                    {
                        Session["cartItems"] = 1;
                    }
                    else
                    {
                        int currentItems = (int)Session["cartItems"];
                        Session["cartItems"] = currentItems + 1;
                    }
                    Response.Redirect("ShoppingCart.aspx");
                }
                else
                {
                    Response.Redirect("Index.aspx");

                }
            }
        }
    }
}