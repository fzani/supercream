<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Account.aspx.cs" Inherits="Admin_Account" StylesheetTheme="SuperCream"
    Culture="Auto" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>
<%@ Register Src="../Controls/ErrorView.ascx" TagName="ErrorView" TagPrefix="Alterax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainPlaceHolder" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="ErrorUpdatePanel" runat="server" UpdateMode="Conditional">
        <Triggers>
            <asp:PostBackTrigger ControlID="AddAccountButton" />
            <asp:PostBackTrigger ControlID="AccountGridView" />
        </Triggers>
        <ContentTemplate>
            <div class="ErrorOutput">
                <Alterax:ErrorView ID="ErrorViewControl" Visible="false" runat="server" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="AccountUpdatePanel" runat="server" UpdateMode="Conditional">
        <Triggers>
            <asp:PostBackTrigger ControlID="CustomerDropDownList" />
        </Triggers>
        <ContentTemplate>
            <asp:Panel ID="SetupAccountPanel" Visible="true" runat="server">
                <div class="FormInput">
                    <fieldset id="Fieldset2">
                        <legend>
                            <h3>
                                Add New Invoice Address
                            </h3>
                        </legend>
                        <table style="width: 100%;">
                            <tr>
                                <td>
                                    Customer
                                </td>
                                <td style="text-align: left;" colspan="3">
                                    <asp:DropDownList ID="CustomerDropDownList" AutoPostBack="true" Width="94%" runat="server"
                                        OnSelectedIndexChanged="CustomerDropDownList_SelectedIndexChanged" TabIndex="1">
                                    </asp:DropDownList>
                                    <ajaxtoolkit:ListSearchExtender ID="ListSearchExtender1" runat="server" TargetControlID="CustomerDropDownList"
                                        PromptCssClass="ListSearchExtenderPrompt" PromptText="Text to Search For" QueryPattern="Contains"
                                        QueryTimeout="2000" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" Display="Dynamic" ValidationGroup="AddGroup"
                                        ControlToValidate="CustomerDropDownList" InitialValue="-1" ErrorMessage="You must select Customer"
                                        Text="*" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Invoice To
                                </td>
                                <td colspan="3">
                                    <asp:TextBox ID="CompanyToInvoiceToTextBox" runat="server" Width="94%" MaxLength="80"
                                        TabIndex="2"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" Display="Dynamic" ValidationGroup="AddGroup"
                                        ControlToValidate="CompanyToInvoiceToTextBox" InitialValue="" ErrorMessage="Invoice to is a required Field"
                                        Text="*" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    For Attention Of
                                </td>
                                <td>
                                    <asp:DropDownList ID="ForTheAttentionOfDropDownList" Display="Dynamic" DataValueField="ID"
                                        DataTextField="FirstName" TabIndex="3" runat="server" ValidationGroup="AddGroup"
                                        Width="94%" AutoPostBack="True" OnSelectedIndexChanged="ForTheAttentionOfDropDownList_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" Display="Dynamic" ValidationGroup="AddGroup"
                                        ControlToValidate="ForTheAttentionOfDropDownList" InitialValue="-1" ErrorMessage="For the Attention must be selected"
                                        Text="*" runat="server" />
                                </td>
                                <td>
                                    <i>
                                        <asp:Label ID="ContactLabel" Text="Contact No" Visible="false" runat="server"></asp:Label>
                                    </i>
                                </td>
                                <td>
                                    <i>
                                        <asp:Label ID="ContactNoLabel" ForeColor="Green" Font-Size="1.2em" CssClass="EmphGreen"
                                            Visible="false" runat="server"></asp:Label>
                                    </i>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 20%;">
                                    Address
                                </td>
                                <td style="width: 30%">
                                    <asp:TextBox ID="InvoiceAddressLine1TextBox" Width="90%" ValidationGroup="AddGroup"
                                        TabIndex="4" MaxLength="25" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" Display="Dynamic" ValidationGroup="AddGroup"
                                        ControlToValidate="InvoiceAddressLine1TextBox" InitialValue="" ErrorMessage="Address line is a required field"
                                        Text="*" runat="server" />
                                </td>
                                <td style="width: 15%">
                                    County
                                </td>
                                <td style="width: 35%">
                                    <asp:TextBox ID="InvoiceCountyTextBox" runat="server" ValidationGroup="AddGroup"
                                        TabIndex="7" MaxLength="25" Width="92%"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ValidationGroup="AddGroup"
                                        ControlToValidate="InvoiceCountyTextBox" Display="Dynamic" InitialValue="" ErrorMessage="County is a required field"
                                        Text="*" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                    <asp:TextBox ID="InvoiceAddressLine2TextBox" Width="90%" ValidationGroup="AddGroup"
                                        TabIndex="5" MaxLength="25" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    Post Code
                                </td>
                                <td>
                                    <asp:TextBox ID="InvoicePostCodeTextBox" ValidationGroup="AddGroup" runat="server"
                                        TabIndex="8" MaxLength="8" Width="90%"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" Display="Dynamic" ValidationGroup="AddGroup"
                                        ControlToValidate="InvoicePostCodeTextBox" InitialValue="" ErrorMessage="Post Code is a required field"
                                        Text="*" runat="server" />
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorPostCodeTextBox" Display="Dynamic"
                                        ValidationExpression="^([Gg][Ii][Rr] 0[Aa]{2})|((([A-Za-z][0-9]{1,2})|(([A-Za-z][A-Ha-hJ-Yj-y][0-9]{1,2})|(([A-Za-z][0-9][A-Za-z])|([A-Za-z][A-Ha-hJ-Yj-y][0-9]?[A-Za-z])))) {0,1}[0-9][A-Za-z]{2})$"
                                        ControlToValidate="InvoicePostCodeTextBox" Text="E" ErrorMessage="Invalid UK phone number"
                                        runat="server" />
                                </td>
                            </tr>
                            <tr>
                                
                                <td>
                                    City/Town
                                </td>
                                <td>
                                    <asp:TextBox ID="InvoiceTownTextBox" Width="90%" MaxLength="25" ValidationGroup="AddGroup"
                                        TabIndex="6" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" Display="Dynamic" ValidationGroup="AddGroup"
                                        ControlToValidate="InvoiceTownTextBox" InitialValue="" ErrorMessage="City/Town is a required field"
                                        Text="*" runat="server" />
                                </td>
                                <td colspan="2">
                                </td>
                            </tr>
                            <tr>
                            </tr>
                            <tr>
                                <td>
                                    Payment Terms
                                </td>
                                <td>
                                    <asp:DropDownList ID="PaymentTermsDropDownList" ValidationGroup="AddGroup" runat="server"
                                        TabIndex="9" Width="94%">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="AddGroup"
                                        ControlToValidate="PaymentTermsDropDownList" Display="Dynamic" InitialValue="-1"
                                        ErrorMessage="You must select Payment Terms" Text="*" runat="server" />
                                </td>
                                <td colspan="2">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Account No
                                </td>
                                <td>
                                    <asp:TextBox ID="AccountNoTextBox" runat="server" MaxLength="15" ValidationGroup="AddGroup"
                                        TabIndex="10" Width="90%"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="AddGroup"
                                        ControlToValidate="AccountNoTextBox" InitialValue="" Display="Dynamic" ErrorMessage="Account No is a required field"
                                        Text="*" runat="server" />
                                </td>
                                <td colspan="2">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                    <table class="progressupdate">
                                        <tr>
                                            <td>
                                            </td>
                                            <td>
                                                <div class="progressupdate">
                                                    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="AccountUpdatePanel"
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
                    <table style="width: 100%">
                        <tr>
                            <td>
                            </td>
                            <td>
                                <table class="progressupdate">
                                    <tr>
                                        <td>
                                            <asp:Button ID="AddAccountButton" ValidationGroup="AddGroup" Text="Add Invoice Address Details"
                                                Visible="true" runat="server" OnClick="AddAccountButton_Click" TabIndex="11" />
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </div>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="SelectAccountsUpdatePanel" runat="server" UpdateMode="Conditional">
        <Triggers>
            <asp:PostBackTrigger ControlID="CustomerDropDownList" />
            <asp:PostBackTrigger ControlID="AddAccountButton" />
        </Triggers>
        <ContentTemplate>
            <asp:Panel ID="UpdateInvoicePanel" runat="server" Visible="false">
                <div class="FormInput">
                    <fieldset id="Fieldset1">
                        <legend>
                            <h3>
                                Update Existing Invoice Address
                            </h3>
                        </legend>
                        <asp:GridView ID="AccountGridView" Width="98%" EmptyDataText="No Accounts have yet been defined for this Customer"
                            runat="server" AutoGenerateColumns="False" CssClass="simplegrid" DataKeyNames="ID"
                            DataSourceID="ObjectDataSource1" OnRowCommand="AccountGridView_RowCommand" OnRowDataBound="AccountGridView_RowDataBound">
                            <RowStyle CssClass="row-a" />
                            <AlternatingRowStyle CssClass="row-b" />
                            <EmptyDataTemplate>
                                "No Accounts have yet been defined for this Customer
                            </EmptyDataTemplate>
                            <Columns>
                                <asp:TemplateField Visible="false" SortExpression="ID">
                                    <ItemTemplate>
                                        <asp:Label ID="ID" runat="server" Text='<%# Bind("ID") %>' Visible="false"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Account No" ItemStyle-Width="20%" SortExpression="AlphaID">
                                    <ItemTemplate>
                                        <asp:Label ID="AlphaIDLabel" runat="server" Text='<%# Bind("AlphaID") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Invoice To" ItemStyle-Width="65%" SortExpression="CompanyToInvoiceTo">
                                    <ItemTemplate>
                                        <asp:Label ID="CompanyToInvoiceToLabel" runat="server" Text='<%# Bind("CompanyToInvoiceTo") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="15%">
                                    <ItemTemplate>
                                        <asp:Button ID="btnTrigger" runat="server" Style="display: none" />
                                        <asp:Button ID="UpdateGridButton" Text="Select" CommandName="Select" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                            ValidationGroup="GridViewGroup" runat="server"></asp:Button>
                                        <ajaxtoolkit:ModalPopupExtender ID="PopupControlExtender1" DropShadow="true" runat="server"
                                            TargetControlID="btnTrigger" PopupControlID="PanelMessage" CancelControlID="CancelButton"
                                            BackgroundCssClass="XPopUpBackGround" />
                                        <asp:Panel Style="display: none" ID="PanelMessage" runat="server" CssClass="modalPopup">
                                            <fieldset id="Fieldset2">
                                                <legend>
                                                    <h3>
                                                        Invoice Address
                                                    </h3>
                                                </legend>
                                                <table>
                                                    <tr>
                                                        <td>
                                                            Invoice To
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="CompanyToInvoiceToTextBox" runat="server" Width="200px" MaxLength="50"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            For the Attention Of
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ForTheAttentionOfDropDownList" DataValueField="ID" DataTextField="FirstName"
                                                                runat="server" ValidationGroup="AddGroup" Width="200px">
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" ValidationGroup="AddGroup"
                                                                ControlToValidate="ForTheAttentionOfDropDownList" InitialValue="-1" ErrorMessage="For the Attention must be selected"
                                                                Text="*" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            Payment Terms
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="PaymentTermsDropDownList" runat="server" ValidationGroup="GridViewPanel"
                                                                Width="350px">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            Account No
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="AccountNoTextBox" runat="server" ValidationGroup="GridViewPanel"
                                                                MaxLength="15" Width="350px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            Invoice Address
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="InvoiceAddressLine1TextBox" Width="350px" MaxLength="40" ValidationGroup="GridViewPanel"
                                                                runat="server"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="InvoiceAddressLine2TextBox" Width="350px" MaxLength="40" ValidationGroup="GridViewPanel"
                                                                runat="server"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            City/Town
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="InvoiceTownTextBox" Width="350px" MaxLength="25" runat="server"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            County
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="InvoiceCountyTextBox" runat="server" MaxLength="25" ValidationGroup="GridViewPanel"
                                                                Width="350px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            Post Code
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="InvoicePostCodeTextBox" runat="server" ValidationGroup="GridViewPanel"
                                                                MaxLength="8" Width="200px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </fieldset>
                                            <asp:Label ID="cpItemDetails" runat="server" Visible="false"></asp:Label>
                                            <p>
                                                <center>
                                                    <asp:Button ID="OkButton" runat="server" Text="Update" ValidationGroup="GridViewPanel"
                                                        OnClick="ModalPopupUpdateAccountButton_Click" CssClass="button" />
                                                    <asp:Button ID="DeleteButton" runat="server" Text="Delete" ValidationGroup="GridViewPanel"
                                                        OnClick="ModalPopupDeleteAccountButton_Click" CssClass="button" />
                                                    <asp:Button ID="CancelButton" Text="Cancel" runat="server" ValidationGroup="GridViewPanel"
                                                        CssClass="button" />
                                                </center>
                                            </p>
                                        </asp:Panel>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetAllAccountsByCustomerID"
                            TypeName="AccountUI" OnSelecting="ObjectDataSource1_Selecting" OnSelected="ObjectDataSource1_Selected">
                            <SelectParameters>
                                <asp:Parameter Name="id" Type="Int32" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                    </fieldset>
                </div>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
