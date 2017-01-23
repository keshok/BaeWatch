<%@ Page Title="BaeWatch Beta (Release 1.0)" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="FriendsListaspx.aspx.cs" Inherits="SearchBarwithMasterPage.FriendsListaspx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
<link href="Homepage.css" rel="stylesheet" type="text/css" />
    <asp:gridview ID="GridView1" runat="server" AutoGenerateColumns="false" Width="864px">
        <Columns>
            <asp:BoundField DataField ="Username" HeaderText="Friend Name " />
             <asp:TemplateField HeaderText="ID">
                <ItemTemplate>
                    <asp:LinkButton ID="FriendID" OnClick="LinkButton1_Click" Text='<%#Eval("FriendID")%>' runat="server">LinkButton</asp:LinkButton>
                </ItemTemplate>
             </asp:TemplateField>
            <asp:BoundField DataField ="Name" HeaderText="Friend Name" />
        </Columns>
    </asp:gridview>
</asp:Content>
