<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="VatCode.aspx.cs" Inherits="Admin_VatCode" StylesheetTheme="SuperCream" %>

<%@ Register Src="../Controls/ErrorView.ascx" TagName="ErrorView" TagPrefix="Alterax" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainPlaceHolder" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="ErrorUpdatePanel" runat="server" UpdateMode="Conditional">
        <Triggers>
            <asp:PostBackTrigger ControlID="AddVatCodeButton" />
            <asp:PostBackTrigger ControlID="VatCodeGridView" />
        </Triggers>
        <ContentTemplate>
            <div class="ErrorOutput">
                <Alterax:ErrorView ID="ErrorViewControl" Visible="false" runat="server" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="AddVatCodeUpdatePanel" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <asp:Panel ID="VatCodeManagementPanel" Visible="true" runat="server">
                <div class="FormHeader">
                    <div class="HeaderContainerPanel">
                        <table class="ContentHeader" cellpadding="0" cellspacing="0">
                            <tr>
                                <td class="Right">
                                    <asp:Panel ID="GeneralPanel" runat="server" Width="100%" Visible="true">
                                        <table class="ContentHeader" cellpadding="0">
                                            <tr>
                                                <td style="width: 30%; text-align: left;">
                                                    <span class="RequiredFieldMessage">*</span> <i>indicates a required field</i>
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
            <div class="FormInput">
                <asp:Panel ID="AddPanel" runat="server" DefaultButton="AddVatCodeButton">
                    <fieldset id="VarInputLegend">
                        <legend>
                            <h3>
                                Enter Vat Code</h3>
                        </legend>
                        <table style="width: 100%;">
                            <tr>
                                <td style="width: 20%;">
                                    Code
                                </td>
                                <td style="width: 40%;">
                                    <asp:TextBox ID="CodeTestBox" runat="server" MaxLength="5" ValidationGroup="AddGroup"
                                        Width="250px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="AddGroup"
                                        ControlToValidate="CodeTestBox" ErrorMessage="Name is a required field" InitialValue=""
                                        Text="*" runat="server" />
                                </td>
                                <td style="width: 40%;">
                                    <asp:CheckBox ID="VatExemptableCode" ValidationGroup="AddGroup" Text="Vat Exemptable Code"
                                        runat="server" TextAlign="Left" AutoPostBack="True" OnCheckedChanged="VatExemptableCode_CheckedChanged" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Description
                                </td>
                                <td colspan="2">
                                    <asp:TextBox ID="DescriptionTextBox" runat="server" ValidationGroup="AddGroup" MaxLength="20"
                                        Width="250px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="AddGroup"
                                        ControlToValidate="DescriptionTextBox" ErrorMessage="Name is a required Text Box"
                                        InitialValue="" Text="*" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Percentage Value
                                </td>
                                <td colspan="2">
                                    <asp:TextBox ID="PercentageTextBox" runat="server" ValidationGroup="AddGroup" MaxLength="5"
                                        Width="50px"></asp:TextBox>
                                    %
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server"
                                        TargetControlID="PercentageTextBox" FilterType="Custom, Numbers" ValidChars="." />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="AddGroup"
                                        ControlToValidate="PercentageTextBox" ErrorMessage="Percentage is a required Text Box"
                                        InitialValue="" Text="*" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td colspan="2">
                                    <table class="progressupdate">
                                        <tr>
                                            <td>
                                                <asp:Button ID="AddVatCodeButton" Text="Add" ValidationGroup="AddGroup" runat="server"
                                                    OnClick="AddVatCodeButton_Click" />
                                            </td>
                                            <td>
                                                <div class="progressupdate">
                                                    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="AddVatCodeUpdatePanel"
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
                    </fieldset></asp:Panel>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="SelectVatCodeUpdatePanel" runat="server" UpdateMode="Conditional">
        <Triggers>
            <asp:PostBackTrigger ControlID="AddVatCodeButton" />
        </Triggers>
        <ContentTemplate>
            <div class="FormInput">
                <fieldset>
                    <div class="RightBox">
                        <b>Select Standard Vat Rate &nbsp;</h>
                            <div class="VatSelection">
                                <asp:DropDownList ID="SelectStandardVatRateDropDownList" Style="width: 250px" runat="server">
                                </asp:DropDownList>
                                <br />
                                <asp:Button ID="SaveSelectionButton" Text="Save Selection" runat="server" 
                                    Style="margin: 5px 0px 5px 0px;" onclick="SaveSelectionButton_Click" />
                            </div>
                    </div>
                </fieldset>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="VatCodeGridUpdatePanel" runat="server" UpdateMode="Conditional">
        <Triggers>
            <asp:PostBackTrigger ControlID="AddVatCodeButton" />
        </Triggers>
        <ContentTemplate>
            <div class="FormInput">
                <asp:GridView ID="VatCodeGridView" Width="98%" runat="server" AutoGenerateColumns="False"
                    CssClass="simplegrid" DataSourceID="VatCodeObjectDataSource" DataKeyNames="ID"
                    OnRowDataBound="VatCodeGridView_RowDataBound" OnRowUpdated="VatCodeGridView_RowUpdated"
                    OnRowCancelingEdit="VatCodeGridView_RowCancelingEdit" OnRowDeleting="VatCodeGridView_RowDeleting">
                    <RowStyle CssClass="row-a" />
                    <AlternatingRowStyle CssClass="row-b" />
                    <Columns>
                        <asp:TemplateField ItemStyle-Width="30%" ShowHeader="False">
                            <ItemTemplate>
                                <asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" CommandName="Edit"
                                    Text="Edit"></asp:LinkButton>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:Button ID="UpdateButton" runat="server" ValidationGroup="UpdateGroup" CausesValidation="True"
                                    CommandName="Update" Text="Update"></asp:Button>
                                &nbsp;<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel"
                                    Text="Cancel"></asp:Button>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" Visible="False" />
                        <asp:TemplateField HeaderText="Code" ItemStyle-Width="10%" SortExpression="Code">
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("Code") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="VatCodeTextBox" runat="server" MaxLength="3" Width="30px" Text='<%# Bind("Code") %>'></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="UpdateGroup"
                                    ControlToValidate="VatCodeTextBox" Display="Dynamic" ErrorMessage="VatCode is a required Field"
                                    InitialValue="" Text="*" runat="server" />
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Description" ItemStyle-Width="30%" SortExpression="Description">
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox2" runat="server" MaxLength="20" Width="150px" Text='<%# Bind("Description") %>'></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="UpdateGroup"
                                    ControlToValidate="TextBox2" ErrorMessage="Description is a required Text Box"
                                    InitialValue="" Text="*" runat="server" />
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Percentage" ItemStyle-Width="20%" SortExpression="PercentageValue">
                            <ItemTemplate>
                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("PercentageValue") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox3" runat="server" MaxLength="5" Width="50px" Text='<%# Bind("PercentageValue") %>'></asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server"
                                    TargetControlID="TextBox3" FilterType="Custom,Numbers" ValidChars="." />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator99" ValidationGroup="UpdateGroup"
                                    ControlToValidate="TextBox3" ErrorMessage="Percentage is a required Text Box"
                                    InitialValue="" Text="*" runat="server" />
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-Width="10%" ShowHeader="False">
                            <ItemTemplate>
                                <asp:Button ID="DeleteButton" runat="server" CausesValidation="false" CommandName="Delete"
                                    Text="Delete" />
                            </ItemTemplate>
                            <ControlStyle CssClass="button" />
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-Width="10%">
                            <ItemTemplate>
                                <asp:Image ID="Image1" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <asp:ObjectDataSource ID="VatCodeObjectDataSource" runat="server" SelectMethod="GetAllVatCodes"
                    TypeName="VatCodeUI" DeleteMethod="DeleteVatCode" OnDeleted="VatCodeObjectDataSource_Deleted"
                    OnSelected="VatCodeObjectDataSource_Selected" UpdateMethod="UpdateVatCode" OnUpdating="VatCodeObjectDataSource_Updating">
                    <DeleteParameters>
                        <asp:Parameter Name="id" Type="Int32" />
                    </DeleteParameters>
                </asp:ObjectDataSource>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
