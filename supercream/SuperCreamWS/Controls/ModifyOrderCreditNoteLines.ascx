<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ModifyOrderCreditNoteLines.ascx.cs"
    Inherits="Controls_ModifyOrderCreditNoteLines" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<div class="FormInput">
    <fieldset id="Fieldset3">
        <asp:Panel ID="InvoiceSearchCriteriaPanel" runat="server">
            <legend>
                <h3>
                    Available Order Lines to Credit</h3>
            </legend>
            <fieldset>
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
                                <asp:Label ID="ProductIDLabel" runat="server" Text='<%# Bind("ProductID") %>' Visible="false"></asp:Label>
                                <asp:Label ID="ProductNameLabel" runat="server" Text='<%# Bind("ProductID") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="ProductNameLabel" runat="server" Text='<%# Bind("ProductID") %>'></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="No Of Units" SortExpression="NoOfUnits">
                            <ItemTemplate>
                                <asp:Label ID="NoOfUnitsLabel" runat="server" Text='<%# Bind("NoOfUnits") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("NoOfUnits") %>'></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Discount" SortExpression="Discount">
                            <ItemTemplate>
                                <asp:Label ID="Label3" runat="server" Text='<%# Eval("Discount", "{0}%") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Discount") %>'></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Price (After Discount)" SortExpression="Price">
                            <ItemTemplate>
                                <asp:Label ID="OrderLinePriceAfterDiscountLabel" runat="server"></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:Label ID="OrderLinePriceAfterDiscountLabel" runat="server"></asp:Label>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Net Price" SortExpression="Price">
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
                         <asp:TemplateField ItemStyle-Width="10%">
                                <HeaderTemplate>
                                    Exists
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Image ID="CreditNoteExistsImage" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        <asp:TemplateField HeaderText="Net Price" SortExpression="Price">
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
                                                Select Quantity to Credit
                                            </h3>
                                        </legend>
                                        <table style="width: 100%">
                                            <tr>
                                                <td>
                                                    <asp:DropDownList ID="QuantityToCreditDropDownList" Style="width: 50px" runat="server">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                        </table>
                                        <asp:Button ID="UpdateButton" Text="Update" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                            OnClick="UpdateOrderCreditLineButton_Click" runat="server" />
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
                    SelectMethod="GetAvailableOrderLines" TypeName="OrderCreditNoteLineUI">
                    <SelectParameters>
                        <asp:Parameter Name="orderId" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </fieldset>
            <asp:Panel ID="CreditLinesPanel" runat="server" Visible="false">
                <legend>
                    <h3>
                        Credit Note Lines
                    </h3>
                </legend>
                <fieldset>
                    <asp:GridView ID="CreditNoteLinesGridView" Width="97%" runat="server" AutoGenerateColumns="False"
                        DataSourceID="CreditNoteLinesObjectDataSource" DataKeyNames="ID" OnRowDataBound="CreditNoteLinesGridView_RowDataBound"
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
                                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("Discount", "{0}%") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Discount") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Price (After Discount)" SortExpression="Price">
                                <ItemTemplate>
                                    <asp:Label ID="OrderLinePriceAfterDiscountLabel" runat="server"></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:Label ID="OrderLinePriceAfterDiscountLabel" runat="server"></asp:Label>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Net Price" SortExpression="Price">
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
                            <asp:TemplateField HeaderText="Edit" SortExpression="SpecialInstructions">
                                <ItemTemplate>
                                    <asp:Button ID="btnTrigger" runat="server" Style="display: none" />
                                    <asp:ImageButton ID="EditImage" ImageUrl="~/images/user6_(edit)_16x16.gif" CommandName="Select"
                                        CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" runat="server" />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:ImageButton ID="EditImage" ImageUrl="~/images/user6_(edit)_16x16.gif" CommandName="Select"
                                        runat="server" />
                                </EditItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <asp:ObjectDataSource ID="CreditNoteLinesObjectDataSource" runat="server" OnSelecting="ObjectDataSource1_Selecting"
                        SelectMethod="GetCreditNoteLines" TypeName="OrderCreditNoteLineUI">
                        <SelectParameters>
                            <asp:Parameter Name="creditNoteId" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </fieldset>
            </asp:Panel>
        </asp:Panel>
</div>
