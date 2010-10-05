<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MaintainSpecialInvoices.ascx.cs"
    Inherits="Controls_MaintainSpecialInvoices" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Panel ID="ModifyOrderPanel" Visible="true" runat="server">
    <div class="FormInput">
        <fieldset id="Fieldset3">
            <asp:Panel ID="OrderSearchPanel" DefaultButton="SearchButton" runat="server">
                <legend>
                    <h3>
                        Special Invoices</h3>
                </legend>
                <table class="search" style="width: 100%">
                    <tr>
                        <td class="right" style="width: 100%">
                            <table class="left" style="width: 100%">
                                <tr>
                                    <td style="width: 20%">
                                        Invoice No
                                    </td>
                                    <td style="width: 80%">
                                        <asp:TextBox ID="InvoiceNoTextBox" Width="300px" MaxLength="20" runat="server"></asp:TextBox>
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
                                            InitialValue="" Text="*" runat="server" />
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
                                            InitialValue="" Text="*" runat="server" />
                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender1" Format="dd/MM/yyyy" runat="server"
                                            TargetControlID="DateToTextBox" PopupButtonID="Image2" />
                                        <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="DateToTextBox"
                                            Mask="99/99/9999" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                                            OnInvalidCssClass="MaskedEditError" MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Order Status
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="OrderStatusDropDownList" runat="server" Width="250px" DataSourceID="OrderStatusXmlDataSource"
                                            DataTextField="LongName" AutoPostBack="true" DataValueField="ID" OnSelectedIndexChanged="OrderStatusDropDownList_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        <asp:XmlDataSource ID="OrderStatusXmlDataSource" runat="server" DataFile="~/App_Data/InvoiceStauses.xml">
                                        </asp:XmlDataSource>
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
            <asp:Panel ID="SpecialInvoicesSearchGridPanel" runat="server">
                <asp:GridView ID="SpecialInvoicesSearchGridView" Width="98%" runat="server" AutoGenerateColumns="False"
                    DataSourceID="ObjectDataSource1" OnRowCommand="SpecialInvoicesSearchGridView_RowCommand"
                    OnRowDataBound="SpecialInvoicesSearchGridView_RowDataBound">
                    <Columns>
                        <asp:TemplateField ItemStyle-Width="20%" ShowHeader="False">
                            <ItemTemplate>
                                <asp:LinkButton ID="SelectButton" runat="server" CausesValidation="false" CommandName="Select"
                                    CommandArgument='<%# Bind("ID") %>' Text="Select" />
                            </ItemTemplate>
                            <ItemStyle Width="10%" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="InvoiceNo" HeaderText="Invoice No" SortExpression="InvoiceNo"
                            ItemStyle-Width="15%">
                            <ItemStyle Width="15%" />
                        </asp:BoundField>
                        <asp:TemplateField ItemStyle-Width="45%" HeaderText="Customer Name" ShowHeader="False">
                            <ItemTemplate>
                                <asp:Label ID="CustomerNameLabel" runat="server" />
                            </ItemTemplate>
                            <ItemStyle Width="45%" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="OrderDate" HeaderText="Invoice Date" SortExpression="OrderDate"
                            DataFormatString="{0:d}" ItemStyle-Width="25%">
                            <ItemStyle Width="15%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="DeliveryDate" HeaderText="DeliveryDate" SortExpression="DeliveryDate"
                            DataFormatString="{0:d}" ItemStyle-Width="25%">
                            <ItemStyle Width="15%" />
                        </asp:BoundField>
                    </Columns>
                </asp:GridView>
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetSpecialInvoices"
                    TypeName="SpecialInvoiceHeaderUI" OnSelecting="ObjectDataSource1_Selecting">
                    <SelectParameters>
                        <asp:Parameter Name="orderNo" Type="String" />
                        <asp:Parameter Name="invoiceNo" Type="String" />
                        <asp:Parameter Name="customerName" Type="String" />
                        <asp:Parameter Name="dateFrom" Type="DateTime" />
                        <asp:Parameter Name="dateTo" Type="DateTime" />
                        <asp:Parameter Name="orderStatus" Type="Int16" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </asp:Panel>
        </fieldset>
        <fieldset>
            <asp:Panel ID="SpecialInvoiceHeaderPanel" runat="server">
                <legend>
                    <h3>
                        Special Invoice Header Details</h3>
                </legend>
                <table style="width: 100%">
                    <tr>
                        <td style="width: 30%;">
                            Customer Name
                        </td>
                        <td>
                            <asp:DropDownList ID="CustomerDropDownList" AutoPostBack="true" Width="400px" runat="server"
                                ValidationGroup="AddOrderDetailsGroup" OnSelectedIndexChanged="CustomerDropDownList_SelectedIndexChanged">
                            </asp:DropDownList>
                            <ajaxToolkit:ListSearchExtender ID="ListSearchExtender2" runat="server" TargetControlID="CustomerDropDownList"
                                PromptCssClass="ListSearchExtenderPrompt" PromptText="Text to Search For" QueryPattern="Contains"
                                QueryTimeout="2000" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ValidationGroup="AddOrderDetailsGroup"
                                ControlToValidate="CustomerDropDownList" InitialValue="-1" ErrorMessage="You must select Customer"
                                Text="*" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 30%;">
                            Account
                        </td>
                        <td>
                            <asp:DropDownList ID="AccountDropDownList" AutoPostBack="true" Width="400px" runat="server"
                                ValidationGroup="AddOrderDetailsGroup">
                            </asp:DropDownList>
                            <ajaxToolkit:ListSearchExtender ID="ListSearchExtender1" runat="server" TargetControlID="AccountDropDownList"
                                PromptCssClass="ListSearchExtenderPrompt" PromptText="Text to Search For" QueryPattern="Contains"
                                QueryTimeout="2000" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" ValidationGroup="AddOrderDetailsGroup"
                                ControlToValidate="AccountDropDownList" InitialValue="-1" ErrorMessage="You must select Account"
                                Text="*" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 30%;">
                            Outlet Store
                        </td>
                        <td>
                            <asp:DropDownList ID="OutletStoreDropDownList" AutoPostBack="true" Width="400px"
                                runat="server" ValidationGroup="AddOrderDetailsGroup">
                            </asp:DropDownList>
                            <ajaxToolkit:ListSearchExtender ID="ListSearchExtender3" runat="server" TargetControlID="OutletStoreDropDownList"
                                PromptCssClass="ListSearchExtenderPrompt" PromptText="Text to Search For" QueryPattern="Contains"
                                QueryTimeout="2000" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" ValidationGroup="AddOrderDetailsGroup"
                                ControlToValidate="OutletStoreDropDownList" InitialValue="-1" ErrorMessage="You must select Outlet Store"
                                Text="*" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 30%;">
                            Invoice No
                        </td>
                        <td style="width: 70%;">
                            <asp:TextBox ID="InvoiceHeaderNoTextBox" Width="250px" ValidationGroup="AddOrderDetailsButton"
                                MaxLength="20" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="AddOrderDetailsGroup"
                                ControlToValidate="InvoiceHeaderNoTextBox" ErrorMessage="Order No is required"
                                InitialValue="" Text="*" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 30%;">
                            Date of Order
                        </td>
                        <td style="width: 70%;">
                            <asp:TextBox ID="OrderDateTextBox" Style="vertical-align: middle;" runat="server"
                                ValidationGroup="AddOrderDetailsGroup" MaxLength="100" Width="100px"></asp:TextBox>
                            <asp:Image runat="Server" Style="vertical-align: middle;" ID="Image3" ImageUrl="~/images/Calendar_scheduleHS.png"
                                AlternateText="Click to show calendar" />
                            <asp:RequiredFieldValidator ID="OrderDateRequiredFieldValidator" runat="server" ControlToValidate="OrderDateTextBox"
                                Display="Dynamic" ErrorMessage="Order Date is a required field" SetFocusOnError="True"
                                ValidationGroup="AddOrderDetailsGroup">*</asp:RequiredFieldValidator>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender2" Format="dd/MM/yyyy" runat="server"
                                TargetControlID="OrderDateTextBox" PopupButtonID="Image3" />
                            <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender3" runat="server" TargetControlID="OrderDateTextBox"
                                Mask="99/99/9999" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                                OnInvalidCssClass="MaskedEditError" MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 30%;">
                            Delivery Date
                        </td>
                        <td style="width: 70%;">
                            <asp:TextBox ID="DeliveryDateTextBox" Style="vertical-align: middle;" runat="server"
                                ValidationGroup="AddOrderDetailsGroup" MaxLength="100" Width="100px"></asp:TextBox>
                            <asp:Image runat="Server" Style="vertical-align: middle;" ID="Image4" ImageUrl="~/images/Calendar_scheduleHS.png"
                                AlternateText="Click to show calendar" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="DeliveryDateTextBox"
                                Display="Dynamic" ErrorMessage="Delivery Date is a required field" SetFocusOnError="True"
                                ValidationGroup="AddOrderDetailsGroup">*</asp:RequiredFieldValidator>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender3" Format="dd/MM/yyyy" runat="server"
                                TargetControlID="DeliveryDateTextBox" PopupButtonID="Image4" />
                            <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender4" runat="server" TargetControlID="DeliveryDateTextBox"
                                Mask="99/99/9999" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                                OnInvalidCssClass="MaskedEditError" MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Special Instructions
                        </td>
                        <td>
                            <asp:TextBox ID="OrderHeaderSpecialInstructionsTextBox" Width="95%" Height="100px"
                                TextMode="MultiLine" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:LinkButton ID="AddOrderLineDetailsButton" runat="server" ValidationGroup="AddOrderDetailsGroup"
                                Text="Add Invoice Line Details" OnClick="AddOrderLineDetailsButton_Click" />
                            <asp:LinkButton ID="Button1" CausesValidation="false" runat="server" Text="| Cancel | "
                                OnClick="CancelNewOrderButton_Click" />
                            <asp:LinkButton ID="DeleteOrderButton" CausesValidation="false" runat="server" Text="Void Special Invoice Details"
                                OnClick="GetVoidSpecialInvoiceReasonButton_Click" />
                            <asp:Button ID="btnTrigger1" runat="server" Style="display: none" />
                            <ajaxToolkit:ModalPopupExtender ID="ReasonForVoidingPopupExtenderInvoice" DropShadow="true"
                                runat="server" TargetControlID="btnTrigger1" PopupControlID="ReasonForVoidingPanelMessage"
                                CancelControlID="CancelReasonorVoidingButton" BackgroundCssClass="XPopUpBackGround" />
                            <asp:Panel Style="display: none" DefaultButton="ReasonforVoidingButton" Width="700px"
                                ID="ReasonForVoidingPanelMessage" runat="server" CssClass="modalPopup">
                                <table>
                                    <tr>
                                        <td style="width: 30%">
                                            <h3>
                                                Reason for Voiding Order</h3>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="ReasonforVoidingTextBox" Width="100%" Height="300px" TextMode="MultiLine"
                                                runat="server" ValidationGroup="VoidOrderDetailsGroup"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1ReasonForVoiding" Display="Dynamic"
                                                ValidationGroup="VoidOrderDetailsGroup" ControlToValidate="ReasonforVoidingTextBox"
                                                InitialValue="" ErrorMessage="Invoice to is a required Field" Text="*" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Button ID="ReasonforVoidingButton" CoommandArgument='<%# SpecialInvoiceID %>'
                                                Text="Void Special Invoice" runat="server" OnClick="VoidOrderButton_Click" ValidationGroup="VoidOrderDetailsGroup" />
                                            <asp:Button ID="CancelReasonorVoidingButton" Text="Cancel" CausesValidation="false"
                                                runat="server" />
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="PrintButton" Text="Print" Width="200px" runat="server" OnClick="PrintButton_Click" />
                        </td>
                        <td>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <asp:Panel ID="AddSpecialInvoiceLineDetailsPanel" runat="server">
                <table style="width: 100%">
                    <tr>
                        <td class="emphasise" style="width: 15%">
                            <b>Description</b>
                        </td>
                        <td style="width: 85%">
                            <asp:TextBox ID="LineDescriptionTextBox" MaxLength="100" Width="80%" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ValidationGroup="AddSpecialInvoiceLinesGroup"
                                ControlToValidate="LineDescriptionTextBox" ErrorMessage="Description is required"
                                InitialValue="" Text="*" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="emphasise">
                            Qty/unit
                        </td>
                        <td>
                            <asp:TextBox ID="QtyPerUnitTextBox" Width="60px" runat="server"></asp:TextBox>
                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server"
                                TargetControlID="QtyPerUnitTextBox" FilterType="Numbers" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ValidationGroup="AddSpecialInvoiceLinesGroup"
                                ControlToValidate="QtyPerUnitTextBox" ErrorMessage="Qty per unit is required"
                                InitialValue="" Text="*" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="emphasise">
                            No Of Units
                        </td>
                        <td>
                            <asp:TextBox ID="NoOfUnitsTextBox" MaxLength="3" Width="60px" runat="server" AutoPostBack="True"></asp:TextBox>
                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                TargetControlID="NoOfUnitsTextBox" FilterType="Numbers" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ValidationGroup="AddSpecialInvoiceLinesGroup"
                                ControlToValidate="NoOfUnitsTextBox" ErrorMessage="No of units is required" InitialValue=""
                                Text="*" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="emphasise">
                            <i>Price (per units)</i>
                        </td>
                        <td>
                            <asp:TextBox ID="PricePerUnitsTextBox" runat="server"></asp:TextBox>
                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server"
                                TargetControlID="PricePerUnitsTextBox" FilterType="Custom,Numbers" ValidChars="£." />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" ValidationGroup="AddSpecialInvoiceLinesGroup"
                                ControlToValidate="NoOfUnitsTextBox" ErrorMessage="Price per units is required"
                                InitialValue="" Text="*" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="emphasise">
                            <i>Discount (%)</i>
                        </td>
                        <td>
                            <asp:TextBox ID="DiscountTextBox" runat="server"></asp:TextBox>
                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server"
                                TargetControlID="DiscountTextBox" FilterType="Custom,Numbers" ValidChars="%." />
                        </td>
                    </tr>
                    <tr>
                        <td class="emphasise">
                            <i>Price Charge</i>
                        </td>
                        <td>
                            <asp:Label ID="PriceChargeTextBox" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="emphasise">
                            <i>Vat Exempt</i>
                        </td>
                        <td>
                            <asp:CheckBox ID="VatExemptCheckBox" runat="server"></asp:CheckBox>
                            &nbsp;&nbsp;
                            <asp:Label ID="PriceIncludingVatLabel" Visible="false" Font-Italic="true" Font-Size="Medium"
                                runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="emphasise" colspan="2">
                            Special Instructions
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="margin-left: 20px">
                            <asp:TextBox ID="SpecialInstructionsTextBox" Height="100" Width="80%" runat="server"
                                TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:LinkButton ID="AddSpecialInvoiceLineButton" Text="Add |" ValidationGroup="AddSpecialInvoiceLinesGroup"
                                runat="server" OnClick="AddSpecialInvoiceLineButton_Click"></asp:LinkButton>
                            <asp:LinkButton ID="CancelSpecialInvoiceLineButton" Text="Cancel |" runat="server"
                                OnClick="CancelSpecialInvoiceLineButton_Click1"></asp:LinkButton>
                            <asp:LinkButton ID="CalculateButton" Text="Calculate" runat="server" OnClick="CalculateButton_Click1">
                            </asp:LinkButton>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <asp:Panel ID="SpecialInvoiceLinesGridViewPanel" runat="server">
                <fieldset id="Fieldset1">
                    <div align="center">
                        <asp:GridView ID="AddSpecialInvoiceLinesGridViewPanel" runat="server" Width="96%"
                            DataKeyNames="ID" AutoGenerateColumns="False" DataSourceID="ObjectDataSource2"
                            OnRowDataBound="AddSpecialInvoiceLinesGridViewPanel_RowDataBound" OnRowCommand="AddSpecialInvoiceLinesGridViewPanel_RowCommand">
                            <Columns>
                                <asp:TemplateField Visible="false" SortExpression="ID">
                                    <ItemTemplate>
                                        <asp:Label ID="ID" runat="server" Text='<%# Bind("ID") %>' Visible="false"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Description" HeaderText="Description" ItemStyle-Width="25%"
                                    SortExpression="Description" />
                                <asp:BoundField DataField="NoOfUnits" HeaderText="NoOfUnits" ItemStyle-Width="14%"
                                    SortExpression="NoOfUnits" />
                                <asp:BoundField DataField="Price" HeaderText="Price(per unit)(£)" ItemStyle-Width="20%"
                                    SortExpression="Price" />
                                <asp:TemplateField HeaderText="Ex. Vat Price" ItemStyle-Width="16%">
                                    <ItemTemplate>
                                        <asp:Label ID="priceLabel" runat="server"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Discount" ItemStyle-Width="16%" HeaderText="Discount (%)"
                                    SortExpression="Discount" />
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:Button ID="btnTrigger" runat="server" Style="display: none" />
                                        <asp:LinkButton ID="UpdateGridButton" Text="Select" CommandName="Select" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                            runat="server"></asp:LinkButton>
                                        <ajaxToolkit:ModalPopupExtender ID="InvoiceDetailsPopupControlExtender" DropShadow="true"
                                            runat="server" TargetControlID="btnTrigger" PopupControlID="PanelMessage" CancelControlID="CancelButton"
                                            BackgroundCssClass="XPopUpBackGround" />
                                        <asp:Panel Style="display: none" ID="PanelMessage" runat="server" Width="700px" CssClass="modalPopup">
                                            <fieldset id="Fieldset2">
                                                <legend>
                                                    <h3>
                                                        Special Invoice Line Detail
                                                    </h3>
                                                </legend>
                                                <table style="text-align: left">
                                                    <tr>
                                                        <td class="emphasise" style="width: 15%">
                                                            <b>Description</b>
                                                        </td>
                                                        <td style="width: 85%">
                                                            <asp:TextBox ID="ID" Visible="false"></asp:TextBox>
                                                            <asp:TextBox ID="LineDescriptionTextBox" MaxLength="100" Width="80%" runat="server"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="GridViewPanel"
                                                                ControlToValidate="LineDescriptionTextBox" ErrorMessage="Description is required"
                                                                InitialValue="" Text="*" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="emphasise">
                                                            Qty/unit
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="QtyPerUnitTextBox" Width="60px" runat="server"></asp:TextBox>
                                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server"
                                                                TargetControlID="QtyPerUnitTextBox" FilterType="Numbers" />
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="GridViewPanel"
                                                                ControlToValidate="QtyPerUnitTextBox" ErrorMessage="Qty per unit is required"
                                                                InitialValue="" Text="*" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="emphasise">
                                                            No Of Units
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="NoOfUnitsTextBox" MaxLength="3" Width="60px" runat="server"></asp:TextBox>
                                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                                                TargetControlID="NoOfUnitsTextBox" FilterType="Numbers" />
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ValidationGroup="GridViewPanel"
                                                                ControlToValidate="NoOfUnitsTextBox" ErrorMessage="No of units is required" InitialValue=""
                                                                Text="*" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="emphasise">
                                                            <i>Price (per units)</i>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="PricePerUnitsTextBox" runat="server"></asp:TextBox>
                                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server"
                                                                TargetControlID="PricePerUnitsTextBox" FilterType="Custom,Numbers" ValidChars="£." />
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ValidationGroup="GridViewPanel"
                                                                ControlToValidate="PricePerUnitsTextBox" ErrorMessage="Price per units is required"
                                                                InitialValue="" Text="*" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="emphasise">
                                                            <i>Discount (%)</i>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="DiscountTextBox" runat="server"></asp:TextBox>
                                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server"
                                                                TargetControlID="DiscountTextBox" FilterType="Custom,Numbers" ValidChars="%." />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="emphasise">
                                                            <i>Price Charge</i>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="PriceChargeLabel" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="emphasise">
                                                            <i>Vat Exempt</i>
                                                        </td>
                                                        <td>
                                                            <asp:CheckBox ID="VatExemptCheckBox" runat="server"></asp:CheckBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="emphasise" colspan="2">
                                                            Special Instructions
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2">
                                                            <asp:TextBox ID="SpecialInstructionsTextBox" runat="server" TextMode="MultiLine"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </fieldset>
                                            <asp:Label ID="cpItemDetails" runat="server" Visible="false"></asp:Label>
                                            <p>
                                                <center>
                                                    <asp:Button ID="OkButton" runat="server" Text="Update" OnClick="InvoiceLineUpdateButton_Click"
                                                        CausesValidation="false" ValidationGroup="GridViewPanel" CssClass="button" />
                                                    <asp:Button ID="DeleteButton" runat="server" OnClick="InvoiceLineDeleteButton_Click"
                                                        CausesValidation="false" Text="Delete" ValidationGroup="GridViewPanel" CssClass="button" />
                                                    <asp:Button ID="CancelButton" Text="Cancel" runat="server" ValidationGroup="GridViewPanel"
                                                        CssClass="button" />
                                                </center>
                                            </p>
                                        </asp:Panel>
                                    </ItemTemplate>
                                    <ItemStyle Width="9%" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="GetSpecialInvoiceLines"
                            TypeName="SpecialInvoiceLineUI" OnSelecting="ObjectDataSource2_Selecting">
                            <SelectParameters>
                                <asp:Parameter Name="id" Type="Int32" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                    </div>
                    <table>
                        <tr>
                            <td>
                                <asp:Button ID="CompleteButton" Width="200" Text="Save" Style="margin: 5px 0px 5px 0px;"
                                    runat="server" OnClick="CompleteButton_Click" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
        </fieldset>
    </div>
</asp:Panel>
