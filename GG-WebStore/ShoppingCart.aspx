<%@ Page Title="" Language="C#" MasterPageFile="~/Master1.Master" AutoEventWireup="true" CodeBehind="ShoppingCart.aspx.cs" Inherits="GG_WebStore.ShoppingCart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="styles.css">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.4.0/css/all.min.css" integrity="sha512-iecdLmaskl7CVkqkXNQ/ZH/XLlvWZOJyj7Yy7tcenmpD1ypASozpmT/E0iPtmFIB46ZmdtAc9eNBvH0H/ZpiBw==" crossorigin="anonymous" referrerpolicy="no-referrer" />
    <link rel="stylesheet" href="https://fonts.googleapis.com/css2?family=Material+Symbols+Outlined:opsz,wght,FILL,GRAD@48,400,0,0" />
    <link rel="stylesheet" href="https://pro.fontawesome.com/releases/v5.10.0/css/all.css" />
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!--Banner at the Top-->
        <section id="banner" >
            <h4></h4>
            <h2>Check your<span>Shopping cart</span> at GroomedGents</h2> 
        </section><!--End of Banner at the top-->

    <section id="cart" class="section-p1">
            <table width="100%">
                <thead>
                    <tr>
                        <td>Remove</td>
                        <td>Image</td>
                        <td>Product</td>
                        <td>Price</td>
                        <td>Quantity</td>
                        <td>Subtotal</td>
                    </tr>
                    </thead>
                    <tbody id="idTableData" runat="server">
                       <%-- <tr>
                            <td><a href="#"><i class="far fa-times-circle"></i></a></td>
                            <td><img src="images/pro1-fragrance.jpg" alt=""></td>
                            <td>Coty Jovan Musk Men Cologne 118ml</td>
                            <td>R400</td>
                            <td><input type="number" value="1"></td>
                            <td>R400</td>
                        </tr>
                        <tr>
                            <td><a href="#"><i class="far fa-times-circle"></i></a></td>
                            <td><img src="images/pro1-fragrance.jpg" alt=""></td>
                            <td>Coty Jovan Musk Men Cologne 118ml</td>
                            <td>R400</td>
                            <td><input type="number" value="1"></td>
                            <td>R400</td>
                        </tr>
                        <tr>
                            <td><a href="#"><i class="far fa-times-circle"></i></a></td>
                            <td><img src="images/pro1-fragrance.jpg" alt=""></td>
                            <td>Coty Jovan Musk Men Cologne 118ml</td>
                            <td>R400</td>
                            <td><input type="number" value="1"></td>
                            <td>R400</td>
                        </tr>--%>
                    </tbody>
                <%--</thead>--%>
            </table>

        </section>

        <section id="cart-add" class="section-p1">
            <div id="coupon">
                <h3>Apply Coupon</h3>
                <div>
                    <input type="text" placeholder="Enter your coupon">
                    <button class="coupon-btn">Apply</button>
                </div>
            </div>

            <div id="subtotal" >
                <h3>Cart Totals</h3>
                <table>
                    <tr>
                        <td>Cart SubTotal</td>
                        <td ID="idSubtotal" runat="server">R 555</td>
                    </tr>
                     <tr>
                        <td>Discount</td>
                        <td ID="discount" runat="server">R0</td>
                    </tr>
                    <tr>
                        <td>Shipping</td>
                        <td ID="idShipping" runat="server">Free</td>
                    </tr>
                     <tr>
                        <td>VAT(15%)</td>
                        <td ID="idVat" runat="server">Free</td>
                    </tr>
                    <tr>
                        <td><strong>Total</strong></td>
                        <td ID="idTotal" runat="server">R555</td>
                    </tr>
                </table>
                <%--<button "coupon-btn">Proceed to checkout</button>--%>
                <asp:Button style="background-color: coral; color: #fff;padding: 12px 20px; border: none; cursor: pointer;" ID="Button1" runat="server" Text="Proceed to checkout" OnClick="Button1_Click1" />
            </div>
        </section>

    <script>

        var redirectUrl;
        // Function to update total price for a product row
        function updateTotalPrice(row) {

            var priceCell = row.querySelector(".product-price");
            var totalCell = row.querySelector(".product-total");
            var quantityInput = row.querySelector(".quantity-input");
            var productIdInput = row.querySelector(".product-id");
            var invoiceIdInput = row.querySelector(".invoice-id");

            var price = parseFloat(priceCell.textContent.replace("R", ""));
            var quantity = parseInt(quantityInput.value);
            var productId = productIdInput.value;
            var invoiceId = invoiceIdInput.value;

            if (!isNaN(price) && !isNaN(quantity)) {
                var totalPrice = price * quantity;
                totalCell.textContent = "R" + totalPrice.toFixed(2);

                // Construct the URL with parameters and redirect
                redirectUrl = 'ShoppingCart.aspx?command=updateCart&productId=' + productId + '&invoiceId=' + invoiceId + '&quantity=' + quantity;

            }
        }

        // Add event listeners for quantity inputs
        var quantityInputs = document.querySelectorAll(".quantity-input");
        quantityInputs.forEach(function (input) {
            input.addEventListener("input", function () {
                var productRow = this.closest(".product-row");
                updateTotalPrice(productRow);
                window.location.href = redirectUrl;
            });
        });

        // Calculate initial total prices for each product row
        var productRows = document.querySelectorAll(".product-row");
        productRows.forEach(function (row) {
            updateTotalPrice(row);
        });

    </script>

</asp:Content>
