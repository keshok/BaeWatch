<%@ Page Title="BaeWatch Beta (Release 1.0)" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="UserProfile.aspx.cs" Inherits="SearchBarwithMasterPage.UserProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="userprofile.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .auto-style1 {
            width: 399px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
    <asp:image ID="ProfilePic" Height="500px" Width="500px" runat="server"></asp:image>
    <div style="font-family: Arial">
        <table border="1" >
            <div id="profile"style="font-family: Arial;text-align:center" >
                <table border="2" >
                    <tr>
                        <td>
                            <b>ID</b>
                        </td>
                        <td class="auto-style1">
                            <asp:Label ID="lblID" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <b>Username</b>
                        </td>
                        <td class="auto-style1">
                            <asp:Label ID="lblUsername" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <b>Description</b>
                        </td>
                        <td class="auto-style1">
                            <asp:Label ID="lblDesc" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <b>Interests</b>
                        </td>
                        <td class="auto-style1">
                            <asp:Label ID="lblIntest" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <b>Gender</b>

                        </td>
                        <td class="auto-style1">
                            <asp:Label ID="lblGender" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <b>Sexual Orientation</b>
                        </td>
                        <td>
                            <asp:label runat="server" ID="lblO"></asp:label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <b>Relationship Type</b>
                        </td>
                        <td>
                            <asp:label runat="server" ID="lblType"></asp:label>
                        </td>
                    </tr>
                </table>
                <!--</table>-->
                <asp:Button ID="btnAddFriends" runat="server" OnClick="Button1_Click" Text="Add to friends list " />
                <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                <br />
                <asp:Button ID="btnWink" runat="server" Text="Wink at user" Width="159px" OnClick="btnWink_Click" />
                <br />
                <asp:textbox runat="server" Height="59px" Width="601px" ID="txrComments"></asp:textbox>
                <asp:button ID="btnPost" runat="server" text="Post" OnClick="btnPost_Click" />
                <asp:gridview runat="server" ID="gridview1"  AutoGenerateColumns="false" Width="607px">
                    <Columns>
                        <asp:BoundField DataField ="Comment" HeaderText="Comment" />
                        <asp:BoundField DataField="CID" HeaderText="ID" />
                    </Columns>
                </asp:gridview>
            </div>
        </table>
        <asp:Label ID="lblText" runat="server" Text="To Delete Comment, Put Comment ID In Here :"></asp:Label>&nbsp;
        <asp:TextBox ID="txtDeleteComment" runat="server"></asp:TextBox>
        <asp:Button ID="btnDeleteComment" runat="server" Text="Delete" OnClick="btnDeleteComment_Click" />
        <br />
        <asp:Button ID="btnBlock" runat="server" Text="Block User" OnClick="btnBlock_Click" />
    </div>
</asp:Content>
