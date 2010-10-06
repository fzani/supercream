<%@ Control Language="C#" AutoEventWireup="true" CodeFile="NewOrder.ascx.cs" Inherits="Controls_NewOrder" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="ProductSearch.ascx" TagName="ProductSearch" TagPrefix="uc1" %>
<asp:Panel ID="NewOrderPanel" Visible="true" runat="server">
    <div class="FormInput">
        <fieldset id="Fieldset3">
            <div>
                <h2>
                    Order No &nbsp;
                    <asp:Label ID="OrderNoLabel" Width="150px" MaxLength="20" runat="server"></asp:Label>
                </h2>
            </div>
            <asp:Panel ID="OrderHeaderPanel" runat="server">
                <legend>
                    <h3>
                        Order Header Details</h3>
                </legend>
                <table style="width: 100%">
                    <tr>
                        <td style="width: 25%;">
                            Customer Name
                        </td>
                        <td>
                            <asp:DropDownList ID="CustomerDropDownList" AutoPostBack="true" Width="300px" runat="server"
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
                        <td style="width: 25%;">
                            Date of Order
                        </td>
                        <td style="width: 75%;">
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
                        <td style="width: 25%;">
                            Delivery Date
                        </td>
                        <td style="width: 75%;">
                            <asp:TextBox ID="DeliveryDateTextBox" Style="vertical-align: middle;" runat="server"
                                ValidationGroup="AddOrderDetailsGroup" MaxLength="100" Width="100px"></asp:TextBox>
                            <asp:Image runat="Server" Style="vertical-align: middle;" ID="Image2" ImageUrl="~/images/Calendar_scheduleHS.png"
                                AlternateText="Click to show calendar" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="DeliveryDateTextBox"
                                Display="Dynamic" ErrorMessage="Delivery Date is a required field" SetFocusOnError="True"
                                ValidationGroup="AddOrderDetailsGroup">*</asp:RequiredFieldValidator>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" Format="dd/MM/yyyy" runat="server"
                                TargetControlID="DeliveryDateTextBox" PopupButtonID="Image2" />
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
                            <asp:LinkButton ID="AddOrderDetailsButton" runat="server" ValidationGroup="AddOrderDetailsGroup"
                                Text="Add Order Details" OnClick="AddOrderDetailsButton_Click" />
                            &nbsp | &nbsp;
                            <asp:LinkButton ID="CancelNewOrderButton" CausesValidation="false" runat="server"
                                Text="Cancel Order Details" OnClick="CancelNewOrderButton_Click" />
                            &nbsp;
                            <asp:LinkButton ID="ShowCustomerDetailsButton" Text="| Show Customer Details" runat="server"
                                OnClick="ShowCustomerDetailsButton_Click" Visible="False" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <asp:Button ID="btnTrigger6" runat="server" Style="display: none" />
            <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtenderShowCustomer" DropShadow="true"
                runat="server" TargetControlID="btnTrigger6" PopupControlID="ShowCustomerDetailsPanel"
                BackgroundCssClass="XPopUpBackGround" />
            <asp:Panel Style="display: none" Width="700px" Height="350px" ScrollBars="Auto" DefaultButton="ShowComplete_Button"
                ID="ShowCustomerDetailsPanel" runat="server" CssClass="modalPopup">
                <table style="width: 100%; margin: 0px 0px 20px 0px;" cellpadding="0" cellspacing="0">
                    <tr>
                        <td style="width: 20%;">
                            <h3>
                                Customer Name
                            </h3>
                        </td>
                        <td style="width: 80%;">
                            <asp:Label ID="CustomerNameTextBoxLabel" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            <asp:Repeater ID="ContactDetailsRepeater" OnItemDataBound="OrderDetailsContact_ItemDataBound"
                                runat="server">
                                <ItemTemplate>
                                    <ul>
                                        <li>Contact &nbsp;
                                            <%#Eval("FirstName") %>&nbsp;<%#Eval("LastName") %>
                                            <ul>
                                                <asp:Repeater ID="PhoneDetailsRepeater" runat="server">
                                                    <ItemTemplate>
                                                        <li>
                                                            <%#Eval("PhoneType") %>
                                                            - <i>
                                                                <%#Eval("PhoneNumber") %>
                                                            </i></li>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </ul>
                                        </li>
                                    </ul>
                                </ItemTemplate>
                            </asp:Repeater>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            <asp:Repeater ID="ShopDetailsRepeater" OnItemDataBound="ShopDetails_ItemDataBound"
                                runat="server">
                                <ItemTemplate>
                                    <ul>
                                        <li>Shop Name &nbsp;
                                            <%#Eval("Name") %>
                                            <ul>
                                                <li>
                                                    <%#Eval("Address")%>
                                                </li>
                                                <li>
                                                    <%#Eval("OpeningHoursNotes")%>
                                                </li>
                                                <li>
                                                    <%#Eval("Note")%>
                                                </li>
                                            </ul>
                                        </li>
                                    </ul>
                                </ItemTemplate>
                            </asp:Repeater>
                        </td>
                    </tr>
                </table>
                <asp:Button ID="ShowComplete_Button" Width="100%" Text="OK" CausesValidation="false"
                    runat="server" />
            </asp:Panel>
        </fieldset>
