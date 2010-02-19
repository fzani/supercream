<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Product.aspx.cs" Inherits="Product_Admin" StylesheetTheme="SuperCream" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="~/Controls/ErrorView.ascx" TagName="ErrorView" TagPrefix="Alterax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainPlaceHolder" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="ErrorUpdatePanel" runat="server" UpdateMode="Conditional">
        <Triggers>
            <asp:PostBackTrigger ControlID="NewProductButton" />
            <asp:PostBackTrigger ControlID="MaintainProductButton" />
            <asp:PostBackTrigger ControlID="AddProductCodeButton" />
            <asp:PostBackTrigger ControlID="SearchButton" />
            <asp:PostBackTrigger ControlID="ModifyProductCodeButton" />
            <asp:PostBackTrigger ControlID="ProductGridView" />
        </Triggers>
        <ContentTemplate>
            <div class="ErrorOutput">
                <Alterax:ErrorView ID="ErrorViewControl" Visible="false" runat="server" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="SetupNewProductUpdatePanel" runat="server" UpdateMode="Conditional">
        <Triggers>
            <asp:PostBackTrigger ControlID="NewProductButton" />
            <asp:PostBackTrigger ControlID="AddProductCodeButton" />
            <asp:PostBackTrigger ControlID="ProductGridView" />
        </Triggers>
        <ContentTemplate>
            <asp:Panel ID="SetupNewProductPanel" runat="server" Visible="true">
                <div class="FormInput">
                    <fieldset id="Fieldset1">
                        <legend>
                            <h3>
                                Product Maintenance</h3>
                        </legend>
                        <table style="width: 100%; text-align: center;">
                            <tr>
                                <td>
                                    <asp:Button ID="NewProductButton" Text="New Product" runat="server" CausesValidation="false"
                                        OnClick="NewProductButton_Click" />
                                </td>
                                <td>
                                    <asp:Button ID="MaintainProductButton" Text="Modify Existing Product" CausesValidation="false"
                                        runat="server" OnClick="MaintainProductButton_Click" />
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                </div>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="AddProductUpdatePanel" runat="server" UpdateMode="Conditional">
        <Triggers>
            <asp:PostBackTrigger ControlID="NewProductButton" />
        </Triggers>
        <ContentTemplate>
            <asp:Panel ID="AddProductPanel" runat="server">
                <div class="FormInput">
                    <fieldset id="VarInputLegend">
                        <legend>
                            <h3>
                                Enter New Product</h3>
                        </legend>
                        <table style="width: 100%">
                            <tr>
                                <td>
                                    Product Code
                                </td>
                                <td>
                                    <asp:TextBox ID="CodeTestBox" runat="server" MaxLength="10" Width="130px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="CodeTestBox"
                                        ErrorMessage="Product Code is a required Text Box" InitialValue="" Text="Required"
                                        runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Product Name
                                </td>
                                <td>
                                    <asp:TextBox ID="DescriptionTextBox" runat="server" MaxLength="50" Width="430px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="DescriptionTextBox"
                                        ErrorMessage="Product Description is a required field" InitialValue="" Text="Required"
                                        runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Unit Quantity
                                </td>
                                <td>
                                    <asp:TextBox ID="UnitQuantityTextBox" runat="server" MaxLength="6" Width="50px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="UnitQuantityTextBox"
                                        ErrorMessage="Unit Quantity is a required Text Box" InitialValue="" Text="Required"
                                        runat="server" />
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server"
                                        TargetControlID="UnitQuantityTextBox" FilterType="Numbers">
                                    </ajaxToolkit:FilteredTextBoxExtender>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Unit Price
                                </td>
                                <td>
                                    <asp:TextBox ID="UnitPriceTextBox" runat="server" MaxLength="9" Width="70px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="UnitPriceTextBox"
                                        ErrorMessage="Unit Price is a required field" InitialValue="" Text="Required"
                                        runat="server" />
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                        TargetControlID="UnitPriceTextBox" FilterType="Custom,Numbers" ValidChars="£,." />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    RRP
                                </td>
                                <td>
                                    <asp:TextBox ID="RRPTextBox" runat="server" MaxLength="9" Width="70px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="RRPTextBox"
                                        ErrorMessage="Unit Quantity is a required Text Box" InitialValue="" Text="Required"
                                        runat="server" />
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server"
                                        TargetControlID="RRPTextBox" FilterType="Custom,Numbers" ValidChars="£,." />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Vat Exempt
                                </td>
                                <td>
                                    <asp:RadioButtonList ID="VatExemptionRadioButtonList" runat="server" RepeatDirection="Horizontal"
                                        Width="250px" AutoPostBack="True" OnSelectedIndexChanged="VatExemptionRadioButtonList_SelectedIndexChanged">
                                        <asp:ListItem Text="Yes"></asp:ListItem>
                                        <asp:ListItem Text="No" Selected="True"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Vat Code
                                </td>
                                <td>
                                    <asp:DropDownList ID="VatCodeDropDownList" runat="server" Width="300px">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                    <table class="progressupdate">
                                        <tr>
                                            <td>
                                                <asp:Button ID="AddProductCodeButton" Text="Add" runat="server" OnClick="AddProductCodeButton_Click1" />
                                                <asp:Button ID="CancelNewProductButton" CausesValidation="false" Text="Cancel" runat="server"
                                                    OnClick="CancelNewProductCodeButton_Click1" />
                                            </td>
                                            <td>
                                                <div class="progressupdate">
                                                    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="AddProductUpdatePanel"
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
    <asp:UpdatePanel ID="GridViewUpdatePanel" runat="server" UpdateMode="Conditional">
        <Triggers>
            <asp:PostBackTrigger ControlID="MaintainProductButton" />
        </Triggers>
        <ContentTemplate>
            <asp:Panel ID="GridViewPanel" Visible="false" DefaultButton="SearchButton" runat="server">
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
                                        <asp:Label ID="ProductNameLabel" Text="Product Name" runat="server"></asp:Label>
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
                        <tr>
                            <td>
                                <asp:GridView ID="ProductGridView" runat="server" DataKeyNames="ID" DataSourceID="ObjectDataSource1"
                                    OnRowCommand="ProductGridView_RowCommand" OnPageIndexChanging="ProductGridView_PageIndexChanging"
                                    OnRowDeleted="ProductGridView_RowDeleted" OnRowDeleting="ProductGridView_RowDeleting">
                                    <Columns>
                                        <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" Visible="False" />
                                        <asp:BoundField DataField="ProductCode" HeaderText="Product Code" ItemStyle-Width="20%"
                                            SortExpression="ProductCode" Visible="True">
                                            <ItemStyle Width="20%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Description" ItemStyle-Width="60%" HeaderText="Product Name"
                                            SortExpression="ID" Visible="True">
                                            <ItemStyle Width="60%" />
                                        </asp:BoundField>
                                        <asp:TemplateField ItemStyle-Width="20%">
                                            <ItemTemplate>
                                                <asp:Button ID="ModifyGridButton" ControlStyle-CssClass="button" ItemStyle-Width="20%"
                                                    runat="server" CommandArgument='<%# Bind("ID") %>' CommandName="ModifyProduct"
                                                    Text="Select Product" />
                                                <asp:Button ID="DeleteButton" ControlStyle-CssClass="button" ItemStyle-Width="20%"
                                                    runat="server" CommandArgument='<%# Bind("ID") %>' CommandName="Delete" Text="Delete Product" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetAllProducts"
                                    TypeName="ProductUI" DeleteMethod="DeleteProduct" OnSelecting="ObjectDataSource1_Selecting">
                                    <SelectParameters>
                                        <asp:Parameter Name="productCode" Type="String" />
                                        <asp:Parameter Name="productDescription" Type="String" />
                                    </SelectParameters>
                                    <DeleteParameters>
                                        <asp:Parameter Name="id" Type="Int32" />
                                    </DeleteParameters>
                                </asp:ObjectDataSource>
                            </td>
                        </tr>
                </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="ModifyProductUpdatePanel" runat="server" UpdateMode="Conditional">
        <Triggers>
        </Triggers>
        <ContentTemplate>
            <asp:Panel ID="ModifyProductPanel" Visible="false" runat="server">
                <div class="FormInput">
                    <fieldset id="Fieldset2">
                        <legend>
                            <h3>
                                Enter Product</h3>
                        </legend>
                        <table style="width: 100%">
                            <tr>
                                <td>
                                    Product Code
                                </td>
                                <td>
                                    <asp:TextBox ID="ModifyCodeTextBox" runat="server" MaxLength="10" Width="130px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="ModifyCodeTextBox"
                                        ErrorMessage="Product Code is a required Text Box" InitialValue="" Text="Required"
                                        runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Description
                                </td>
                                <td>
                                    <asp:TextBox ID="ModifyDescriptionTextBox" runat="server" MaxLength="50" Width="430px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ControlToValidate="ModifyDescriptionTextBox"
                                        ErrorMessage="Product Description is a required field" InitialValue="" Text="Required"
                                        runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Unit Quantity
                                </td>
                                <td>
                                    <asp:TextBox ID="ModifyUnitQuantityTextBox" runat="server" MaxLength="6" Width="50px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ControlToValidate="ModifyUnitQuantityTextBox"
                                        ErrorMessage="Unit Quantity is a required Text Box" InitialValue="" Text="Required"
                                        runat="server" />
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server"
                                        TargetControlID="ModifyUnitQuantityTextBox" FilterType="Numbers">
                                    </ajaxToolkit:FilteredTextBoxExtender>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Unit Price
                                </td>
                                <td>
                                    <asp:TextBox ID="ModifyUnitPriceTextBox" runat="server" MaxLength="9" Width="70px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" ControlToValidate="ModifyUnitPriceTextBox"
                                        ErrorMessage="Unit Price is a required field" InitialValue="" Text="Required"
                                        runat="server" />
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server"
                                        TargetControlID="ModifyUnitPriceTextBox" FilterType="Custom,Numbers" ValidChars="£,." />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    RRP
                                </td>
                                <td>
                                    <asp:TextBox ID="ModifyRRPTextBox" runat="server" MaxLength="9" Width="70px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" ControlToValidate="ModifyRRPTextBox"
                                        ErrorMessage="Unit Quantity is a required Text Box" InitialValue="" Text="Required"
                                        runat="server" />
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server"
                                        TargetControlID="ModifyRRPTextBox" FilterType="Custom,Numbers" ValidChars="£,." />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Vat Exempt
                                </td>
                                <td>
                                    <asp:RadioButtonList ID="ModifyVatExemptionRadioButtonList" runat="server" RepeatDirection="Horizontal"
                                        Width="250px" AutoPostBack="True" OnSelectedIndexChanged="ModifiedVatExemptionRadioButtonList_SelectedIndexChanged">
                                        <asp:ListItem Text="Yes"></asp:ListItem>
                                        <asp:ListItem Text="No" Selected="True"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Vat Code
                                </td>
                                <td>
                                    <asp:DropDownList ID="ModifyVatCodeDropDownList" runat="server" Width="300px">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                    <table class="progressupdate">
                                        <tr>
                                            <td>
                                                <asp:Button ID="ModifyProductCodeButton" Text="Save" runat="server" OnClick="ModifyProductCodeButton_Click" />
                                                <asp:Button ID="ProductCancelButton" Text="Cancel" runat="server" OnClick="CancelProductCodeButton_Click" />
                                            </td>
                                            <td>
                                                <div class="progressupdate">
                                                    <asp:UpdateProgress ID="UpdateProgress2" runat="server" AssociatedUpdatePanelID="ModifyProductUpdatePanel"
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
                </div>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
