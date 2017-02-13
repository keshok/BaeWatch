<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="SearchBarwithMasterPage.Registration" %>

<!DOCTYPE html>
<link href="Layout.css" rel="stylesheet" type="text/css" />
<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
	<title>BaeWatch Beta (Release 1.0)</title>
</head>

<body>
	<div class="container">
		<form id="form1" runat="server">
			<h3>BaeWatch Sign-up Form</h3>
			<h4>Making Dating and Networking Seamless and Effortless :)</h4>
			<hr />
			<br />

			<table>
				<tr>
					<td><asp:label ID="lblUsername" runat="server" type="text" Text="Username"></asp:label></td>
					<td> <asp:textBox ID="txtUserName" runat="server" type="text"></asp:textBox></td>
				</tr>
				<tr>
					<td><asp:label ID="lblPassword" runat="server" type="text" Text="Password"></asp:label></td>
					<td>
						<asp:textbox ID="txtPassword" runat="server" type="text" TextMode="Password"></asp:textbox>
						<input type="checkbox" onchange="document.getElementById('txtPassword').type = this.checked ? 'text' : 'password'"> Show Password
					</td>
				</tr>
				<tr>
					<td><asp:label ID="lblDescription" runat="server" type="text" Text="Description"></asp:label></td>
					<td><asp:textBox ID="txtDescription" runat="server" type="text"></asp:textBox></td>
				</tr>
				<tr>
					<td><asp:label ID="lblInterests" runat="server" type="text" Text="Interests/Hobbies"></asp:label>&nbsp&nbsp</td>
					<td><asp:textBox ID="txtInterests" runat="server" type="text"></asp:textBox></td>
				</tr>
				<tr>
					<td> <asp:label ID="lblGender" runat="server" type="text" Text="Gender"></asp:label></td>
					<td>
						<asp:radiobutton ID="Male" Text="&nbsp;Male" runat="server"></asp:radiobutton>&nbsp&nbsp
						<asp:radiobutton  ID="Female" Text="&nbsp;Female" runat="server"></asp:radiobutton>&nbsp&nbsp
						<asp:radiobutton  ID="Other" Text="&nbsp;Other" runat="server"></asp:radiobutton>
					</td>
				</tr>
				<tr>
					<td><asp:label ID="lblOrientation" runat="server" Text="Sexual Orientation"></asp:label></td>
					<td>
						<asp:radiobutton ID="Strait" Text="&nbsp;Straight" runat="server"></asp:radiobutton>&nbsp&nbsp
						<asp:radiobutton ID="Gay" Text="&nbsp;Gay" runat="server"></asp:radiobutton>&nbsp&nbsp
						<asp:radiobutton ID="OtherOrientation" Text="&nbsp;Other" runat="server"></asp:radiobutton>
					</td>
				</tr>
				<tr>
					<td><asp:label ID="lblType" runat="server" Text="Relationship Type"></asp:label></td>
					<td>
						<asp:radiobutton ID="LongT" Text="&nbsp;Long Term" runat="server"></asp:radiobutton>&nbsp&nbsp
						<asp:radiobutton ID="ShortT" Text="&nbsp;Short Term" runat="server"></asp:radiobutton>&nbsp&nbsp
						<asp:radiobutton ID="Friends" Text="&nbsp;Friendship" runat="server"></asp:radiobutton>
					</td>
				</tr>
				<tr>
					<td><asp:label ID="lblImage" runat="server" Text="Profile Picture"></asp:label></td>
					<td><asp:FileUpload ID="ImageSearch" runat="server" /></td>
				</tr>
			</table>
			<br />
			<asp:button ID="btnRegister" CssClass="button" runat="server" Text="Register" OnClick="btnRegister_Click" />
			<asp:button ID="btnLogin" CssClass="button" runat="server" Text="Log In" OnClick="btnLogin_Click" />
			<br />
			<asp:label ID="lblMessage" ForeColor="Red" runat="server" Text=""></asp:label>
			<p class="copyright">&copy; Copyright 2016 <a href="StartScreen.aspx" target="_self" title="BaeWatch">BaeWatch</a></p>
		</form>
	</div>
</body>
</html>