<%@ Page Title="" Language="C#" MasterPageFile="~/Master1.Master" AutoEventWireup="true" CodeBehind="Shop.aspx.cs" Inherits="GG_WebStore.Shop" %>
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
            <h2>Shopping <span>Experience</span> with GroomedGents</h2> 
        </section><!--End of Banner at the top-->
        
        <!--Products-->
        <section id="product1" class="section-p1">
            <h2>Our Products</h2>
            <p>Here you can checkout our new products with fair price on GroomedGents</p>
            <div class="filters-products">

                <div class="filters">
                   <%-- <h2>Filters</h2>
                    <h3>Category</h3>
                    <div class="Category-filter">
                        <input type="checkbox">
                        <p>Haircare</p>
                    </div>
                    <div class="Category-filter">
                        <input type="checkbox">
                        <p>Skincare</p>
                    </div> 
                    <div class="Category-filter">                       
                        <input type="checkbox">
                        <p>Frangrances</p>
                    </div>
                    <div class="Category-filter">
                        <input type="checkbox">
                        <p>Booters</p>
                    </div>

                    <h3>Brand</h3>
                    <div class="Category-filter">
                        <input type="checkbox">
                        <p>MAN</p>
                    </div>
                    <div class="Category-filter">
                        <input type="checkbox">
                        <p>ADIDAS</p>
                    </div> 
                    <div class="Category-filter">                       
                        <input type="checkbox">
                        <p>MASK</p>
                    </div>
                    <div class="Category-filter">
                        <input type="checkbox">
                        <p>NIVEA</p>
                    </div>
                    <h3>Price</h3>
                    <div class="Category-filter">
                        <input type="checkbox">
                        <p>Any</p>
                    </div>
                    <div class="Category-filter">
                        <input type="checkbox">
                        <p>R0-R499</p>
                    </div> 
                    <div class="Category-filter">                       
                        <input type="checkbox">
                        <p>R500-R999</p>
                    </div>
                    <div class="Category-filter">
                        <input type="checkbox">
                        <p>R1000-Any</p>
                    </div>
                    <button class="filter-btn">Apply Filters</button>--%>
                
                     <h2>Sorting</h2>
                    <h3>Category</h3>
                    <div class="Category-filter">
                        <a id="shavingSupplier" runat="server">Shaving-Suppliers</a>                     
                    </div>
                    <div class="Category-filter">
                         <a id="Skincare" runat="server">Skincare</a>  
                        
                    </div> 
                    <div class="Category-filter">                       
                        <a id="Frangrances" runat="server">Fragrance</a>  
                       
                    </div>
                  

                    <h3>Brand</h3>
                    <div class="Category-filter">
                       <a id="Musk" runat="server">Musk</a>  
                    </div>
                    <div class="Category-filter">
                        <a id="MAN" runat="server">MAN</a>  
                    </div> 
                    <div class="Category-filter">                       
                        <a id="Nivea" runat="server">Nivea-Men</a>  
                    </div>
       
                    <h3>Price</h3>
                    <div class="Category-filter">
                         <a id="stPrice" runat="server">R50-R199</a>
                       <!-- <p>Any</p> -->
                    </div>
                    <div class="Category-filter">
                          <a  id="ndPrice" runat="server">R200-R499</a>
                       <!-- <p>R0-R499</p> -->
                    </div> 
                    <div class="Category-filter">                       
                        <a  id="rdPrice" runat="server">R500-R1000</a>
                       <!-- <p>R500-R999</p> -->
                    </div>
                    <div class="Category-filter">
                         <a  id="thPrice" runat="server">Any</a>
                         <!-- <p>R1000-Any</p>   -->
                    </div>
                </div>

                <!--Products Container-->
                <div class="pro-container" id="lblProducts" runat="server"  >

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
            </div>
        </section><!--End of products container-->


    <script>

    </script>
</asp:Content>
