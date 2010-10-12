<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MaintainOfferItems.ascx.cs"
    Inherits="Controls_MaintainOfferItems" %>
<div class="FormInput" style="width: 95%">
    <fieldset id="Fieldset3">
        <legend><span>
            <h3>
                Modify Offer Items
            </h3>
        </span></legend>
    </fieldset>
    <fieldset>
        <div style="text-align: right">
            <asp:DropDownList ID="OfferBundleDropDownList" runat="server" AutoPostBack="true"
                DataSourceID="ObjectDataSource1" DataTextField="Name" DataValueField="ID" Width="40%">
            </asp:DropDownList>
        </div>
    </fieldset>
    <fieldset>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetAllOffers"
            TypeName="OfferUI"></asp:ObjectDataSource>
        <asp:ListView ID="ListView1" runat="server" DataKeyNames="ID" DataSourceID="OfferItemDataSource"
            GroupItemCount="2" InsertItemPosition="FirstItem" OnItemDataBound="ListView1_ItemDataBound">
            <EmptyItemTemplate>
                <td runat="server" />
            </EmptyItemTemplate>
            <ItemTemplate>
                <td id="Td1" runat="server" style="">
                    <asp:Label ID="IDLabel" Visible="false" runat="server" Text='<%# Eval("ID") %>' />
                    Product:
                    <asp:Label ID="ProductDescriptionLabel" runat="server" />
                    <br />
                    Discount:
                    <asp:Label ID="DiscountLabel" runat="server" Text='<%# Eval("Discount") %>' />
                    <br />
                    <asp:CheckBox ID="VatExemptCheckBox" runat="server" Checked='<%# Eval("VatExempt") %>'
                        Enabled="false" Text="VatExempt" />
                    <br />
                    NoOfUnits:
                    <asp:Label ID="NoOfUnitsLabel" runat="server" Text='<%# Eval("NoOfUnits") %>' />
                    <br />
                    UnitPrice:
                    <asp:Label ID="UnitPriceLabel" runat="server" Text='<%# Eval("UnitPrice") %>' />
                    <br />
                    <asp:Button ID="DeleteButton" Width="50" runat="server" CommandName="Delete" Text="Delete" />
                    <asp:Button ID="EditButton" Width="50" runat="server" CommandName="Edit" Text="Edit" />
                    <br />
                </td>
            </ItemTemplate>
            <AlternatingItemTemplate>
                <td id="Td1" runat="server" style="">
                    <asp:Label ID="IDLabel" Visible="false" runat="server" Text='<%# Eval("ID") %>' />
                    Product:
                    <asp:Label ID="ProductDescriptionLabel" runat="server" />
                    <br />
                    Discount:
                    <asp:Label ID="DiscountLabel" runat="server" Text='<%# Eval("Discount") %>' />
                    <br />
                    <asp:CheckBox ID="VatExemptCheckBox" runat="server" Checked='<%# Eval("VatExempt") %>'
                        Enabled="false" Text="VatExempt" />
                    <br />
                    NoOfUnits:
                    <asp:Label ID="NoOfUnitsLabel" runat="server" Text='<%# Eval("NoOfUnits") %>' />
                    <br />
                    UnitPrice:
                    <asp:Label ID="UnitPriceLabel" runat="server" Text='<%# Eval("UnitPrice") %>' />
                    <br />
                    <asp:Button ID="DeleteButton" Width="50" runat="server" CommandName="Delete" Text="Delete" />
                    <asp:Button ID="EditButton" Width="50" runat="server" CommandName="Edit" Text="Edit" />
                    <br />
                </td>
            </AlternatingItemTemplate>
            <EmptyDataTemplate>
                <table runat="server" style="">
                    <tr>
                        <td>
                            No data was returned.
                        </td>
                    </tr>
                </table>
            </EmptyDataTemplate>
            <InsertItemTemplate>
                <td runat="server" style="">
                    ExtensionData:
                    <asp:TextBox ID="ExtensionDataTextBox" runat="server" Text='<%# Bind("ExtensionData") %>' />
                    <br />
                    Discount:
                    <asp:TextBox ID="DiscountTextBox" runat="server" Text='<%# Bind("Discount") %>' />
                    <br />
                    ID:
                    <asp:TextBox ID="IDTextBox" runat="server" Text='<%# Bind("ID") %>' />
                    <br />
                    NoOfUnits:
                    <asp:TextBox ID="NoOfUnitsTextBox" runat="server" Text='<%# Bind("NoOfUnits") %>' />
                    <br />
                    OfferId:
                    <asp:TextBox ID="OfferIdTextBox" runat="server" Text='<%# Bind("OfferId") %>' />
                    <br />
                    ProductId:
                    <asp:TextBox ID="ProductIdTextBox" runat="server" Text='<%# Bind("ProductId") %>' />
                    <br />
                    UnitPrice:
                    <asp:TextBox ID="UnitPriceTextBox" runat="server" Text='<%# Bind("UnitPrice") %>' />
                    <br />
                    VatCodeId:
                    <asp:TextBox ID="VatCodeIdTextBox" runat="server" Text='<%# Bind("VatCodeId") %>' />
                    <br />
                    <asp:CheckBox ID="VatExemptCheckBox" runat="server" Checked='<%# Bind("VatExempt") %>'
                        Text="VatExempt" />
                    <br />
                    <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="Insert" />
                    <br />
                    <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Clear" />
                    <br />
                </td>
            </InsertItemTemplate>
            <LayoutTemplate>
                <table runat="server">
                    <tr runat="server">
                        <td runat="server">
                            <table id="groupPlaceholderContainer" runat="server" border="0" style="">
                                <tr id="groupPlaceholder" runat="server">
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr runat="server">
                        <td runat="server" style="">
                            <asp:DataPager ID="DataPager1" runat="server" PageSize="12">
                                <Fields>
                                    <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowNextPageButton="False"
                                        ShowPreviousPageButton="False" />
                                    <asp:NumericPagerField />
                                    <asp:NextPreviousPagerField ButtonType="Button" ShowLastPageButton="True" ShowNextPageButton="False"
                                        ShowPreviousPageButton="False" />
                                </Fields>
                            </asp:DataPager>
                        </td>
                    </tr>
                </table>
            </LayoutTemplate>
            <EditItemTemplate>
                <td runat="server" style="">
                    ExtensionData:
                    <asp:TextBox ID="ExtensionDataTextBox" runat="server" Text='<%# Bind("ExtensionData") %>' />
                    <br />
                    Discount:
                    <asp:TextBox ID="DiscountTextBox" runat="server" Text='<%# Bind("Discount") %>' />
                    <br />
                    ID:
                    <asp:TextBox ID="IDTextBox" runat="server" Text='<%# Bind("ID") %>' />
                    <br />
                    NoOfUnits:
                    <asp:TextBox ID="NoOfUnitsTextBox" runat="server" Text='<%# Bind("NoOfUnits") %>' />
                    <br />
                    OfferId:
                    <asp:TextBox ID="OfferIdTextBox" runat="server" Text='<%# Bind("OfferId") %>' />
                    <br />
                    ProductId:
                    <asp:TextBox ID="ProductIdTextBox" runat="server" Text='<%# Bind("ProductId") %>' />
                    <br />
                    UnitPrice:
                    <asp:TextBox ID="UnitPriceTextBox" runat="server" Text='<%# Bind("UnitPrice") %>' />
                    <br />
                    VatCodeId:
                    <asp:TextBox ID="VatCodeIdTextBox" runat="server" Text='<%# Bind("VatCodeId") %>' />
                    <br />
                    <asp:CheckBox ID="VatExemptCheckBox" runat="server" Checked='<%# Bind("VatExempt") %>'
                        Text="VatExempt" />
                    <br />
                    <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Update" />
                    <br />
                    <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancel" />
                    <br />
                </td>
            </EditItemTemplate>
            <GroupTemplate>
                <tr id="itemPlaceholderContainer" runat="server">
                    <td id="itemPlaceholder" runat="server">
                    </td>
                </tr>
            </GroupTemplate>
            <SelectedItemTemplate>
                <td runat="server" style="">
                    ExtensionData:
                    <asp:Label ID="ExtensionDataLabel" runat="server" Text='<%# Eval("ExtensionData") %>' />
                    <br />
                    Discount:
                    <asp:Label ID="DiscountLabel" runat="server" Text='<%# Eval("Discount") %>' />
                    <br />
                    ID:
                    <asp:Label ID="IDLabel" runat="server" Text='<%# Eval("ID") %>' />
                    <br />
                    NoOfUnits:
                    <asp:Label ID="NoOfUnitsLabel" runat="server" Text='<%# Eval("NoOfUnits") %>' />
                    <br />
                    OfferId:
                    <asp:Label ID="OfferIdLabel" runat="server" Text='<%# Eval("OfferId") %>' />
                    <br />
                    ProductId:
                    <asp:Label ID="ProductIdLabel" runat="server" Text='<%# Eval("ProductId") %>' />
                    <br />
                    UnitPrice:
                    <asp:Label ID="UnitPriceLabel" runat="server" Text='<%# Eval("UnitPrice") %>' />
                    <br />
                    VatCodeId:
                    <asp:Label ID="VatCodeIdLabel" runat="server" Text='<%# Eval("VatCodeId") %>' />
                    <br />
                    <asp:CheckBox ID="VatExemptCheckBox" runat="server" Checked='<%# Eval("VatExempt") %>'
                        Enabled="false" Text="VatExempt" />
                    <br />
                    <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="Delete" />
                    <br />
                    <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
                    <br />
                </td>
            </SelectedItemTemplate>
        </asp:ListView>
        <asp:ObjectDataSource ID="OfferItemDataSource" runat="server" DataObjectTypeName="WcfFoundationService.OfferItem"
            DeleteMethod="Delete" InsertMethod="Save" SelectMethod="FindAll" TypeName="OfferItemUI"
            UpdateMethod="UpdateOfferItem"></asp:ObjectDataSource>
    </fieldset>
</div>
