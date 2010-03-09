<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" StylesheetTheme="SuperCream"
    AutoEventWireup="true" CodeFile="Customer.aspx.cs" Inherits="Admin_Customer" %>

<%@ Register Src="../Controls/ErrorView.ascx" TagName="ErrorView" TagPrefix="Alterax" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="ErrorUpdatePanel" runat="server" UpdateMode="Conditional">
        <Triggers>
            <asp:PostBackTrigger ControlID="AddCustomerButton" />
            <asp:PostBackTrigger ControlID="OutletStoreGridView" />
            <asp:PostBackTrigger ControlID="MaintainCustomersButton" />
            <asp:PostBackTrigger ControlID="CustomerSaveButton" />
            <asp:PostBackTrigger ControlID="AddShopButton" />
            <asp:PostBackTrigger ControlID="CancelShopButton" />
            <asp:PostBackTrigger ControlID="SearchButton" />
            <asp:PostBackTrigger ControlID="CustomerListGridView" />
            <asp:PostBackTrigger ControlID="AddNewContactButton" />
            <asp:PostBackTrigger ControlID="CancelAddContactButton" />
            <asp:PostBackTrigger ControlID="AddContactButton" />
            <asp:PostBackTrigger ControlID="ContactDetailDataList" />
        </Triggers>
        <ContentTemplate>
            <div class="ErrorOutput">
                <Alterax:ErrorView ID="ErrorViewControl" Visible="false" runat="server" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="CustomerMenuUpdatePanel" runat="server" UpdateMode="Conditional">
        <Triggers>
            <asp:PostBackTrigger ControlID="CustomerListGridView" />
            <asp:PostBackTrigger ControlID="OutletStoreGridView" />
        </Triggers>
        <ContentTemplate>
            <asp:Panel ID="CustomerMenuPanel" Visible="true"
                runat="server">
                <div class="FormHeader">
                    <div class="HeaderContainerPanel">
                        <table class="ContentHeader" cellpadding="0" cellspacing="0">
                            <tr>
                                <td class="Right">
                                    <asp:Panel ID="GeneralPanel" DefaultButton="NewCustomerButton"  runat="server" Width="100%"
                                        Visible="true">
                                        <table class="ContentHeader" cellpadding="0">
                                            <tr>
                                                <td style="width: 30%; text-align: left;">
                                                    <span class="RequiredFieldMessage">*</span> <i>indicates a required field</i>
                                                </td>
                                                <td class="Right" style="width: 70%;">
                                                    <asp:LinkButton ID="NewCustomerButton" Text="New Customer" runat="server" OnClick="AddNewCustomerButton_Click" />
                                                    &nbsp; |
                                                    <asp:LinkButton ID="MaintainCustomersButton" Text="Modify Customer" runat="server"
                                                        OnClick="MaintainCustomersButton_Click" />
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
    <asp:UpdatePanel ID="AddCustomerUpdatePanel" runat="server" UpdateMode="Conditional">
        <Triggers>
            <asp:PostBackTrigger ControlID="NewCustomerButton" />
            <asp:PostBackTrigger ControlID="MaintainCustomersButton" />
            <asp:PostBackTrigger ControlID="CustomerListGridView" />
        </Triggers>
        <ContentTemplate>
            <asp:Panel ID="AddCustomerPanel" DefaultButton="AddCustomerButton" Visible="false"
                runat="server">
                <div class="FormInput">
                    <fieldset id="VarInputLegend">
                        <legend>
                            <h3>
                                Add a Customer</h3>
                        </legend>
                        <table style="width: 100%">
                            <tr>
                                <td>
                                    Name
                                </td>
                                <td>
                                    <asp:TextBox ID="NameTextBox" runat="server" ValidationGroup="NewCustomerGroup" MaxLength="50"
                                        Width="500px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="NewCustomerGroup"
                                        ControlToValidate="NameTextBox" ErrorMessage="Name is a required Text Box" InitialValue=""
                                        Text="*" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Price List
                                </td>
                                <td>
                                    <asp:DropDownList ID="PriceListDropDownList" ValidationGroup="NewCustomerGroup" Width="300px"
                                        AppendDataBoundItems="True" runat="server">
                                        <asp:ListItem Value="-1">-- No Item Selected --</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="NewCustomerGroup"
                                        ControlToValidate="PriceListDropDownList" InitialValue="-1" ErrorMessage="You must select Price List"
                                        Text="*" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                    <table class="progressupdate">
                                        <tr>
                                            <td>
                                                <asp:LinkButton ID="AddCustomerButton" Text="Add Shop Details" ValidationGroup="NewCustomerGroup"
                                                    runat="server" OnClick="AddCustomerButton_Click" />
                                            </td>
                                            <td>
                                                <div class="progressupdate">
                                                    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="AddCustomerUpdatePanel"
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
    <asp:UpdatePanel ID="AddShopUpdatePanel" runat="server" UpdateMode="Conditional">
        <Triggers>
            <asp:PostBackTrigger ControlID="AddCustomerButton" />
            <asp:PostBackTrigger ControlID="CustomerSaveButton" />
            <asp:PostBackTrigger ControlID="CustomerListGridView" />
            <asp:PostBackTrigger ControlID="NewCustomerButton" />
            <asp:PostBackTrigger ControlID="MaintainCustomersButton" />
            <asp:PostBackTrigger ControlID="CustomerListGridView" />
        </Triggers>
        <ContentTemplate>
            <asp:Panel ID="AddShopPanel" DefaultButton="AddShopButton" runat="server">
                <div class="FormInput">
                    <fieldset id="Fieldset2">
                        <legend>
                            <h3>
                                Enter New Shop</h3>
                        </legend>
                        <table style="width: 100%">
                            <tr>
                                <td style="width: 20%">
                                </td>
                                <td style="width: 30%">
                                </td>
                                <td style="width: 10%">
                                </td>
                                <td style="width: 30%">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Name
                                </td>
                                <td colspan="3">
                                    <asp:TextBox ID="ShopNameTextBox" runat="server" ValidationGroup="NewOutletGroup"
                                        MaxLength="40" Width="350px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ValidationGroup="NewOutletGroup"
                                        ControlToValidate="ShopNameTextBox" ErrorMessage="Name is a required Text Box"
                                        InitialValue="" Text="*" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Address
                                </td>
                                <td colspan="3">
                                    <asp:TextBox ID="AddressLine1TextBox" runat="server" ValidationGroup="NewOutletGroup"
                                        MaxLength="40" Width="350px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="NewOutletGroup"
                                        ControlToValidate="AddressLine1TextBox" ErrorMessage="Address Line is a required Text Box"
                                        InitialValue="" Text="*" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td colspan="3">
                                    <asp:TextBox ID="AddressLine2TextBox" runat="server" ValidationGroup="NewOutletGroup"
                                        MaxLength="40" Width="350px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Town/City
                                </td>
                                <td colspan="3">
                                    <asp:TextBox ID="TownTextBox" runat="server" ValidationGroup="NewOutletGroup" MaxLength="40"
                                        Width="350px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ValidationGroup="NewOutletGroup"
                                        ControlToValidate="TownTextBox" ErrorMessage="City/Town is a required Text Box"
                                        InitialValue="" Text="*" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    County
                                </td>
                                <td colspan="3">
                                    <asp:TextBox ID="CountyTextBox" runat="server" ValidationGroup="NewOutletGroup" MaxLength="40"
                                        Width="350px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" ValidationGroup="NewOutletGroup"
                                        ControlToValidate="CountyTextBox" ErrorMessage="County is a required Text Box"
                                        InitialValue="" Text="*" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Post Code
                                </td>
                                <td colspan="3">
                                    <asp:TextBox ID="PostCodeTextBox" runat="server" ValidationGroup="NewOutletGroup"
                                        MaxLength="8" Width="350px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" ValidationGroup="NewOutletGroup"
                                        ControlToValidate="PostCodeTextBox" Display="Dynamic" ErrorMessage="Post Code is a required Text Box"
                                        InitialValue="" Text="*" runat="server" />
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorPostCodeTextBox" ValidationGroup="NewOutletGroup"
                                        ValidationExpression="^([Gg][Ii][Rr] 0[Aa]{2})|((([A-Za-z][0-9]{1,2})|(([A-Za-z][A-Ha-hJ-Yj-y][0-9]{1,2})|(([A-Za-z][0-9][A-Za-z])|([A-Za-z][A-Ha-hJ-Yj-y][0-9]?[A-Za-z])))) {0,1}[0-9][A-Za-z]{2})$"
                                        ControlToValidate="PostCodeTextBox" Text="Format Error" ErrorMessage="Invalid UK Post Code"
                                        Display="Dynamic" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Map Ref.
                                </td>
                                <td colspan="3">
                                    <asp:TextBox ID="MapReferenceTextBox" runat="server" ValidationGroup="NewOutletGroup"
                                        MaxLength="8" Width="350px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ValidationGroup="NewOutletGroup"
                                        ControlToValidate="MapReferenceTextBox" Display="Dynamic" ErrorMessage="Map Reference is a required Text Box"
                                        InitialValue="" Text="*" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td style="vertical-align: top">
                                    Opening Hours
                                </td>
                                <td>
                                    <asp:TextBox ID="OpeningHoursTextBox" runat="server" ValidationGroup="NewOutletGroup"
                                        TextMode="MultiLine" MaxLength="20" Height="150px" Width="90%"></asp:TextBox>
                                </td>
                                <td style="vertical-align: top">
                                    Notes
                                </td>
                                <td>
                                    <asp:TextBox ID="NotesTextBox" runat="server" ValidationGroup="NewOutletGroup" TextMode="MultiLine"
                                        MaxLength="20" Height="150px" Width="90%"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <table class="progressupdate">
                                        <tr>
                                            <td>
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <asp:LinkButton ID="AddShopButton" Text="Add Shop" ValidationGroup="NewOutletGroup" runat="server"
                                                                OnClick="AddShopButton_Click" />&nbsp;
                                                        </td>
                                                        <td>
                                                            <asp:Button ID="CancelShopButton" CausesValidation="false" runat="server" OnClick="CancelShopButton_Click"
                                                                Text="Cancel" ValidationGroup="NewOutletGroup" />
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td colspan="2">
                                    <div class="progressupdate">
                                        <asp:UpdateProgress ID="UpdateProgress2" runat="server" AssociatedUpdatePanelID="AddShopUpdatePanel"
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
    <asp:UpdatePanel ID="OutletShopBasketPanel" runat="server" UpdateMode="Conditional">
        <Triggers>
            <asp:PostBackTrigger ControlID="AddShopButton" />
            <asp:PostBackTrigger ControlID="CustomerListGridView" />
        </Triggers>
        <ContentTemplate>
            <asp:Panel ID="ShopBasketPanel" runat="server" Visible="false">
                <div class="FormInput">
                    <fieldset id="Fieldset3">
                        <legend>
                            <h3>
                                Added Shops</h3>
                        </legend>
                        <asp:GridView ID="OutletStoreGridView" Width="98%" runat="server" Visible="false"
                            AutoGenerateColumns="False" CssClass="simplegrid" OnRowCommand="OutletStoreGridView_RowCommand"
                            OnRowDeleting="OutletStoreGridView_RowDeleting">
                            <RowStyle CssClass="row-a" />
                            <AlternatingRowStyle CssClass="row-b" />
                            <Columns>
                                <asp:BoundField DataField="Name" HeaderText="Name" ItemStyle-Width="25%" SortExpression="Name" />
                                <asp:BoundField DataField="OpeningHoursNotes" ItemStyle-Width="35%" HeaderText="OpeningHoursNotes"
                                    SortExpression="OpeningHoursNotes" />
                                <asp:BoundField DataField="Notes" HeaderText="Notes" ItemStyle-Width="35%" SortExpression="Notes" />
                                <asp:ButtonField ButtonType="Button" ItemStyle-Width="5%" ControlStyle-CssClass="button"
                                    CommandName="Delete" Text="Delete" />
                            </Columns>
                        </asp:GridView>
                        <table>
                            <tr>
                                <td>
                                </td>
                                <td id="CustomerUpdateTD">
                                    <asp:Button ID="CustomerSaveButton" Text="Save" runat="server" OnClick="CustomerSaveButton_Click" />
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                </div>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="CustomerListUpdatePanel" runat="server" UpdateMode="Conditional">
        <Triggers>
            <asp:PostBackTrigger ControlID="MaintainCustomersButton" />
            <asp:PostBackTrigger ControlID="CustomerListGridView" />
        </Triggers>
        <ContentTemplate>
            <asp:Panel ID="CustomerListGridViewPanel" DefaultButton="SearchButton" Visible="false"
                runat="server">
                <div class="FormInput">
                    <fieldset id="Fieldset4">
                        <legend>
                            <h3>
                                Select Customer</h3>
                        </legend>
                        <table class="search">
                            <tr>
                                <td class="right">
                                    <table class="left">
                                        <tr>
                                            <td>
                                                <asp:Label ID="CustomerNameLabel" Text="Customer Name" runat="server"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="CustomerNameSearchTextBox" Width="300px" MaxLength="40" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="AccountNoLabel" Text="Account No" runat="server"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="AccountNoTextBox" Width="300px" MaxLength="15" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="TelephoneNoLabel" Text="Telephone No" runat="server"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TelephoneNoSearchTextBox" Width="300px" MaxLength="30" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                            </td>
                                            <td>
                                                <asp:Button ID="SearchButton" Text="Search" runat="server" OnClick="SearchButton_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <tr>
                                    <td>
                                        <asp:GridView ID="CustomerListGridView" Width="98%" runat="server" DataKeyNames="ID"
                                            Visible="False" AutoGenerateColumns="False" CssClass="simplegrid" DataSourceID="ObjectDataSource1"
                                            OnRowCommand="CustomerListGridView_RowCommand" OnRowDataBound="CustomerListGridView_RowDataBound">
                                            <RowStyle CssClass="row-a" />
                                            <AlternatingRowStyle CssClass="row-b" />
                                            <Columns>
                                                <asp:BoundField Visible="false" DataField="ID" HeaderText="ID" SortExpression="Name">
                                                </asp:BoundField>
                                                <asp:BoundField ItemStyle-Width="53%" DataField="Name" HeaderText="Name" SortExpression="Name">
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="Account No" SortExpression="AccountNo">
                                                    <ItemTemplate>
                                                        <asp:BulletedList ID="AccountNoBulletedList" runat="server" BulletStyle="Disc" DisplayMode="Text"
                                                            DataTextField="AlphaID" DataValueField="ID">
                                                        </asp:BulletedList>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="27%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField ShowHeader="False">
                                                    <ItemTemplate>
                                                        <asp:Button ID="Button1" runat="server" CausesValidation="false" CommandName="ModifyCustomer"
                                                            Text="Shop Details" Width="100%" CommandArgument='<%# Bind("ID") %>' />
                                                        <asp:Button ID="Button2" runat="server" CausesValidation="false" CommandName="ModifyCustomerContact"
                                                            Text="Customer Contacts" Width="100%" CommandArgument='<%# Bind("ID") %>' />
                                                        <asp:Button ID="Button3" runat="server" CausesValidation="false" CommandName="DeleteCustomer"
                                                            Text="Delete Customer" Width="100%" CommandArgument='<%# Bind("ID") %>' />
                                                    </ItemTemplate>
                                                    <ControlStyle CssClass="button" />
                                                    <ItemStyle Width="20%" />
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetAllCustomers"
                                            TypeName="CustomerUI" OnSelecting="ObjectDataSource1_Selecting">
                                            <SelectParameters>
                                                <asp:Parameter Name="customerName" Type="String" />
                                                <asp:Parameter Name="telephoneNo" Type="String" />
                                                <asp:Parameter Name="accountNo" Type="String" />
                                            </SelectParameters>
                                        </asp:ObjectDataSource>
                                    </td>
                                </tr>
                        </table>
                    </fieldset>
                </div>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="ModifyCustomerUpdatePanel" runat="server" UpdateMode="Conditional">
        <Triggers>
            <asp:PostBackTrigger ControlID="AddModifiedShopButton" />
            <asp:PostBackTrigger ControlID="CancelModifiedShopButton" />
            <asp:PostBackTrigger ControlID="ModifyCustomerSaveButton" />
            <asp:PostBackTrigger ControlID="CustomerListGridView" />
        </Triggers>
        <ContentTemplate>
            <div class="FormInput">
                <asp:Panel ID="ModifyCustomerPanel" runat="server">
                    <fieldset id="Fieldset5">
                        <legend>
                            <h3>
                                Modify Existing Customer</h3>
                        </legend>
                        <table style="width: 100%">
                            <tr>
                                <td>
                                    Name
                                </td>
                                <td>
                                    <asp:TextBox ID="ModifyNameTextBox" runat="server" ValidationGroup="NewCustomerGroup"
                                        MaxLength="40" Width="350px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="ModifyRequiredFieldValidator2" ValidationGroup="NewCustomerGroup"
                                        ControlToValidate="ModifyNameTextBox" ErrorMessage="Name is a required Text Box"
                                        InitialValue="" Text="*" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Price List
                                </td>
                                <td>
                                    <asp:DropDownList ID="ModifyPriceListDropDownList" Width="300px" runat="server">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                    <table class="progressupdate">
                                        <tr>
                                            <td colspan="1">
                                                <table class="progressupdate">
                                                    <tr>
                                                        <td>
                                                            <asp:LinkButton ID="ModifyShopButtton" Text="Add Shop" runat="server" OnClick="ModifyShopButton_Click" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td>
                                                <div class="progressupdate">
                                                    <asp:UpdateProgress ID="UpdateProgress3" runat="server" AssociatedUpdatePanelID="ModifyCustomerUpdatePanel"
                                                        DisplayAfter="1">
                                                        <ProgressTemplate>
                                                            <asp:Image ID="aspImg2" runat="server" ImageUrl="~/images/progress3.gif"></asp:Image>
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
                </asp:Panel>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="ModifyShopUpdatePanel" runat="server" UpdateMode="Conditional">
        <Triggers>
            <asp:PostBackTrigger ControlID="ModifyShopButtton" />
            <asp:PostBackTrigger ControlID="CustomerListGridView" />
        </Triggers>
        <ContentTemplate>
            <asp:Panel ID="AddModifiedShopPanel" DefaultButton="AddModifiedShopButton" Visible="false"
                runat="server">
                <div class="FormInput">
                    <fieldset id="Fieldset6">
                        <legend>
                            <h3>
                                Enter New Shop</h3>
                        </legend>
                        <table>
                            <tr>
                                <td style="width: 20%">
                                </td>
                                <td style="width: 40%">
                                </td>
                                <td style="width: 5%">
                                </td>
                                <td style="width: 35%">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Name
                                </td>
                                <td colspan="3">
                                    <asp:TextBox ID="ModifiedShopNameTextBox" runat="server" ValidationGroup="NewOutletGroup"
                                        MaxLength="40" Width="370px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="ModifiedRequiredFieldValidator4" ValidationGroup="NewOutletGroup"
                                        ControlToValidate="ModifiedShopNameTextBox" ErrorMessage="Name is a required Text Box"
                                        InitialValue="" Text="*" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Address
                                </td>
                                <td colspan="3">
                                    <asp:TextBox ID="ModifiedAddressLine1TextBox" runat="server" ValidationGroup="NewOutletGroup"
                                        MaxLength="40" Width="370px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="ModifiedRequiredFieldValidator1" ValidationGroup="NewOutletGroup"
                                        ControlToValidate="ModifiedAddressLine1TextBox" ErrorMessage="Address Line is a required Text Box"
                                        InitialValue="" Text="*" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td colspan="3">
                                    <asp:TextBox ID="ModifiedAddressLine2TextBox" runat="server" ValidationGroup="NewOutletGroup"
                                        MaxLength="40" Width="370px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Town/City
                                </td>
                                <td colspan="3">
                                    <asp:TextBox ID="ModifiedTownTextBox" runat="server" ValidationGroup="NewOutletGroup"
                                        MaxLength="40" Width="370px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="ModifiedRequiredFieldValidator8" ValidationGroup="NewOutletGroup"
                                        ControlToValidate="ModifiedTownTextBox" ErrorMessage="City/Town is a required Text Box"
                                        InitialValue="" Text="*" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    County
                                </td>
                                <td colspan="3">
                                    <asp:TextBox ID="ModifiedCountyTextBox" runat="server" ValidationGroup="NewOutletGroup"
                                        MaxLength="40" Width="370px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="ModifiedRequiredFieldValidator9" ValidationGroup="NewOutletGroup"
                                        ControlToValidate="ModifiedCountyTextBox" ErrorMessage="County is a required Text Box"
                                        InitialValue="" Text="*" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Post Code
                                </td>
                                <td colspan="3">
                                    <asp:TextBox ID="ModifiedPostCodeTextBox" runat="server" ValidationGroup="NewOutletGroup"
                                        MaxLength="8" Width="60px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="ModifiedRequiredFieldValidator10" ValidationGroup="NewOutletGroup"
                                        ControlToValidate="ModifiedPostCodeTextBox" ErrorMessage="Post Code is a required Text Box"
                                        InitialValue="" Text="*" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Map Ref.
                                </td>
                                <td colspan="3">
                                    <asp:TextBox ID="ModifiedMapReferenceTextBox" runat="server" ValidationGroup="NewOutletGroup"
                                        MaxLength="8" Width="60px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ValidationGroup="NewOutletGroup"
                                        ControlToValidate="ModifiedMapReferenceTextBox" ErrorMessage="Map Reference is a required Text Box"
                                        InitialValue="" Text="*" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td style="vertical-align: top;">
                                    Opening Hours
                                </td>
                                <td>
                                    <asp:TextBox ID="ModifiedOpeningHoursTextBox" runat="server" ValidationGroup="NewOutletGroup"
                                        TextMode="MultiLine" MaxLength="20" Height="150px" Width="90%"></asp:TextBox>
                                </td>
                                <td style="vertical-align: top;">
                                    Notes
                                </td>
                                <td>
                                    <asp:TextBox ID="ModifiedNotesTextBox" runat="server" ValidationGroup="NewOutletGroup"
                                        TextMode="MultiLine" MaxLength="20" Height="150px" Width="220px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <table class="progressupdate">
                                        <tr>
                                            <td style="width: 5%">
                                                <asp:Button ID="AddModifiedShopButton" Text="Add Shop" ValidationGroup="NewOutletGroup"
                                                    runat="server" OnClick="AddModifiedShopButton_Click" />
                                            </td>
                                            <td style="width: 95%">
                                                &nbsp;
                                                <asp:Button ID="CancelModifiedShopButton" CausesValidation="false" Text="Cancel"
                                                    runat="server" OnClick="CancelModifiedShopButton_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td colspan="2">
                                    <div class="progressupdate">
                                        <asp:UpdateProgress ID="UpdateProgress99" runat="server" AssociatedUpdatePanelID="ModifyShopUpdatePanel"
                                            DisplayAfter="1">
                                            <ProgressTemplate>
                                                <asp:Image ID="ProgressImg3" runat="server" ImageUrl="~/images/progress3.gif"></asp:Image>
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
    <asp:UpdatePanel ID="ModifyOutletShopBasketUpdatePanel" runat="server" UpdateMode="Conditional">
        <Triggers>
            <asp:PostBackTrigger ControlID="AddModifiedShopButton" />
            <asp:PostBackTrigger ControlID="CustomerListGridView" />
        </Triggers>
        <ContentTemplate>
            <asp:Panel ID="ModifyShopBasketPanel" Visible="false" runat="server">
                <div class="FormInput">
                    <fieldset id="Fieldset7">
                        <legend>
                            <h3>
                                Select Shop</h3>
                        </legend>
                        <div class="DataList">
                            <asp:DataList ID="OutletStoreDataList" runat="server" OnItemCommand="OutletStoreDataList_ItemCommand"
                                DataSourceID="ShopDataListObjectDataSource" OnItemDataBound="OutletStoreDataList_ItemDataBound">
                                <HeaderTemplate>
                                    <table class="datalist" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <th style="width: 10%">
                                            </th>
                                            <th style="width: 45%">
                                                Name
                                            </th>
                                            <th style="width: 35%">
                                                Opening Hours
                                            </th>
                                            <th style="width: 10%">
                                            </th>
                                        </tr>
                                    </table>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <table class="datalist" cellpadding="0" cellspacing="0">
                                        <tr class="row-a">
                                            <td style="width: 10%">
                                                <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/images/btn_expand.gif"
                                                    CommandName="Select" AlternateText="Click to view Shop"></asp:ImageButton>
                                            </td>
                                            <td style="width: 45%">
                                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                                            </td>
                                            <td style="width: 35%">
                                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("OpeningHoursNotes") %>'></asp:Label>
                                            </td>
                                            <td style="width: 10%">
                                                <asp:Button ID="SelectButton" runat="server" CommandName="Delete" CommandArgument='<%# Bind("ID") %>'
                                                    Text="Delete" />
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                                <AlternatingItemTemplate>
                                    <table class="datalist" cellpadding="0" cellspacing="0">
                                        <tr class="row-b">
                                            <td style="width: 10%">
                                                <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/images/btn_expand.gif"
                                                    CommandName="Select" AlternateText="Click to view orders"></asp:ImageButton>
                                            </td>
                                            <td style="width: 45%">
                                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                                            </td>
                                            <td style="width: 35%">
                                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("OpeningHoursNotes") %>'></asp:Label>
                                            </td>
                                            <td style="width: 10%">
                                                <asp:Button ID="SelectButton" runat="server" CommandName="Delete" CommandArgument='<%# Bind("ID") %>'
                                                    Text="Delete" />
                                            </td>
                                        </tr>
                                    </table>
                                </AlternatingItemTemplate>
                                <SelectedItemTemplate>
                                    <asp:Panel ID="SelectedPanel" runat="server">
                                        <legend>
                                            <h3>
                                                Modify Existing Shop Details</h3>
                                        </legend>
                                        <fieldset id="Fieldset2">
                                            <asp:Label ID="IDLabel" runat="server" Visible="false" Width="350px"></asp:Label>
                                            <table class="datalist" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td colspan="4">
                                                        <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/images/btn_minimise.gif"
                                                            CommandName="UnSelect" AlternateText="Click to view orders"></asp:ImageButton>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Name
                                                    </td>
                                                    <td colspan="3">
                                                        <asp:TextBox ID="ShopNameTextBox" runat="server" ValidationGroup="NewOutletGroup"
                                                            MaxLength="40" Width="350px"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ValidationGroup="NewOutletGroup"
                                                            ControlToValidate="ShopNameTextBox" ErrorMessage="Name is a required Text Box"
                                                            InitialValue="" Text="*" runat="server" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Address
                                                    </td>
                                                    <td colspan="3">
                                                        <asp:TextBox ID="AddressLine1TextBox" runat="server" ValidationGroup="NewOutletGroup"
                                                            MaxLength="40" Width="350px"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="NewOutletGroup"
                                                            ControlToValidate="AddressLine1TextBox" ErrorMessage="Address Line is a required Text Box"
                                                            InitialValue="" Text="*" runat="server" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td colspan="3">
                                                        <asp:TextBox ID="AddressLine2TextBox" runat="server" ValidationGroup="NewOutletGroup"
                                                            MaxLength="40" Width="350px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Town/City
                                                    </td>
                                                    <td colspan="3">
                                                        <asp:TextBox ID="TownTextBox" runat="server" ValidationGroup="NewOutletGroup" MaxLength="40"
                                                            Width="350px"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ValidationGroup="NewOutletGroup"
                                                            ControlToValidate="TownTextBox" ErrorMessage="City/Town is a required Text Box"
                                                            InitialValue="" Text="*" runat="server" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        County
                                                    </td>
                                                    <td colspan="3">
                                                        <asp:TextBox ID="CountyTextBox" runat="server" ValidationGroup="NewOutletGroup" MaxLength="40"
                                                            Width="350px"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" ValidationGroup="NewOutletGroup"
                                                            ControlToValidate="CountyTextBox" ErrorMessage="County is a required Text Box"
                                                            InitialValue="" Text="*" runat="server" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Post Code
                                                    </td>
                                                    <td colspan="3">
                                                        <asp:TextBox ID="PostCodeTextBox" runat="server" ValidationGroup="NewOutletGroup"
                                                            MaxLength="8" Width="350px"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" ValidationGroup="NewOutletGroup"
                                                            ControlToValidate="PostCodeTextBox" ErrorMessage="Post Code is a required Text Box"
                                                            InitialValue="" Text="*" runat="server" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Map Ref.
                                                    </td>
                                                    <td colspan="3">
                                                        <asp:TextBox ID="MapReferenceTextBox" runat="server" ValidationGroup="NewOutletGroup"
                                                            MaxLength="8" Width="350px"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ValidationGroup="NewOutletGroup"
                                                            ControlToValidate="MapReferenceTextBox" ErrorMessage="Map Reference is a required Text Box"
                                                            InitialValue="" Text="*" runat="server" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="vertical-align: top; width: 15%">
                                                        Opening Hours
                                                    </td>
                                                    <td style="vertical-align: top; width: 35%;">
                                                        <asp:TextBox ID="OpeningHoursTextBox" runat="server" ValidationGroup="NewOutletGroup"
                                                            TextMode="MultiLine" MaxLength="20" Height="150px" Width="90%"></asp:TextBox>
                                                    </td>
                                                    <td style="vertical-align: top; width: 15%;">
                                                        Notes
                                                    </td>
                                                    <td style="vertical-align: top; width: 35%;">
                                                        <asp:TextBox ID="NotesTextBox" runat="server" ValidationGroup="NewOutletGroup" TextMode="MultiLine"
                                                            MaxLength="20" Height="150px" Width="90%"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        <table class="progressupdate">
                                                            <tr>
                                                                <td>
                                                                    <asp:Button ID="AddShopButton" Text="Modify Shop" CommandName="Update" CommandArgument='<%# Bind("ID") %>'
                                                                        ValidationGroup="NewOutletGroup" runat="server" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </fieldset>
                                    </asp:Panel>
                                </SelectedItemTemplate>
                            </asp:DataList>
                        </div>
                        <table>
                            <tr>
                                <td>
                                    <asp:ObjectDataSource ID="ShopDataListObjectDataSource" runat="server" SelectMethod="GetOutletStoresByCustomerID"
                                        TypeName="CustomerUI" OnSelecting="ShopDataListObjectDataSource_Selecting">
                                        <SelectParameters>
                                            <asp:QueryStringParameter Name="id" QueryStringField="ID" Type="Int32" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                                </td>
                                <td id="Td1">
                                    <asp:Button ID="ModifyCustomerSaveButton" Text="Save" runat="server" OnClick="CustomerUpdateButton_Click" />
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                </div>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="AddCustomerContactUpdatePanel" runat="server" UpdateMode="Conditional">
        <Triggers>
            <asp:PostBackTrigger ControlID="NewCustomerButton" />
            <asp:PostBackTrigger ControlID="MaintainCustomersButton" />
            <asp:PostBackTrigger ControlID="ContactDetailDataList" />
        </Triggers>
        <ContentTemplate>
            <div class="ErrorOutput">
                <Alterax:ErrorView ID="ErrorView1" Visible="false" runat="server" />
                <asp:PostBackTrigger ControlID="CustomerContactUpdateButton" />
            </div>
            <div class="FormInput">
                <asp:Panel ID="AddCustomerContactPanel" runat="server">
                    <fieldset id="Fieldset8">
                        <legend>
                            <h3>
                                Modify Customer Contacts</h3>
                        </legend>
                        <table style="width: 100%">
                            <tr>
                                <td>
                                    Name
                                </td>
                                <td>
                                    <asp:TextBox ID="CustomerContactNameTextBox" runat="server" ValidationGroup="NewCustomerGroup"
                                        MaxLength="40" Width="500px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="CCRequiredFieldValidator2" ValidationGroup="NewCustomerGroup"
                                        ControlToValidate="CustomerContactNameTextBox" ErrorMessage="Name is a required Text Box"
                                        InitialValue="" Text="*" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Price List
                                </td>
                                <td>
                                    <asp:DropDownList ID="CustomerContactPriceListDropDownList" Width="300px" runat="server">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                    <table class="progressupdate">
                                        <tr>
                                            <td colspan="1">
                                                <table class="progressupdate">
                                                    <tr>
                                                        <td>
                                                            <asp:Button ID="AddNewContactButton" Text="Add Contact" runat="server" OnClick="AddNewContactButton_Click" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td>
                                                <div class="progressupdate">
                                                    <asp:UpdateProgress ID="CCUpdateProgress1" runat="server" AssociatedUpdatePanelID="AddCustomerContactUpdatePanel"
                                                        DisplayAfter="1">
                                                        <ProgressTemplate>
                                                            <asp:Image ID="aspImgContactUpdate" runat="server" ImageUrl="~/images/progress3.gif">
                                                            </asp:Image>
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
                </asp:Panel>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="AddContactDetailUpdatePanel" runat="server" UpdateMode="Conditional">
        <Triggers>
            <asp:PostBackTrigger ControlID="AddNewContactButton" />
            <asp:PostBackTrigger ControlID="NewCustomerButton" />
            <asp:PostBackTrigger ControlID="MaintainCustomersButton" />
            <asp:PostBackTrigger ControlID="ContactDetailDataList" />
            <asp:PostBackTrigger ControlID="CustomerContactUpdateButton" />
        </Triggers>
        <ContentTemplate>
            <asp:Panel ID="AddContactPanel" DefaultButton="AddContactButton" Visible="false"
                runat="server">
                <div class="FormInput">
                    <fieldset id="Fieldset9">
                        <legend>
                            <h3>
                                Enter New Contact</h3>
                        </legend>
                        <table>
                            <tr>
                                <td style="width: 25%">
                                </td>
                                <td style="width: 25%">
                                </td>
                                <td style="width: 15%">
                                </td>
                                <td style="width: 35%">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Job Role
                                </td>
                                <td colspan="3">
                                    <asp:TextBox ID="JobRoleTextBox" runat="server" ValidationGroup="NewContactGroup"
                                        MaxLength="35" Width="300px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="CCRequiredFieldValidator7" ValidationGroup="NewContactGroup"
                                        ControlToValidate="JobRoleTextBox" ErrorMessage="Name is a required Text Box"
                                        InitialValue="" Text="*" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Title
                                </td>
                                <td colspan="3">
                                    <asp:TextBox ID="TitleTextBox" runat="server" ValidationGroup="NewContactGroup" MaxLength="35"
                                        Width="300px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="CCRequiredFieldValidator3" ValidationGroup="NewContactGroup"
                                        ControlToValidate="TitleTextBox" ErrorMessage="Name is a required Text Box" InitialValue=""
                                        Text="*" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    First Name
                                </td>
                                <td colspan="3">
                                    <asp:TextBox ID="FirstNameTextBox" runat="server" ValidationGroup="NewContactGroup"
                                        MaxLength="35" Width="300px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Last Name
                                </td>
                                <td colspan="3">
                                    <asp:TextBox ID="LastNameTextBox" runat="server" ValidationGroup="NewContactGroup"
                                        MaxLength="35" Width="300px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="CCRequiredFieldValidator11" ValidationGroup="NewContactGroup"
                                        ControlToValidate="LastNameTextBox" ErrorMessage="Name is a required Text Box"
                                        InitialValue="" Text="*" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Daytime Telephone No.
                                </td>
                                <td colspan="3">
                                    <asp:TextBox ID="DayTimeTelephoneNoTextBox" runat="server" ValidationGroup="NewContactGroup"
                                        MaxLength="20" Width="300px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="CCRequiredFieldValidator14" ValidationGroup="NewContactGroup"
                                        ControlToValidate="DayTimeTelephoneNoTextBox" ErrorMessage="Day Time Telephone No is Required"
                                        InitialValue="" Text="*d" Display="Dynamic" runat="server" />
                                    <asp:RegularExpressionValidator ID="CCRegularExpressionValidator" runat="server"
                                        ControlToValidate="DayTimeTelephoneNoTextBox" ErrorMessage="Invalid UK phone number"
                                        Text="Format Error" Display="Dynamic" ValidationExpression="^(\(?\+?[0-9]*\)?)?[0-9_\- \(\)]*$">
                                    </asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Home Phone No.
                                </td>
                                <td colspan="3">
                                    <asp:TextBox ID="HomePhoneNoTextBox" runat="server" ValidationGroup="NewContactGroup"
                                        MaxLength="20" Width="300px"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="CCRegularExpressionValidator1" runat="server"
                                        ControlToValidate="HomePhoneNoTextBox" ErrorMessage="Invalid UK phone number"
                                        Text="Format Error" Display="Dynamic" ValidationExpression="^(\(?\+?[0-9]*\)?)?[0-9_\- \(\)]*$"></asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Mobile No.
                                </td>
                                <td colspan="3">
                                    <asp:TextBox ID="MobileNoTextBox" runat="server" ValidationGroup="NewContactGroup"
                                        MaxLength="20" Width="300px"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="MobileNoTextBox"
                                        ErrorMessage="Invalid UK phone number" Text="Format Error" Display="Dynamic"
                                        ValidationExpression="^(\(?\+?[0-9]*\)?)?[0-9_\- \(\)]*$"></asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    EMail Address
                                </td>
                                <td colspan="3">
                                    <asp:TextBox ID="EMailAddressTextBox" runat="server" ValidationGroup="NewContactGroup"
                                        MaxLength="20" Width="300px"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="EMailAddressTextBox"
                                        ErrorMessage="Invalid UK phone number" Text="Format Error" Display="Dynamic"
                                        ValidationExpression=".+@[^\.].*\.[a-z]{2,}"></asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td style="vertical-align: top;">
                                    Notes
                                </td>
                                <td colspan="3">
                                    <asp:TextBox ID="TextBox1" runat="server" ValidationGroup="NewContactGroup" TextMode="MultiLine"
                                        MaxLength="20" Height="150px" Width="70%"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <table class="progressupdate">
                                        <tr>
                                            <td style="width: 5%;">
                                                <asp:Button ID="AddContactButton" Text="Add Contact" ValidationGroup="NewContactGroup"
                                                    runat="server" OnClick="AddContactButton_Click" />
                                            </td>
                                            <td style="width: 95%;">
                                                &nbsp;
                                                <asp:Button ID="CancelAddContactButton" Text="Cancel" runat="server" OnClick="CancelAddContactButton_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td colspan="2">
                                    <div class="progressupdate">
                                        <asp:UpdateProgress ID="UpdateProgress4" runat="server" AssociatedUpdatePanelID="AddContactDetailUpdatePanel"
                                            DisplayAfter="1">
                                            <ProgressTemplate>
                                                <asp:Image ID="AddContactProgressImg" runat="server" ImageUrl="~/images/progress3.gif">
                                                </asp:Image>
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
    <asp:UpdatePanel ID="ModifyExistingCustomersUpdatePanel" runat="server" UpdateMode="Conditional">
        <Triggers>
            <asp:PostBackTrigger ControlID="AddContactButton" />
            <asp:PostBackTrigger ControlID="CustomerListGridView" />
            <asp:PostBackTrigger ControlID="AddContactButton" />
            <asp:PostBackTrigger ControlID="CancelAddContactButton" />
        </Triggers>
        <ContentTemplate>
            <asp:Panel ID="ContactDataListPanel" Visible="false" runat="server">
                <div class="FormInput">
                    <fieldset id="Fieldset10">
                        <legend>
                            <h3>
                                Select Contact</h3>
                        </legend>
                        <div class="DataList">
                            <asp:DataList ID="ContactDetailDataList" runat="server" OnItemCommand="ContactDetailDataList_ItemCommand"
                                OnItemDataBound="ContactDetailDataList_ItemDataBound" DataSourceID="ContactDetailObjectDataSource">
                                <HeaderTemplate>
                                    <table class="datalist" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <th style="width: 2%">
                                            </th>
                                            <th style="width: 38%">
                                                Name
                                            </th>
                                            <th style="width: 50%">
                                                Job Role
                                            </th>
                                            <th style="width: 10%">
                                            </th>
                                        </tr>
                                    </table>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <table class="datalist" cellpadding="0" cellspacing="0">
                                        <tr class="row-a">
                                            <td width="2%">
                                                <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/images/btn_expand.gif"
                                                    CommandName="Select" AlternateText="Click to view orders"></asp:ImageButton>
                                            </td>
                                            <td style="width: 38%">
                                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("FirstName") %>'></asp:Label>
                                                &nbsp;
                                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("LastName") %>'></asp:Label>
                                            </td>
                                            <td style="width: 50%">
                                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("JobRole") %>'></asp:Label>
                                            </td>
                                            <td style="width: 10%">
                                                <asp:Button ID="SelectButton" runat="server" CommandName="Delete" CommandArgument='<%# Bind("ID") %>'
                                                    Text="Delete" />
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                                <AlternatingItemTemplate>
                                    <table class="datalist" cellpadding="0" cellspacing="0">
                                        <tr class="row-b">
                                            <td width="2%">
                                                <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/images/btn_expand.gif"
                                                    CommandName="Select" AlternateText="Click to view orders"></asp:ImageButton>
                                            </td>
                                            <td style="width: 38%">
                                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("FirstName") %>'></asp:Label>
                                                &nbsp;
                                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("LastName") %>'></asp:Label>
                                            </td>
                                            <td style="width: 50%">
                                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("JobRole") %>'></asp:Label>
                                            </td>
                                            <td style="width: 10%">
                                                <asp:Button ID="SelectButton" runat="server" CommandName="Delete" CommandArgument='<%# Bind("ID") %>'
                                                    Text="Delete" />
                                            </td>
                                        </tr>
                                    </table>
                                </AlternatingItemTemplate>
                                <SelectedItemTemplate>
                                    <asp:Panel ID="SelectedPanel" runat="server">
                                        <legend>
                                            <h3>
                                                Modify Existing Contact Details</h3>
                                        </legend>
                                        <fieldset id="Fieldset2">
                                            <asp:Label ID="IDLabel" runat="server" Visible="false" MaxLength="40" Width="350px"></asp:Label>
                                            <table class="datalist" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td colspan="4">
                                                        <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/images/btn_minimise.gif"
                                                            CommandName="UnSelect" AlternateText="Click to view orders"></asp:ImageButton>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Job Role
                                                    </td>
                                                    <td colspan="3">
                                                        <asp:TextBox ID="JobRoleTextBox" runat="server" ValidationGroup="NewContactGroup"
                                                            MaxLength="35" Width="300px"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="CCDDRequiredFieldValidator4" ValidationGroup="NewContactGroup"
                                                            ControlToValidate="JobRoleTextBox" ErrorMessage="Job Role is a required field"
                                                            InitialValue="" Text="*" runat="server" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Title
                                                    </td>
                                                    <td colspan="3">
                                                        <asp:TextBox ID="TitleTextBox" runat="server" ValidationGroup="NewContactGroup" MaxLength="35"
                                                            Width="300px"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="CCDDRequiredFieldValidator1" ValidationGroup="NewContactGroup"
                                                            ControlToValidate="TitleTextBox" ErrorMessage="Address Line is a required field"
                                                            InitialValue="" Text="*" runat="server" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        First Name
                                                    </td>
                                                    <td colspan="3">
                                                        <asp:TextBox ID="FirstNameTextBox" runat="server" ValidationGroup="NewContactGroup"
                                                            MaxLength="35" Width="300px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Last Name
                                                    </td>
                                                    <td colspan="3">
                                                        <asp:TextBox ID="LastNameTextBox" runat="server" ValidationGroup="NewContactGroup"
                                                            MaxLength="35" Width="300px"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="CCDDRequiredFieldValidator8" ValidationGroup="NewContactGroup"
                                                            ControlToValidate="LastNameTextBox" ErrorMessage="Last Name is a required field"
                                                            InitialValue="" Text="*" runat="server" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Day Time Telephone No
                                                    </td>
                                                    <td colspan="3">
                                                        <asp:TextBox ID="DayTimeTelephoneNoTextBox" runat="server" ValidationGroup="NewContactGroup"
                                                            MaxLength="20" Width="300px"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="CCDDRequiredFieldValidator9" ValidationGroup="NewContactGroup"
                                                            ControlToValidate="DayTimeTelephoneNoTextBox" ErrorMessage="Day Time Telephone No is a required field"
                                                            InitialValue="" Text="*" runat="server" />
                                                        <asp:RegularExpressionValidator ID="CCRegularExpressionValidator" runat="server"
                                                            ControlToValidate="DayTimeTelephoneNoTextBox" ErrorMessage="Invalid UK phone number"
                                                            Text="Format Error" Display="Dynamic" ValidationExpression="^(\(?\+?[0-9]*\)?)?[0-9_\- \(\)]*$" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Home Telephone No
                                                    </td>
                                                    <td colspan="3">
                                                        <asp:TextBox ID="HomeTelephoneNoTextBox" runat="server" ValidationGroup="NewContactGroup"
                                                            MaxLength="20" Width="300px"></asp:TextBox>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="HomeTelephoneNoTextBox"
                                                            ErrorMessage="Invalid UK phone number" Text="Format Error" Display="Dynamic"
                                                            ValidationExpression="^(\(?\+?[0-9]*\)?)?[0-9_\- \(\)]*$" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Mobile Telephone No
                                                    </td>
                                                    <td colspan="3">
                                                        <asp:TextBox ID="MobileTelephoneTextBox" runat="server" ValidationGroup="NewContactGroup"
                                                            MaxLength="20" Width="300px"></asp:TextBox>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="MobileTelephoneTextBox"
                                                            ErrorMessage="Invalid UK phone number" Text="Format Error" Display="Dynamic"
                                                            ValidationExpression="^(\(?\+?[0-9]*\)?)?[0-9_\- \(\)]*$">
                                                        </asp:RegularExpressionValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        EMail Address
                                                    </td>
                                                    <td colspan="3">
                                                        <asp:TextBox ID="EMailAddressTextBox" runat="server" ValidationGroup="NewContactGroup"
                                                            MaxLength="20" Width="300px"></asp:TextBox>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="EMailAddressTextBox"
                                                            ErrorMessage="Invalid UK phone number" Text="Format Error" Display="Dynamic"
                                                            ValidationExpression=".+@[^\.].*\.[a-z]{2,}"></asp:RegularExpressionValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="vertical-align: top; width: 15%;">
                                                        Notes
                                                    </td>
                                                    <td style="vertical-align: top; width: 35%;" colspan="3">
                                                        <asp:TextBox ID="NotesTextBox" runat="server" ValidationGroup="NewContactGroup" TextMode="MultiLine"
                                                            MaxLength="20" Height="150px" Width="60%"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        <table class="progressupdate">
                                                            <tr>
                                                                <td>
                                                                    <asp:Button ID="AddContactButton" Text="Modify Contact" CommandName="Update" CommandArgument='<%# Bind("ID") %>'
                                                                        ValidationGroup="NewContactGroup" runat="server" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </fieldset>
                                    </asp:Panel>
                                </SelectedItemTemplate>
                            </asp:DataList>
                        </div>
                        <table>
                            <tr>
                                <td>
                                    <asp:ObjectDataSource ID="ContactDetailObjectDataSource" runat="server" TypeName="CustomerUI"
                                        SelectMethod="GetContactDetailsByCustomerID" OnSelecting="ContactDetailObjectDataSource_Selecting">
                                        <SelectParameters>
                                            <asp:QueryStringParameter Name="id" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                                </td>
                                <td id="Td2">
                                    <asp:Button ID="CustomerContactUpdateButton" Text="Save" runat="server" OnClick="CustomerContactUpdateButton_Click" />
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                </div>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
