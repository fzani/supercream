<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login"
    StylesheetTheme="SuperCream" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head id="Head1" runat="server">
    <meta name="Description" content="Order Processing." />
    <meta name="Keywords" content="your, keywords" />
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <meta name="Distribution" content="Global" />
    <meta name="Author" content="John Coxhead - jcoxhead@hotmail.com" />
    <meta name="Robots" content="index,follow" />
    <title>Super Cream</title>
</head>
<body>
    <div id="header">
        <h1 id="logo-text">
            <a href="~/General/Default.aspx">Super Cream Order Processing</a></h1>
        <p id="slogan">
            The way forward ...</p>
        <div id="header-links">
            <p>
                <a id="A1" href="~/General/Default.aspx" runat="server">Home</a> | <a id="A2" href="~/General/Support.aspx"
                    runat="server">Contact</a> | <a id="A3" href="~/General/Default.aspx" runat="server">Site Map</a>
            </p>
        </div>
    </div>
    <form id="MainForm" runat="server">
    <asp:Panel runat="server">
        <asp:Login ID="Login1" runat="server" Width="100%">
            <LayoutTemplate>
                <div align="center" style="width: 100%; margin-bottom: 200px;">
                    <table style="margin-top: 50px; background: #eaeaea; width: 40%;">
                        <tr>
                            <td style="text-align: left; padding-top: 10px; padding-bottom: 5px; width: 25%;">
                                <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">User Name:</asp:Label>
                            </td>
                            <td style="text-align: left; padding-top: 10px; padding-bottom: 5px; width: 75%;">
                                <asp:TextBox ID="UserName" Width="90%" MaxLength="15" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator Display="Dynamic" ID="UserNameRequired" runat="server"
                                    ControlToValidate="UserName" ErrorMessage="User Name is required." Text="*" ToolTip="User Name is required."
                                    ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left; padding-bottom: 5px;">
                                <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Password:</asp:Label>
                            </td>
                            <td style="text-align: left; padding-bottom: 5px;">
                                <asp:TextBox ID="Password" runat="server" MaxLength="15" Width="90%" TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="PasswordRequired" Display="Dynamic" runat="server"
                                    ControlToValidate="Password" ErrorMessage="Password is required." Text="*" ToolTip="Password is required."
                                    ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td style="padding-bottom: 5px;">
                            </td>
                            <td style="text-align: left; padding-bottom: 5px;">
                                <asp:CheckBox ID="RememberMe" runat="server" Text="Remember me next time." />
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <span style="color: Red">
                                    <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                </span>
                            </td>
                        </tr>
                        <tr>
                            <td style="padding-bottom: 10px">
                            </td>
                            <td style="text-align: left; padding-bottom: 10px">
                                <asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="Log In" ValidationGroup="Login1" />
                            </td>
                        </tr>
                    </table>
                </div>
            </LayoutTemplate>
        </asp:Login>
    </asp:Panel>
    </form>
</body>
