<%@ Page Title="BaeWatch Beta (Release 1.0)" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Homepage.aspx.cs" Inherits="SearchBarwithMasterPage.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
    <link href="Homepage.css" rel="stylesheet" type="text/css" />
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
    <div class="Cont">
        <b>Categories</b>
            <table style="width: 100%;">
                <tr>
                    <td><b>Gender : </b></td>
                    <td>
                        <asp:button  ID="btnMale" runat="server" text="Male" OnClick="btnMale_Click" EnableTheming="True" />
                        <asp:Button ID="btnFemale" runat="server" Text="Female" OnClick="btnFemale_Click" />
                    </td>
                </tr>
                <tr>
                    <td><b>Sexual Orientation : </b></td>
                    <td>
                        <asp:Button ID="Btnstraight" runat="server" Text="Straight" OnClick="Btnstraight_Click" />
                        <asp:Button ID="BtnGay" runat="server" Text="Gay" OnClick="BtnGay_Click" style="width: 38px" />
                        <asp:Button ID="BtnOther" runat="server" Text="Other" OnClick="BtnOther_Click" />
                    </td>
                </tr>
                <tr>
                    <td><b>Relationship Type : </b></td>
                    <td>
                        <asp:Button ID="Long" runat="server" Text="Long Term" OnClick="Long_Click"  />
                        <asp:Button ID="Short" runat="server" Text="Short Term" OnClick="Short_Click" Width="83px" />
                        <asp:Button ID="Friends" runat="server" Text="Friendship" OnClick="Friends_Click" />
                    </td>
                </tr>
            </table>
        <br />
        <asp:Label ID="StatusMessage" runat="server" Text=""></asp:Label>
        <asp:GridView ID="HomepageGridView" runat="server" AutoGenerateColumns="false" style="background:lightgreen">
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
                <asp:BoundField DataField="Orientation" HeaderText="Orientation" />
                <asp:BoundField DataField="Type" HeaderText="Type" />
                <asp:TemplateField HeaderText="Image">
                    <ItemTemplate>
                        <asp:Image ID="Image1" runat="server" Height="100px" Width="100px" ImageUrl='<%#"data:Image/png;base64," + Convert.ToBase64String((byte[])Eval("ImageData")) %>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
