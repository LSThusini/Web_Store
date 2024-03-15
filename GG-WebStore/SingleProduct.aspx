<%@ Page Title="" Language="C#" MasterPageFile="~/Master1.Master" AutoEventWireup="true" CodeBehind="SingleProduct.aspx.cs" Inherits="GG_WebStore.SingleProduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <title>Groomed Gents</title>
    <link rel="stylesheet" href="styles.css">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.4.0/css/all.min.css" integrity="sha512-iecdLmaskl7CVkqkXNQ/ZH/XLlvWZOJyj7Yy7tcenmpD1ypASozpmT/E0iPtmFIB46ZmdtAc9eNBvH0H/ZpiBw==" crossorigin="anonymous" referrerpolicy="no-referrer" />
    <link rel="stylesheet" href="https://fonts.googleapis.com/css2?family=Material+Symbols+Outlined:opsz,wght,FILL,GRAD@48,400,0,0" />
    <link rel="stylesheet" href="https://pro.fontawesome.com/releases/v5.10.0/css/all.css" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!--Banner at the Top-->
        <section id="banner" >
            <h4></h4>
            <h2>More about<span>Product</span>.</h2> 
        </section><!--End of Banner at the top-->

    <!----Single Product-->
        <section class="singleContainer" id="pro1" runat="server">
           <%-- <div type='hidden' class="pro-image">
                <img src="images/pro1-fragrance.jpg" width="100%">
            </div>
            <div type='hidden' class="pro-desripction">
                <h5>Home/Cologne</h5>
                <h4>Coty Jovan Musk Men Cologne 118ml</h4>
                <h2>R400</h2>
                <input type="number" value="1"="quantity">
                
                <button class="add-to-cart-button">Add To Cart</button>
                <h3>Description</h3>
                <p>Coty jovan musk men cologne perfume 118ml has 
                    a manly aroma that is ideal for a romantic mood. You can a
                    lso apply this cologne anytime, or before attending any kind of party. 
                    The best thing about this beauty product is that it works well on the body, 
                    producing a manly smell that is perfect mixture of ingredients like spices and woods.
                     It has top notes of black pepper, amalfi lemon, carnation, lime.
                     Middle notes of spearmint, lavender, amber, spice notes. Base notes of musk, woody notes
                </p>
            </div>--%>

        </section>
        

        <!--Featured products-->
        <section id="product1" class="section-p1">
            <h2>Featured Products</h2>
            <p>Fregrances and skin care</p>
            <div id="featured" runat="server" class="pro-container">

                <%--<div class="pro" onclick="window.location.href='product2_descr.html';">
                    <img src="images/pro2_facewash.jpg">
                    <div class="des">
                        <span>man</span>
                        <h5>facewash for all skin</h5>
                        <div class="star">
                            <i class="fas fa-star"></i>
                            <i class="fas fa-star"></i>
                            <i class="fas fa-star"></i>
                            <i class="fas fa-star"></i>
                            <i class="fas fa-star"></i>
                        </div>
                        <h4>R112</h4>
                    </div>
                    <a href="#"><i class="fas fa-shopping-cart cart"></i></a>
                </div>

                <div class="pro" onclick="window.location.href='product3_descr.html';">
                    <img src="images/pro3-azaro.jpg">
                    <div class="des">
                        <span>azaro</span>
                        <h5>naturally made smell</h5>
                        <div class="star">
                            <i class="fas fa-star"></i>
                            <i class="fas fa-star"></i>
                            <i class="fas fa-star"></i>
                            <i class="fas fa-star"></i>
                            <i class="fas fa-star"></i>
                        </div>
                        <h4>R2000</h4>
                    </div>
                    <a href="#"><i class="fas fa-shopping-cart cart"></i></a>
                </div>

                <div class="pro">
                    <img src="images/pro4-vitamins.file">
                    <div class="des">
                        <span>pure man</span>
                        <h5>rejuvinate your bed time pleasure</h5>
                        <div class="star">
                            <i class="fas fa-star"></i>
                            <i class="fas fa-star"></i>
                            <i class="fas fa-star"></i>
                            <i class="fas fa-star"></i>
                            <i class="fas fa-star"></i>
                        </div>
                        <h4>R200</h4>
                    </div>
                    <a href="#"><i class="fas fa-shopping-cart cart"></i></a>
                </div>

                <div class="pro">
                    <img src="images/pro3-hairMosturizer.file">
                    <div class="des">
                        <span>manonly</span>
                        <h5>hair treatment</h5>
                        <div class="star">
                            <i class="fas fa-star"></i>
                            <i class="fas fa-star"></i>
                            <i class="fas fa-star"></i>
                            <i class="fas fa-star"></i>
                            <i class="fas fa-star"></i>
                        </div>
                        <h4>R80</h4>
                    </div>
                    <a href="#"><i class="fas fa-shopping-cart cart"></i></a>
                </div>--%>
            </div>
        </section>

</asp:Content>
