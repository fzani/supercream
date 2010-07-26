<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MembershipUserCollection>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Index</h2>
    <p>
        <%= Html.ActionLink("Register New User", "Register", "Account") %>
        if you don't have an account.
    </p>
    <h2>
        Existing Users</h2>
    <table>
        <% foreach (MembershipUser user in Model)
           { %>
        <tr>
            <td>
                <%= user.UserName %>
            </td>
            <td>
                <%= user.Email %>
            </td>
            <td>
                <%= Html.ActionLink("Edit", "Edit", new { user.UserName })%>
                <%= Html.ActionLink("Delete", "Delete", new { user.UserName } ) %>
            </td>
        </tr>
        <% } %>
    </table>
</asp:Content>
