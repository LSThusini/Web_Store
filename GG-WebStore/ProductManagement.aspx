<%@ Page Title="" Language="C#" MasterPageFile="~/Master1.Master" AutoEventWireup="true" CodeBehind="ProductManagement.aspx.cs" Inherits="GG_WebStore.ProductManagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

     <link rel="stylesheet" href="styles.css">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.4.0/css/all.min.css" integrity="sha512-iecdLmaskl7CVkqkXNQ/ZH/XLlvWZOJyj7Yy7tcenmpD1ypASozpmT/E0iPtmFIB46ZmdtAc9eNBvH0H/ZpiBw==" crossorigin="anonymous" referrerpolicy="no-referrer" />
    <link rel="stylesheet" href="https://fonts.googleapis.com/css2?family=Material+Symbols+Outlined:opsz,wght,FILL,GRAD@48,400,0,0" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section id="cart"  section-p1"> 
        
            <!--Banner at the Top-->
        <section id="banner" >
            <h4></h4>
            <h2>Manage<span>Inventory</span> at GroomedGents</h2> 
        </section><!--End of Banner at the top-->
                
                    <table width="100%">
                <thead id="tableDisplay" runat="server">
                    <tr>
                        <td>Delete Product</td>
                        <td>Image</td>
                        <td>Name</td>
                        <td>Price</td>
                        <td>Discount</td>
                        <td>Edit Product</td>
                    </tr>
                  
                    <tbody>  
                        <tr>
                            <td><a href="#"><i class="far fa-times-circle"></i></a></td>
                            <td><img src="images/pro1-fragrance.jpg" alt=""></td>
                            <td>Coty Jovan Musk Men Cologne 118ml</td>
                            <td>R400</td>
                            <td>R82</td>
                            <td><a href="#">Update Products</a></td>
                        </tr> 
                    </tbody>
                       <tr>
                            <td><a href="#">Add Product</a></td>
                        </tr>
                </thead>
            </table>
    </section>
</asp:Content>
