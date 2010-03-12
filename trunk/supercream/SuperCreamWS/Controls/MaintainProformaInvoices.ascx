<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MaintainProformaInvoices.ascx.cs"
    Inherits="Controls_MaintainProformaInvoices" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<div class="FormInput">
    <fieldset id="Fieldset3">
        <asp:Panel ID="InvoiceSearchCriteriaPanel" DefaultButton="SearchButton" runat="server">
            <legend>
                <h3>
                    Search Proforma Invoices</h3>
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
                                <td>
                                    <asp:DropDownList ID="InvoicesPrintedDropDownList" Width="250px" AutoPostBack="true"
                                        runat="server" OnSelectedIndexChanged="InvoicesPrintedDropDownList_SelectedIndexChanged">
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
            <asp:GridView ID="InvoiceGridView" DataKeyNames="ID" runat="server" Width="98%" AllowPaging="True"
                DataSourceID="InvoiceObjectDataSource" AutoGenerateColumns="False" OnRowDataBound="InvoiceGridView_RowDataBound"
                OnRowCommand="InvoiceGridView_RowCommand">
                <AlternatingRowStyle BackColor="White" />
                <EmptyDataTemplate>
                    <h3>
                        No records Found</h3>
                </EmptyDataTemplate>
                <Columns>
                    <asp:TemplateField ItemStyle-Width="10%" ShowHeader="False">
                        <ItemTemplate>
                            <asp:LinkButton ID="SelectButton" runat="server" CausesValidation="false" CommandName="Select"
                                CommandArgument='<%# Bind("ID") %>' Text="Select" />
                        </ItemTemplate>
                        <ItemStyle Width="10%" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Order No." ItemStyle-Width="20%" SortExpression="AlphaID">
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("AlphaID") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("AlphaID") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemStyle Width="20%" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Invoice No." ItemStyle-Width="20%" SortExpression="InvoiceNo">
                        <ItemTemplate>
                            <asp:Label ID="InvoiceLabel" runat="server" Text='<%# Bind("InvoiceNo") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="InvoiceTextBox" runat="server" Text='<%# Bind("InvoiceNo") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemStyle Width="20%" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Customer Name" ItemStyle-Width="30%" SortExpression="CustomerID">
                        <ItemTemplate>
                            <table>
                                <tr>
                                    <td>
                                        <asp:Label ID="CustomerNameLabel" runat="server" Text='<%# Bind("CustomerID") %>'></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Image ID="ConfirmedImage" runat="server" ImageUrl="~/images/ok_16x16.gif" />
                                        &nbsp; &nbsp;
                                        <asp:Image ID="PrintedImage" runat="server" Visible="false" ImageUrl="~/images/print.gif" />
                                        &nbsp;
                                        <asp:Image ID="RePrintedImage" runat="server" Visible="false" ImageUrl="~/images/print_16x16.gif" />
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("CustomerID") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemStyle Width="30%" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Order Date" SortExpression="OrderDate">
                        <ItemTemplate>
                            <asp:Label ID="Label3" runat="server" ItemStyle-Width="20%" Text='<%# DataBinder.Eval(Container.DataItem, "OrderDate", "{0:d}") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox3" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "OrderDate", "{0:d}") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <table>
                <tr>
                    <td style="vertical-align: middle; margin-left: 20px;">
                        <i>Credit Note = Confirmed = &nbsp;
                            <asp:Image ID="ConfirmedImage" runat="server" ImageAlign="Middle" ImageUrl="~/images/ok_16x16.gif" />
                            &nbsp Printed = &nbsp;
                            <asp:Image ID="PrintedImage" runat="server" ImageAlign="Middle" ImageUrl="~/images/print.gif" />
                            &nbsp; Reprinted = &nbsp;
                            <asp:Image ID="RePrintedImage" runat="server" ImageAlign="Middle" ImageUrl="~/images/print_16x16.gif" />
                        </i>
                    </td>
                </tr>
            </table>
            <asp:ObjectDataSource ID="InvoiceObjectDataSource" runat="server" SelectMethod="GetOrderHeadersSearchWithPrintedStatuses"
                TypeName="OrderHeaderUI" OnSelecting="InvoiceObjectDataSource_Selecting">
                <SelectParameters>
                    <asp:Parameter Name="orderHeader" Type="String" />
                    <asp:Parameter Name="invoiceNo" Type="String" />
                    <asp:Parameter Name="customerName" Type="String" />
                    <asp:Parameter Name="dateFrom" Type="DateTime" />
                    <asp:Parameter Name="dateTo" Type="DateTime" />
                    <asp:Parameter Name="actualOrderStatus" Type="Int16" />
                    <asp:Parameter Name="printedOrderStatus" Type="Int16" />
                </SelectParameters>
            </asp:ObjectDataSource>
        </asp:Panel>
        <asp:Button runat="server" ID="hiddenTargetControlForModalPopup" Style="display: none" />
        <ajaxToolkit:ModalPopupExtender ID="CreditNoteModalPopupExtender" DropShadow="true"
            runat="server" TargetControlID="hiddenTargetControlForModalPopup" PopupControlID="DisplayActionPanel"
            CancelControlID="CancelActionPanelButton" BackgroundCssClass="XPopUpBackGround" />
        <asp:Panel Style="display: none;" ID="DisplayActionPanel" runat="server" DefaultButton="CancelActionPanelButton"
            CssClass="modalPopup">
            <div style="width: 800px;">
                <table style="width: 100%; background-color: #7CAACB;">
                    <tr>
                        <td style="font-size: 1.2em; color: White; width: 530px;">
                            Description
                        </td>
                        <td style="font-size: 1.2em; color: White; width: 270px;">
                            Reason for Action
                        </td>
                    </tr>
                </table>
            </div>
            <div style="width: 800px;">
                <table style="width: 100%;">
                    <tr>
                        <td colspan="4" style="text-align: center">
                            <asp:Button ID="CancelActionPanelButton" Width="100%" Text="OK" runat="server" />
                        </td>
                    </tr>
                </table>
            </div>
        </asp:Panel>
        <asp:Panel ID="InvoiceEntryPanel" Visible="false" runat="server">
            <h3>
                Select Invoice Details</h3>
            <table style="width: 100%">
                <tr>
                    <td colspan="2">
                        <hr />
                    </td>
                </tr>
                <tr>
                    <td>
                        <h2>
                            <i>Order No</i></h2>
                    </td>
                    <td>
                        <h2>
                            <i>
                                <asp:Label ID="OrderHeaderNoLabel" runat="server"></asp:Label>
                            </i>
                        </h2>
                    </td>
                </tr>
                <tr>
                    <td>
                        <h2>
                            <i>Invoice No</i></h2>
                    </td>
                    <td>
                        <h2>
                            <i>
                                <asp:Label ID="InvoiceHeaderNoLabel" runat="server"></asp:Label>
                            </i>
                        </h2>
                    </td>
                </tr>
                <tr>
                    <td>
                        Select Delivery Address
                    </td>
                    <td>
                        <asp:DropDownList ID="DeliveryDropDownList" AutoPostBack="true" Width="250px" ValidationGroup="ModifyInvoiceDetailsGroup"
                            runat="server" OnSelectedIndexChanged="DeliveryDropDownList_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ValidationGroup="ModifyInvoiceDetailsGroup"
                            ControlToValidate="DeliveryDropDownList" InitialValue="-1" ErrorMessage="You must select Delivery"
                            Text="*" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        Select Account for Invoice
                    </td>
                    <td>
                        <asp:DropDownList ID="AccountDropDownList" AutoPostBack="true" Width="250px" OnSelectedIndexChanged="AccountDropDownList_SelectedIndexChanged"
                            ValidationGroup="ModifyInvoiceDetailsGroup" runat="server">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ValidationGroup="ModifyInvoiceDetailsGroup"
                            ControlToValidate="AccountDropDownList" InitialValue="-1" ErrorMessage="You must select Account"
                            Text="*" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:LinkButton ID="CancelSelectInvoiceDetails" Text="Cancel Select Details" Width="100%"
                            runat="server" OnClick="CancelSelectInvoiceDetails_Click" />
                    </td>
                </tr>
            </table>
            <asp:Panel ID="OrderHeaderDetailsPanel" Visible="false" runat="server">
                <table style="width: 100%">
                    <tr>
                        <td colspan="4">
                            <asp:Button ID="ConfirmInvoice" Text="Confirm Proforma Invoice" runat="server" ValidationGroup="ModifyInvoiceDetailsGroup"
                                OnClick="ConfirmInvoice_Click" />
                            <asp:Button ID="ChangeInvoiceDetailsButton" ValidationGroup="ModifyInvoiceDetailsGroup"
                                Visible="false" Text="Change Invoice Details" runat="server" OnClick="ChangeInvoiceDetailsButton_Click" />
                            <asp:Button ID="CancelInvoiceButton" ValidationGroup="ModifyInvoiceDetailsGroup"
                                Visible="false" Text="Cancel Invoice" runat="server" OnClick="CancelInvoiceButton_Click" />
                            <asp:Button ID="PrintInvoiceButton" ValidationGroup="ModifyInvoiceDetailsGroup" Visible="false"
                                Text="Print Invoice" runat="server" OnClick="PrintInvoiceButton_Click" />
                            <asp:Button ID="RePrintInvoiceButton" ValidationGroup="ModifyInvoiceDetailsGroup"
                                Visible="false" Text="RePrint Invoice" runat="server" OnClick="RePrintInvoiceButton_Click" />
                            <asp:Button ID="btnTrigger" runat="server" Style="display: none" />
                            <asp:Button ID="btnOKTrigger" runat="server" Style="display: none" />
                            <ajaxToolkit:ModalPopupExtender ID="PrintFailedPopupControlExtender" DropShadow="true"
                                runat="server" TargetControlID="btnTrigger" PopupControlID="PrintPanelMessage"
                                CancelControlID="OKFailedPrintButton" BackgroundCssClass="XPopUpBackGround" />
                            <asp:Panel Style="display: none" ID="PrintPanelMessage" runat="server" Width="400px"
                                CssClass="modalPopup">
                                <asp:Label ID="Label1" Text="Print Failed" Style="font-weight: bold; margin-left: 20px;"
                                    runat="server"></asp:Label>
                                <br />
                                <br />
                                <asp:Label ID="PrintFailedLabel" Text="Failure reason" Style="margin-left: 20px;"
                                    runat="server"></asp:Label>
                                <br />
                                <br />
                                <center>
                                    <asp:TextBox ID="ErrorTextBox" TextMode="MultiLine" Wrap="true" Height="50" Width="80%"
                                        ReadOnly="true" runat="server"></asp:TextBox>
                                    <br />
                                    <asp:Button ID="OKFailedPrintButton" runat="server" Text="OK" ValidationGroup="GridViewPanel"
                                        CssClass="button" />
                                </center>
                            </asp:Panel>
                            <ajaxToolkit:ModalPopupExtender ID="OKModalPopupExtender" DropShadow="true" runat="server"
                                TargetControlID="btnOKTrigger" PopupControlID="PrintOKPanel" CancelControlID="OkPrintButton"
                                BackgroundCssClass="XPopUpBackGround" />
                            <asp:Panel Style="display: none" ID="PrintOKPanel" runat="server" Width="400px" CssClass="modalPopup">
                                <asp:Label ID="Label2" Text="Printing Document ..." Style="font-weight: bold; margin-left: 20px;"
                                    runat="server"></asp:Label>
                                <br />
                                <br />
                                <asp:Label ID="Label5" Text="press OK to continue" Style="font-weight: bold; margin-left: 20px;"
                                    runat="server"></asp:Label>
                                <br />
                                <center>
                                    <asp:Button ID="OKPrintButton" runat="server" Text="OK" ValidationGroup="GridViewPanel"
                                        CssClass="button" />
                                </center>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <h3>
                                Proforma Invoice</h3>
                        </td>
                    </tr>
                    <tr>
                        <td class="emphasise" style="width: 25%">
                            Date Of Order
                        </td>
                        <td class="emphasise" style="width: 25%">
                            Payment Terms
                        </td>
                        <td class="emphasise" style="width: 25%">
                            Invoice No
                        </td>
                        <td class="emphasise" style="width: 25%">
                            Delivery Van
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 25%">
                            <asp:Label ID="DateOfOrderLabel" runat="server"></asp:Label>
                        </td>
                        <td style="width: 25%">
                            <asp:Label ID="PaymentTermsLabel" runat="server"></asp:Label>
                        </td>
                        <td style="width: 25%">
                            <asp:Label ID="InvoiceLabel" runat="server"></asp:Label>
                        </td>
                        <td style="width: 25%">
                            <asp:DropDownList ID="DeliveryVanDropDownList" AutoPostBack="true" runat="server"
                                DataSourceID="VanObjectDataSource" DataTextField="Description" DataValueField="ID"
                                Width="120px" OnSelectedIndexChanged="DeliveryVanDropDownList_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="ModifyInvoiceDetailsGroup"
                                ControlToValidate="DeliveryVanDropDownList" InitialValue="-1" ErrorMessage="You must select Van"
                                Text="*" runat="server" />
                            <asp:ObjectDataSource ID="VanObjectDataSource" runat="server" SelectMethod="GetAllVans"
                                TypeName="VanUI"></asp:ObjectDataSource>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <asp:Panel ID="DisplayInvoicePanel" Visible="false" runat="server">
                <table style="width: 96%" cellpadding="0" cellspacing="0">
                    <tr>
                        <td style="width: 50%">
                            <table style="width: 100%; border: solid 1px #eaeaea;">
                                <tr>
                                    <td style="width: 50%">
                                        <b>Invoice Address</b>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 50%">
                                        <asp:Label ID="CustomerCompanyNameLabel" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="CustomerAddressLine1Label" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="CustomerAddressLine2Label" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="TownLabel" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="CountyLabel" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="PostCodeLabel" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="CustomerContactNameLabel" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="CustomerContactTelephoneLabel" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td style="width: 50%">
                            <table style="width: 100%; border: solid 1px #eaeaea;">
                                <tr>
                                    <td>
                                        <b>
                                            <asp:Label ID="YourCompanyNameLabel" runat="server"></asp:Label>
                                        </b>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="YourAddressLine1Label" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="YourAddressLine2Label" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="YourAddressTownLabel" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="YourAddressCountyLabel" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="YourAddressPostCodeLabel" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="YourAddressVatRegistrationNo" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Tel:
                                        <asp:Label ID="OfficePhoneNumber1Label1" runat="server"></asp:Label>
                                        or
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="OfficePhoneNumber1Label2" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <table style="width: 100%; border: solid 1px #eaeaea;">
                                <tr>
                                    <td style="width: 50%">
                                        <b>Delivery Address</b>
                                    </td>
                                    <td style="width: 50%">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 50%">
                                        <asp:Label ID="DeliveryCompanyNameLabel" runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="DeliveryCountyLabel" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="DeliveryCustomerAddressLine1Label" runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="DeliveryTownLabel" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="DeliveryCustomerAddressLine2Label" runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="DeliveryPostCodeLabel" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b>Map Reference : &nbsp;</b>
                                        <asp:Label ID="DeliveryMapReferenceLabel" runat="server"></asp:Label>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <asp:Repeater ID="InvoiceRepeater" Visible="false" runat="server" DataSourceID="InvoiceLinesObjectDataSource"
                OnItemDataBound="Repeater1_ItemDataBound">
                <HeaderTemplate>
                    <table style="width: 100%">
                        <tr>
                            <td style="width: 10%">
                                <b>No Of Units</b>
                            </td>
                            <td style="width: 28%">
                                <b>Product Description</b>
                            </td>
                            <td style="width: 15%">
                                <b>Qty Per Unit</b>
                            </td>
                            <td style="width: 18%">
                                <b>Price Per Unit</b>
                            </td>
                            <td style="width: 7%">
                                <b>R.R.P</b>
                            </td>
                            <td style="width: 10%">
                                <b>Vat Exempt</b>
                            </td>
                            <td style="width: 10%">
                                <b>Net Price</b>
                            </td>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                            <asp:Label ID="Label4" Visible="false" Text='<%# Bind("ID") %>' runat="server"></asp:Label>
                            <asp:Label ID="NoOfUnitsLabel" Text='<%# Bind("NoOfUnits") %>' runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="DescriptionLabel" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="QtyPerUnitLabel" Text='<%# Bind("QtyPerUnit") %>' runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="PricePerUnitLabel" Text='<%# Bind("Price") %>' runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="RRPLabel" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="VatExemptibleLabel" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="NetPriceLabel" Text="1.24" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            <b><i>
                                <asp:Label ID="SpecialInstructionsNameLabel" Text="Special Instructions" Visible="false"
                                    runat="server"></asp:Label>
                            </i></b>
                        </td>
                        <td colspan="5">
                            <asp:TextBox ID="SpecialInstructionsTextBox" ReadOnly="true" Visible="false" TextMode="MultiLine"
                                Height="50px" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    <tr>
                        <td colspan="7">
                            <table style="width: 100%;">
                                <tr>
                                    <td style="width: 14%">
                                    </td>
                                    <td style="width: 14%">
                                    </td>
                                    <td style="width: 14%">
                                    </td>
                                    <td style="width: 14%">
                                    </td>
                                    <td style="width: 14%">
                                    </td>
                                    <td style="width: 14%">
                                    </td>
                                    <td style="width: 14%">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="7">
                                        <hr />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <b>Special Instructions</b>
                                    </td>
                                    <td colspan="3">
                                        <asp:TextBox ID="SpecialInstructionsHeaderTextBox" ReadOnly="true" TextMode="MultiLine"
                                            Width="95%" Height="100px" runat="server">
                                        </asp:TextBox>
                                    </td>
                                    <td>
                                        <b>Total</b>
                                    </td>
                                    <td>
                                        <asp:Label ID="TotalLabel" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <b>Payment Terms</b>
                                    </td>
                                    <td colspan="3">
                                        <asp:Label ID="PaymentTermsLabel" runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        <b>+VAT</b>
                                    </td>
                                    <td>
                                        <asp:Label ID="VatLabel" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="5">
                                        <b>Total No. Of Units for Delivery</b> &nbsp;
                                        <asp:Label ID="TotalItemsLabel" runat="server"></asp:Label>
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <b>Delivery Date</b>
                                    </td>
                                    <td>
                                        <asp:Label ID="DeliveryDateLabel" runat="server"></asp:Label>
                                    </td>
                                    <td colspan="2">
                                        <b>Delivery Van</b> &nbsp;
                                        <asp:Label ID="DeliveryVanLabel" runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        <b>Total</b>
                                    </td>
                                    <td>
                                        <asp:Label ID="NetTotalLabel" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
            <asp:ObjectDataSource ID="InvoiceLinesObjectDataSource" runat="server" SelectMethod="GetOrderLines"
                TypeName="OrderLineUI">
                <SelectParameters>
                    <asp:ControlParameter ControlID="InvoiceGridView" Name="id" PropertyName="SelectedValue"
                        Type="Int32" />
                </SelectParameters>
            </asp:ObjectDataSource>
        </asp:Panel>
    </fieldset>
</div>
