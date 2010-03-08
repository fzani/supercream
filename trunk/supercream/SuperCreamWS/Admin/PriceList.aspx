<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" StylesheetTheme="SuperCream"
    AutoEventWireup="true" CodeFile="PriceList.aspx.cs" Inherits="Admin_PriceList" %>

<%@ Register Src="../Controls/ErrorView.ascx" TagName="ErrorView" TagPrefix="Alterax" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="ErrorUpdatePanel" runat="server" UpdateMode="Conditional">
        <Triggers>
            <asp:PostBackTrigger ControlID="CreatePriceListButton" />
            <asp:PostBackTrigger ControlID="AddPriceListButton" />
            <asp:PostBackTrigger ControlID="NewPriceListButton" />
            <asp:PostBackTrigger ControlID="MaintainPriceListButton" />
        </Triggers>
        <ContentTemplate>
            <div class="ErrorOutput">
                <Alterax:ErrorView ID="ErrorViewControl" Visible="false" runat="server" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="SetupNewPriceListUpdatePanel" runat="server" UpdateMode="Conditional">
        <Triggers>
        </Triggers>
        <ContentTemplate>
            <asp:Panel ID="SetupNewPriceListPanel" Visible="true" runat="server">
                <div class="FormHeader">
                    <div class="HeaderContainerPanel">
                        <table class="ContentHeader" cellpadding="0" cellspacing="0">
                            <tr>
                                <td class="Right">
                                    <asp:Panel ID="GeneralPanel" DefaultButton="NewPriceListButton" runat="server" Width="100%"
                                        Visible="true">
                                        <table class="ContentHeader" cellpadding="0">
                                            <tr>
                                                <td style="width: 30%; text-align: left;">
                                                    <span class="RequiredFieldMessage">*</span> <i>indicates a required field</i>
                                                </td>
                                                <td class="Right" style="width: 70%;">
                                                    <asp:LinkButton ID="NewPriceListButton" Text="New PriceList" runat="server" OnClick="AddNewPriceListButton_Click" />
                                                    &nbsp; |
                                                    <asp:LinkButton ID="MaintainPriceListButton" Text="Modify PriceList" runat="server"
                                                        OnClick="MaintainPriceListButton_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="AddPriceListUpdatePanel" runat="server" UpdateMode="Conditional">
        <Triggers>
            <asp:PostBackTrigger ControlID="NewPriceListButton" />
            <asp:PostBackTrigger ControlID="MaintainPriceListButton" />
            <asp:PostBackTrigger ControlID="CancelNewPriceListButton" />            
        </Triggers>
        <ContentTemplate>
            <asp:Panel ID="NewPriceListPanel" DefaultButton="AddPriceListButton" Visible="false"
                runat="server">
                <div class="FormInput">
                    <fieldset id="VarInputLegend">
                        <legend>
                            <h3>
                                Create PriceList</h3>
                        </legend>
                        <table style="width: 100%">
                            <tr>
                                <td>
                                    Price List Name
                                </td>
                                <td>
                                    <asp:TextBox ID="NameTextBox" runat="server" ValidationGroup="NewPriceListGroup"
                                        MaxLength="50" Width="500px" EnableViewState="False"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="NewPriceListGroup"
                                        ControlToValidate="NameTextBox" ErrorMessage="Price List Name is a required Text Box"
                                        InitialValue="" Text="*" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                    <table class="progressupdate">
                                        <tr>
                                            <td>
                                                <asp:LinkButton ID="CreatePriceListButton" Text="Create New Price List" ValidationGroup="NewPriceListGroup"
                                                    runat="server" OnClick="AddPriceListButton_Click" />
                                            </td>
                                            <td>
                                                <div class="progressupdate">
                                                    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="AddPriceListUpdatePanel"
                                                        DisplayAfter="1">
                                                        <ProgressTemplate>
                                                            <asp:Image ID="aspImg1" runat="server" ImageUrl="~/images/progress3.gif"></asp:Image>
                                                        </ProgressTemplate>
                                                    </asp:UpdateProgress>
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                </div>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="EnterPriceListUpdatePanel" runat="server" UpdateMode="Conditional">
        <Triggers>
            <asp:PostBackTrigger ControlID="AddPriceListButton" />
        </Triggers>
        <ContentTemplate>
            <asp:Panel ID="SetupPriceListPanel" DefaultButton="AddPriceListButton" runat="server">
                <div class="FormInput">
                    <fieldset id="Fieldset2">
                        <legend>
                            <h3>
                                Enter New PriceList</h3>
                        </legend>
                        <table style="width: 100%">
                            <tr>
                                <td style="width: 15%">
                                </td>
                                <td style="width: 35%">
                                </td>
                                <td style="width: 25%">
                                </td>
                                <td style="width: 25%">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Date Effective From
                                </td>
                                <td colspan="3">
                                    <asp:TextBox ID="DateEffectiveFromTextBox" Style="vertical-align: middle;" runat="server"
                                        ValidationGroup="NewOutletGroup" MaxLength="100" Width="100px"></asp:TextBox>
                                    <asp:Image runat="Server" Style="vertical-align: middle;" ID="Image1" ImageUrl="~/images/Calendar_scheduleHS.png"
                                        AlternateText="Click to show calendar" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ValidationGroup="NewOutletGroup"
                                        ControlToValidate="DateEffectiveFromTextBox" ErrorMessage="Date Effective From is required"
                                        InitialValue="" Text="*" runat="server" />
                                    <ajaxToolkit:CalendarExtender ID="calendarButtonExtender" Format="dd/MM/yyyy" runat="server"
                                        TargetControlID="DateEffectiveFromTextBox" PopupButtonID="Image1" />
                                    <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="DateEffectiveFromTextBox"
                                        Mask="99/99/9999" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                                        OnInvalidCssClass="MaskedEditError" MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Date Effective To
                                </td>
                                <td colspan="3">
                                    <asp:TextBox ID="DateEffectiveToTextBox" runat="server" ValidationGroup="NewOutletGroup"
                                        MaxLength="40" Width="100px"></asp:TextBox>
                                    <asp:Image runat="Server" Style="vertical-align: middle;" ID="Image2" ImageUrl="~/images/Calendar_scheduleHS.png"
                                        AlternateText="Click to show calendar" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="NewOutletGroup"
                                        ControlToValidate="DateEffectiveToTextBox" ErrorMessage="Date Effective From is required"
                                        InitialValue="" Text="*" runat="server" />
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" Format="dd/MM/yyyy" runat="server"
                                        TargetControlID="DateEffectiveToTextBox" PopupButtonID="Image2" />
                                    <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="DateEffectiveToTextBox"
                                        Mask="99/99/9999" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                                        OnInvalidCssClass="MaskedEditError" MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <div style="display: inline">
                                        <asp:Button ID="AddPriceListButton" Text="Add PriceList" Width="48%" ValidationGroup="NewOutletGroup"
                                            runat="server" OnClick="CreatePriceListButton_Click" />
                                        &nbsp;
                                        <asp:Button ID="CancelNewPriceListButton" Width="49%" Text="Cancel" CausesValidation="false"
                                            runat="server" OnClick="CancelNewPriceListButton_Click" />
                                    </div>
                                </td>
                                <td colspan="2">
                                    <div class="progressupdate">
                                        <asp:UpdateProgress ID="UpdateProgress2" runat="server" AssociatedUpdatePanelID="EnterPriceListUpdatePanel"
                                            DisplayAfter="1">
                                            <ProgressTemplate>
                                                <asp:Image ID="ProgressImg2" runat="server" ImageUrl="~/images/progress3.gif"></asp:Image>
                                            </ProgressTemplate>
                                        </asp:UpdateProgress>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                </div>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="PriceListDataGridUpdatePanel" runat="server" UpdateMode="Conditional">
        <Triggers>
            <asp:PostBackTrigger ControlID="CreatePriceListButton" />
            <asp:PostBackTrigger ControlID="MaintainPriceListButton" />
        </Triggers>
        <ContentTemplate>
            <asp:Panel ID="PriceListDataGridPanel" runat="server" Visible="true">
                <div class="FormInput">
                    <fieldset id="Fieldset4">
                        <legend>
                            <h3>
                                PriceList Maintenance</h3>
                        </legend>
                        <asp:GridView ID="PriceListGridView" Width="98%" runat="server" AutoGenerateColumns="False"
                            CssClass="simplegrid" DataSourceID="ObjectDataSource1" OnRowCommand="PriceListGridView_RowCommand">
                            <RowStyle CssClass="row-a" />
                            <AlternatingRowStyle CssClass="row-b" />
                            <Columns>
                                <asp:TemplateField Visible="false" SortExpression="ID">
                                    <ItemTemplate>
                                        <asp:Label ID="ID" runat="server" Text='<%# Bind("ID") %>' Visible="false"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Price List Name" SortExpression="ID" ItemStyle-Width="60%">
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("PriceListName") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ShowHeader="False" ItemStyle-Width="20%">
                                    <ItemTemplate>
                                        <asp:Button ID="btnTrigger" runat="server" Style="display: none" />
                                        <asp:LinkButton ID="ModifyPriceListButtonButton" runat="server" CausesValidation="false"
                                            CommandName="SelectButton" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                            Text="Modify Price List Header" />
                                        <ajaxToolkit:ModalPopupExtender ID="PopupControlExtender1" DropShadow="true" runat="server"
                                            TargetControlID="btnTrigger" PopupControlID="PanelMessage" CancelControlID="CancelButton"
                                            BackgroundCssClass="XPopUpBackGround" />
                                        <ajaxToolkit:ConfirmButtonExtender ID="ConfirmButtonExtender2" runat="server" TargetControlID="DeleteButton"
                                            ConfirmText="Are you sure you want to Delete this Price List Header - There may be dependent price list items for this Price List Header which will be deleted?" />
                                        <asp:Panel Style="display: none" ID="PanelMessage" runat="server" CssClass="modalPopup">
                                            <fieldset id="Fieldset2">
                                                <legend>
                                                    <h3>
                                                        Invoice Address
                                                    </h3>
                                                </legend>
                                                <table>
                                                    <tr>
                                                        <td>
                                                            Price List Name
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="PriceListNameTextBox" runat="server" MaxLength="50" Width="500px"
                                                                ValidationGroup="NewOutletGroup"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="PriceListNameTextBox"
                                                                ValidationGroup="NewOutletGroup" ErrorMessage="Price List Name is a required field"
                                                                InitialValue="" Text="*" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            Date Effective From
                                                        </td>
                                                        <td colspan="3">
                                                            <asp:TextBox ID="DateEffectiveFromTextBox" Style="vertical-align: middle;" runat="server"
                                                                ValidationGroup="NewOutletGroup" MaxLength="100" Width="100px"></asp:TextBox>
                                                            <asp:Image runat="Server" Style="vertical-align: middle;" ID="Image1" ImageUrl="~/images/Calendar_scheduleHS.png"
                                                                AlternateText="Click to show calendar" />
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ValidationGroup="NewOutletGroup"
                                                                ControlToValidate="DateEffectiveFromTextBox" ErrorMessage="Date Effective From is required"
                                                                InitialValue="" Text="*" runat="server" />
                                                            <ajaxToolkit:CalendarExtender ID="calendarButtonExtender" Format="dd/MM/yyyy" runat="server"
                                                                TargetControlID="DateEffectiveFromTextBox" PopupButtonID="Image1" />
                                                            <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="DateEffectiveFromTextBox"
                                                                Mask="99/99/9999" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                                                                OnInvalidCssClass="MaskedEditError" MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            Date Effective To
                                                        </td>
                                                        <td colspan="3">
                                                            <asp:TextBox ID="DateEffectiveToTextBox" runat="server" ValidationGroup="NewOutletGroup"
                                                                MaxLength="40" Width="100px"></asp:TextBox>
                                                            <asp:Image runat="Server" Style="vertical-align: middle;" ID="Image2" ImageUrl="~/images/Calendar_scheduleHS.png"
                                                                AlternateText="Click to show calendar" />
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="NewOutletGroup"
                                                                ControlToValidate="DateEffectiveToTextBox" Display="Dynamic" ErrorMessage="Date Effective From is required"
                                                                InitialValue="" Text="*" runat="server" />
                                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" Format="dd/MM/yyyy" runat="server"
                                                                TargetControlID="DateEffectiveToTextBox" PopupButtonID="Image2" />
                                                            <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="DateEffectiveToTextBox"
                                                                Mask="99/99/9999" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                                                                OnInvalidCssClass="MaskedEditError" MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </fieldset>
                                            <p>
                                                <asp:Button ID="OkButton" runat="server" Text="Update" ValidationGroup="NewOutletGroup"
                                                    CssClass="button" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                                    OnClick="PriceListHeaderDataList_UpdateCommand" />
                                                <asp:Button ID="DeleteButton" runat="server" Text="Delete" ValidationGroup="NewOutletGroup"
                                                    CommandArgument='<%# Bind("ID") %>' OnClick="PriceListHeaderDataList_DeleteCommand"
                                                    CssClass="button" />
                                                <asp:Button ID="CancelButton" Text="Cancel" runat="server" CausesValidation="false"
                                                    ValidationGroup="NewOutletGroup" CssClass="button" />
                                            </p>
                                        </asp:Panel>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ShowHeader="False" ItemStyle-Width="20%">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="ModifyButton" runat="server" CausesValidation="false" CommandName="Modify"
                                            CommandArgument='<%# Bind("ID") %>' Text="Modify Price List Item" />
                                    </ItemTemplate>
                                    <ControlStyle CssClass="button" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetAllWithoutNoItems"
                            TypeName="PriceListHeaderUI"></asp:ObjectDataSource>
                    </fieldset>
                </div>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="AddPriceListItem" runat="server" UpdateMode="Conditional">
        <Triggers>
            <asp:PostBackTrigger ControlID="CreatePriceListButton" />
            <asp:PostBackTrigger ControlID="PriceListGridView" />
            <asp:PostBackTrigger ControlID="PriceListItemDataList" />
        </Triggers>
        <ContentTemplate>
            <asp:Panel ID="AddPriceListPanel" runat="server" Visible="false">
                <div class="FormInput">
                    <fieldset id="Fieldset3">
                        <legend>
                            <h3>
                                PriceList Maintenance
                            </h3>
                        </legend>
                        <table style="width: 100%">
                            <tr>
                                <td align="center">
                                    <asp:ListBox ID="ProductListFromListBox" DataTextField="Description" DataValueField="ID"
                                        Height="200px" Width="250px" runat="server"></asp:ListBox>
                                    <div style="text-align: left">
                                        <ajaxToolkit:ListSearchExtender ID="ListSearchExtender1" runat="server" QueryTimeout="2000"
                                            QueryPattern="Contains" TargetControlID="ProductListFromListBox" PromptCssClass="ListSearchExtenderPrompt"
                                            IsSorted="true">
                                        </ajaxToolkit:ListSearchExtender>
                                    </div>
                                </td>
                                <td align="center">
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:Button ID="MoveRightProductButton" Text=">>" runat="server" OnClick="MoveRightProductButton_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Button ID="MoveLeftProductButton" Text="<<" runat="server" OnClick="MoveLeftProductButton_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td align="center">
                                    <asp:ListBox ID="ProductListToListBox" DataTextField="Description" DataValueField="ID"
                                        Height="200px" Width="250px" runat="server"></asp:ListBox>
                                    <div style="text-align: left">
                                        <ajaxToolkit:ListSearchExtender ID="ListSearchExtender2" runat="server" QueryTimeout="2000"
                                            QueryPattern="Contains" TargetControlID="ProductListToListBox" PromptCssClass="ListSearchExtenderPrompt"
                                            IsSorted="true">
                                        </ajaxToolkit:ListSearchExtender>
                                    </div>
                                </td>
                            </tr>
                        </table>
                        <asp:Panel ID="EnterPricePanel" Visible="false" runat="server">
                            <table>
                                <tr>
                                    <td>
                                        Original Price
                                    </td>
                                    <td>
                                        <asp:Label ID="OriginalPriceLabel" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Price After Discount Applied
                                    </td>
                                    <td>
                                        <asp:Label ID="DiscountAppliedLabel" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Enter Discount to be applied
                                    </td>
                                    <td>
                                        <asp:TextBox ID="DiscountTextBox" runat="server" Width="40px" MaxLength="5" AutoPostBack="True"
                                            OnTextChanged="DiscountTextBox_TextChanged"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="DiscountTextBox"
                                            ErrorMessage="Unit Price is a required field" InitialValue="" Text="*" runat="server" />
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                            TargetControlID="DiscountTextBox" FilterType="Custom,Numbers" ValidChars="." />
                                        %
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Check Discount
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="DiscountCheckBox" runat="server"></asp:CheckBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Button ID="SavePriceListItemButton" Text="Add Price List Item" runat="server"
                                            OnClick="SavePriceListItemButton_Click" />
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </fieldset>
                </div>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="PriceListItemDataListUpdatePanel" runat="server" UpdateMode="Conditional">
        <Triggers>
            <asp:PostBackTrigger ControlID="CreatePriceListButton" />
            <asp:PostBackTrigger ControlID="MaintainPriceListButton" />
            <asp:PostBackTrigger ControlID="SavePriceListItemButton" />
            <asp:PostBackTrigger ControlID="MoveLeftProductButton" />
        </Triggers>
        <ContentTemplate>
            <asp:Panel ID="PriceListItemPanel" runat="server" Visible="true">
                <div class="FormInput">
                    <fieldset id="Fieldset5">
                        <legend>
                            <h3>
                                PriceList Item Maintenance</h3>
                        </legend>
                        <div class="DataList">
                            <asp:DataList ID="PriceListItemDataList" runat="server" DataSourceID="ObjectDataSource2"
                                OnItemCommand="PriceListItemDataList_ItemCommand" OnCancelCommand="PriceListItemDataList_CancelCommand"
                                OnEditCommand="PriceListItemDataList_EditCommand" OnUpdateCommand="PriceListItemDataList_UpdateCommand"
                                DataKeyField="ID">
                                <HeaderTemplate>
                                    <table style="width: 100%" class="datalist" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <th style="width: 30%">
                                            </th>
                                            <th style="width: 20%">
                                                Product Name
                                            </th>
                                            <th style="width: 20%">
                                                Original Price
                                            </th>
                                            <th style="width: 20%">
                                                Discount
                                            </th>
                                            <th colspan="2" style="width: 10%">
                                                Value
                                            </th>
                                        </tr>
                                    </table>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <table class="datalist" style="width: 100%; text-align: left;" cellpadding="0" cellspacing="0">
                                        <tr class="row-a">
                                            <td style="width: 30%">
                                                <asp:Button ID="EditButton" runat="server" Text="Edit" CommandName="Edit" AlternateText="Click to Edit orders">
                                                </asp:Button>
                                                <asp:Button ID="Button1" runat="server" CommandName="Delete" CommandArgument='<%# Bind("ID") %>'
                                                    Text="Delete" />
                                            </td>
                                            <td style="width: 20%">
                                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("ProductName") %>'></asp:Label>
                                            </td>
                                            <td style="width: 20%">
                                                <asp:Label ID="Label3" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "OriginalPrice", "{0:c}") %>'></asp:Label>
                                            </td>
                                            <td style="width: 20%">
                                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("Discount") %>'></asp:Label>%
                                            </td>
                                            <td style="width: 10%">
                                                <asp:Label ID="Label4" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DiscountApplied", "{0:c}") %>'></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <table class="datalist" style="width: 100%; text-align: left;" cellpadding="0" cellspacing="0">
                                        <tr class="row-a">
                                            <td style="width: 30%">
                                                <asp:Button ID="UpdateButton" runat="server" Text="Update" CommandName="Update" AlternateText="Click to view orders">
                                                </asp:Button>
                                                <asp:Button ID="CancelButton" runat="server" Text="Cancel" CommandName="Cancel" AlternateText="Click to view orders">
                                                </asp:Button>
                                            </td>
                                            <td style="width: 20%">
                                                <asp:Label ID="ProductNameLabel" runat="server" Text='<%# Bind("ProductName") %>'></asp:Label>
                                            </td>
                                            <td style="width: 20%">
                                                <asp:Label ID="OriginalPriceLabel" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "OriginalPrice", "{0:c}") %>'></asp:Label>
                                            </td>
                                            <td style="width: 20%">
                                                <asp:TextBox ID="DiscountTextBox" MaxLength="5" Width="40px" runat="server" Text='<%# Bind("Discount") %>'></asp:TextBox>%
                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                                    TargetControlID="DiscountTextBox" FilterType="Custom,Numbers" ValidChars="." />
                                            </td>
                                            <td style="width: 10%">
                                                <asp:Label ID="DiscountAppliedLabel" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DiscountApplied", "{0:c}") %>'></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </EditItemTemplate>
                            </asp:DataList>
                        </div>
                        <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="GetPriceListItems"
                            TypeName="PriceListItemUI" OnSelecting="ObjectDataSource2_Selecting">
                            <SelectParameters>
                                <asp:Parameter Name="id" Type="Int32" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                    </fieldset>
                </div>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
