﻿<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MaintainOfferQualiicationItems.ascx.cs"
    Inherits="Controls_MaintainOfferQualiicationItems" %>
<div class="FormInput" style="width: 95%">
    <fieldset id="Fieldset3">
        <legend><span>
            <h3>
                Maintain Offer Qualification Items
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
        <asp:ListView ID="ListView1" DataKeyNames="ID" runat="server" DataSourceID="ObjectDataSource2"
            Style="width: 100%" GroupItemCount="2" OnItemDataBound="ListView1_ItemDataBound"
            InsertItemPosition="FirstItem" OnItemInserting="ListView1_ItemInserting" OnItemUpdating="ListView1_ItemUpdating"
            OnItemDeleting="ListView1_ItemDeleting" 
            onitemdeleted="ListView1_ItemDeleted" oniteminserted="ListView1_ItemInserted">
            <EmptyItemTemplate>
                <td runat="server" />
            </EmptyItemTemplate>
            <ItemTemplate>
                <td runat="server" style="width: 50%">
                    <table id="BundledItem">
                        <tr>
                            <td style="width: 20%">
                                <asp:Label ID="IDLabel" Visible="false" runat="server" Text='<%# Bind("ID") %>' />
                                <asp:Label ID="OfferIdLabel" Visible="false" runat="server" Text='<%# Bind("OfferId") %>' />
                                Product
                            </td>
                            <td style="width: 80%">
                                <asp:Label ID="ProductDescriptionLabel" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Quantity
                            </td>
                            <td>
                                <asp:Label ID="QtyLabel" runat="server" Text='<%# Bind("Qty") %>' />
                            </td>
                        </tr>
                    </table>
                    <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
                    <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" CommandArgument='<%# Bind("ID") %>'
                        Text="Delete" />
                </td>
            </ItemTemplate>
            <AlternatingItemTemplate>
                <td id="Td1" runat="server" style="width: 50%">
                    <table id="AlternateBundledItem">
                        <tr>
                            <td style="width: 20%">
                                <asp:Label ID="IDLabel" Visible="false" runat="server" Text='<%# Bind("ID") %>' />
                                <asp:Label ID="OfferIdLabel" Visible="false" runat="server" Text='<%# Bind("OfferId") %>' />
                                Product
                            </td>
                            <td style="width: 80%">
                                <asp:Label ID="ProductDescriptionLabel" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Quantity
                            </td>
                            <td>
                                <asp:Label ID="QtyLabel" runat="server" Text='<%# Bind("Qty") %>' />
                            </td>
                        </tr>
                    </table>
                    <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
                    <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" CommandArgument='<%# Bind("ID") %>'
                        Text="Delete" />
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
                    <table class="BundledOrder">
                        <tr>
                            <td colspan="2">
                                <h3>
                                    Insert</h3>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 20%">
                                Select Product
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
                                Quantity
                            </td>
                            <td>
                                <asp:TextBox ID="QuantityTextBox" Width="50" MaxLength="4" runat="server" Text='<%# Bind("Qty") %>' />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ValidationGroup="SaveQualificationOffer"
                                    ControlToValidate="QuantityTextBox" ErrorMessage="Quantity must be entered" InitialValue=""
                                    Text="*" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <br />
                                <br />
                                <asp:Button ID="InsertButton" Width="48%" runat="server" ValidationGroup="SaveQualificationOffer" CommandName="Insert" 
                                    Text="Save" />
                                <asp:Button ID="CancelButton" Width="48%" runat="server" CommandName="Cancel" Text="Clear" />
                                <br />
                                <br />
                            </td>
                        </tr>
                    </table>
                </td>
            </InsertItemTemplate>
            <LayoutTemplate>
                <table style="width: 100%" runat="server">
                    <tr runat="server">
                        <td runat="server">
                            <table style="width: 100%" id="groupPlaceholderContainer" runat="server" border="0">
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
                    <table id="EditingBundledItem">
                        <tr>
                            <td style="width: 20%">
                                <asp:Label ID="IDLabel" Visible="false" runat="server" Text='<%# Bind("ID") %>' />
                                Product:
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
                                Quantity
                            </td>
                            <td>
                                <asp:TextBox ID="QtyTextBox" Width="40" MaxLength="4" runat="server" Text='<%# Bind("Qty") %>' />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ValidationGroup="UpdateQualificationOffer"
                                    ControlToValidate="QtyTextBox" ErrorMessage="Quantity must be entered" InitialValue=""
                                    Text="*" runat="server" />
                            </td>
                        </tr>
                    </table>
                    <asp:Button ID="UpdateButton" runat="server" ValidationGroup="UpdateQualificationOffer"
                        CommandName="Update" Text="Update" />
                    <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancel" />
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
                    ID:
                    <asp:Label ID="IDLabel" runat="server" Text='<%# Eval("ID") %>' />
                    <br />
                    OfferId:
                    <asp:Label ID="OfferIdLabel" runat="server" Text='<%# Eval("OfferId") %>' />
                    <br />
                    ProductId:
                    <asp:Label ID="ProductIdLabel" runat="server" Text='<%# Eval("ProductId") %>' />
                    <br />
                    Qty:
                    <asp:Label ID="QtyLabel" runat="server" Text='<%# Eval("Qty") %>' />
                    <br />
                    <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="Delete" />
                    <br />
                    <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
                    <br />
                </td>
            </SelectedItemTemplate>
        </asp:ListView>
        <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" DataObjectTypeName="WcfFoundationService.OfferQualificationItem"
            DeleteMethod="Delete" InsertMethod="Save" SelectMethod="FindAllByOfferId" TypeName="OfferQualificationItemUI"
            UpdateMethod="UpdateOfferQualificationItem">
            <SelectParameters>
                <asp:ControlParameter ControlID="OfferBundleDropDownList" Name="id" PropertyName="SelectedValue"
                    Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </fieldset>
</div>
