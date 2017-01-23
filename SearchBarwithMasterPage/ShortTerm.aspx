<%@ Page Title="BaeWatch Beta (Release 1.0)" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ShortTerm.aspx.cs" Inherits="SearchBarwithMasterPage.ShortTerm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
    <link href="Homepage.css" rel="stylesheet" type="text/css" />
    <asp:GridView ID="HomepageGridView" runat="server" AutoGenerateColumns="false">
        <Columns>
            <asp:TemplateField HeaderText="ID">
                <ItemTemplate>
                    <asp:LinkButton ID="ID" OnClick="LinkButton1_Click" Text='<%#Eval("ID")%>' runat="server">LinkButton</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField ="Username" HeaderText="Username" />
            <asp:BoundField DataField ="Description" HeaderText="Description" />
            <asp:BoundField DataField ="Intrests" HeaderText="Interests" />
            <asp:BoundField DataField="Gender" HeaderText="Gender" />
            <asp:TemplateField HeaderText="Image">
                <ItemTemplate>
                    <asp:Image ID="Image1" runat="server" Height="100px" Width="100px" ImageUrl='<%#"data:Image/png;base64," + Convert.ToBase64String((byte[])Eval("ImageData")) %>' />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
