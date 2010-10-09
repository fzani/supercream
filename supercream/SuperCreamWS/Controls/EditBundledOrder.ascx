<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EditBundledOrder.ascx.cs"
    Inherits="EditBundledOrder" %>

<asp:FormView ID="FormView1" runat="server" AllowPaging="True" DataKeyNames="ID"
    DataSourceID="SqlDataSource" Width="100%">
    <EditItemTemplate>
        <table style="width: 70%">
            <tr class="row-a">
                <th style="width: 30%">
                    Name
                </th>
                <td style="width: 70%">
                    <asp:Label ID="IDLabel1" Visible="false" runat="server" Text='<%# Eval("ID") %>' />
                    <asp:TextBox ID="NameTextBox" runat="server" Width="90%" Text='<%# Bind("Name") %>' />
                </td>
            </tr>
            <tr class="row-b">
                <th>
                    ValidFrom
                </th>
                <td>
                    <asp:TextBox ID="ValidFromTextBox" runat="server" Width="90%" Text='<%# Eval("ValidFrom", "{0:d}") %>' />
                </td>
            </tr>
            <tr class="row-a">
                <th>
                    ValidTo
                </th>
                <td>
                    <asp:TextBox ID="ValidToTextBox" runat="server" Width="90%" Text='<%# Eval("ValidTo", "{0:d}") %>' />
                </td>
            </tr>
        </table>
        <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update"
            Text="Update" />
        &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False"
            CommandName="Cancel" Text="Cancel" />
    </EditItemTemplate>
    <InsertItemTemplate>
        <table style="width: 70%">
            <tr class="row-a">
                <th style="width: 30%">
                    Name
                </th>
                <td style="width: 70%">
                    <asp:TextBox ID="TextBox1" runat="server" Visible="false" Text='<%# Bind("ID") %>' />
                    <asp:TextBox ID="NameTextBox" runat="server" Width="90%" Text='<%# Bind("Name") %>' />
                </td>
            </tr>
            <tr class="row-b">
                <th>
                    ValidFrom
                </th>
                <td>
                    <asp:TextBox ID="ValidFromTextBox" Width="90%" runat="server" Text='<%# Bind("ValidFrom") %>' />
                </td>
            </tr>
            <tr class="row-a">
                <th>
                    ValidTo
                </th>
                <td>
                    <asp:TextBox ID="ValidToTextBox" Width="90%" runat="server" Text='<%# Bind("ValidTo") %>' />
                </td>
            </tr>
        </table>
        <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert"
            Text="Insert" />
        &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False"
            CommandName="Cancel" Text="Cancel" />
    </InsertItemTemplate>
    <ItemTemplate>
        <table style="width: 70%">
            <tr class="row-a">
                <th style="width: 30%">
                    Name
                </th>
                <td style="width: 70%">
                    <asp:Label ID="Label1" runat="server" Visible="false" Text='<%# Eval("ID") %>' />
                    <asp:Label ID="NameLabel" runat="server" Text='<%# Bind("Name") %>' />
                </td>
            </tr>
            <tr class="row-b">
                <th>
                    Valid From
                </th>
                <td>
                    <asp:Label ID="ValidFromLabel" runat="server" Text='<%# Eval("ValidFrom", "{0:d}") %>' />
                </td>
            </tr>
            <tr class="row-b">
                <th>
                    Valid To Valid To
                </th>
                <td>
                    <asp:Label ID="ValitdoLabel" runat="server" Text='<%# Eval("ValidTo", "{0:d}") %>' />
                </td>
            </tr>
        </table>
        <asp:Button ID="NewOrderBundleButton" runat="server" CommandName="New" Text="New" />
        <asp:Button ID="EditOrderBundleButton" runat="server" CommandName="Edit" Text="Edit" />
        <asp:Button ID="DeleteOrderBundleButton" runat="server" CommandName="Delete" Text="Delete" />
    </ItemTemplate>
    <EmptyDataTemplate>
        <h3>
            There are no Bundled Items Defined</h3>
    </EmptyDataTemplate>
</asp:FormView>
<mvp:PageDataSource ID="widgetDataSource" runat="server" EnablePaging="true" 
    DataObjectTypeName="SP.Core.Domain.Offer"
    ConflictDetection="CompareAllValues" 
    OldValuesParameterFormatString="original{0}"
    SelectMethod="GetOffers" 
    SelectCountMethod="GetOffersCount" 
    UpdateMethod="UpdateOffer"
    InsertMethod="InsertOffer" 
    DeleteMethod="DeleteOffer">
</mvp:PageDataSource>

