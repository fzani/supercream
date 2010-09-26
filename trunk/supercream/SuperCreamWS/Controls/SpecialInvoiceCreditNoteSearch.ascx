<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SpecialInvoiceCreditNoteSearch.ascx.cs"
    Inherits="Controls_CreditNoteSearch" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<div class="FormInput">
    Invoice
    <fieldset id="Fieldset3">
        <asp:Panel ID="CreditNoteSearchCriteriaPanel" DefaultButton="SearchButton" runat="server">
            <legend>
                <h3>
                    Search Credit Notes</h3>
            </legend>
            <table class="search" style="width:100%">
                <tr>
                    <td class="right" style="width:100%">
                        <table class="left" style="width:100%">
                            <tr>
                                <td style="width:30%">
                                    <asp:Label ID="InvoiceNoLabel" Text="Invoice No" runat="server"></asp:Label>
                                </td>
                                <td style="width:70%">
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
                                    Credit Note Due Date From
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
                                    Credit Note Due Date To
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
        <asp:Panel ID="CreditNoteSelectionGrid" runat="server">
            <h2>
                Credit Notes</h2>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="98%"
                DataSourceID="CreditNotesObjectDataSource" OnRowCommand="GridView1_RowCommand">
                <EmptyDataTemplate>
                    <div align="center" class="CenterBox">
                        <span style="text-align: center">
                            <h3>
                                <asp:Label ID="Label3" Text="No Items Found" runat="server"></asp:Label>
                            </h3>
                        </span>
                    </div>
                </EmptyDataTemplate>
                <Columns>
                    <asp:TemplateField HeaderText="Order No/Reference" SortExpression="OrderNo/Reference">
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("OrderNo") %>'></asp:Label>
                            <br />
                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("Reference") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="20%" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="InvoiceNo" HeaderText="Invoice No" ItemStyle-Width="15%"
                        SortExpression="InvoiceNo">
                        <ItemStyle Width="15%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="CustomerName" HeaderText="Customer Name" ItemStyle-Width="40%"
                        SortExpression="CustomerName" Visible="">
                        <ItemStyle Width="35%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="DueDate" HeaderText="Credit Note Due Date"
                        SortExpression="DueDate" ItemStyle-HorizontalAlign="Center" DataFormatString="{0:d}">
                        <ItemStyle Width="20%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="CreditNoteID" HeaderText="CreditNoteID" SortExpression="CreditNoteID"
                        Visible="false" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="EditCreditNoteButton" runat="server" CommandArgument='<%# Bind("CreditNoteID") %>'
                                CommandName="EditCreditNote" ControlStyle-CssClass="button" ItemStyle-Width="20%"
                                Text="Select" />
                        </ItemTemplate>
                        <ItemStyle Width="10%" HorizontalAlign="Center" />
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:ObjectDataSource ID="CreditNotesObjectDataSource" runat="server" OnSelecting="ObjectDataSource1_Selecting"
                SelectMethod="SearchCreditNotes" TypeName="SpecialInvoiceCreditNoteUI">
                <SelectParameters>                    
                    <asp:Parameter Name="invoiceNo" Type="String" />
                    <asp:Parameter Name="customerName" Type="String" />
                    <asp:Parameter Name="dateFrom" Type="DateTime" />
                    <asp:Parameter Name="dateTo" Type="DateTime" />
                </SelectParameters>
            </asp:ObjectDataSource>
        </asp:Panel>
    </fieldset>
</div>
