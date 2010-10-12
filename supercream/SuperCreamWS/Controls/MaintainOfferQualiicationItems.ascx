<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MaintainOfferQualiicationItems.ascx.cs"
    Inherits="Controls_MaintainOfferQualiicationItems" %>
<div class="FormInput" style="width: 95%">
    <fieldset id="Fieldset3">
        <legend><span>
            <h3>
                Modify Offer Qualification Items
            </h3>
        </span></legend>
    </fieldset>
    <fieldset>
        <div style="text-align: right">
            <asp:DropDownList ID="OfferBundleDropDownList" runat="server" DataSourceID="ObjectDataSource1"
                DataTextField="Name" DataValueField="ID" Width="40%">
            </asp:DropDownList>
        </div>
    </fieldset>
    <fieldset>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetAllOffers"
            TypeName="OfferUI"></asp:ObjectDataSource>
        <asp:ListView ID="ListView1" runat="server" DataSourceID="ObjectDataSource2" Style="width: 100%"
            GroupItemCount="3" OnItemDataBound="ListView1_ItemDataBound">
            <EmptyItemTemplate>
                <td runat="server" />
            </EmptyItemTemplate>
            <ItemTemplate>
                <td runat="server" style="width: 30%">
                    <asp:Label ID="IDLabel" Visible="false" runat="server" Text='<%# Eval("ID") %>' />
                    <asp:Label ID="OfferIdLabel" Visible="false" runat="server" Text='<%# Eval("OfferId") %>' />
                    Product:
                    <asp:Label ID="ProductDescriptionLabel" runat="server" />
                    <br />
                    Qty:
                    <asp:Label ID="QtyLabel" runat="server" Text='<%# Eval("Qty") %>' />
                    <br />
                    <br />
                    <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
                    <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="Delete" />
                    <br />
                    <br />
                </td>
            </ItemTemplate>
            <AlternatingItemTemplate>
                <td id="Td1" runat="server" style="width: 30%">
                    <asp:Label ID="IDLabel" Visible="false" runat="server" Text='<%# Eval("ID") %>' />
                    <asp:Label ID="OfferIdLabel" Visible="false" runat="server" Text='<%# Eval("OfferId") %>' />
                    Product:
                    <asp:Label ID="ProductDescriptionLabel" runat="server" />
                    <br />
                    Qty:
                    <asp:Label ID="QtyLabel" runat="server" Text='<%# Eval("Qty") %>' />
                    <br />
                    <br />
                    <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
                    <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="Delete" />
                    <br />
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
                    ID:
                    <asp:TextBox ID="IDTextBox" runat="server" Text='<%# Bind("ID") %>' />
                    <br />
                    OfferId:
                    <asp:TextBox ID="OfferIdTextBox" runat="server" Text='<%# Bind("OfferId") %>' />
                    <br />
                    ProductId:
                    <asp:TextBox ID="ProductIdTextBox" runat="server" Text='<%# Bind("ProductId") %>' />
                    <br />
                    Qty:
                    <asp:TextBox ID="QtyTextBox" runat="server" Text='<%# Bind("Qty") %>' />
                    <br />
                    <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="Insert" />
                    <br />
                    <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Clear" />
                    <br />
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
                    <asp:TextBox ID="IDTextBox" Visible="false" runat="server" Text='<%# Bind("ID") %>' />
                    <br />
                    OfferId:
                    <asp:TextBox ID="OfferIdTextBox" runat="server" Text='<%# Bind("OfferId") %>' />
                    <br />
                    ProductId:
                    <asp:TextBox ID="ProductIdTextBox" runat="server" Text='<%# Bind("ProductId") %>' />
                    <br />
                    Qty:
                    <asp:TextBox ID="QtyTextBox" runat="server" Text='<%# Bind("Qty") %>' />
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
            DeleteMethod="Save" InsertMethod="Save" OldValuesParameterFormatString="original_{0}"
            SelectMethod="FindAll" TypeName="OfferQualificationItemUI" UpdateMethod="UpdateOfferQualificationItem">
        </asp:ObjectDataSource>
    </fieldset>
</div>