</asp:Panel>
<asp:Panel ID="ProductSearchPanel" Visible="false" runat="server">
    <uc1:ProductSearch ID="ProductSearch" runat="server" />
</asp:Panel>
<asp:Panel ID="AddOrderDetailsPanel" Visible="false" runat="server">
    <table style="width: 100%">
        <tr>
            <td class="emphasise" style="width: 30%">
                <b>Product Code</b>
            </td>
            <td style="width: 20%">
                <asp:Label ID="ProductCodeLabel" runat="server"></asp:Label>
            </td>
            <td class="emphasise" style="width: 20%">
                <b>Product Name</b>
            </td>
            <td style="width: 30%">
                <asp:Label ID="ProductDescriptionLabel" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                Qty/unit
            </td>
            <td>
                <asp:Label ID="QtyPerUnitLabel" runat="server"></asp:Label>
            </td>
            <td>
                <i>Original Unit Price</i>
            </td>
            <td>
                <asp:Label ID="ProductPriceLabel" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                R.R.P
            </td>
            <td>
                <asp:Label ID="RRPLabel" runat="server"></asp:Label>
            </td>
            <td colspan="1">
                <asp:Label ID="PriceDiscountNameLabel" runat="server"></asp:Label>
            </td>
            <td>
                <asp:Label ID="PriceListDiscountLabel" runat="server"></asp:Label>
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
            </td>
            <td class="emphasise">
                <asp:Label ID="PriceLabel" Text="Price" runat="server"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="PriceTextBox" MaxLength="7" Width="60px" runat="server" OnTextChanged="PriceTextBox_TextChanged"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ValidationGroup="NewOutletGroup"
                    ControlToValidate="PriceTextBox" ErrorMessage="Price is required" InitialValue=""
                    Text="*" runat="server" />
                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server"
                    TargetControlID="PriceTextBox" FilterType="Custom,Numbers" ValidChars="£." />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="PriceListDefined" Visible="false" runat="server"></asp:Label>
            </td>
            <td class="emphasise">
                <asp:Label ID="TotalPriceLabel" Text="Total Price (Ex. Vat)" runat="server"></asp:Label>
            </td>
            <td>
                <asp:Label ID="TotalPriceValueLabel" Font-Size="Medium" ForeColor="Red" MaxLength="7"
                    Width="60px" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <table>
                    <tr>
                        <td style="width: 30%">
                            <asp:Button ID="CalculateButton" Text="Calculate" CausesValidation="false" runat="server"
                                OnClick="CalculateButton_Click" />
                            <asp:Button ID="AddOrderLineButton" Text="Add Line" runat="server" Visible="false"
                                OnClick="AddOrderLineButton_Click" />
                            <asp:Button ID="CancelButton" Text="Cancel" CausesValidation="false" runat="server"
                                OnClick="CancelButton_Click" />
                        </td>
                        <td style="width: 70%">
                            <table>
                                <tr>
                                    <td>
                                        <asp:CheckBox ID="ContinueCheckBox" runat="server" Text="<i>Do you want to continue</i>"
                                            AutoPostBack="True" OnCheckedChanged="ContinueCheckBox_CheckedChanged" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:CheckBox ID="SpecialInstructionsCheckBox" runat="server" Text="<i>Do you have any Special Instructions on this Order Line</i>"
                                            AutoPostBack="True" OnCheckedChanged="SpecialInstructionsCheckBox_CheckedChanged" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td colspan="3">
                <asp:TextBox ID="SpecialInstructionsTextBox" Width="90%" Height="60px" TextMode="MultiLine"
                    Visible="false" runat="server"></asp:TextBox>
            </td>
        </tr>
    </table>
