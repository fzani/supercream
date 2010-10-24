<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MaintainOfferItems.ascx.cs"
    Inherits="Controls_MaintainOfferItems" %>
<div class="FormInput" style="width: 95%">
    <fieldset id="Fieldset3">
        <legend><span>
            <h3>
                Maintain Offer Items
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
        <asp:ListView ID="ListView1" runat="server" DataKeyNames="ID" Style="width: 100%"
            DataSourceID="OfferItemDataSource" GroupItemCount="2" InsertItemPosition="FirstItem"
            OnItemUpdating="ListView1_ItemUpdating" OnItemDataBound="ListView1_ItemDataBound"
            OnItemInserting="ListView1_ItemInserting" 
            onitemdeleted="ListView1_ItemDeleted" oniteminserted="ListView1_ItemInserted">
            <EmptyItemTemplate>
                <td runat="server" />
            </EmptyItemTemplate>
            <ItemTemplate>
                <td id="Td2" runat="server" style="width: 50%">
                    <table id="BundledItem">
                        <tr>
                            <td style="width: 20%">
                                <h3>
                                    Product
                                </h3>
                            </td>
                            <td style="width: 80%">
                                <asp:Label ID="IDLabel" Visible="false" runat="server" Text='<%# Eval("ID") %>' />
                                <asp:Label ID="VatCodeIdLabel" Visible="false" runat="server" Text='<%# Bind("VatCodeId") %>' />
                                <asp:Label ID="ProductDescriptionLabel" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:CheckBox ID="VatExemptCheckBox" runat="server" Checked='<%# Eval("VatExempt") %>'
                                    Enabled="false" Text="VatExempt" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                NoOfUnits
                            </td>
                            <td>
                                <asp:Label ID="NoOfUnitsLabel" runat="server" Text='<%# Eval("NoOfUnits") %>' />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                UnitPrice
                            </td>
                            <td>
                                <asp:Label ID="UnitPriceLabel" runat="server" Text='<%# Eval("UnitPrice","{0:c}") %>' />
                            </td>
                        </tr>
                    </table>
                    <asp:Button ID="DeleteButton" Width="48%" runat="server" CommandName="Delete" Text="Delete" />
                    <asp:Button ID="EditButton" Width="48%" runat="server" CommandName="Edit" Text="Edit" />
                </td>
            </ItemTemplate>
            <AlternatingItemTemplate>
                <td id="Td2" runat="server" style="width: 50%">
                    <table id="AlternateBundledItem">
                        <tr>
                            <td style="width: 20%">
                                <h3>
                                    Product
                                </h3>
                            </td>
                            <td style="width: 80%">
                                <asp:Label ID="IDLabel" Visible="false" runat="server" Text='<%# Eval("ID") %>' />
                                <asp:Label ID="VatCodeIdLabel" Visible="false" runat="server" Text='<%# Bind("VatCodeId") %>' />
                                <asp:Label ID="ProductDescriptionLabel" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:CheckBox ID="VatExemptCheckBox" runat="server" Checked='<%# Eval("VatExempt") %>'
                                    Enabled="false" Text="VatExempt" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                NoOfUnits
                            </td>
                            <td>
                                <asp:Label ID="NoOfUnitsLabel" runat="server" Text='<%# Eval("NoOfUnits") %>' />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                UnitPrice
                            </td>
                            <td>
                                <asp:Label ID="UnitPriceLabel" runat="server" Text='<%# Eval("UnitPrice","{0:c}") %>' />
                            </td>
                        </tr>
                    </table>
                    <asp:Button ID="DeleteButton" Width="48%" runat="server" CommandName="Delete" Text="Delete" />
                    <asp:Button ID="EditButton" Width="48%" runat="server" CommandName="Edit" Text="Edit" />
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
                <td id="Td2" runat="server" style="width: 50%">
                    <table class="BundledOrder">
                        <tr>
                            <td colspan="2">
                                <h3>
                                    Insert</h3>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 20%">
                                Product
                            </td>
                            <td style="width: 80%">
                                <asp:DropDownList ID="ProductDropDownList" DataTextField="Description" DataValueField="ID"
                                    DataSourceID="ProductsObjectDataSource" runat="server" />
                                <asp:ObjectDataSource ID="ProductsObjectDataSource" runat="server" SelectMethod="GetAllProducts"
                                    TypeName="ProductUI"></asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                NoOfUnits
                            </td>
                            <td>
                                <asp:TextBox ID="NoOfUnitsTextBox" MaxLength="4" Width="40" runat="server" Text='<%# Bind("NoOfUnits") %>' />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ValidationGroup="InsertQualificationOffer"
                                    ControlToValidate="NoOfUnitsTextBox" ErrorMessage="Quantity must be entered"
                                    InitialValue="" Text="*" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                    <asp:Button ID="InsertButton" Width="48%" runat="server" ValidationGroup="InsertQualificationOffer"
                        CommandName="Insert" Text="Insert" />
                    <asp:Button ID="CancelButton" Width="48%" runat="server" CommandName="Cancel" Text="Clear" />
                </td>
            </InsertItemTemplate>
            <LayoutTemplate>
                <table style="width: 95%" runat="server">
                    <tr runat="server">
                        <td runat="server">
                            <table id="groupPlaceholderContainer" style="width: 100%" runat="server" border="0">
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
                <td id="Td2" runat="server" style="width: 48%">
                    <table id="EditingBundledItem">
                        <tr>
                            <td style="width: 20%">
                                <asp:Label ID="IDLabel" Visible="false" runat="server" Text='<%# Bind("ID") %>' />
                                <h3>
                                    Product
                                </h3>
                            </td>
                            <td style="width: 80%">
                                <asp:DropDownList ID="ProductDropDownList" Enabled="false" Width="95%" DataTextField="Description"
                                    DataValueField="ID" DataSourceID="ProductsObjectDataSource" SelectedValue='<%#Bind("ProductId") %>'
                                    runat="server" />
                                <asp:ObjectDataSource ID="ProductsObjectDataSource" runat="server" SelectMethod="GetAllProducts"
                                    TypeName="ProductUI"></asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                NoOfUnits
                            </td>
                            <td>
                                <asp:TextBox ID="NoOfUnitsTextBox" runat="server" Width="40" MaxLength="4" Text='<%# Bind("NoOfUnits") %>' />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ValidationGroup="EditQualificationOffer"
                                    ControlToValidate="NoOfUnitsTextBox" ErrorMessage="Quantity must be entered"
                                    InitialValue="" Text="*" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                    <asp:Button ID="UpdateButton" Width="48%" ValidationGroup="EditQualificationOffer"
                        runat="server" CommandName="Update" Text="Update" />
                    <asp:Button ID="CancelButton" Width="48%" runat="server" CommandName="Cancel" Text="Cancel" />
                </td>
            </EditItemTemplate>
            <GroupTemplate>
                <tr id="itemPlaceholderContainer" runat="server">
                    <td id="itemPlaceholder" runat="server">
                    </td>
                </tr>
            </GroupTemplate>
        </asp:ListView>
        <asp:ObjectDataSource ID="OfferItemDataSource" runat="server" DataObjectTypeName="WcfFoundationService.OfferItem"
            DeleteMethod="Delete" InsertMethod="Save" SelectMethod="FindAllByOfferId" TypeName="OfferItemUI"
            UpdateMethod="UpdateOfferItem">
            <SelectParameters>
                <asp:ControlParameter ControlID="OfferBundleDropDownList" Name="id" PropertyName="SelectedValue"
                    Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </fieldset>
</div>
