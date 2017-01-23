<%@ Page Title="BaeWatch Beta (Release 1.0)" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Notifications.aspx.cs" Inherits="SearchBarwithMasterPage.Notifications" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
<b>Your Notifications</b>
    <link href="Homepage.css" rel="stylesheet" type="text/css" />
    <asp:GridView ID="NotificationsTable" runat="server" AutoGenerateColumns="false" style="background:lightgreen">
        <EmptyDataTemplate>No Notifications</EmptyDataTemplate>
        <Columns>
            <asp:TemplateField HeaderText="ID">
                <ItemTemplate>
                    <asp:LinkButton ID="SID" OnClick="LinkButton1_Click" Text='<%#Eval("SID")%>' runat="server">LinkButton</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Sender" HeaderText="Name" />
            <asp:BoundField DataField="Message" HeaderText="" />
        </Columns>
    </asp:GridView>
    <asp:Button ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_Click" />
    <asp:Label ID="lblText" runat="server" Text=""></asp:Label>
</asp:Content>
