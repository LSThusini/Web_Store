using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GG_WebStore.ServiceReference1;
namespace GG_WebStore
{
    public partial class ProductManagement : System.Web.UI.Page
    {
        
        
            Service1Client sr = new Service1Client();
            protected void Page_Load(object sender, EventArgs e)
            {
                displayProduct();
            }

            protected void Page_LoadComplete(object sender, EventArgs e)
            {
                if (Request.QueryString["deleteID"] != null)
                {
                    int prodID = int.Parse(Request.QueryString["deleteID"]);
                    bool deleteProd = sr.DeleteProductById(prodID);
                    if (deleteProd)
                    {
                        displayProduct();
                    }
                    else
                    {
                        displayProduct();
                    }
                }
            }

            private void displayProduct()
            {
                var getProducts = sr.getAllProducts();
                String display = "";
                if (getProducts != null)
                {
                    display += "<tr>";
                    display += "<td>Delete Product</td>";
                    display += "<td>Image</td>";
                    display += "<td>Name</td>";
                    display += "<td>Price</td>";
                    display += "<td>Edit Product</td>";
                    display += "</tr>";
                    foreach (Product p in getProducts)
                    {

                        if (p != null)
                        {

                            display += "<tbody>";

                            display += "<tr>";
                            display += "<td><a href='?deleteID=" + p.ProductId + "'><i class='far fa-times-circle'></i></a></td>";
                            display += "<td><img src='" + p.ProImage + "' alt=''></td>";
                            display += "<td>" + p.ProName + "</td>";
                            display += "<td>R" + p.ProPrice + "</td>";
                            display += "<td><a href='Updateproduct.aspx?updateID=" + p.ProductId + "'>Update Products</a></td>";
                            display += "</tr>";

                            display += "</tbody>";

                        }
                    }
                    display += "<tr><td><a href='Addproduct.aspx'>Add Product</a></td></tr>";
                    tableDisplay.InnerHtml = display;
                }
            }
        }
}