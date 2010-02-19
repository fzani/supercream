<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MaintainDeliveryNote.ascx.cs"
    Inherits="Controls_MaintainDeliveryNote" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<div class="FormInput">
    <fieldset id="Fieldset3">
        <asp:Panel ID="DeliveryNoteSearchCriteriaPanel" DefaultButton="SearchButton" runat="server">
            <legend>
                <h3>
                    Search Delivery Notes</h3>
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
                                    Delivery Note/Delivery Notes Printed
                                </td>
                                <td>
                                    <asp:DropDownList ID="DeliveryNotesPrintedDropDownList" Width="250px" AutoPostBack="true"
                                        runat="server" OnSelectedIndexChanged="DeliveryNotesDropDownList_SelectedIndexChanged">
                                        <asp:ListItem Text="- No Item Selected --" Value="-1"></asp:ListItem>
                                        <asp:ListItem Text="Delivery Notes" Value="6"></asp:ListItem>
                                        <asp:ListItem Text="Delivery Notes Printed" Value="7"></asp:ListItem>
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
        <asp:Panel ID="DeliveryNoteHeaderSearchGridPanel" runat="server">
            <asp:GridView ID="DeliveryNoteGridView" DataKeyNames="ID" runat="server" Width="98%"
                AllowPaging="True" DataSourceID="DeliveryNoteObjectDataSource" AutoGenerateColumns="False"
                OnRowDataBound="DeliveryNoteGridView_RowDataBound" OnRowCommand="DeliveryNoteGridView_RowCommand">
                <EmptyDataTemplate>
                    <h3>
                        No records Found</h3>
                </EmptyDataTemplate>
                <Columns>
                    <asp:TemplateField ItemStyle-Width="15%" ShowHeader="False">
                        <ItemTemplate>
                            <asp:Button ID="SelectButton" runat="server" CausesValidation="false" CommandName="Select"
                                CommandArgument='<%# Bind("ID") %>' Text="Select" />
                        </ItemTemplate>
                        <ItemStyle Width="15%" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Order No." ItemStyle-Width="25%" SortExpression="AlphaID">
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("AlphaID") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("AlphaID") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemStyle Width="20%" />
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
            <asp:ObjectDataSource ID="DeliveryNoteObjectDataSource" runat="server" SelectMethod="GetOrderHeadersSearchWithPrintedStatuses"
                TypeName="OrderHeaderUI" OnSelecting="DeliveryNoteObjectDataSource_Selecting">
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
        <asp:Panel ID="DeliveryNoteEntryPanel" Visible="false" runat="server">
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
                        Select Delivery Address
                    </td>
                    <td>
                        <asp:DropDownList ID="DeliveryDropDownList" AutoPostBack="true" Width="250px" ValidationGroup="ModifyInvoiceDetailsGroup"
                            runat="server" OnSelectedIndexChanged="DeliveryDropDownList_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ValidationGroup="ModifyInvoiceDetailsGroup"
                            ControlToValidate="DeliveryDropDownList" InitialValue="-1" ErrorMessage="You must select Delivery"
                            Text="*" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        Select Account for Invoice
                    </td>
                    <td>
                        <asp:DropDownList ID="AccountDropDownList" AutoPostBack="true" Width="250px" ValidationGroup="ModifyInvoiceDetailsGroup"
                            runat="server">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ValidationGroup="ModifyInvoiceDetailsGroup"
                            ControlToValidate="AccountDropDownList" InitialValue="-1" ErrorMessage="You must select Account"
                            Text="*" runat="server" />
                    </td>
                </tr>
            </table>
            <asp:Panel ID="OrderHeaderDetailsPanel" Visible="false" runat="server">
                <table style="width: 100%">
                    <tr>
                        <td colspan="7">
                            <asp:Button ID="ConfirmDelivery" Text="Confirm Delivery Note" runat="server" ValidationGroup="ModifyInvoiceDetailsGroup"
                                OnClick="ConfirmDeliveryNote_Click" />
                            <asp:Button ID="ChangeDeliveryNoteDetailsButton" ValidationGroup="ModifyInvoiceDetailsGroup"
                                Visible="false" Text="Change Delivery Note Details" runat="server" OnClick="ChangeDeliveryNoteDetailsButton_Click" />
                            <asp:Button ID="CancelDeliveryNoteButton" ValidationGroup="ModifyInvoiceDetailsGroup"
                                Visible="false" Text="Cancel Delivery Note" runat="server" OnClick="CancelInvoiceButton_Click" />
                            <asp:Button ID="CreateInvoiceButton" Text="Create Invoice" runat="server" ValidationGroup="ModifyInvoiceDetailsGroup"
                                OnClick="CreateInvoiceButton_Click" />
                            <asp:Button ID="PrintDeliveryNoteButton" ValidationGroup="ModifyInvoiceDetailsGroup"
                                Visible="false" Text="Print Delivery Note" runat="server" 
                                onclick="PrintDeliveryNoteButton_Click" />
                            <asp:Button ID="RePrintDeliveryButton" ValidationGroup="ModifyInvoiceDetailsGroup"
                                Visible="false" Text="RePrint Delivery Note" runat="server" />
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
                                <asp:Label ID="Label5" Text="Printing Document ..." Style="font-weight: bold; margin-left: 20px;"
                                    runat="server"></asp:Label>
                                <br />
                                <br />
                                <asp:Label ID="Label6" Text="press OK to continue" Style="font-weight: bold; margin-left: 20px;"
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
            <asp:Panel ID="DisplayDeliveryNotePanel" Visible="false" runat="server">
                <table style="width: 100%" cellpadding="0" cellspacing="0">
                    <tr>
                        <td style="width: 50%">
                            <table style="width: 100%; border: solid 1px #eaeaea;">
                                <tr>
                                    <td style="width: 50%">
                                        <b>Delivery Address</b>
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
                </table>
            </asp:Panel>
            <asp:Repeater ID="DeliveryNoteRepeater" Visible="false" runat="server" DataSourceID="DeliveryNoteLinesObjectDataSource"
                OnItemDataBound="Repeater1_ItemDataBound">
                <HeaderTemplate>
                    <table style="width: 100%">
                        <tr>
                            <td style="width: 15%">
                                <b>No Of Units</b>
                            </td>
                            <td style="width: 55%">
                                <b>Product Description</b>
                            </td>
                            <td style="width: 15%">
                                <b>Qty Per Unit</b>
                            </td>
                            <td style="width: 15%">
                                <b>R.R.P</b>
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
                            <asp:Label ID="RRPLabel" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <b><i>
                                <asp:Label ID="SpecialInstructionsNameLabel" Text="Special Instructions" Visible="false"
                                    runat="server"></asp:Label>
                            </i></b>
                        </td>
                        <td colspan="3">
                            <asp:TextBox ID="SpecialInstructionsTextBox" Width="90%" ReadOnly="true" Visible="false"
                                TextMode="MultiLine" Height="50px" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    <tr>
                        <td colspan="4">
                            <table>
                                <tr>
                                    <td style="width: 40%">
                                    </td>
                                    <td style="width: 60%">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <hr />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="vertical-align: top">
                                        <b>Special Instructions</b>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="SpecialInstructionsHeaderTextBox" ReadOnly="true" TextMode="MultiLine"
                                            Width="95%" Height="100px" runat="server">
                                        </asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b>Total No. Of Units for Delivery</b> &nbsp;
                                        <asp:Label ID="TotalItemsLabel" runat="server"></asp:Label>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b>Delivery Date</b> &nbsp;
                                        <asp:Label ID="DeliveryDateLabel" runat="server"></asp:Label>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
            <asp:ObjectDataSource ID="DeliveryNoteLinesObjectDataSource" runat="server" SelectMethod="GetOrderLines"
                TypeName="OrderLineUI">
                <SelectParameters>
                    <asp:ControlParameter ControlID="DeliveryNoteGridView" Name="id" PropertyName="SelectedValue"
                        Type="Int32" />
                </SelectParameters>
            </asp:ObjectDataSource>
        </asp:Panel>
    </fieldset>
</div>
