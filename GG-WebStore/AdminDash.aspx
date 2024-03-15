<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminDash.aspx.cs" Inherits="GG_WebStore.AdminDash" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.4/css/all.min.css"/>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.4.0/css/all.min.css" integrity="sha512-iecdLmaskl7CVkqkXNQ/ZH/XLlvWZOJyj7Yy7tcenmpD1ypASozpmT/E0iPtmFIB46ZmdtAc9eNBvH0H/ZpiBw==" crossorigin="anonymous" referrerpolicy="no-referrer" />
    <link rel="stylesheet" href="https://fonts.googleapis.com/css2?family=Material+Symbols+Outlined:opsz,wght,FILL,GRAD@48,400,0,0" />
    <link rel="stylesheet" href="https://pro.fontawesome.com/releases/v5.10.0/css/all.css" />
    <link  rel="stylesheet" href="styles.css"/>

    <style>
         
            /*  import google fonts */
@import url("https://fonts.googleapis.com/css2?family=Poppins:wght@400;500;600;700");
*{
  margin: 0;
  padding: 0;
  outline: none;
  border: none;
  text-decoration: none;
  box-sizing: border-box;
  font-family: "Poppins", sans-serif;
}
body{
  background: #fff;
}
.container{
  display: flex;
}
nav{
  position: relative;
  top: 0;
  bottom: 0;
  height: 100vh;
  left: 0;
  background: rgb(206, 205, 205);
  width: 280px;
  overflow: hidden;
  box-shadow: 0 20px 35px rgba(0, 0, 0, 0.1);
}
.logo{
  text-align: center;
  display: flex;
  margin: 10px 0 0 10px;
}
.logo img{
  width: 45px;
  height: 45px;
  border-radius: 50%;
}
.logo span{
  font-weight: bold;
  padding-left: 15px;
  font-size: 18px;
  text-transform: uppercase;
}
nav ul a{
  position: relative;
  color: rgb(85, 83, 83);
  font-size: 14px;
  display: table;
  width: 280px;
  padding: 10px;
}

a:hover{
    cursor: pointer;
}


nav .fas{
  position: relative;
  width: 70px;
  height: 40px;
  top: 14px;
  font-size: 20px;
  text-align: center;
}
.nav-item{
  position: relative;
  top: 12px;
  margin-left: 10px;
}
nav ul a:hover{
  background: coral;
}
.logout{
  position: absolute;
  bottom: 0;
}

/* Main Section */
.main{
  position: relative;
  padding: 20px;
  width: 100%;
}
.main-top{
  display: flex;
  width: 100%;
}
.main-top i{
  position: absolute;
  right: 0;
  margin: 10px 30px;
  color: rgb(110, 109, 109);
  cursor: pointer;
}
.main-skills{
  display: flex;
  margin-top: 20px;
}
.main-skills .card{
  width: 25%;
  margin: 10px;
  background: #fff;
  text-align: center;
  border-radius: 20px;
  padding: 10px;
  box-shadow: 0 20px 35px rgba(0, 0, 0, 0.1);
}
.main-skills .card h3{
  margin: 10px;
  text-transform: capitalize;
}
.main-skills .card p{
  font-size: 12px;
}
.main-skills .card button{
  background: orangered;
  color: #fff;
  padding: 7px 15px;
  border-radius: 10px;
  margin-top: 15px;
  cursor: pointer;
}
.main-skills .card button:hover{
  background: rgba(223, 70, 15, 0.856);
}
.main-skills .card i{
  font-size: 22px;
  padding: 10px;
}

