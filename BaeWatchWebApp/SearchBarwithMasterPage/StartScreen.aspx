<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StartScreen.aspx.cs" Inherits="SearchBarwithMasterPage.StartScreen" %>

<!DOCTYPE html>
<link href="Layout.css" rel="stylesheet" type="text/css" />
<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title>BaeWatch Beta (Release 1.0)</title>
</head>

<body>
    <div class="container">
        <form id="form1" runat="server">
            <fieldset>
                <img alt="BaeWatch Official Logo" src="/images/logo.gif" />
            </fieldset>
            <fieldset>
                <asp:button ID="Button1" CssClass="button" runat="server" Text="Sign In" OnClick="btnSignIn_Click" />
                <asp:button ID="Button3" CssClass="button" runat="server" Text="Register" OnClick="btnRegister_Click" />
            </fieldset>
            <p class="copyright">&copy; Copyright 2016 <a href="StartScreen.aspx" target="_self" title="BaeWatch">BaeWatch</a></p>
        </form>
    </div>
</body>
</html>
