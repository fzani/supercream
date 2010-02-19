<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ProductSearch.ascx.cs"
    Inherits="Controls_ProductSearch" %>
<asp:Panel ID="GridViewPanel" Visible="true" DefaultButton="SearchButton" runat="server">
    <div class="FormInput">
        <fieldset id="Fieldset3">
            <legend>
                <h3>
                    Select Product to Add to Order</h3>
            </legend>
            <table class="search">
                <tr>
                    <td class="right">
                        <table class="left">
                            <tr>
                                <td>
                                    <asp:Label ID="ProductCodeLabel" Text="Product Code" runat="server"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="ProductCodeSearchTextBox" Width="300px" MaxLength="10" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="ProductNameLabel" Text="Product Description" runat="server"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="ProductNameSearchTextBox" Width="300px" MaxLength="30" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                    <asp:Button ID="SearchButton" Text="Search" CausesValidation="false" runat="server"
                                        OnClick="SearchButton_Click" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <asp:GridView ID="ProductSearchGridView" runat="server" Width="98%" AllowPaging="True"
                AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="ProductSearchDataSource"
                OnRowCommand="ProductSearchGridView_RowCommand">
                <EmptyDataTemplate>
                    <h3>
                        No rows Found</h3>
                </EmptyDataTemplate>
                <Columns>
                    <asp:BoundField DataField="ProductCode" HeaderText="ProductCode" ItemStyle-Width="10%"
                        SortExpression="ProductCode" />
                    <asp:BoundField DataField="Description" HeaderText="Description" ItemStyle-Width="60%"
                        SortExpression="Description" />
                    <asp:BoundField DataField="UnitQty" HeaderText="UnitQty" ItemStyle-Width="10%" SortExpression="UnitQty" />
                    <asp:TemplateField ItemStyle-Width="20%">
                        <ItemTemplate>
                            <asp:Button ID="AddProductButton" runat="server" CommandArgument='<%# Bind("ID") %>'
                                CommandName="AddProductToOrder" ControlStyle-CssClass="button" ItemStyle-Width="20%"
                                Text="Add Product to Order" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:ObjectDataSource ID="ProductSearchDataSource" runat="server" SelectMethod="GetAllProducts"
                TypeName="ProductUI" OnSelecting="ProductSearchDataSource_Selecting">
                <SelectParameters>
                    <asp:Parameter Name="productCode" Type="String" />
                    <asp:Parameter Name="productDescription" Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>
        </fieldset>
    </div>
</asp:Panel>
