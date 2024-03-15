<%@ Page Title="" Language="C#" MasterPageFile="~/Master1.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="GG_WebStore.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        * {
    box-sizing: border-box;
}

.Login {
    margin-top: 6%;
    text-align: center;
    align-items : center;
    border: 1px solid grey;
    max-width: 20%;
    margin-left: 40%;
    padding-bottom: 30px;
}

body{
    /*background-color:rgb(199, 197, 197);*/
    background-color: white;
    width: 100%;
}

    .Login h1 {
        margin-bottom: 50px;
    }

    .Login input {
        margin: 5px 0;
        border: none;
        border-bottom: 1px solid gray;
        padding-right: 50px;
        padding-bottom: 10px;
        background-color: transparent;
    }

    .Login p {
        font-size: 15px;
        font-weight: bold;
        margin: 5px 0;
    }

    .Login .forgot-password {
        cursor: pointer;
    }

        .Login .forgot-password:hover {
            color: grey;
        }

    .Login .login-button {
        font-size: 20px;
        padding: 5px 70px;
        border-radius: 10px;
        border: none;
        color: white;
        background-color: coral;
        margin-top: 20px;
        margin-bottom: 30px;
        cursor: pointer;
        transition: 0.2s ease;
    }

        .Login .login-button:hover {
            opacity: 0.8;
        }

        .Login .login-button:active {
            opacity: 0.5;
        }

span {
    cursor: pointer;
    font-weight: bold;
    text-decoration: underline;
    transition: 0.2s ease;
}

    span:hover {
        color: grey;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!--Banner at the Top-->
        <section id="banner" >
            <h4></h4>
            <h2>User <span>Login</span> at GroomedGents</h2> 
        </section><!--End of Banner at the top-->

    <section id="main-page">
            <div class="Login">
                <h1>Login</h1>
                <p>Username</p>
                <input ID="txtUserEmail" runat="server" class="username-input" placeholder="Type your E-mail">
                <p>Password</p>
                <input ID="txtPassword" runat="server" type="password" class="password-input" placeholder="Type your password">
                 <p class="lblResult" ID="lblResult" runat="server"></p>
                <p class="forgot-password">Forgot password?</p>
               <!-- <button class="login-button">Login</button> -->
                <asp:Button class="login-button" ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
                <p>Don't have an account?<a href="register.html"><span>Register.</span></a></p>
            </div>
        <br />
        <br />
        </section>
</asp:Content>
