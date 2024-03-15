<%@ Page Title="" Language="C#" MasterPageFile="~/Master1.Master" AutoEventWireup="true" CodeBehind="Checkout.aspx.cs" Inherits="GG_WebStore.Checkout" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Groomed Gents</title>
    <link rel="stylesheet" href="styles.css">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.4.0/css/all.min.css" integrity="sha512-iecdLmaskl7CVkqkXNQ/ZH/XLlvWZOJyj7Yy7tcenmpD1ypASozpmT/E0iPtmFIB46ZmdtAc9eNBvH0H/ZpiBw==" crossorigin="anonymous" referrerpolicy="no-referrer" />
    <link rel="stylesheet" href="https://fonts.googleapis.com/css2?family=Material+Symbols+Outlined:opsz,wght,FILL,GRAD@48,400,0,0" />
    <link rel="stylesheet" href="https://pro.fontawesome.com/releases/v5.10.0/css/all.css" />

	<style>
		*{padding:0; margin:0; box-sizing: border-box; font-family:sans-serif;}
header{
	width: 100vw;
	min-height: 100vh;
	background: #34495e;
	font-size: 1.2rem;
	display: flex;
	justify-content: center;
	align-items: center;
}
body{
	background-color: white;
}
.container{
	background: transparent;
	max-width: 800px;
	min-height: 500px;
	display: flex;
	/*justify-content:space-between;*/
	justify-content:flex-end;
	align-items: flex-start;
	padding: 0.5rem 1.5rem;
}
.left{
	flex-basis: 50%;
	
}
.right{
	flex-basis: 50%;
	
}
form{
	padding: 1rem;
}

h3{
	margin-top: 1rem;
	color:#2c3e50;
	}

form input[type="text"]{
	width: 100%;
	padding: 0.5rem 0.7rem;
	margin: 0.5rem 0;
	outline: none;
}

.coupon-btn{
	background-color: coral;
    color: #fff;
    padding: 12px 20px;
    border : none;
    cursor : pointer;
}

#zip{
	display: flex;
	margin-top: 0.5rem;
}
#zip select{
	padding: 0.5rem 0.7rem;
}
#zip input[type="number"]{
	padding: 0.5rem 0.7rem;
	margin-left: 5px;	
}
input[type="submit"]{
	width: 100%;
	padding: 0.7rem 1.5rem;
	background: #34495e;
	color: white;
	border: none;
	outline: none;
	margin-top: 1rem;
	cursor: pointer;
}

input[type="submit"]:hover{
	background: #2c3e50;
}


@media only screen and (max-width: 770px){
	.container{
		flex-direction: column;
	}
	body{
		overflow-x: hidden;
	}
}
	</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<div id="subtotal" >
                <h3>Cart Totals</h3>
                <table>
                    <tr>
                        <td>Cart SubTotal</td>
                        <td ID="idsubtotal" runat="server">R 555</td>
                    </tr>
                    <tr>
                        <td>Shipping</td>
                        <td ID="idShipping" runat="server">Free</td>
                    </tr>
                     <tr>
                        <td>VAT</td>
                        <td ID="idVat" runat="server">Free</td>
                    </tr>
                    <tr>
                        <td><strong>Total</strong></td>
                        <td ID="idTotal" runat="server">R555</td>
                    </tr>
                </table> 
            </div>
    <div class="container">
		<div class="left">
			<h3>BILLING ADDRESS</h3>
			<form>
				Full name
				<input id="name" runat="server" type="text" name="" placeholder="Enter name">
				Email
				<input id="email" runat="server" type="text" name="" placeholder="Enter email">

				Address
				<input id="address" runat="server" type="text" name="" placeholder="Enter address">
				
				City
				<input id="city" runat="server" type="text" name="" placeholder="Enter City">
				<div id="zip">
					<label>
						Province
						<select>
							<option>Choose Province..</option>
							<option>Gauteng</option>
							<option>Mpumalanga</option>
							<option>Western Cape</option>
							<option>Kwazulu Natal</option>
						</select>
					</label>
						<label>
						Zip code
						<input type="number" id="zipCode" runat="server" name="" placeholder="Zip code">
					</label>
				</div>
			</form>
		</div>
		<div class="right">
			<h3>PAYMENT</h3>
			<form>
				Accepted Card <br>
				<img src="images/pay/card1.png" width="100">
				<img src="images/pay/card2.png" width="50">
				<br><br>

				Credit card number
			<input id="cardNumber" runat="server" type="text" name="" placeholder="Enter card number">
				
				Exp month
				<input id="month" runat="server" type="text" name="" placeholder="Enter Month">
				<div id="zip">
					<label>
						Exp year
						<select>
							<option>Choose Year..</option>
							<option>2022</option>
							<option>2023</option>
							<option>2024</option>
							<option>2025</option>
						</select>
					</label>
						<label>
						CVV
						<input id="cvvNumber" runat="server" type="number" name="" placeholder="CVV">
					</label>
				</div>
			</form>
			<%--<button class="coupon-btn">Proceed with Payment</button>--%>
			<asp:Button  style="background-color: coral; color: #fff;padding: 12px 20px; border: none; cursor: pointer;" ID="newButton" runat="server" Text="Proceed to Pay" OnClick="Unnamed1_Click" />
		</div>
		<h1 id="results" runat="server"></h1>
	</div>
</asp:Content>
