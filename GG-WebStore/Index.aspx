<%@ Page Title="" Language="C#" MasterPageFile="~/Master1.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="GG_WebStore.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--Display Picture -->
        <div class="banner_card">
            <img src="images/D2-removebg-preview.png">
            <div class="banner_text">
                <h2>Re-ignite your musculinity with </h2>
                <h1>Groomed Gents</h1>
                <button class="shopnow-button" onclick="window.location.href='Shop.aspx';">Shop Now</button>
            </div>
        </div>

        <!--Features-->
        <section id="feature">
            <div class="fe-box">
                <img src="images/features/f1.png" alt="">
                <h6>Free Shipping</h6>
            </div>
            <div class="fe-box">
                <img src="images/features/f2.png" alt="">
                <h6>Online Order</h6>
            </div>
            <div class="fe-box">
                <img src="images/features/f3.png" alt="">
                <h6>Save Money</h6>
            </div>
            <div class="fe-box">
                <img src="images/features/f4.png" alt="">
                <h6>Promotions</h6>
            </div>
             <div class="fe-box">
                <img src="images/features/f5.png" alt="">
                <h6>Happy Sell</h6>
            </div>
            

        </section>
    

        <!--Featured Products-->
        <section id="product1" class="section-p1" >
            <h2>Featured Products</h2>
            <p>Scent and skincare collection New Designs</p>

            <!--Products Container-->
            <div Id="featured" runat="server" class="pro-container">

                    <!--Single product-->
                    <%--<div class="pro" onclick="window.location.href='product1_descr.html';">
                        <img src="images/pro1-fragrance.jpg">
                        <div class="des">
                            <span>musk</span>
                            <h5>nice smelling fragrance</h5>
                            <div class="star">
                                <i class="fas fa-star"></i>
                                <i class="fas fa-star"></i>
                                <i class="fas fa-star"></i>
                                <i class="fas fa-star"></i>
                                <i class="fas fa-star"></i>
                            </div>
                            <h4>R400</h4>
                        </div>
                        <a href="#"><i class="fal fa-shopping-cart cart"></i></a>
                    </div>
               

                <div class="pro" onclick="window.location.href='product2_descr.html';">
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
                </div>

                <div class="pro">
                    <img src="images/pro6-nourish.jpg">
                    <div class="des">
                        <span>ESEE</span>
                        <h5>body loation</h5>
                        <div class="star">
                            <i class="fas fa-star"></i>
                            <i class="fas fa-star"></i>
                            <i class="fas fa-star"></i>
                            <i class="fas fa-star"></i>
                            <i class="fas fa-star"></i>
                        </div>
                        <h4>R900</h4>
                    </div>
                    <a href="#"><i class="fas fa-shopping-cart cart"></i></a>
                </div>

                <div class="pro">
                    <img src="images/pro7.jpg">
                    <div class="des">
                        <span>neoutrogena</span>
                        <h5>hydrate with hydro booster</h5>
                        <div class="star">
                            <i class="fas fa-star"></i>
                            <i class="fas fa-star"></i>
                            <i class="fas fa-star"></i>
                            <i class="fas fa-star"></i>
                            <i class="fas fa-star"></i>
                        </div>
                        <h4>R800</h4>
                    </div>
                    <a href="#"><i class="fas fa-shopping-cart cart"></i></a>
                </div>

                <div class="pro">
                    <img src="images/pro8.jpg">
                    <div class="des">
                        <span>SPP</span>
                        <h5>skin combo</h5>
                        <div class="star">
                            <i class="fas fa-star"></i>
                            <i class="fas fa-star"></i>
                            <i class="fas fa-star"></i>
                            <i class="fas fa-star"></i>
                            <i class="fas fa-star"></i>
                        </div>
                        <h4>R3000</h4>
                    </div>
                    <a href="#"><i class="fas fa-shopping-cart cart"></i></a>
                </div>--%>

            </div>

        </section><!--End of featured product-->

        <section id="banner" class="section-m1">
            <h4></h4>
            <h2>Up to <span>70% OFF</span>-all Skincare & Hairgrooming</h2>
            <button class="normal">Explore More</button>
        </section>

         <!--New Arrival Products-->
         <section id="product1" >
            <h2>New Arrival</h2>
            <p>Scent and skincare collection New Designs</p>

            <!--Products Container-->
            <div ID="IdnewArrivals" runat="server" class="pro-container">

                    <!--Single product-->
                   <%-- <div class="pro" onclick="window.location.href='product1_descr.html';">
                        <img src="images/pro1-fragrance.jpg">
                        <div class="des">
                            <span>musk</span>
                            <h5>nice smelling fragrance</h5>
                            <div class="star">
                                <i class="fas fa-star"></i>
                                <i class="fas fa-star"></i>
                                <i class="fas fa-star"></i>
                                <i class="fas fa-star"></i>
                                <i class="fas fa-star"></i>
                            </div>
                            <h4>R400</h4>
                        </div>
                        <a href="#"><i class="fas fa-shopping-cart cart"></i></a>
                    </div>
               

                <div class="pro" onclick="window.location.href='product2_descr.html';">
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
                </div>

                <div class="pro">
                    <img src="images/pro6-nourish.jpg">
                    <div class="des">
                        <span>ESEE</span>
                        <h5>body loation</h5>
                        <div class="star">
                            <i class="fas fa-star"></i>
                            <i class="fas fa-star"></i>
                            <i class="fas fa-star"></i>
                            <i class="fas fa-star"></i>
                            <i class="fas fa-star"></i>
                        </div>
                        <h4>R900</h4>
                    </div>
                    <a href="#"><i class="fas fa-shopping-cart cart"></i></a>
                </div>

                <div class="pro">
                    <img src="images/pro7.jpg">
                    <div class="des">
                        <span>neoutrogena</span>
                        <h5>hydrate with hydro booster</h5>
                        <div class="star">
                            <i class="fas fa-star"></i>
                            <i class="fas fa-star"></i>
                            <i class="fas fa-star"></i>
                            <i class="fas fa-star"></i>
                            <i class="fas fa-star"></i>
                        </div>
                        <h4>R800</h4>
                    </div>
                    <a href="#"><i class="fas fa-shopping-cart cart"></i></a>
                </div>

                <div class="pro">
                    <img src="images/pro8.jpg">
                    <div class="des">
                        <span>SPP</span>
                        <h5>skin combo</h5>
                        <div class="star">
                            <i class="fas fa-star"></i>
                            <i class="fas fa-star"></i>
                            <i class="fas fa-star"></i>
                            <i class="fas fa-star"></i>
                            <i class="fas fa-star"></i>
                        </div>
                        <h4>R3000</h4>
                    </div>
                    <a href="#"><i class="fas fa-shopping-cart cart"></i></a>
                </div>--%>

            </div>

        </section><!--End of new arrivals product container-->
</asp:Content>
