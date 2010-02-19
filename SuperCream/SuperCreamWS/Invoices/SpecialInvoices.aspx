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
            <asp:Panel ID="SpecialInvoiceMenuPanel" DefaultButton="NewInvoiceButton" runat="server">
                <div class="FormInput" style="text-align: center;">
                    <fieldset id="Fieldset1">
                        <legend>
                            <h3>
                                Special Invoice Maintenance</h3>
                        </legend>
                        <table style="width: 100%">
                            <tr>
                                <td>
                                    <asp:Button ID="NewInvoiceButton" Text="New Special Invoice" runat="server" OnClick="NewInvoiceButton_Click" />
                                </td>
                                <td>
                                    <asp:Button ID="MaintainInvoiceButton" Text="Modify Special Invoices" runat="server"
                                        OnClick="MaintainInvoiceButton_Click" />
                                </td>
                            </tr>
                        </table>
                    </fieldset>
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
