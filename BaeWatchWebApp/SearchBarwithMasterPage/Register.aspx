<%@ Page Title="BaeWatch Beta (Release 1.0)" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="SearchBarwithMasterPage.Register" %>
<%@ MasterType VirtualPath="~/MasterPage.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
  <link href="Layout.css" rel="stylesheet" type="text/css" />
    <table style="width: 100%;">
        <tr>
            <td><asp:Label ID="lblUsername" runat="server" Text="Username "></asp:Label></td>
            <td> <asp:TextBox ID="txtUserName" runat="server" Width="476px"></asp:TextBox></td>
        </tr>
        <tr>
            <td><asp:label ID="lblPassword" runat="server" text="Password"></asp:label></td>
            <td><asp:textbox ID="txtPassword" runat="server" Width="476px"></asp:textbox></td>
        </tr>
        <tr>
            <td><asp:Label ID="lblDescription" runat="server" Text="Description "></asp:Label></td>
            <td><asp:TextBox ID="txtDescription" runat="server" Width="476px"></asp:TextBox></td>
        </tr>
        <tr>
            <td><asp:Label ID="lblIntrests" runat="server" Text="Interests "></asp:Label></td>
            <td><asp:TextBox ID="txtIntrests" runat="server" Width="476px"></asp:TextBox></td>
        </tr>
        <tr>
            <td> <asp:Label ID="lblGender" runat="server" Text="Gender"></asp:Label></td>
            <td>
                <asp:radiobutton ID="Male" Text="Male" runat="server"></asp:radiobutton>
                <asp:radiobutton  ID="Female" Text="Female" runat="server"></asp:radiobutton>
                <asp:radiobutton  ID="Other" Text="Other" runat="server"></asp:radiobutton>
            </td>
        </tr>
        <tr>
            <td><asp:Label ID="lblOrientation" runat="server" Text="Orientation "></asp:Label></td>
            <td>
                <asp:radiobutton ID="Strait" Text="Strait" runat="server"></asp:radiobutton>
                <asp:radiobutton ID="Gay" Text="Gay" runat="server"></asp:radiobutton>
                <asp:radiobutton ID="OtherOrientation" Text="Other" runat="server"></asp:radiobutton>
            </td>
        </tr>
        <tr>
            <td><asp:Label ID="lblType" runat="server" Text="Type "></asp:Label></td>
            <td>
                <asp:radiobutton ID="LongT" Text="Long Term" runat="server"></asp:radiobutton>
                <asp:radiobutton ID="ShortT" Text="Short Term" runat="server"></asp:radiobutton>
                <asp:radiobutton ID="Friends" Text="Just Friends" runat="server"></asp:radiobutton>
            </td>
        </tr>
        <tr>
            <td><asp:Label ID="lblImage" runat="server" Text="Profile Picture"></asp:Label></td>
            <td><asp:FileUpload ID="ImageSearch" runat="server" /></td>
        </tr>
    </table>
    <br />
    <asp:Button ID="btnRegister" runat="server" Text="Register" OnClick="btnRegister_Click" />
    <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
    <br />
    <br />
    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
</asp:Content>
