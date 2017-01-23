<%@ Page Title="BaeWatch Beta (Release 1.0)" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Winks.aspx.cs" Inherits="SearchBarwithMasterPage.Winks" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
    <link href="Homepage.css" rel="stylesheet" type="text/css" />
    <b>;)</b>
    <asp:GridView ID="WinkList" runat="server" AutoGenerateColumns="false">
        <EmptyDataTemplate>No Winks</EmptyDataTemplate>
        <Columns>
            <asp:TemplateField HeaderText="ID">
                <ItemTemplate>
                    <asp:LinkButton ID="ID" OnClick="LinkButton1_Click" Text='<%#Eval("SenderID")%>' runat="server">LinkButton</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Sender" HeaderText="Name" />
        </Columns>
    </asp:GridView>
    <asp:Button ID="btnClearWinks" runat="server" Text="Clear Winks" OnClick="btnClearWinks_Click" />
</asp:Content>
