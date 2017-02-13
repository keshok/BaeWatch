<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AccountSettings.aspx.cs" Inherits="SearchBarwithMasterPage.AccountSettings" %>

<!DOCTYPE html>
<link href="Layout.css" rel="stylesheet" type="text/css" />
<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title>BaeWatch Beta (Release 1.0)</title>
</head>

<body>
    <div class="container">
        <form id="form1" runat="server">
            <h4 style="font-size: large">Update Your User Profile</h4>
            <hr />
            <table">
                <tr>
                    <td>
                        <b>Description:</b>
                    </td>
                    <td>
                        <asp:textbox ID="txtDescription" runat="server"></asp:textbox>
                    </td>
                    <td>
                        <div style="text-align:center;">
                            <asp:button ID="btnUpdateDesc" CssClass="button4" runat="server" text="Update" OnClick="btnUpdateDesc_Click" />
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <b>Interests/Hobbies:</b>
                    </td>
                    <td>
                        <asp:textbox  ID="txtInterests" runat="server"></asp:textbox>
                    </td>
                    <td>
                        <div style="text-align:center;">
                            <asp:button ID="btnUpdateInt" CssClass="button4" runat="server" text="Update" OnClick="btnUpdateInt_Click" />
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <b>Gender&nbsp&nbsp</b>
                    </td>
                    <td>
                        <asp:radiobutton ID="Male" GroupName="Genders" Text="&nbsp;Male" runat="server"></asp:radiobutton>&nbsp&nbsp
                        <asp:radiobutton ID="Female" GroupName="Genders" Text="&nbsp;Female" runat="server"></asp:radiobutton>&nbsp&nbsp
                        <asp:radiobutton ID="Other" GroupName="Genders" Text="&nbsp;Other" runat="server"></asp:radiobutton>
                    </td>
                    <td>
                        <div style="text-align:center;">
                            <asp:button ID="btnUpdateGender" CssClass="button4" runat="server" text="Update" OnClick="btnUpdateGender_Click" />
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <b>Sexual Orientation&nbsp&nbsp</b>
                    </td>
                    <td>
                        <asp:radiobutton ID="Strait" GroupName="Orientation" Text="&nbsp;Straight" runat="server"></asp:radiobutton>&nbsp&nbsp
                        <asp:radiobutton ID="Gay" GroupName="Orientation" Text="&nbsp;Gay" runat="server"></asp:radiobutton>&nbsp&nbsp
                        <asp:radiobutton ID="OtherOrientation" GroupName="Orientation" Text="&nbsp;Other" runat="server"></asp:radiobutton>
                    </td>
                    <td>
                        <div style="text-align:center;">
                            <asp:button ID="btnOrientation" CssClass="button4" runat="server" text="Update" OnClick="btnOrientation_Click"/>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <b>Relationship Type&nbsp&nbsp</b>
                    </td>
                    <td>
                        <asp:radiobutton ID="LongT" Text="&nbsp;Long Term" runat="server"></asp:radiobutton>&nbsp&nbsp
                        <asp:radiobutton ID="ShortT" Text="&nbsp;Short Term" runat="server"></asp:radiobutton>&nbsp&nbsp
                        <asp:radiobutton ID="Friends" Text="&nbsp;Friendship" runat="server"></asp:radiobutton>
                    </td>
                    <td>
                        <div style="text-align:center;">
                            <asp:button ID="btnUpdateType" CssClass="button4" runat="server" text="Update" OnClick="btnUpdateType_Click" />
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <b>Change Password</b>
                    </td>
                    <td>
                         <asp:textBox runat="server" ID="Password" TextMode="Password" />
                    </td>
                    <td>
                        <div style="text-align:center;">
                            <asp:button ID="btnUpdatePassword" CssClass="button4" runat="server" text="Update" OnClick="btnUpdatePassword_Click"  />
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <b>Profile Picture&nbsp&nbsp</b>
                    </td>
                    <td>
                        <asp:FileUpload ID="ImageSearch" runat="server" />
                    </td>
                    <td>
                        <div style="text-align:center;">
                            <asp:button ID="btnUpdateImage"  CssClass="button4" runat="server" text="Update" OnClick="btnUpdateImage_Click" />
                        </div>
                    </td>
                </tr>
            </table>
            <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
            <hr />
            <br />
            <asp:Button ID="btnHomePage" CssClass="button3" runat="server" Text="Go Back to Homepage" OnClick="btnHomePage_Click" />
            <asp:Button ID="btnDelete" CssClass="button2" runat="server" Text="Delete Account" OnClick="btnDelete_Click" />
            <p class="copyright">&copy; Copyright 2016 <a href="StartScreen.aspx" target="_self" title="BaeWatch">BaeWatch</a></p>
        </form>
    </div>
</body>
</html>