<%@ Page Title="BaeWatch Beta (Release 1.0)" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="DeleteConfirm.aspx.cs" Inherits="SearchBarwithMasterPage.DeleteConfirm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
    <link href="Homepage.css" rel="stylesheet" type="text/css" />
    <asp:Label ID="lblDelete" runat="server" Text="Are you sure you want to delete your account? "></asp:Label>
    <br />
    <asp:button ID="btnYes" runat="server" text="Yes" OnClick="btnYes_Click" />
    <asp:button ID="btnNo"  runat="server" text="No" style="margin-left: 200px" OnClick="btnNo_Click" />
</asp:Content>
