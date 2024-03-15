using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GG_WebStore
{
    public partial class Addproduct : System.Web.UI.Page
    {
        ServiceReference1.Service1Client serviceClient = new ServiceReference1.Service1Client();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAddProduct_Click(object sender, EventArgs e)
        {

            var NewProduct = serviceClient.AddProduct(txtUserName.Value, int.Parse(txtActive.Value), decimal.Parse(txtPrice.Value), txtImage.Value, decimal.Parse(txtDiscount.Value), int.Parse(cartId.Value), txtDescription.Value, int.Parse(txtBrandId.Value), int.Parse(txtStock.Value));
            if (NewProduct)
            {
                Response.Redirect("ProductManagement.aspx");
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Could not add product')", true);
            }

        }
    }
}