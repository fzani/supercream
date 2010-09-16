<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MaintainCompletedInvoices.ascx.cs"
    Inherits="Controls_MaintainCompletedInvoices" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<div class="FormInput">
    <fieldset id="Fieldset3">
        <asp:Panel ID="InvoiceSearchCriteriaPanel" DefaultButton="SearchButton" runat="server">
            <legend>
                <h3>
                    Search Invoices</h3>
            </legend>
            <table class="search" style="width: 100%;">
                <tr>
                    <td class="right" style="width: 100%;">
                        <table class="left" style="width: 100%;">
                            <tr>
                                <td style="width: 25%;">
                                    <asp:Label ID="InvoiceNoLabel" Text="Invoice No" runat="server"></asp:Label>
                                </td>
                                <td style="width: 75%;">
                                    <asp:TextBox ID="InvoiceNoSearchTextBox" Width="300px" MaxLength="10" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="OrderNoLabel" Text="Order No" runat="server"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="OrderNoSearchTextBox" Width="300px" MaxLength="10" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="CustomerNameLabel" Text="Customer Name" runat="server"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="CustomerNameSearchTextBox" Width="300px" MaxLength="30" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Invoice Date From
                                </td>
                                <td>
                                    <asp:TextBox ID="DateFromTextBox" Style="vertical-align: middle;" runat="server"
                                        ValidationGroup="NewOutletGroup" MaxLength="100" Width="100px"></asp:TextBox>
                                    <asp:Image runat="Server" Style="vertical-align: middle;" ID="Image1" ImageUrl="~/images/Calendar_scheduleHS.png"
                                        AlternateText="Click to show calendar" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ValidationGroup="NewOutletGroup"
                                        ControlToValidate="DateFromTextBox" ErrorMessage="Date Effective From is required"
                                        InitialValue="" Text="Required" runat="server" />
                                    <asp:RequiredFieldValidator ID="StartDateRequiredFieldValidator" runat="server" ControlToValidate="DateFromTextBox"
                                        Display="Dynamic" ErrorMessage="Start Date is a required field" SetFocusOnError="True"
                                        ValidationGroup="AddLeaveGroup">*</asp:RequiredFieldValidator>
                                    <ajaxToolkit:CalendarExtender ID="calendarButtonExtender" Format="dd/MM/yyyy" runat="server"
                                        TargetControlID="DateFromTextBox" PopupButtonID="Image1" />
                                    <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="DateFromTextBox"
                                        Mask="99/99/9999" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                                        OnInvalidCssClass="MaskedEditError" MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Invoice Date To
                                </td>
                                <td>
                                    <asp:TextBox ID="DateToTextBox" Style="vertical-align: middle;" runat="server" ValidationGroup="NewOutletGroup"
                                        MaxLength="100" Width="100px"></asp:TextBox>
                                    <asp:Image runat="Server" Style="vertical-align: middle;" ID="Image2" ImageUrl="~/images/Calendar_scheduleHS.png"
                                        AlternateText="Click to show calendar" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="NewOutletGroup"
                                        ControlToValidate="DateToTextBox" ErrorMessage="Date Effective From is required"
                                        InitialValue="" Text="Required" runat="server" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="DateToTextBox"
                                        Display="Dynamic" ErrorMessage="Start Date is a required field" SetFocusOnError="True"
                                        ValidationGroup="AddLeaveGroup">*</asp:RequiredFieldValidator>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" Format="dd/MM/yyyy" runat="server"
                                        TargetControlID="DateToTextBox" PopupButtonID="Image2" />
                                    <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="DateToTextBox"
                                        Mask="99/99/9999" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                                        OnInvalidCssClass="MaskedEditError" MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Invoices/InvoicesPrinted
                                </td>
                                <td>
                                    <asp:DropDownList ID="InvoicesPrintedDropDownList" Width="250px" AutoPostBack="true"
                                        runat="server">
                                        <asp:ListItem Text="- No Item Selected --" Value="-1"></asp:ListItem>
                                        <asp:ListItem Text="Invoices" Value="2"></asp:ListItem>
                                        <asp:ListItem Text="Invoices Printed" Value="3"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                    <asp:Button ID="SearchButton" Text="Search" CausesValidation="false" runat="server"
                                        OnClick="SearchButton_Click" />
                                    <asp:Button ID="ClearButton" Text="Clear Search" CausesValidation="false" runat="server"
                                        OnClick="ClearButton_Click" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <asp:ListView ID="InvoiceDetailsListView" runat="server" DataSourceID="ObjectDataSource1"
            runat="server">
            <ItemTemplate>
                <tr style="">
                    <td>
                        <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
                    </td>
                    <td>
                        <asp:Label ID="InvoiceNoLabel" runat="server" Text='<%# Eval("InvoiceNo") %>' />
                    </td>
                    <td>
                        <asp:Label ID="OrderIDLabel" runat="server" Text='<%# Eval("OrderID") %>' />
                    </td>
                    <td>
                        <asp:Label ID="OrderDateLabel" runat="server" Text=' <%# DataBinder.Eval(Container.DataItem, "OrderDate", "{0:d}")%>' />
                    </td>
                    <td>
                        <asp:Label ID="InvoiceDateLabel" runat="server" Text=' <%# DataBinder.Eval(Container.DataItem, "InvoiceDate", "{0:d}")%>' />
                    </td>
                    <td style="text-align: center;">
                        <asp:CheckBox ID="InvoicePaymentCompleteCheckBox" runat="server" Checked='<%# Eval("InvoicePaymentComplete") %>'
                            Enabled="false" />
                    </td>
                </tr>
            </ItemTemplate>
            <AlternatingItemTemplate>
                <tr style="">
                    <td>
                        <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
                    </td>
                    <td>
                        <asp:Label ID="InvoiceNoLabel" runat="server" Text='<%# Eval("InvoiceNo") %>' />
                    </td>
                    <td>
                        <asp:Label ID="OrderIDLabel" runat="server" Text='<%# Eval("OrderID") %>' />
                    </td>
                    <td>
                        <asp:Label ID="OrderDateLabel" runat="server" Text=' <%# DataBinder.Eval(Container.DataItem, "OrderDate", "{0:d}")%>' />
                    </td>
                    <td>
                        <asp:Label ID="InvoiceDateLabel" runat="server" Text=' <%# DataBinder.Eval(Container.DataItem, "InvoiceDate", "{0:d}")%>' />
                    </td>
                    <td style="text-align: center;">
                        <asp:CheckBox ID="InvoicePaymentCompleteCheckBox" runat="server" Checked='<%# Eval("InvoicePaymentComplete") %>'
                            Enabled="false" />
                    </td>
                </tr>
            </AlternatingItemTemplate>
            <EmptyDataTemplate>
                <table runat="server" style="">
                    <tr>
                        <td>
                            No data was returned.
                        </td>
                    </tr>
                </table>
            </EmptyDataTemplate>
            <InsertItemTemplate>
                <tr style="">
                    <td>
                        <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="Insert" />
                        <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Clear" />
                    </td>
                    <td>
                        <asp:TextBox ID="InvoiceNoTextBox" runat="server" Text='<%# Bind("InvoiceNo") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="OrderIDTextBox" runat="server" Text='<%# Bind("OrderID") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="OrderDateTextBox" runat="server" Text='<%# Bind("OrderDate") %>' />
                    </td>
                    <td>
                        <asp:CheckBox ID="InvoicePaymentCompleteCheckBox" runat="server" Checked='<%# Bind("InvoicePaymentComplete") %>' />
                    </td>
                </tr>
            </InsertItemTemplate>
            <LayoutTemplate>
                <table runat="server" style="width: 100%">
                    <tr runat="server">
                        <td runat="server">
                            <table id="itemPlaceholderContainer" runat="server" border="0" style="">
                                <tr runat="server" style="">
                                    <th runat="server" style="width: 20%">
                                    </th>
                                    <th runat="server" style="width: 20%">
                                        InvoiceNo
                                    </th>
                                    <th id="Th2" runat="server" style="width: 20%">
                                        OrderID
                                    </th>
                                    <th runat="server" style="width: 20%">
                                        OrderDate
                                    </th>
                                    <th>
                                        Invoice Date
                                    </th>
                                    <th id="Th1" runat="server" style="width: 20%">
                                        InvoicePaymentComplete
                                    </th>
                                </tr>
                                <tr id="itemPlaceholder" runat="server">
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr runat="server">
                        <td runat="server" style="">
                        </td>
                    </tr>
                </table>
            </LayoutTemplate>
            <EditItemTemplate>
                <tr style="">
                    <td>
                        <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Update" />
                        <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancel" />
                    </td>
                    <td>
                        <asp:Label ID="InvoiceNoTextBox" runat="server" Text='<%# Bind("InvoiceNo") %>' />
                    </td>
                    <td>
                        <asp:Label ID="OrderIDTextBox" runat="server" Text='<%# Bind("OrderID") %>' />
                    </td>
                    <td>
                    </td>
                    <td>
                        <asp:CheckBox ID="InvoicePaymentCompleteCheckBox" runat="server" Checked='<%# Bind("InvoicePaymentComplete") %>' />
                    </td>
                </tr>
            </EditItemTemplate>
            <SelectedItemTemplate>
                <tr style="">
                    <td>
                        <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
                    </td>
                    <td>
                        <asp:Label ID="InvoiceNoLabel" runat="server" Text='<%# Eval("InvoiceNo") %>' />
                    </td>
                    <td>
                        <asp:Label ID="OrderIDLabel" runat="server" Text='<%# Eval("OrderID") %>' />
                    </td>
                    <td>
                        <asp:Label ID="OrderDateLabel" runat="server" Text='<%# Bind("OrderDate") %>' />
                    </td>
                    <td>
                        <asp:CheckBox ID="InvoicePaymentCompleteCheckBox" runat="server" Checked='<%# Eval("InvoicePaymentComplete") %>'
                            Enabled="false" />
                    </td>
                </tr>
            </SelectedItemTemplate>
        </asp:ListView>
    </fieldset>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetInvoicesWithStatus"
        TypeName="OrderHeaderUI" DataObjectTypeName="WcfFoundationService.InvoiceWithStatus"
        UpdateMethod="UpdateInvoiceCompletionStatus" OnSelecting="ObjectDataSource1_Selecting">
        <SelectParameters>
            <asp:Parameter Name="orderNo" Type="String" />
            <asp:Parameter Name="invoiceNo" Type="String" />
            <asp:Parameter Name="customerName" Type="String" />
            <asp:Parameter Name="dateFrom" Type="DateTime" />
            <asp:Parameter Name="dateTo" Type="DateTime" />
            <asp:Parameter Name="orderStatus" Type="Object" />
        </SelectParameters>
    </asp:ObjectDataSource>
</div>
