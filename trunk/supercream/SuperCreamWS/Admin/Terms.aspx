<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Terms.aspx.cs" Inherits="Admin_Terms" StylesheetTheme="SuperCream" %>

<%@ Register Src="../Controls/ErrorView.ascx" TagName="ErrorView" TagPrefix="Alterax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainPlaceHolder" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="ErrorUpdatePanel" runat="server" UpdateMode="Conditional">
        <Triggers>
            <asp:PostBackTrigger ControlID="AddTermsButton" />
            <asp:PostBackTrigger ControlID="TermssGridView" />
        </Triggers>
        <ContentTemplate>
            <div class="ErrorOutput">
                <Alterax:ErrorView ID="ErrorViewControl" Visible="false" runat="server" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="AddTermsUpdatePanel" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="TermsManagementPanel" Visible="true" runat="server">
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
                <asp:Panel ID="AddPanel" runat="server" DefaultButton="AddTermsButton">
                    <fieldset id="VarInputLegend">
                        <legend>
                            <h3>
                                Enter Payment Terms Description</h3>
                        </legend>
                        <table style="width: 100%">
                            <tr>
                                <td>
                                    Description :
                                </td>
                                <td>
                                    <asp:TextBox ID="DescriptionTextBox" ValidationGroup="AddTerms" runat="server" MaxLength="40"
                                        Width="400px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="DescriptionTextBox"
                                        ErrorMessage="Description is a required Field" ValidationGroup="AddTerms" InitialValue=""
                                        Text="Required" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                    <table class="progressupdate">
                                        <tr>
                                            <td>
                                                <asp:Button ID="AddTermsButton" Text="Add" ValidationGroup="AddTerms" runat="server"
                                                    OnClick="AddTermsButton_Click" />
                                            </td>
                                            <td>
                                                <div class="progressupdate">
                                                    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="AddTermsUpdatePanel"
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
                </asp:Panel>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="TermssGridUpdatePanel" runat="server" UpdateMode="Conditional">
        <Triggers>
            <asp:PostBackTrigger ControlID="AddTermsButton" />
        </Triggers>
        <ContentTemplate>
            <div class="FormInput">
                <asp:GridView ID="TermssGridView" Width="98%" runat="server" AutoGenerateColumns="False"
                    CssClass="simplegrid" DataSourceID="TermssObjectDataSource" DataKeyNames="ID"
                    OnRowUpdated="TermssGridView_RowUpdated">
                    <RowStyle CssClass="row-a" />
                    <AlternatingRowStyle CssClass="row-b" />
                    <Columns>
                        <asp:TemplateField ShowHeader="False" ItemStyle-Width="27%">
                            <ItemTemplate>
                                <asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" CommandName="Edit"
                                    Text="Edit"></asp:LinkButton>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:Button ID="UpdateButton" runat="server" CausesValidation="True" ValidationGroup="GridViewGroup"
                                    CommandName="Update" Text="Update"></asp:Button>
                                &nbsp;<asp:Button ID="CancelButton" ValidationGroup="GridViewGroup" runat="server"
                                    CausesValidation="False" CommandName="Cancel" Text="Cancel"></asp:Button>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" Visible="False" />
                        <asp:TemplateField HeaderText="Description" SortExpression="Description" ItemStyle-Width="63%">
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="TermsTextBox" runat="server" MaxLength="30" Width="300px" Text='<%# Bind("Description") %>'></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="TermsTextBox"
                                    ErrorMessage="Description is a required Field" ValidationGroup="GridViewGroup"
                                    InitialValue="" Text="Required" runat="server" />
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:ButtonField ButtonType="Button" ControlStyle-CssClass="button" ValidationGroup="GridViewGroup"
                            CommandName="Delete" Text="Delete">
                            <ControlStyle CssClass="button" />
                            <ItemStyle Width="10%" />
                        </asp:ButtonField>
                    </Columns>
                </asp:GridView>
                <asp:ObjectDataSource ID="TermssObjectDataSource" runat="server" SelectMethod="GetAllTermss"
                    TypeName="TermsUI" DeleteMethod="DeleteTerms" OnDeleted="TermsObjectDataSource_Deleted"
                    OnSelected="TermsObjectDataSource_Selected" DataObjectTypeName="WcfFoundationService.Terms"
                    UpdateMethod="UpdateTerms" OnUpdating="TermssObjectDataSource_Updating" OnUpdated="TermssObjectDataSource_Updated">
                    <DeleteParameters>
                        <asp:Parameter Name="id" Type="Int32" />
                    </DeleteParameters>
                </asp:ObjectDataSource>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
