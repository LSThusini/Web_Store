﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master1.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="GG_WebStore.Register" %>
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

    .register .response-message{
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

    <!--Banner at the Top-->
        <section id="banner" >
            <h4></h4>
            <h2>User <span>Register</span> at GroomedGents</h2> 
        </section><!--End of Banner at the top-->
    <div class="register">
           <h1>Register</h1>
            <p >Username</p>
            <input placeholder="Type your name" ID="txtUserName" runat="server">
            <p>Email</p>
            <input placeholder="Type your E-mail" ID="txtUserEmail" runat="server">
            <p>Password</p>
            <input type="password" placeholder="Type your password" ID="txtUserPass" runat="server">
            <p>Confirm Password</p>
            <input type="password" placeholder="Type your password" ID="txtconfirmPass" runat="server">
            <p class="response-message" ID="response" runat="server"></p>
            <div class="tacbox">
                <input type="checkbox" />
                <label for="checkbox"> I agree to the <a href="#">Terms and Conditions</a>.</label>
            </div>
            <!--<button class="register-button" ID="btnRegister">Register</button> -->
            <asp:Button class="register-button" ID="btnRegister" runat ="server" Text="Register" OnClick="Button1_Click" />
            <p>Have an account?<a href="Login.aspx"><span>Login.</span></a></p>
            
        </div>
    <br />
    <br />
</asp:Content>
