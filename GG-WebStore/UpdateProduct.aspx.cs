using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GG_WebStore
{
    public partial class UpdateProduct : System.Web.UI.Page
    {

        ServiceReference1.Service1Client serviceClient = new ServiceReference1.Service1Client();
        protected void Page_Load(object sender, EventArgs e)
        {


        }


        protected void btnUpdateProduct_Click(object sender, EventArgs e)
        {

            //Check if the updateId query string parameter is present in the URL
            if (Request.QueryString["updateID"] != null)
            {
                //Extract the productId from the query string and parse it to an integer
                int productId = int.Parse(Request.QueryString["updateID"]);
                // Call the "EditProduct" method to update the product with the provided values.
                // The values are obtained from the corresponding text fields on the page.

                var update = serviceClient.EditProduct(productId, txtUserName.Value, int.Parse(txtActive.Value), decimal.Parse(txtPrice.Value), txtImage.Value, decimal.Parse(txtDiscount.Value), int.Parse(cartId.Value), txtDescription.Value, int.Parse(txtBrandId.Value), int.Parse(txtStock.Value));
                //Check if the product update was sucessful
                if (update)
                {
                    // Redirect to the "managerpage.aspx" after a successful update.
                    Response.Redirect("ProductManagement.aspx");
                }
                else
                {
                    // Display an alert message if the update was not successful.
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Could not Update product')", true);
                }

            }
        }

    }
}