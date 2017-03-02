<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Notifications.aspx.cs" Inherits="SearchBarwithMasterPage.Notifications" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
    <link href="Homepage.css" rel="stylesheet" type="text/css" />
    <b>Your Notifications</b>
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
