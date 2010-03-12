<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SpecialInvoices.aspx.cs"
    MasterPageFile="~/MasterPage.master" Inherits="Invoices_SpecialInvoices" StylesheetTheme="SuperCream" %>

<%@ Register Src="~/Controls/ErrorView.ascx" TagName="ErrorView" TagPrefix="Alterax" %>
<%@ Register Src="../Controls/MaintainSpecialInvoices.ascx" TagName="MaintainSpecialInvoices"
    TagPrefix="uc1" %>
<%@ Register Src="../Controls/NewSpecialInvoice.ascx" TagName="NewSpecialInvoice"
    TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainPlaceholder" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <asp:UpdatePanel ID="ErrorUpdatePanel" runat="server" UpdateMode="Conditional">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="NewInvoiceButton" />
            <asp:AsyncPostBackTrigger ControlID="NewSpecialInvoice" />
            <asp:AsyncPostBackTrigger ControlID="MaintainInvoiceButton" />
            <asp:AsyncPostBackTrigger ControlID="MaintainSpecialInvoices" />
        </Triggers>
        <ContentTemplate>
            <div class="ErrorOutput">
                <Alterax:ErrorView ID="ErrorViewControl" Visible="false" runat="server" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="SpecialInvoiceUpdatePanel" runat="server" UpdateMode="Conditional">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="NewSpecialInvoice" />
        </Triggers>
        <ContentTemplate>
            <asp:Panel ID="SpecialInvoiceMenuPanel" runat="server">
                <div class="FormHeader">
                    <div class="HeaderContainerPanel">
                        <table class="ContentHeader" cellpadding="0" cellspacing="0">
                            <tr>
                                <td class="Right">
                                    <asp:Panel ID="GeneralPanel" DefaultButton="NewInvoiceButton" runat="server" Width="100%"
                                        Visible="true">
                                        <table class="ContentHeader" cellpadding="0">
                                            <tr>
                                                <td style="width: 30%; text-align: left;">
                                                    <span class="RequiredFieldMessage">*</span> <i>indicates a required field</i>
                                                </td>
                                                <td class="Right" style="width: 70%;">
                                                    <asp:LinkButton ID="NewInvoiceButton" Text="New Special Invoice" runat="server" OnClick="NewInvoiceButton_Click" />
                                                    &nbsp; |
                                                    <asp:LinkButton ID="MaintainInvoiceButton" Text="Modify Special Invoices" runat="server"
                                                        OnClick="MaintainInvoiceButton_Click" />
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
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="NewSpecialInvoiceUpdatePanel" runat="server" UpdateMode="Conditional">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="NewInvoiceButton" />
            <asp:AsyncPostBackTrigger ControlID="MaintainInvoiceButton" />
            <asp:AsyncPostBackTrigger ControlID="MaintainSpecialInvoices" />
        </Triggers>
        <ContentTemplate>
            <uc2:NewSpecialInvoice ID="NewSpecialInvoice" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="ModifySpecialInvoiceUpdatePanel" runat="server" UpdateMode="Conditional">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="NewInvoiceButton" />
            <asp:AsyncPostBackTrigger ControlID="MaintainInvoiceButton" />
            <asp:AsyncPostBackTrigger ControlID="NewSpecialInvoice" />
        </Triggers>
        <ContentTemplate>
            <uc1:MaintainSpecialInvoices ID="MaintainSpecialInvoices" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
