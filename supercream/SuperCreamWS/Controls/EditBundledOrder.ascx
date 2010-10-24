<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EditBundledOrder.ascx.cs"
    Inherits="EditBundledOrder" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<div class="FormInput">
    <fieldset id="Fieldset3">
        <legend>
            <h3>
                Maintain Offers</h3>
        </legend>
        <div style="text-align: left">
            <table class="search" style="width: 80%">
                <tr>
                    <td style="width: 20%">
                        Search
                    </td>
                    <td style="width: 0%">
                        <asp:TextBox ID="SearchTextBox" Width="200" runat="server">
                        </asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        <asp:Button ID="SearchButton" Text="Search" runat="server" />
                    </td>
                </tr>
            </table>
        </div>
        <asp:FormView ID="FormView1" Style="padding: 5px;" runat="server" Width="100%" DataKeyNames="Id"
            AllowPaging="True" PagerSettings-Mode="NumericFirstLast" DataSourceID="OffersObjectDataSource"
            OnItemDeleted="FormView1_ItemDeleted" OnItemInserted="FormView1_ItemInserted"
            OnItemUpdated="FormView1_ItemUpdated">
            <EditItemTemplate>
                <table style="width: 80%" class="formgrid">
                    <tr class="row-a">
                        <th style="width: 30%">
                            Name
                        </th>
                        <td style="width: 70%; padding-left: 10px;">
                            <asp:Label ID="IDLabel1" Visible="false" runat="server" Text='<%# Eval("ID") %>' />
                            <asp:TextBox ID="NameTextBox" runat="server" Width="95%" Text='<%# Bind("Name") %>' />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="UpdateBundledOrderGroup"
                                ControlToValidate="NameTextBox" ErrorMessage="Date Effective From is required"
                                InitialValue="" Text="*" runat="server" />
                        </td>
                    </tr>
                    <tr class="row-b">
                        <th>
                            ValidFrom
                        </th>
                        <td style="padding-left: 10px;">
                            <asp:TextBox ID="ValidFromTextBox" runat="server" MaxLength="100" Width="100px" Text='<%# Bind("ValidFrom", "{0:d}") %>' />
                            <asp:Image runat="Server" Style="vertical-align: middle;" ID="CalendarImage1" ImageUrl="~/images/Calendar_scheduleHS.png"
                                AlternateText="Click to show calendar" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ValidationGroup="UpdateBundledOrderGroup"
                                ControlToValidate="ValidFromTextBox" ErrorMessage="Date Effective From is required"
                                InitialValue="" Text="*" runat="server" />
                            <ajaxToolkit:CalendarExtender ID="calendarButtonExtender" Format="dd/MM/yyyy" runat="server"
                                TargetControlID="ValidFromTextBox" PopupButtonID="CalendarImage1" />
                            <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="ValidFromTextBox"
                                Mask="99/99/9999" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                                OnInvalidCssClass="MaskedEditError" MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" />
                        </td>
                    </tr>
                    <tr class="row-a">
                        <th>
                            ValidTo
                        </th>
                        <td style="padding-left: 10px;">
                            <asp:TextBox ID="ValidToTextBox" runat="server" MaxLength="100" Width="100px" Text='<%# Bind("ValidTo", "{0:d}") %>' />
                            <asp:Image runat="Server" Style="vertical-align: middle;" ID="CalendarImage2" ImageUrl="~/images/Calendar_scheduleHS.png"
                                AlternateText="Click to show calendar" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="UpdateBundledOrderGroup"
                                ControlToValidate="ValidToTextBox" ErrorMessage="Date Effective To is required"
                                InitialValue="" Text="*" runat="server" />
                            <ajaxToolkit:CalendarExtender ID="CalendarButtonExtender1" Format="dd/MM/yyyy" runat="server"
                                TargetControlID="ValidToTextBox" PopupButtonID="CalendarImage2" />
                            <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="ValidToTextBox"
                                Mask="99/99/9999" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                                OnInvalidCssClass="MaskedEditError" MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" />
                        </td>
                    </tr>
                </table>
                <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" ValidationGroup="UpdateBundledOrderGroup"
                    CommandName="Update" Text="Update" />
                &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False"
                    CommandName="Cancel" Text="Cancel" />
            </EditItemTemplate>
            <InsertItemTemplate>
                <table style="width: 80%" class="formgrid">
                    <tr class="row-a">
                        <th style="width: 30%">
                            Name
                        </th>
                        <td style="width: 70%; padding-left: 10px;">
                            <asp:TextBox ID="NameTextBox" runat="server" Width="95%" Text='<%# Bind("Name") %>' />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="NewBundledOrder"
                                ControlToValidate="NameTextBox" ErrorMessage="Date Effective From is required"
                                InitialValue="" Text="*" runat="server" />
                        </td>
                    </tr>
                    <tr class="row-b">
                        <th>
                            Valid From
                        </th>
                        <td style="padding-left: 10px;">
                            <asp:TextBox ID="ValidFromTextBox" MaxLength="100" Width="100px" runat="server" Text='<%# Bind("ValidFrom") %>' />
                            <asp:Image runat="Server" Style="vertical-align: middle;" ID="CalendarImage1" ImageUrl="~/images/Calendar_scheduleHS.png"
                                AlternateText="Click to show calendar" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ValidationGroup="NewBundledOrder"
                                ControlToValidate="ValidFromTextBox" ErrorMessage="Date Effective From is required"
                                InitialValue="" Text="*" runat="server" />
                            <ajaxToolkit:CalendarExtender ID="calendarButtonExtender" Format="dd/MM/yyyy" runat="server"
                                TargetControlID="ValidFromTextBox" PopupButtonID="CalendarImage1" />
                            <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="ValidFromTextBox"
                                Mask="99/99/9999" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                                OnInvalidCssClass="MaskedEditError" MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" />
                        </td>
                    </tr>
                    <tr class="row-a">
                        <th>
                            Valid To
                        </th>
                        <td style="padding-left: 10px;">
                            <asp:TextBox ID="ValidToTextBox" runat="server" MaxLength="100" Width="100px" Text='<%# Bind("ValidTo", "{0:d}") %>' />
                            <asp:Image runat="Server" Style="vertical-align: middle;" ID="CalendarImage2" ImageUrl="~/images/Calendar_scheduleHS.png"
                                AlternateText="Click to show calendar" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="NewBundledOrder"
                                ControlToValidate="ValidToTextBox" ErrorMessage="Date Effective To is required"
                                InitialValue="" Text="*" runat="server" />
                            <ajaxToolkit:CalendarExtender ID="CalendarButtonExtender1" Format="dd/MM/yyyy" runat="server"
                                TargetControlID="ValidToTextBox" PopupButtonID="CalendarImage2" />
                            <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="ValidToTextBox"
                                Mask="99/99/9999" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                                OnInvalidCssClass="MaskedEditError" MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" />
                        </td>
                    </tr>
                </table>
                <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" ValidationGroup="NewBundledOrder"
                    CommandName="Insert" Text="Insert" />
                &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False"
                    CommandName="Cancel" Text="Cancel" />
            </InsertItemTemplate>
            <ItemTemplate>
                <table style="width: 80%" class="formgrid">
                    <tr class="row-a">
                        <th style="width: 30%">
                            Name
                        </th>
                        <td style="width: 70%; padding-left: 10px;">
                            <asp:Label ID="Label1" runat="server" Visible="false" Text='<%# Eval("ID") %>' />
                            <asp:Label ID="NameLabel" runat="server" Text='<%# Bind("Name") %>' />
                        </td>
                    </tr>
                    <tr class="row-b">
                        <th>
                            Valid From
                        </th>
                        <td style="padding-left: 10px;">
                            <asp:Label ID="ValidFromLabel" runat="server" Text='<%# Eval("ValidFrom", "{0:d}") %>' />
                        </td>
                    </tr>
                    <tr class="row-b">
                        <th>
                            Valid To
                        </th>
                        <td style="padding-left: 10px;">
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
        <asp:ObjectDataSource ID="OffersObjectDataSource" runat="server" SelectMethod="GetAllOffers"
            TypeName="OfferUI" InsertMethod="SaveOffer" UpdateMethod="UpdateOffer" 
            DeleteMethod="DeleteOffer">
            <SelectParameters>
                <asp:ControlParameter ControlID="SearchTextBox" Name="offer" 
                    PropertyName="Text" Type="String" />
            </SelectParameters>
            <InsertParameters>
                <asp:Parameter Name="name" Type="String" />
                <asp:Parameter Name="validFrom" Type="DateTime" />
                <asp:Parameter Name="validTo" Type="DateTime" />
            </InsertParameters>
            <DeleteParameters>
                <asp:Parameter Name="id" Type="Int32" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="id" Type="Int32" />
                <asp:Parameter Name="name" Type="String" />
                <asp:Parameter Name="validFrom" Type="DateTime" />
                <asp:Parameter Name="validTo" Type="DateTime" />
            </UpdateParameters>
        </asp:ObjectDataSource>
</div>
