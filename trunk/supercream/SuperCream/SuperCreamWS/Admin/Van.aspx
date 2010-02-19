<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Van.aspx.cs" Inherits="Admin_Van" StylesheetTheme="SuperCream" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="../Controls/ErrorView.ascx" TagName="ErrorView" TagPrefix="Alterax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainPlaceHolder" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="ErrorUpdatePanel" runat="server" UpdateMode="Conditional">
        <Triggers>
            <asp:PostBackTrigger ControlID="AddVanButton" />
            <asp:PostBackTrigger ControlID="VansGridView" />
        </Triggers>
        <ContentTemplate>
            <div class="ErrorOutput">
                <Alterax:ErrorView ID="ErrorViewControl" Visible="false" runat="server" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="AddVansUpdatePanel" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="FormInput">
                <asp:Panel ID="AddPanel" runat="server" DefaultButton="AddVanButton">
                    <fieldset id="VarInputLegend">
                        <legend>
                            <h3>
                                Enter Van Descriptions</h3>
                        </legend>
                        <table style="width: 100%">
                            <tr>
                                <td>
                                    Description :
                                </td>
                                <td>
                                    <asp:TextBox ID="DescriptionTextBox" ValidationGroup="AddVan" runat="server" MaxLength="40"
                                        Width="400px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="AddVan"
                                        ControlToValidate="DescriptionTextBox" ErrorMessage="Description is a required Field"
                                        InitialValue="" Text="Required" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Maximum Reccomended Parcel Count :
                                </td>
                                <td>
                                    <asp:TextBox ID="MaximumRecommendedTextBox" ValidationGroup="AddVan" runat="server"
                                        Width="60px" MaxLength="4"></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                        TargetControlID="MaximumRecommendedTextBox" FilterType="Numbers" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="AddVan"
                                        ControlToValidate="MaximumRecommendedTextBox" ErrorMessage="Description is a required Field"
                                        InitialValue="" Text="Required" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                    <table class="progressupdate">
                                        <tr>
                                            <td>
                                                <asp:Button ID="AddVanButton" Text="Add" ValidationGroup="AddVan" runat="server"
                                                    OnClick="AddVanButton_Click" />
                                            </td>
                                            <td>
                                                <div class="progressupdate">
                                                    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="AddVansUpdatePanel"
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
    <asp:UpdatePanel ID="VansGridUpdatePanel" runat="server" UpdateMode="Conditional">
        <Triggers>
            <asp:PostBackTrigger ControlID="AddVanButton" />
        </Triggers>
        <ContentTemplate>
            <div class="FormInput">
                <asp:GridView ID="VansGridView" Width="98%" runat="server" AutoGenerateColumns="False"
                    CssClass="simplegrid" DataSourceID="VansObjectDataSource" DataKeyNames="ID" OnRowUpdated="VansGridView_RowUpdated">
                    <RowStyle CssClass="row-a" />
                    <AlternatingRowStyle CssClass="row-b" />
                    <Columns>
                        <asp:TemplateField ShowHeader="False" ItemStyle-Width="30%">
                            <ItemTemplate>
                                <asp:Button ID="EditButton" runat="server" CausesValidation="False" CommandName="Edit"
                                    Text="Edit"></asp:Button>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:Button ID="UpdateButton" runat="server" CausesValidation="True" ValidationGroup="GridViewGroup"
                                    CommandName="Update" Text="Update"></asp:Button>
                                &nbsp;<asp:Button ID="CancelButton" ValidationGroup="GridViewGroup" runat="server"
                                    CausesValidation="False" CommandName="Cancel" Text="Cancel"></asp:Button>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" Visible="False" />
                        <asp:TemplateField HeaderText="Description" SortExpression="Description" ItemStyle-Width="50%">
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" MaxLength="30" Width="300px" Text='<%# Bind("Description") %>'></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        
                         <asp:TemplateField HeaderText="MaximumReccomendedParcelCount" SortExpression="MaximumReccomendedParcelCount" 
                            ItemStyle-Width="10%">
                            <ItemTemplate>
                                <asp:Label ID="MaximumReccomendedParcelCountLabel" runat="server" Text='<%# Bind("MaximumReccomendedParcelCount") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="MaximumReccomendedParcelCountTextBox" runat="server" MaxLength="30" Width="60px" Text='<%# Bind("MaximumReccomendedParcelCount") %>'></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        
                        
                        <asp:ButtonField ButtonType="Button" ControlStyle-CssClass="button" ValidationGroup="GridViewGroup"
                            CommandName="Delete" Text="Delete">
                            <ControlStyle CssClass="button" />
                            <ItemStyle Width="10%" />
                        </asp:ButtonField>
                    </Columns>
                </asp:GridView>
                <asp:ObjectDataSource ID="VansObjectDataSource" runat="server" SelectMethod="GetAllVans"
                    TypeName="VanUI" DeleteMethod="DeleteVan" OnDeleted="VanObjectDataSource_Deleted"
                    OnSelected="VanObjectDataSource_Selected" DataObjectTypeName="WcfFoundationService.Van"
                    UpdateMethod="UpdateVan" OnUpdating="VansObjectDataSource_Updating" OnUpdated="VansObjectDataSource_Updated">
                    <DeleteParameters>
                        <asp:Parameter Name="id" Type="Int32" />
                    </DeleteParameters>
                </asp:ObjectDataSource>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
