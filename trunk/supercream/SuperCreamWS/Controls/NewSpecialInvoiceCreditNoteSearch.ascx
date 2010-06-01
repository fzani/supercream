<%@ Control Language="C#" AutoEventWireup="true" CodeFile="NewSpecialInvoiceCreditNoteSearch.ascx.cs"
    Inherits="Controls_NewSpecialInvoiceCreditNoteSearch" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<div class="FormInput">
    <fieldset id="Fieldset3">
        <asp:Panel ID="InvoiceSearchCriteriaPanel" DefaultButton="SearchButton" runat="server">
            <legend>
                <h3>
                    Search Special Invoices</h3>
            </legend>
            <table class="search">
                <tr>
                    <td class="right">
                        <table class="left">
                            <tr>
                                <td>
                                    <asp:Label ID="InvoiceNoLabel" Text="Invoice No" runat="server"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="InvoiceNoSearchTextBox" Width="300px" MaxLength="10" runat="server"></asp:TextBox>
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
                                    Date From
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
                                    Date To
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
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                    <asp:LinkButton ID="SearchButton" Text="Search" CausesValidation="false" runat="server"
                                        OnClick="SearchButton_Click" />
                                    |
                                    <asp:LinkButton ID="ClearButton" Text="Clear Search" CausesValidation="false" runat="server"
                                        OnClick="ClearButton_Click" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <asp:Panel ID="InvoiceHeaderSearchGridPanel" runat="server">
            <h2>
                Special Invoices</h2>
            <asp:GridView ID="InvoiceGridView" DataKeyNames="ID" runat="server" Width="98%" AllowPaging="True"
                DataSourceID="InvoiceObjectDataSource" AutoGenerateColumns="False" OnRowDataBound="InvoiceGridView_RowDataBound"
                OnRowCommand="InvoiceGridView_RowCommand">
                <EmptyDataTemplate>
                    <h3>
                        No records Found</h3>
                </EmptyDataTemplate>
                <Columns>
                    <asp:TemplateField ItemStyle-Width="15%" ShowHeader="False">
                        <ItemTemplate>
                            <asp:LinkButton ID="SelectButton" runat="server" CausesValidation="false" CommandName="Select"
                                CommandArgument='<%# Bind("ID") %>' Text="Select" />
                        </ItemTemplate>
                        <ItemStyle Width="15%" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Invoice No." ItemStyle-Width="25%" SortExpression="InvoiceNo">
                        <ItemTemplate>
                            <asp:Label ID="InvoiceLabel" runat="server" Text='<%# Bind("InvoiceNo") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="InvoiceTextBox" runat="server" Text='<%# Bind("InvoiceNo") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemStyle Width="20%" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Customer Name" ItemStyle-Width="40%" SortExpression="CustomerID">
                        <ItemTemplate>
                            <asp:Label ID="CustomerNameLabel" runat="server" Text='<%# Bind("CustomerID") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("CustomerID") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemStyle Width="40%" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Invoice Date" SortExpression="OrderDate">
                        <ItemTemplate>
                            <asp:Label ID="Label3" runat="server" ItemStyle-Width="20%" Text='<%# DataBinder.Eval(Container.DataItem, "OrderDate", "{0:d}") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox3" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "OrderDate", "{0:d}") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:ObjectDataSource ID="InvoiceObjectDataSource" runat="server" SelectMethod="GetSpecialInvoiceHeadersSearchWithPrintedStatuses"
                TypeName="SpecialInvoiceHeaderUI" OnSelecting="InvoiceObjectDataSource_Selecting">
                <SelectParameters>
                    <asp:Parameter Name="invoiceNo" Type="String" />
                    <asp:Parameter Name="customerName" Type="String" />
                    <asp:Parameter Name="dateFrom" Type="DateTime" />
                    <asp:Parameter Name="dateTo" Type="DateTime" />
                    <asp:Parameter Name="actualOrderStatus" Type="Int16" />
                    <asp:Parameter Name="printedOrderStatus" Type="Int16" />
                </SelectParameters>
            </asp:ObjectDataSource>
        </asp:Panel>
    </fieldset>
</div>
