<%@ Page Title="BaeWatch Beta (Release 1.0)" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AccountSettings.aspx.cs" Inherits="SearchBarwithMasterPage.AccountSettings" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 119px;
        }
        .auto-style2 {
            width: 309px;
        }
        .auto-style3 {
            width: 223px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
    <link href="Layout.css" rel="stylesheet" type="text/css" />
    <b>Update your Information</b>
    <table style="width: 100%;">
        <tr>
            <td class="auto-style1"><b>Description:</b></td>
            <td class="auto-style3">
                <asp:textbox ID="txtDescription" runat="server" Width="509px"></asp:textbox>
            </td>
            <td>
                <asp:button ID="btnUpdateDesc" runat="server" text="Update" OnClick="btnUpdateDesc_Click" />
            </td>
        </tr>
        <tr>
            <td class="auto-style1"><b>Interests:</b></td>
            <td class="auto-style3">
                <asp:textbox  ID="txtInterests" runat="server" Width="509px"></asp:textbox>
            </td>
            <td>
                <asp:button ID="btnUpdateInt" runat="server" text="Update" OnClick="btnUpdateInt_Click" />
            </td>
        </tr>
        <tr>
            <td class="auto-style1"><b>Gender</b></td>
            <td class="auto-style3">
                <asp:radiobutton ID="Male" GroupName="Genders" Text="Male" runat="server"></asp:radiobutton>
                <asp:radiobutton  ID="Female" GroupName="Genders" Text="Female" runat="server"></asp:radiobutton>
                <asp:radiobutton  ID="Other" GroupName="Genders" Text="Other" runat="server"></asp:radiobutton>
            </td>
            <td class="auto-style2">
                <asp:button ID="btnUpdateGender" runat="server" text="Update" OnClick="btnUpdateGender_Click" />
            </td>
        </tr>
        <tr>
            <td><b>Sexual Orientation</b></td>
            <td class="auto-style3">
                <asp:radiobutton ID="Strait" GroupName="Orientation" Text="Straight" runat="server"></asp:radiobutton>
                <asp:radiobutton ID="Gay" GroupName="Orientation" Text="Gay" runat="server"></asp:radiobutton>
                <asp:radiobutton ID="OtherOrientation" GroupName="Orientation" Text="Other" runat="server"></asp:radiobutton>
            </td>
            <td class="auto-style2">
                <asp:button ID="btnOrientation" runat="server" text="Update" OnClick="btnOrientation_Click"/>
            </td>
        </tr>
        <tr>
            <td><b>Relationship Type</b></td>
            <td class="auto-style3">
                <asp:radiobutton ID="LongT" Text="Long Term" runat="server"></asp:radiobutton>
                <asp:radiobutton ID="ShortT" Text="Short Term" runat="server"></asp:radiobutton>
                <asp:radiobutton ID="Friends" Text="Friendship" runat="server"></asp:radiobutton>
            </td>
            <td class="auto-style2">
                <asp:button ID="btnUpdateType" runat="server" text="Update" OnClick="btnUpdateType_Click" />
            </td>
        </tr>
         <tr>
            <td><b>Password</b></td>
            <td class="auto-style3">
                 <asp:textBox runat="server" ID="Password" TextMode="Password" Width="509px" />
            </td>
            <td class="auto-style2">
                <asp:button ID="btnUpdatePassword" runat="server" text="Update" OnClick="btnUpdatePassword_Click"  />
            </td>
        </tr>
        <tr>
            <td><b>Profile Picture</b></td>
            <td class="auto-style3"><asp:FileUpload ID="ImageSearch" runat="server" /></td>
            <td class="auto-style2">
                <asp:button ID="btnUpdateImage" runat="server" text="Update" OnClick="btnUpdateImage_Click" />
            </td>
        </tr>
    </table>
    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
    <br />
    <asp:Button ID="btnDelete" runat="server" Text="Delete your account" OnClick="btnDelete_Click" />
</asp:Content>
