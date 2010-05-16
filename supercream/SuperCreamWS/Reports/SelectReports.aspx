<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SelectReports.aspx.cs" MasterPageFile="~/MasterPage.master"
    StylesheetTheme="SuperCream" Inherits="Reports_SelectReports" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainPlaceholder" runat="Server">
    <div style="margin: 20px">
        <table>
            <tr>
                <td>
                    <h3>
                        Select Report</h3>
                </td>
                <td>
                    <asp:DropDownList ID="ReportsDropDownList" Style="width: 300px" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    <asp:Button ID="SelectButton" Text="Select" OnClick="OnClick_SelectButton" Width="100px"
                        runat="server" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
