<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" StylesheetTheme="SuperCream"
    AutoEventWireup="true" CodeFile="ModifyCustomer.aspx.cs" Inherits="Modify_Customer" %>

<%@ Register Src="../Controls/ErrorView.ascx" TagName="ErrorView" TagPrefix="Alterax" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="ErrorUpdatePanel" runat="server" UpdateMode="Conditional">
        <Triggers>
            <asp:PostBackTrigger ControlID="ModifyShopButtton" />
            <asp:PostBackTrigger ControlID="AddModifiedShopButton" />
            <asp:PostBackTrigger ControlID="CancelModifiedShopButton" />
            <asp:PostBackTrigger ControlID="ModifyCustomerSaveButton" />
        </Triggers>
        <ContentTemplate>
            <div class="ErrorOutput">
                <Alterax:ErrorView ID="ErrorViewControl" Visible="false" runat="server" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="ModifyHeaderCustomerUpdatePanel" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <triggers>
            <asp:PostBackTrigger ControlID="AddModifiedShopButton" />
            <asp:PostBackTrigger ControlID="CancelModifiedShopButton" />
            <asp:PostBackTrigger ControlID="ModifyCustomerSaveButton" />
        </triggers>
            <div class="FormInput">
                <asp:Panel ID="ModifyHeaderCustomerPanel" runat="server">
                    <fieldset id="VarInputLegend">
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
                                        InitialValue="" Text="Required" runat="server" />
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
                                                            <asp:Button ID="ModifyShopButtton" Text="Add Shop" runat="server" OnClick="ModifyShopButton_Click" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td>
                                                <div class="progressupdate">
                                                    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="ModifyHeaderCustomerUpdatePanel"
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
    <asp:UpdatePanel ID="ModifyNewShopUpdatePanel" runat="server" UpdateMode="Conditional">
        <Triggers>
            <asp:PostBackTrigger ControlID="ModifyShopButtton" />
        </Triggers>
        <ContentTemplate>
            <asp:Panel ID="AddModifiedShopPanel" DefaultButton="AddModifiedShopButton" Visible="false"
                runat="server">
                <div class="FormInput">
                    <fieldset id="Fieldset2">
                        <legend>
                            <h3>
                                Enter New Shop</h3>
                        </legend>
                        <table>
                            <tr>
                                <td style="width: 5%">
                                </td>
                                <td style="width: 45%">
                                </td>
                                <td style="width: 5%">
                                </td>
                                <td style="width: 45%">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Name
                                </td>
                                <td colspan="2">
                                    <asp:TextBox ID="ModifiedShopNameTextBox" runat="server" ValidationGroup="NewOutletGroup"
                                        MaxLength="40" Width="350px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="ModifiedRequiredFieldValidator4" ValidationGroup="NewOutletGroup"
                                        ControlToValidate="ModifiedShopNameTextBox" ErrorMessage="Name is a required Text Box"
                                        InitialValue="" Text="Required" runat="server" />
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Address
                                </td>
                                <td colspan="2">
                                    <asp:TextBox ID="ModifiedAddressLine1TextBox" runat="server" ValidationGroup="NewOutletGroup"
                                        MaxLength="40" Width="350px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="ModifiedRequiredFieldValidator1" ValidationGroup="NewOutletGroup"
                                        ControlToValidate="ModifiedAddressLine1TextBox" ErrorMessage="Address Line is a required Text Box"
                                        InitialValue="" Text="Required" runat="server" />
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td colspan="2">
                                    <asp:TextBox ID="ModifiedAddressLine2TextBox" runat="server" ValidationGroup="NewOutletGroup"
                                        MaxLength="40" Width="350px"></asp:TextBox>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Town/City
                                </td>
                                <td colspan="2">
                                    <asp:TextBox ID="ModifiedTownTextBox" runat="server" ValidationGroup="NewOutletGroup"
                                        MaxLength="40" Width="350px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="ModifiedRequiredFieldValidator8" ValidationGroup="NewOutletGroup"
                                        ControlToValidate="ModifiedTownTextBox" ErrorMessage="City/Town is a required Text Box"
                                        InitialValue="" Text="Required" runat="server" />
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    County
                                </td>
                                <td colspan="2">
                                    <asp:TextBox ID="ModifiedCountyTextBox" runat="server" ValidationGroup="NewOutletGroup"
                                        MaxLength="40" Width="350px"></asp:TextBox>
                                    <asp:TextBox ID="ModifiedRequiredFieldValidator9" ValidationGroup="NewOutletGroup"
                                        ControlToValidate="ModifiedCountyTextBox" ErrorMessage="County is a required Text Box"
                                        InitialValue="" Text="Required" runat="server" />
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Post Code
                                </td>
                                <td colspan="2">
                                    <asp:TextBox ID="ModifiedPostCodeTextBox" runat="server" ValidationGroup="NewOutletGroup"
                                        MaxLength="8" Width="350px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="ModifiedRequiredFieldValidator10" ValidationGroup="NewOutletGroup"
                                        ControlToValidate="ModifiedPostCodeTextBox" ErrorMessage="Post Code is a required Text Box"
                                        InitialValue="" Text="Required" runat="server" />
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td style="vertical-align: top;">
                                    Opening Hours
                                </td>
                                <td>
                                    <asp:TextBox ID="ModifiedOpeningHoursTextBox" runat="server" ValidationGroup="NewOutletGroup"
                                        TextMode="MultiLine" MaxLength="20" Height="150px" Width="220px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="ModifiedRequiredFieldValidator5" ValidationGroup="NewOutletGroup"
                                        ControlToValidate="ModifiedOpeningHoursTextBox" ErrorMessage="Opening Hours a required Text Box"
                                        InitialValue="" Text="Required" runat="server" />
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
                                <td colspan="1">
                                    <table class="progressupdate">
                                        <tr>
                                            <td>
                                                <asp:Button ID="AddModifiedShopButton" Text="Add Shop" ValidationGroup="NewOutletGroup"
                                                    runat="server" OnClick="AddModifiedShopButton_Click" />
                                            </td>
                                            <td>
                                                &nbsp;
                                                <asp:Button ID="CancelModifiedShopButton" CausesValidation="false" Text="Cancel"
                                                    runat="server" OnClick="CancelModifiedShopButton_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td colspan="3">
                                    <div class="progressupdate">
                                        <asp:UpdateProgress ID="UpdateProgress99" runat="server" AssociatedUpdatePanelID="ModifyNewShopUpdatePanel"
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
    <asp:UpdatePanel ID="ModifyExistingCustomersUpdatePanel" runat="server" UpdateMode="Conditional">
        <Triggers>
            <asp:PostBackTrigger ControlID="AddModifiedShopButton" />
        </Triggers>
        <ContentTemplate>
            <asp:Panel ID="OutletStoreDataListPanel" runat="server">
                <div class="FormInput">
                    <fieldset id="Fieldset4">
                        <legend>
                            <h3>
                                Select Shop</h3>
                        </legend>
                        <div class="DataList">
                            <asp:DataList ID="OutletStoreDataList" runat="server" OnRowCommand="OutletStoreGridView_RowCommand"
                                OnRowDeleting="OutletStoreGridView_RowDeleting" OnItemCommand="OutletStoreDataList_ItemCommand"
                                DataSourceID="ShopDataListObjectDataSource" OnItemDataBound="OutletStoreDataList_ItemDataBound">
                                <HeaderTemplate>
                                    <table class="datalist" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <th style="width: 2%">
                                            </th>
                                            <th style="width: 38%">
                                                Name
                                            </th>
                                            <th style="width: 50%">
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
                                            <td width="2%">
                                                <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/images/btn_expand.gif"
                                                    CommandName="Select" AlternateText="Click to view Shop"></asp:ImageButton>
                                            </td>
                                            <td style="width: 38%">
                                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                                            </td>
                                            <td style="width: 50%">
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
                                            <td width="2%">
                                                <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/images/btn_expand.gif"
                                                    CommandName="Select" AlternateText="Click to view orders"></asp:ImageButton>
                                            </td>
                                            <td style="width: 38%">
                                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                                            </td>
                                            <td style="width: 50%">
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
                                                        Name
                                                    </td>
                                                    <td colspan="3">
                                                        <asp:TextBox ID="ShopNameTextBox" runat="server" ValidationGroup="NewOutletGroup"
                                                            MaxLength="40" Width="350px"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ValidationGroup="NewOutletGroup"
                                                            ControlToValidate="ShopNameTextBox" ErrorMessage="Name is a required Text Box"
                                                            InitialValue="" Text="Required" runat="server" />
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
                                                            InitialValue="" Text="Required" runat="server" />
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
                                                            InitialValue="" Text="Required" runat="server" />
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
                                                            InitialValue="" Text="Required" runat="server" />
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
                                                            InitialValue="" Text="Required" runat="server" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="vertical-align: top; width: 15%">
                                                        Opening Hours
                                                    </td>
                                                    <td style="vertical-align: top; width: 35%;">
                                                        <asp:TextBox ID="OpeningHoursTextBox" runat="server" ValidationGroup="NewOutletGroup"
                                                            TextMode="MultiLine" MaxLength="20" Height="150px" Width="240px"></asp:TextBox>
                                                    </td>
                                                    <td style="vertical-align: top; width: 15%;">
                                                        Notes
                                                    </td>
                                                    <td style="vertical-align: top; width: 35%;">
                                                        <asp:TextBox ID="NotesTextBox" runat="server" ValidationGroup="NewOutletGroup" TextMode="MultiLine"
                                                            MaxLength="20" Height="150px" Width="240px"></asp:TextBox>
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
                                        TypeName="CustomerUI">
                                        <SelectParameters>
                                            <asp:QueryStringParameter Name="id" QueryStringField="ID" Type="Int32" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                                </td>
                                <td id="CustomerUpdateTD">
                                    <asp:Button ID="ModifyCustomerSaveButton" Text="Save" runat="server" OnClick="CustomerSaveButton_Click" />
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                </div>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
