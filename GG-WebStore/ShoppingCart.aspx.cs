using GG_WebStore.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GG_WebStore
{
    public partial class ShoppingCart : System.Web.UI.Page
    {

        ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();

        decimal subTotal = 0;
        double grandTotal = 0;
        double vatTotal = 0;
        protected void Page_Load(object sender, EventArgs e)
        {

            string checkCommand = Request.QueryString["command"];
            if (checkCommand != null)
            {
                switch (checkCommand)
                {
                    case "delete_item":
                        int prodId = int.Parse(Request.QueryString["ID"]);
                        deleteItem(prodId);
                        break;
                    case "updateCart":
                        string proToUpdate = Request.QueryString["productId"].ToString();
                        string invoiceToUpdate = Request.QueryString["invoiceId"].ToString();
                        string quantity = Request.QueryString["quantity"].ToString();
                        updateCart(int.Parse(invoiceToUpdate), int.Parse(proToUpdate), int.Parse(quantity));
                        break;
                }

            }


            //Check if there is a user that is logged in.
            //Display items on there shopping cart.
            int itemsCount = 0;
            if ((bool)Session["LoggedIn"])
            {
                int userId = (int)Session["Id"];
                dynamic cartList = client.getCarts(userId);

                if (cartList != null)
                {

                    string display = "";

                    foreach (InvoiceLine newCart in cartList)
                    {
                        int productId = newCart.ProductId;
                        int productQuantity = newCart.Quantity;
                        var singleProduct = client.GetSingleProduct(productId);
                        string proImage = singleProduct.ProImage;
                        decimal proPrice = singleProduct.ProPrice;
                        string proName = singleProduct.ProName;
                        decimal totalPrice = productQuantity * proPrice;
                        subTotal += totalPrice;
                        itemsCount++;




                        //Display each of the products in the cart table.
                        display += "<tr class='product-row'>";
                        display += "<td><a href='ShoppingCart.aspx?command=delete_item&ID=" + productId + "' ><i class='far fa-times-circle'></i></a></td>";
                        display += "<td><img src='" + proImage+"' alt=''></td>";
                        display += "<td>"+proName+"</td>";
                        display += "<td class='product-price'>R" + proPrice.ToString("0.00")+"</td>";
                        display += "<td><input style='width: 50px;' type='number' value='"+ productQuantity+"' class='quantity-input'></td>";
                        display += "<td class='product-total'>R" + totalPrice.ToString("0.00")+"</td>";
                        display += "<input type='hidden' class='invoice-id' value='" + client.getUncheackedInvoice(userId) + "'/>";
                        display += "<input type='hidden' class='product-id' value='" + productId + "'/>";
                        display += "</tr>";
                    }

                    idTableData.InnerHtml = display;

                    if(subTotal >= 500 && subTotal < 1000) //Free shipping if the total price in greater than R500.
                    {
                        double vat = 0.15;
                        vatTotal = (double)subTotal * vat;
                        grandTotal = (double)subTotal + vatTotal;
                        idVat.InnerText = "R" + vatTotal.ToString("0.00");
                        idShipping.InnerText = "Free";
                        idTotal.InnerText = "R" + grandTotal.ToString("0.00");
                        idSubtotal.InnerText = "R" + subTotal.ToString("0.00");


                    }
                    else if(subTotal >= 1000) //10% discount if the total price is greater than R1000
                    {

                        double vat = 0.15;
                        vatTotal = (double)subTotal * vat;
                        grandTotal = (double)subTotal + vatTotal;
                        idVat.InnerText = "R" + vatTotal.ToString("0.00");
                        idShipping.InnerText = "R0";
                        discount.InnerText = "-R" + (grandTotal * 0.10).ToString("0.00");
                        idTotal.InnerText = "R" + (grandTotal - (grandTotal * 0.10)).ToString("0.00");
                        idSubtotal.InnerText = "R" + subTotal.ToString("0.00");

                    }
                    else //If the price is less than R500 apply R100 shipping
                    {
                        double vat = 0.15;
                        vatTotal = (double)subTotal * vat;
                        grandTotal = (double)subTotal + vatTotal;
                        idVat.InnerText = "R" + vatTotal.ToString("0.00");
                        idShipping.InnerText = "R100";
                        idTotal.InnerText = "R" + (grandTotal + 100).ToString("0.00");
                        idSubtotal.InnerText = "R" + subTotal.ToString("0.00");

                    }
                   
      
                }

                Session["cartItems"] = itemsCount;
            }  
        }

        private void updateCart(int invoiceToUpdate, int proToUpdate, int quantity)
        {
            bool isUpdated = client.updateCart(invoiceToUpdate, proToUpdate, quantity);
            if (isUpdated)
            {
                Response.Redirect("ShoppingCart.aspx");
            }
            else
            {
                Response.Redirect("Index.aspx");
            }
        }

        private void deleteItem(int prodId)
        {
            string userId = Session["Id"].ToString();
            int uId = int.Parse(userId);
            bool isDeleted = client.deleteFromCart(uId, prodId);
            if (isDeleted)
            {
                Response.Redirect("ShoppingCart.aspx");
            }
            else
            {
                Response.Redirect("Index.aspx");
            }
        }

   

        protected void Button1_Click1(object sender, EventArgs e)
        {
            Session["vat"] = vatTotal.ToString("0.00");
            Session["total"] = grandTotal.ToString("0.00");
            Session["subtotal"] = subTotal.ToString("0.00");

            Response.Redirect("Checkout.aspx");

        }
    }
}