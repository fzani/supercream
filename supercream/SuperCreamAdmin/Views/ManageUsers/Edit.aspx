<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MembershipUser>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Edit
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Edit</h2>
    <h2>
        User --> <span style="color: Green">
            <%= Model.UserName %>
        </span>
    </h2>
    <p>
        Passwords are required to be a minimum of
        <%=Html.Encode(ViewData["PasswordLength"])%>
        characters in length.
    </p>
    <%= Html.ValidationSummary("Account creation was unsuccessful. Please correct the errors and try again.") %>
    <% using (Html.BeginForm(Model))
       { %>
    <div>
        <fieldset>
            <legend>Account Information</legend>
            <p>
                <%= Html.Hidden("username") %>
                <label for="currentPassword">
                    Current password:</label>
                <%= Html.Password("currentPassword") %>
                <%= Html.ValidationMessage("currentPassword") %>
            </p>
            <p>
                <label for="newPassword">
                    New password:</label>
                <%= Html.Password("newPassword") %>
                <%= Html.ValidationMessage("newPassword") %>
            </p>
            <p>
                <label for="confirmPassword">
                    Confirm new password:</label>
                <%= Html.Password("confirmPassword") %>
                <%= Html.ValidationMessage("confirmPassword") %>
            </p>
            <p>
                <input name="submitButton" type="submit" value="Change Password" />
                <input name="submitButton" type="submit" value="Cancel" />
            </p>
        </fieldset>
    </div>
    <% } %>
</asp:Content>
