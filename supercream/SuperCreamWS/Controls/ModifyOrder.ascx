<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ModifyOrder.ascx.cs" Inherits="Controls_ModifyOrder" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="ProductSearch.ascx" TagName="ProductSearch" TagPrefix="uc1" %>
<asp:Panel ID="ModifyOrderPanel" Visible="true" runat="server">
    <div class="FormInput">
        <fieldset id="Fieldset3">
            <legend>
                <h3>
                    Modify Orders</h3>
            </legend>
            <asp:Panel ID="OrderSearchPanel" DefaultButton="SearchButton" Visible="false" runat="server">
                <legend>
                    <h3>
                        Select Order Line</h3>
                </legend>
                <table class="search">
                    <tr>
                        <td class="right">
                            <table class="left">
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
                                        Order Status
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="OrderStatusDropDownList" runat="server" Width="250px" DataSourceID="OrderStatusXmlDataSource"
                                            DataTextField="LongName" AutoPostBack="true" DataValueField="ID" OnSelectedIndexChanged="OrderStatusDropDownList_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        <asp:XmlDataSource ID="OrderStatusXmlDataSource" runat="server" DataFile="~/App_Data/OrderStauses.xml">
                                        </asp:XmlDataSource>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td>
                                        <asp:LinkButton ID="SearchButton" Text="Search" CausesValidation="false" runat="server"
                                            OnClick="SearchButton_Click" />
                                        &nbsp; | &nbsp;
                                        <asp:LinkButton ID="ClearButton" Text="Clear Search" CausesValidation="false" runat="server"
                                            OnClick="ClearButton_Click" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <asp:Panel ID="OrderHeaderSearchGridPanel" runat="server">
                <asp:GridView ID="GridView1" runat="server" Width="98%" PageSize="7" AllowPaging="True"
                    DataSourceID="OrderLineObjectDataSource" AutoGenerateColumns="False" OnRowDataBound="GridView1_RowDataBound"
                    OnRowCommand="GridView1_RowCommand">
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
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Order No." ItemStyle-Width="15%" SortExpression="AlphaID">
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("AlphaID") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("AlphaID") %>'></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Customer Name" ItemStyle-Width="30%" SortExpression="CustomerID">
                            <ItemTemplate>
                                <asp:Label ID="CustomerNameLabel" runat="server" Text='<%# Bind("CustomerID") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("CustomerID") %>'></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Status" ItemStyle-Width="20%">
                            <ItemTemplate>
                                <asp:Label ID="StatusNameLabel" runat="server"></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:Label ID="StatusNameLabel" runat="server"></asp:Label>
                            </EditItemTemplate>
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
                <asp:ObjectDataSource ID="OrderLineObjectDataSource" runat="server" SelectMethod="GetOrderHeadersSearch"
                    TypeName="OrderHeaderUI" OnSelecting="OrderLineObjectDataSource_Selecting">
                    <SelectParameters>
                        <asp:Parameter Name="orderHeader" Type="String" />
                        <asp:Parameter Name="invoiceNo" Type="String" />
                        <asp:Parameter Name="customerName" Type="String" />
                        <asp:Parameter Name="dateFrom" Type="DateTime" />
                        <asp:Parameter Name="dateTo" Type="DateTime" />
                        <asp:Parameter Name="orderStatus" Type="Int16" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </asp:Panel>
            <asp:Panel ID="OrderHeaderPanel" Visible="false" runat="server">
                <legend>
                    <h3>
                        Order Header Details</h3>
                </legend>
                <table style="width: 100%">
                    <tr>
                        <td>
                            Customer Name
                        </td>
                        <td>
                            <asp:DropDownList ID="CustomerDropDownList" AutoPostBack="true" Width="350px" runat="server"
                                DataValueField="ID" ValidationGroup="ModifyOrderDetailsGroup" DataTextField="Name"
                                OnSelectedIndexChanged="CustomerDropDownList_SelectedIndexChanged">
                            </asp:DropDownList>
                            <ajaxToolkit:ListSearchExtender ID="ListSearchExtender2" runat="server" TargetControlID="CustomerDropDownList"
                                PromptCssClass="ListSearchExtenderPrompt" PromptText="Text to Search For" QueryPattern="Contains"
                                QueryTimeout="2000" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ValidationGroup="ModifyOrderDetailsGroup"
                                ControlToValidate="CustomerDropDownList" InitialValue="-1" ErrorMessage="You must select Customer"
                                Text="*" runat="server" />
                        </td>
                        <td>
                            <asp:Label ID="OrderStatusTypeLabel" Visible="false" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 22%;">
                            Order No
                        </td>
                        <td style="width: 50%;">
                            <asp:TextBox ID="OrderNoTextBox" ValidationGroup="ModifyOrderDetailsGroup" Width="355px"
                                MaxLength="20" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ValidationGroup="ModifyOrderDetailsGroup"
                                ControlToValidate="OrderNoTextBox" ErrorMessage="Order No is required" InitialValue=""
                                Text="*" runat="server" />
                        </td>
                        <td style="width: 28%;">
                            <asp:Label ID="OrderStatusNoLabel" Visible="false" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Date of Order
                        </td>
                        <td colspan="2">
                            <asp:TextBox ID="OrderDateTextBox" Style="vertical-align: middle;" runat="server"
                                ValidationGroup="ModifyOrderDetailsGroup" MaxLength="100" Width="100px"></asp:TextBox>
                            <asp:Image runat="Server" Style="vertical-align: middle;" ID="Image3" ImageUrl="~/images/Calendar_scheduleHS.png"
                                AlternateText="Click to show calendar" />
                            <asp:RequiredFieldValidator ID="OrderDateRequiredFieldValidator" runat="server" ControlToValidate="OrderDateTextBox"
                                Display="Dynamic" ErrorMessage="Order Date is a required field" SetFocusOnError="True"
                                ValidationGroup="ModifyOrderDetailsGroup">*</asp:RequiredFieldValidator>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender2" Format="dd/MM/yyyy" runat="server"
                                TargetControlID="OrderDateTextBox" PopupButtonID="Image3" />
                            <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender3" runat="server" TargetControlID="OrderDateTextBox"
                                Mask="99/99/9999" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                                OnInvalidCssClass="MaskedEditError" MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 25%;">
                            Delivery Date
                        </td>
                        <td style="width: 75%;" colspan="2">
                            <asp:TextBox ID="DeliveryDateTextBox" Style="vertical-align: middle;" runat="server"
                                ValidationGroup="AddOrderDetailsGroup" MaxLength="100" Width="100px"></asp:TextBox>
                            <asp:Image runat="Server" Style="vertical-align: middle;" ID="Image4" ImageUrl="~/images/Calendar_scheduleHS.png"
                                AlternateText="Click to show calendar" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="DeliveryDateTextBox"
                                Display="Dynamic" ErrorMessage="Delivery Date is a required field" SetFocusOnError="True"
                                ValidationGroup="ModifyOrderDetailsGroup">*</asp:RequiredFieldValidator>
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
                        <td colspan="2">
                            <asp:TextBox ID="OrderHeaderSpecialInstructionsTextBox" TextMode="MultiLine" Width="95%"
                                Height="100px" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <asp:LinkButton ID="DeleteOrderButton" CausesValidation="false" runat="server" Text="Delete Order Details |"
                                OnClick="DeleteOrderButton_Click" />
                            <asp:LinkButton ID="Modify_OrderLineDetailsLinkButton" Text="Modfy Order Line Details"
                                runat="server" OnClick="Modify_OrderLineDetailsLinkButton_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <asp:LinkButton ID="ConvertToInvoiceButton" Text="Convert to Invoice" runat="server"
                                OnClick="ConvertToInvoiceButton_Click" />
                            <asp:LinkButton ID="CreateInvoiceButton" Text="Create Invoice |" runat="server" OnClick="ShowInvoiceButton_Click" />
                            <asp:LinkButton ID="CreateProformaInvoiceButton" Text="Create Proforma Invoice |"
                                runat="server" OnClick="ShowInvoiceProformaButton_Click" />
                            <asp:LinkButton ID="CreateDeliveryNoteButton" Text="Create Delivery Note" runat="server"
                                OnClick="ShowDeliveryButton_Click" />
                            <asp:Button ID="btnTrigger1" runat="server" Style="display: none" />
                            <asp:Button ID="btnTrigger2" runat="server" Style="display: none" />
                            <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtenderInvoice" DropShadow="true"
                                runat="server" TargetControlID="btnTrigger1" PopupControlID="PanelMessage" CancelControlID="CancelInvoiceButton"
                                BackgroundCssClass="XPopUpBackGround" />
                            <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtenderDeliveryNote" DropShadow="true"
                                runat="server" TargetControlID="btnTrigger2" PopupControlID="CreateDeliveryNotePanel"
                                CancelControlID="CancelDeliveryNoteButton" BackgroundCssClass="XPopUpBackGround" />
                            <asp:Panel Style="display: none" DefaultButton="InvoiceUpdateButton" Width="700px"
                                ID="PanelMessage" runat="server" CssClass="modalPopup">
                                <table>
                                    <tr>
                                        <td>
                                            Invoice No
                                        </td>
                                        <td>
                                            <asp:TextBox ID="InvoiceNoTextBox" Width="500px" MaxLength="30" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Button ID="InvoiceUpdateButton" CommandArgument='<%# OrderID %>' Text="Save"
                                                runat="server" OnClick="CreateInvoiceButton_Click" />
                                            <asp:Button ID="CancelInvoiceButton" Text="Cancel" CausesValidation="false" runat="server" />
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            <asp:Panel Style="display: none" Width="700px" DefaultButton="DeliveryNoteButton"
                                ID="CreateDeliveryNotePanel" runat="server" CssClass="modalPopup">
                                <table>
                                    <tr>
                                        <td>
                                            Invoice No
                                        </td>
                                        <td>
                                            <asp:TextBox ID="DeliveryInvoiceNoTextBox" Width="500px" MaxLength="30" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Button ID="DeliveryNoteButton" CommandArgument='<%# OrderID %>' Text="Save"
                                                runat="server" OnClick="CreateDeliveryNoteButton_Click" />
                                            <asp:Button ID="CancelDeliveryNoteButton" Text="Cancel" CausesValidation="false"
                                                runat="server" />
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <asp:Panel ID="ProductSearchPanel" Visible="false" runat="server">
                <uc1:ProductSearch ID="ProductSearch" runat="server" />
            </asp:Panel>
            <asp:Panel ID="AddOrderDetailsPanel" Visible="false" runat="server">
                <h3>
                    Add Order line detail</h3>
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
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" ValidationGroup="NewOutletGroup"
                                ControlToValidate="PriceTextBox" ErrorMessage="Price is required" InitialValue=""
                                Text="Required" runat="server" />
                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server"
                                TargetControlID="PriceTextBox" FilterType="Custom,Numbers" ValidChars="£." />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Label ID="PriceListDefined" Visible="false" runat="server"></asp:Label>
                        </td>
                        <td class="emphasise">
                            <asp:Label ID="TotalPriceLabel" Text="TotalPrice (Ex. Vat)" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="TotalPriceValueLabel" Font-Size="Medium" ForeColor="Red" MaxLength="7"
                                Width="60px" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
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
                                                OnClick="CancelProductAddButton_Click" />
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
                    DataSourceID="ObjectDataSource1" DataKeyNames="ID" OnRowDataBound="OrderDetailsGridPanel_RowDataBound"
                    OnRowCommand="OrderDetailsGridPanel_RowCommand" ShowFooter="true">
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
            <div class="FormInput">
                <asp:Panel ID="CompleteOrderButtonPanel" Visible="false" runat="server">
                    <fieldset>
                        <div style="margin: 10px">
                            <asp:Button ID="CompleteOrderButton" Width="15%" ValidationGroup="ModifyOrderDetailsGroup"
                                Text="Update Order" runat="server" OnClick="CompleteOrderButton_Click" />
                            &nbsp;
                            <asp:Button ID="CancelTotalOrderButton" Width="15%" ValidationGroup="ModifyOrderDetailsGroup"
                                Text="Cancel" runat="server" OnClick="CancelButton_Click" />
                        </div>
                    </fieldset></asp:Panel>
            </div>
        </fieldset>
    </div>
</asp:Panel>
