<%@ Page Title="" Language="C#" MasterPageFile="~/Master1.Master" AutoEventWireup="true" CodeBehind="UpdateProduct.aspx.cs" Inherits="GG_WebStore.UpdateProduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

       <style>
        .register {
            align-items: center;
            justify-content: space-around;
            text-align: center;
            margin-top: 2%;
            max-width: 30%;
            margin-left: 30%;
            border: 1px solid grey;
            padding-bottom: 20px;
        }

            .register h1 {
                margin-bottom: 50px;
            }

            .register input {
                margin: 0;
                border: none;
                border-bottom: 1px solid gray;
                padding-right: 50px;
                padding-bottom: 10px;
                background-color: transparent;
            }


            .register p {
                font-size: 15px;
                font-weight: bold;
            }

            .register .response-message {
                font-size: 10px;
                font-weight: normal;
            }

            .register input {
                margin: 5px 0;
            }

            .register .register-button {
                font-size: 20px;
                padding: 10px 70px;
                border-radius: 10px;
                border: none;
                color: white;
                background-color: coral;
                margin-top: 30px;
                margin-bottom: 30px;
                cursor: pointer;
                transition: 0.2s ease;
            }

                .register .register-button:hover {
                    opacity: 0.8;
                }

                .register .register-button:active {
                    opacity: 0.5;
                }

        span {
            cursor: pointer;
            text-decoration: underline;
            transition: 0.2s ease;
        }

            span:hover {
                color: grey;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div class="register">
        <h1>Update Product</h1>
        <p>Name</p>
        <input placeholder="Enter your name" id="txtUserName" runat="server">
        <p>Active</p>
        <input placeholder="Enter 1 to indicate the product is active" id="txtActive" runat="server">
        <p>Price</p>
        <input type="number" placeholder="Enter Price" id="txtPrice" runat="server">
        <p>Image</p>
        <input type="text" placeholder="Enter image e.g image/productName.jpg" id="txtImage" runat="server">
        <p>Discount</p>
        <input type="number" placeholder="Enter Discount" id="txtDiscount" runat="server">
        <p>Category Id</p>
        <input type="number" placeholder="Type your password" id="cartId" runat="server">
        <p>Description</p>
        <input type="text" placeholder="Enter product description" id="txtDescription" runat="server">
        <p>Brand Id</p>
        <input type="text" placeholder="Enter brandId" id="txtBrandId" runat="server">
        <p>Product Stock</p>
        <input type="number" placeholder="Enter Stock number" id="txtStock" runat="server">
        <p class="response-message" id="response" runat="server"></p>

        <!--<button class="register-button" ID="btnRegister">Register</button> -->
        <asp:Button class="register-button" ID="btnUpdateProduct" runat="server" Text="Update Product" OnClick="btnUpdateProduct_Click" />
        <%-- <p>Have an account?<a href="login.html"><span>Add Product.</span></a></p>--%>
    </div>
    <br />
    <br />

</asp:Content>