/* Courses */
.main-course{
  margin-top:20px ;
  text-transform: capitalize;
}
.course-box{
  width: 100%;
  height: 300px;
  padding: 10px 10px 30px 10px;
  margin-top: 10px;
  background: #fff;
  border-radius: 10px;
  box-shadow: 0 20px 35px rgba(0, 0, 0, 0.1);
}
.course-box ul{
  list-style: none;
  display: flex;
}
.course-box ul li{
  margin: 10px;
  color: gray;
  cursor: pointer;
}
.course-box ul .active{
  color: #000;
  border-bottom: 1px solid #000;
}
.course-box .course{
  display: flex;
}
.box{
  width: 33%;
  padding: 10px;
  margin: 10px;
  border-radius: 10px;
  background: rgb(235, 233, 233);
  box-shadow: 0 20px 35px rgba(0, 0, 0, 0.1);
}
.box p{
  font-size: 12px;
  margin-top: 5px;
}
.box button{
  background: #000;
  color: #fff;
  padding: 7px 10px;
  border-radius: 10px;
  margin-top: 3rem;
  cursor: pointer;
}
.box button:hover{
  background: rgba(0, 0, 0, 0.842);
}
.box i{
  font-size: 7rem;
  float: right;
  margin: -20px 20px 20px 0;
}
.html{
  color: rgb(25, 94, 54);
}
.css{
  color: rgb(104, 179, 35);
}
.js{
  color: rgb(28, 98, 179);
}
    </style>

</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
    <nav>
      <ul>
        <li><a href="#" class="logo">
            <a href="Index.aspx"><h1 class="logo">GroomedGents</h1></a>
        </a></li>
        <li><a href="AdminDash.aspx">
          <i class="fas fa-home"></i>
          <span class="nav-item">Home</span>
        </a></li>
        <li><a href="Register.aspx">
          <i class="fas fa-user"></i>
          <span class="nav-item">Register</span>
        </a></li>
        
        <li><a href="ProductManagement.aspx">
          <i class="fas fa-chart-bar"></i>
          <span class="nav-item">Inventory</span>
        </a></li>
        
        <li><a href="" id="logoutLink" runat="server" class="logout">
          <i class="fas fa-sign-out-alt"></i>
          <span class="nav-item">Log out</span>
        </a></li>
      </ul>
    </nav>

    <section class="main">
      <div class="main-top">
        <h1>Basic Reports</h1>
        <i class="fas fa-user-cog"></i>
      </div>
      <div class="main-skills">
        <div class="card">
          
          <h3 >Products</h3>
          <p id="numProducts" runat="server">Number of products</p>
          
        </div>
        <div class="card">
          
          <h3>Registered Users</h3>
          <input type="date" runat="server" id="UsersDatefilter">
            <asp:Button ID="Button1" class="coupon-btn" runat="server" Text="Show" OnClick="Button1_Click" />

          <%--<button>Show</button>--%>
          <h4 id="numUsers" runat="server"> Users number</h4>
        </div>
        
      </div>

      <section id="cart" class="main-course">
        <table width="100%">
            <thead>
                <tr>
                    <td>Remove</td>
                    <td>Image</td>
                    <td>Product Name</td>
                    <td>Price</td>
                    <td>On Hand</td>
                    <td>Edit</td>
                    
                </tr>
                </thead>
                <tbody style="height : 100px; overflow: auto;" id="idTableData" runat="server">
                   <%-- <tr>
                        <td><a href="#"><i class="far fa-times-circle"></i></a></td>
                        <td><img src="images/pro1-fragrance.jpg" alt=""></td>
                        <td>Coty Jovan Musk Men Cologne 118ml</td>
                        <td>R400</td>
                        <td>100</td>
                        <td><a>Edit</a></td>
                    </tr>
                    <tr>
                        <td><a href="#"><i class="far fa-times-circle"></i></a></td>
                        <td><img src="images/pro1-fragrance.jpg" alt=""></td>
                        <td>Coty Jovan Musk Men Cologne 118ml</td>
                        <td>R400</td>
                        <td>100</td>
                        <td><a>Edit</a></td>
                    </tr>
                    <tr>
                        <td><a href="#"><i class="far fa-times-circle"></i></a></td>
                        <td><img src="images/pro1-fragrance.jpg" alt=""></td>
                        <td>Coty Jovan Musk Men Cologne 118ml</td>
                        <td>R400</td>
                        <td>100</td>
                        <td><a>Edit</a></td>
                    </tr>--%>
                </tbody>
        </table>
      </section>
    </section>
  </div>
    </form>
</body>
</html>
