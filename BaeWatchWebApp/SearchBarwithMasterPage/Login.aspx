<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SearchBarwithMasterPage.Login" %>

<!DOCTYPE html>
<link href="Layout.css" rel="stylesheet" type="text/css" />
<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title>BaeWatch Beta (Release 1.0)</title>
    <meta name="description" content="Making Dating and Networking Seamless and Effortless :)" />
</head>

<body>
    <div class="container">
        <form id="form1" runat="server">
            <h4 style="font-size: large">Log In</h4>
            <hr />
            <br />
            <asp:placeholder runat="server" ID="LoginForm" Visible="false">
                <div style="margin-bottom: 10px">
                   <asp:label runat="server" AssociatedControlID="UserName">Username</asp:label>
                <div>
                   <asp:textbox runat="server" ID="UserName" />
                </div>
            </div>
            <div style="margin-bottom: 10px">
               <asp:label runat="server" AssociatedControlID="Password">Password</asp:label>
                <div>
                   <asp:textbox runat="server" ID="Password" TextMode="Password" />
                </div>
            </div>
            <div style="margin-bottom: 10px">
                <div>
                   <asp:button runat="server" CssClass="button" OnClick="SignIn" Text="Log In" />
                </div>
            </div>
            </asp:placeholder>
            <asp:placeholder runat="server" ID="LogoutButton" Visible="false">
            <div>
                <div>
                   <asp:button runat="server" CssClass="button" OnClick="SignOut" Text="Sign Out" />
                </div>
            </div>
            </asp:placeholder>
            <asp:placeholder runat="server" ID="LoginStatus" Visible="false">
            <p>
                <span style="color:red"><asp:Literal runat="server" ID="StatusText" /></span>
            </p>
            </asp:placeholder>
         <p class="copyright">&copy; Copyright 2016 <a href="StartScreen.aspx" target="_self" title="BaeWatch">BaeWatch</a></p>
    </form>
    </div>
</body>
</html>