</asp:Panel>
<asp:Panel ID="OrderDetailsGridPanel" runat="server">
    <asp:GridView ID="OrderDetailsGridView" Width="97%" runat="server" AutoGenerateColumns="False"
        DataSourceID="ObjectDataSource1" OnRowDataBound="GridView1_RowDataBound" OnRowCommand="GridView1_RowCommand"
        ShowFooter="true">
        <Columns>
            <asp:TemplateField HeaderText="ID" SortExpression="ID" Visible="false">
                <ItemTemplate>
                    <asp:Label ID="IDLabel" runat="server" Text='<%# Bind("ID") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Product" SortExpression="ProductID">
                <ItemTemplate>
                    <asp:Label ID="ProductNameLabel" runat="server" Text='<%# Bind("ProductID") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="ProductNameLabel" runat="server" Text='<%# Bind("ProductID") %>'></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="No Of Units" SortExpression="NoOfUnits">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("NoOfUnits") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("NoOfUnits") %>'></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Discount" SortExpression="Discount">
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("Discount") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Discount") %>'></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Price" SortExpression="Price">
                <ItemTemplate>
                    <asp:Label ID="OrderLinePriceLabel" runat="server"></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("Price") %>'></asp:TextBox>
                </EditItemTemplate>
                <FooterTemplate>
                    Ex Vat. Total &nbsp;
                    <asp:Label ID="priceLabelTotal" runat="server"></asp:Label>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="SI" SortExpression="SpecialInstructions">
                <ItemTemplate>
                    <asp:Image ID="SIImage" runat="server"></asp:Image>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("SpecialInstructions") %>'></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Edit" SortExpression="SpecialInstructions">
                <ItemTemplate>
                    <asp:Button ID="btnTrigger" runat="server" Style="display: none" />
                    <asp:ImageButton ID="EditImage" ImageUrl="~/images/user6_(edit)_16x16.gif" CommandName="Select"
                        CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" runat="server" />
                    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender" DropShadow="true" runat="server"
                        TargetControlID="btnTrigger" PopupControlID="PanelMessage" CancelControlID="CancelButton"
                        BackgroundCssClass="XPopUpBackGround" />
                    <asp:Panel Style="display: none" Width="700px" ID="PanelMessage" runat="server" CssClass="modalPopup">
                        <fieldset id="Fieldset2">
                            <legend>
                                <h3>
                                    Invoice Address
                                </h3>
                            </legend>
                            <table style="width: 100%">
                                <tr>
                                    <td>
                                        Product Name
                                    </td>
                                    <td>
                                        <asp:Label ID="PanelProductNameLabel" runat="server"></asp:Label>
                                        <asp:Label ID="ProductIDLabel" Visible="false" runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        Order ID
                                    </td>
                                    <td>
                                        <asp:Label ID="AlphaIDLabel" runat="server"></asp:Label>
                                        <asp:Label ID="OrderIDLabel" Visible="false" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Qty
                                    </td>
                                    <td>
                                        <asp:TextBox ID="QtyTextBox" runat="server"></asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server"
                                            TargetControlID="QtyTextBox" FilterType="Numbers" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ValidationGroup="NewPriceListGroup"
                                            ControlToValidate="QtyTextBox" ErrorMessage="Qty is a required Text Box" InitialValue=""
                                            Text="*" runat="server" />
                                    </td>
                                    <td>
                                        No of Units
                                    </td>
                                    <td>
                                        <asp:TextBox ID="NoOfUnitsTextBox" runat="server"></asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server"
                                            TargetControlID="NoOfUnitsTextBox" FilterType="Numbers" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ValidationGroup="NewPriceListGroup"
                                            ControlToValidate="NoOfUnitsTextBox" ErrorMessage="No of Units is a required Text Box"
                                            InitialValue="" Text="*" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Discount
                                    </td>
                                    <td>
                                        <asp:TextBox ID="DiscountTextBox" runat="server"></asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server"
                                            TargetControlID="DiscountTextBox" FilterType="Custom,Numbers" ValidChars="%." />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="NewPriceListGroup"
                                            ControlToValidate="DiscountTextBox" ErrorMessage="Price List Name is a required Text Box"
                                            InitialValue="" Text="*" runat="server" />
                                    </td>
                                    <td>
                                        Price
                                    </td>
                                    <td>
                                        <asp:TextBox ID="PriceTextBox" MaxLength="7" runat="server"></asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                            TargetControlID="PriceTextBox" FilterType="Custom,Numbers" ValidChars="£." />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="NewPriceListGroup"
                                            ControlToValidate="PriceTextBox" ErrorMessage="Price List Name is a required Text Box"
                                            InitialValue="" Text="*" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Special Instructions
                                    </td>
                                    <td colspan="3">
                                        <asp:TextBox ID="SpecialInstructionsTextBox" Width="95%" Height="150px" TextMode="MultiLine"
                                            runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                            <asp:Button ID="UpdateButton" Text="Update" OnClick="UpdateButton_Click" runat="server" />
                            <asp:Button ID="DeleteButton" Text="Delete" OnClick="DeleteButton_Click" CommandName="DeleteButton"
                                CommandArgument='<%# Bind("ID") %>' runat="server" />
                            <asp:Button ID="CancelButton" Text="Cancel" runat="server" />
                    </asp:Panel>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:ImageButton ID="EditImage" ImageUrl="~/images/user6_(edit)_16x16.gif" CommandName="Select"
                        runat="server" />
                </EditItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OnSelecting="ObjectDataSource1_Selecting"
        SelectMethod="GetOrderLines" TypeName="OrderLineUI">
        <SelectParameters>
            <asp:Parameter Name="id" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Panel>
<asp:Panel ID="CancelPurchaseSearchPanel" Visible="false" runat="server">
    <fieldset>
        <table>
            <tr>
                <td>
                    <asp:Button ID="CancelPurchaseSearchButton" Text="Complete Order" runat="server"
                        OnClick="CancelPurchaseSearchButton_Click" />
                </td>
            </tr>
        </table>
    </fieldset>
</asp:Panel>
