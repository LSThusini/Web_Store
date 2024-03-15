<%@ Page Title="" Language="C#" MasterPageFile="~/Master1.Master" AutoEventWireup="true" CodeBehind="PaymentConf.aspx.cs" Inherits="GG_WebStore.PaymentConf" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!--Banner at the Top-->
        <section id="banner" >
            <h4></h4>
            <h2>Payment Confirmation <span>Happy Purchase</span> at GroomedGents</h2> 
        </section><!--End of Banner at the top-->

    <h1 style="text-align : center; padding-top: 20px;">Payment Received!!</h1>
    <div style="text-align : center; margin-top: 100px;">
        <asp:Button style=" margin: 5px 10px 20px 20px;" ID="Button1" class="coupon-btn" runat="server" Text="View Invoices" OnClick="viewInvoices_Click" />
        <asp:Button style=" margin: 5px 10px 20px 20px;" ID="Button2" class="coupon-btn" runat="server" Text="Back to shopping" OnClick="shop_Click"/>
    </div>
    

</asp:Content>
