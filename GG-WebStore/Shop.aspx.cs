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
    public partial class Shop : System.Web.UI.Page
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


            dynamic ListProducts = client.getAllProducts();
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

            lblProducts.InnerHtml = display;

            //Filtering by price 
            stPrice.ServerClick += new EventHandler(stPriceLink_Click);
            ndPrice.ServerClick += new EventHandler(ndPriceLink_Click);
            rdPrice.ServerClick += new EventHandler(rdPriceLink_Click);
            thPrice.ServerClick += new EventHandler(thPriceLink_Click);

            //Filtering by category
            shavingSupplier.ServerClick += new EventHandler(shavingSupplierLink_Click);
            Skincare.ServerClick += new EventHandler(SkincareLink_Click);
            Frangrances.ServerClick += new EventHandler(FrangrancesLink_Click);
            //Accessories.ServerClick += new EventHandler(AccessoriesLink_Click);
            //BodyCare.ServerClick += new EventHandler(BodyCareLink_Click);

            //Filtering by Brand
            Musk.ServerClick += new EventHandler(MuskLink_Click);
            MAN.ServerClick += new EventHandler(MANLink_Click);
            Nivea.ServerClick += new EventHandler(NiveaLink_Click);
            //Axe.ServerClick += new EventHandler(AxeLink_Click);

        }


        //FUnction to add the selected product to cart.
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

        private void NiveaLink_Click(object sender, EventArgs e)
        {
            FilterByBrand("Nivea");
        }



        private void MANLink_Click(object sender, EventArgs e)
        {
            FilterByBrand("MAN");
        }

        private void MuskLink_Click(object sender, EventArgs e)
        {
            FilterByBrand("Musk");
        }


       


        private void BodyCareLink_Click(object sender, EventArgs e)
        {
            FilterByCategory("Body care");
        }

        private void FrangrancesLink_Click(object sender, EventArgs e)
        {
            FilterByCategory("Fragrance");
        }


        private void SkincareLink_Click(object sender, EventArgs e)
        {
            FilterByCategory("Skincare");
        }

        private void shavingSupplierLink_Click(object sender, EventArgs e)
        {
            FilterByCategory("Shaving Supplies");
        }


        private void rdPriceLink_Click(object sender, EventArgs e)
        {
            FilterByPrice(501, 1000);
        }

        private void ndPriceLink_Click(object sender, EventArgs e)
        {
            FilterByPrice(201, 500);
        }

        private void stPriceLink_Click(object sender, EventArgs e)
        {
            FilterByPrice(50, 200);
        }

        //Filtering products by price.
        private void FilterByPrice(decimal min, decimal max)
        {
            
            var firstPrice = client.GetProductsByPriceRange(min, max);
            string display = "";
            foreach (Product p in firstPrice)
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

            lblProducts.InnerHtml = display;

        }

        //Filter by category
        private void FilterByCategory(string category)
        {
            var BodyCare = client.GetProductByCategory(category);
            string display = "";
            foreach (Product p in BodyCare)
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

            lblProducts.InnerHtml = display;
        }
        //Filter products by Brand
        private void FilterByBrand(string brand)
        {
            var BodyCare = client.GetProductByBrand(brand);
            string display = "";
            foreach (Product p in BodyCare)
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

            lblProducts.InnerHtml = display;
        }


        //Display all products
        private void thPriceLink_Click(object sender, EventArgs e)
        {
            dynamic ListProducts = client.getAllProducts();
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

            lblProducts.InnerHtml = display;
        }
    }
}