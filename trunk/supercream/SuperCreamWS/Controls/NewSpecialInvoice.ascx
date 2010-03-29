<%@ Control Language="C#" AutoEventWireup="true" CodeFile="NewSpecialInvoice.ascx.cs"
    Inherits="Controls_NewSpecialInvoice" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<div class="FormInput">
    <fieldset id="Fieldset3">
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
                        Date of Order
                    </td>
                    <td style="width: 70%;">
                        <asp:TextBox ID="OrderDateTextBox" Style="vertical-align: middle;" runat="server"
                            ValidationGroup="AddOrderDetailsGroup" MaxLength="100" Width="100px"></asp:TextBox>
                        <asp:Image runat="Server" Style="vertical-align: middle;" ID="Image1" ImageUrl="~/images/Calendar_scheduleHS.png"
                            AlternateText="Click to show calendar" />
                        <asp:RequiredFieldValidator ID="OrderDateRequiredFieldValidator" runat="server" ControlToValidate="OrderDateTextBox"
                            Display="Dynamic" ErrorMessage="Order Date is a required field" SetFocusOnError="True"
                            ValidationGroup="AddOrderDetailsGroup">*</asp:RequiredFieldValidator>
                        <ajaxToolkit:CalendarExtender ID="calendarButtonExtender" Format="dd/MM/yyyy" runat="server"
                            TargetControlID="OrderDateTextBox" PopupButtonID="Image1" />
                        <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="OrderDateTextBox"
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
                        <asp:Image runat="Server" Style="vertical-align: middle;" ID="Image2" ImageUrl="~/images/Calendar_scheduleHS.png"
                            AlternateText="Click to show calendar" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="DeliveryDateTextBox"
                            Display="Dynamic" ErrorMessage="Delivery Date is a required field" SetFocusOnError="True"
                            ValidationGroup="AddOrderDetailsGroup">*</asp:RequiredFieldValidator>
                        <ajaxToolkit:CalendarExtender ID="CalendarExtender1" Format="dd/MM/yyyy" runat="server"
                            TargetControlID="DeliveryDateTextBox" PopupButtonID="Image1" />
                        <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="DeliveryDateTextBox"
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
                        |
                        <asp:LinkButton CausesValidation="false" runat="server" Text="Cancel Invoice Details"
                            OnClick="CancelNewOrderButton_Click" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <asp:Panel ID="AddSpecialInvoiceLineDetailsPanel" Visible="false" runat="server">
            <h2>
                Special Invoice No:&nbsp;
                <asp:Label ID="SpecialInvoiceLabel" runat="server"></asp:Label></h2>
            <table style="width: 100%">
                <tr>
                    <td class="emphasise" style="width: 15%">
                        <b>Description</b>
                    </td>
                    <td style="width: 85%">
                        <asp:TextBox ID="LineDescriptionTextBox" MaxLength="100" Width="80%" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="AddSpecialInvoiceLinesGroup"
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
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="AddSpecialInvoiceLinesGroup"
                            ControlToValidate="QtyPerUnitTextBox" ErrorMessage="Qty per unit is required"
                            InitialValue="" Text="*" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="emphasise">
                        No Of Units
                    </td>
                    <td>
                        <asp:TextBox ID="NoOfUnitsTextBox" MaxLength="3" Width="60px" runat="server" AutoPostBack="True"
                            OnTextChanged="NoOfUnitsTextBox_TextChanged"></asp:TextBox>
                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                            TargetControlID="NoOfUnitsTextBox" FilterType="Numbers" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ValidationGroup="AddSpecialInvoiceLinesGroup"
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
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ValidationGroup="AddSpecialInvoiceLinesGroup"
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
                            TargetControlID="DiscountTextBox" FilterType="Custom,Numbers" ValidChars="." />
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
                        <asp:LinkButton ID="AddSpecialInvoiceLineButton" Text="Add" ValidationGroup="AddSpecialInvoiceLinesGroup"
                            runat="server" OnClick="AddSpecialInvoiceLineButton_Click"></asp:LinkButton>
                        |
                        <asp:LinkButton ID="CancelSpecialInvoiceLineButton" Text="Cancel |" OnClick="CancelSpecialInvoiceLineButton_Click"
                            CausesValidation="false" runat="server">
                        </asp:LinkButton>
                        <asp:LinkButton ID="CalculateButton" Text="Calculate" runat="server" OnClick="CalculateButton_Click">
                        </asp:LinkButton>
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </fieldset>
    <asp:Panel ID="SpecialInvoiceLinesGridViewPanel" runat="server">
        <fieldset id="Fieldset1">
            <div align="center">
                <asp:GridView ID="AddSpecialInvoiceLinesGridViewPanel" runat="server" Width="96%"
                    DataKeyNames="ID" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1"
                    OnRowDataBound="AddSpecialInvoiceLinesGridViewPanel_RowDataBound" OnRowCommand="AddSpecialInvoiceLinesGridViewPanel_RowCommand">
                    <Columns>
                        <asp:TemplateField Visible="false" SortExpression="ID">
                            <ItemTemplate>
                                <asp:Label ID="ID" runat="server" Text='<%# Bind("ID") %>' Visible="false"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Description" HeaderText="Description" ItemStyle-Width="20%"
                            SortExpression="Description" />
                        <asp:BoundField DataField="NoOfUnits" HeaderText="NoOfUnits" ItemStyle-Width="14%"
                            SortExpression="NoOfUnits" />
                        <asp:BoundField DataField="Price" HeaderText="Price (per unit)" ItemStyle-Width="14%"
                            SortExpression="Price" />
                        <asp:TemplateField HeaderText="Price" ItemStyle-Width="11%">
                            <ItemTemplate>
                                <asp:Label ID="priceLabel" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Discount" ItemStyle-Width="11%" HeaderText="Discount (%)"
                            SortExpression="Discount" />
                        <asp:TemplateField ItemStyle-Width="11%">
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
                                                    <asp:Label ID="PriceChargeTextBox" runat="server"></asp:Label>
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
                                                CssClass="button" />
                                            <asp:Button ID="DeleteButton" runat="server" OnClick="InvoiceLineDeleteButton_Click"
                                                Text="Delete" CssClass="button" />
                                            <asp:Button ID="CancelButton" Text="Cancel" runat="server" CssClass="button" />
                                        </center>
                                    </p>
                                </asp:Panel>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetSpecialInvoiceLines"
                    TypeName="SpecialInvoiceLineUI" OnSelecting="ObjectDataSource1_Selecting">
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
</div>
