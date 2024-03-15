<%@ Page Title="" Language="C#" MasterPageFile="~/Master1.Master" AutoEventWireup="true" CodeBehind="Invoices.aspx.cs" Inherits="GG_WebStore.Invoices" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main id="reports">
		<h1 onclick="window.location.href='Invoices.aspx';">INVOICES</h1>
        <section class="report-container">
			<div class="report" id="invoices_container" runat="server">
                <h2>No Invoices to display</h2>
			</div>             
        </section>
    </main>
</asp:Content>