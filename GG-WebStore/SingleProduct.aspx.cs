using GG_WebStore.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GG_WebStore
{
    public partial class SingleProduct : System.Web.UI.Page
    {

        ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();

        int newProductID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            //Handle the command parsed.
            if (Request.QueryString["command"] != null)
            {
                string command = Request.QueryString["command"];
                switch (command)
                {
                    case "add_to_cart":
                        int proToAddId = int.Parse(Request.QueryString["ID"]);
                        addToCart(proToAddId);
                        break;
                    //case "add_to_wish":
                    //    int proIdToWish = int.Parse(Request.QueryString["ID"]);
                    //    arrayWishlistProducts.Add(proIdToWish);
                    //    break;
                }
            }

            string newProId = Request.QueryString["ID"];
            if(newProId != null)
            {
                newProductID = int.Parse(newProId);
                var newProduct = client.GetSingleProduct(newProductID);
                if(newProduct != null)
                {
                    string displayNew = "";

                    displayNew += "<div class='pro-image'>";
                    displayNew += "<img src='" + newProduct.ProImage+"' width='100%'>";
                    displayNew += "</div>";
                    displayNew += "<div class='pro-desripction'>";
                    displayNew += "<h5>Home/</h5>";
                    displayNew += "<h4>"+ newProduct.ProName+"</h4>";
                    displayNew += "<h2>R"+newProduct.ProPrice.ToString("0.00")+"</h2>";
                    displayNew += "<input type='number' value='1'='quantity'>";
                    displayNew += "<a href='SingleProduct.aspx?command=add_to_cart&ID=" + newProduct.ProductId + "' class='add-to-cart-button'>Add To Cart</i></a>";
                    // displayNew += "<a href='SingleProduct.aspx?command=add_to_cart&ID="+newProduct.ProductId+"'> <button class='add-to-cart-button'>Add To Cart</button> </a>";
                    displayNew += "<h3>Description</h3> ";
                    displayNew += "<p> "+newProduct.ProDescr+" </p>";
                    displayNew += "</div>";

                    pro1.InnerHtml = displayNew;
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

        }


        private void addToCart(int proToAddId)
        {
            //Check if there user is logged in.
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("SingleProduct.aspx?command=add_to_cart&ID=" + newProductID);
        }
    }
}