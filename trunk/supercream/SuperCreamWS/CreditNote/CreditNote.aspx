<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="CreditNote.aspx.cs" StylesheetTheme="SuperCream" Inherits="CreditNote_CreditNote" %>

<%@ Register Src="~/Controls/ErrorView.ascx" TagName="ErrorView" TagPrefix="Alterax" %>
<%@ Register Src="../Controls/NewCreditNote.ascx" TagName="NewCreditNote" TagPrefix="uc1" %>
<%@ Register Src="../Controls/MaintainCreditNote.ascx" TagName="MaintainCreditNote"
    TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainPlaceholder" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <asp:UpdatePanel ID="ErrorUpdatePanel" runat="server" UpdateMode="Conditional">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="NewCreditNote" />
            <asp:AsyncPostBackTrigger ControlID="MaintainCreditNote" />
        </Triggers>
        <ContentTemplate>
            <div class="ErrorOutput">
                <Alterax:ErrorView ID="ErrorViewControl" Visible="false" runat="server" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="CreditNoteUpdatePanel" runat="server" UpdateMode="Conditional">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="NewCreditNote" />
            <asp:AsyncPostBackTrigger ControlID="MaintainCreditNote" />
        </Triggers>
        <ContentTemplate>
            <asp:Panel ID="CreditNoteMenuPanel" DefaultButton="NewCreditNoteButton" runat="server">
                <div class="FormHeader">
                    <div class="HeaderContainerPanel">
                        <table class="ContentHeader" cellpadding="0" cellspacing="0">
                            <tr>
                                <td class="Right">
                                    <asp:Panel ID="GeneralPanel" DefaultButton="NewCreditNoteButton" runat="server" Width="100%"
                                        Visible="true">
                                        <table class="ContentHeader" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td style="width: 30%; text-align: left;">
                                                    <span class="RequiredFieldMessage">*</span> <i>indicates a required field</i>
                                                </td>
                                                <td class="Right" style="width: 70%;">
                                                    <asp:LinkButton ID="NewCreditNoteButton" Text="New Credit Note" runat="server" OnClick="NewCreditNoteButton_Click" />
                                                    &nbsp; |
                                                    <asp:LinkButton ID="MaintainCreditNoteButton" Text="Modify Credit Note" runat="server"
                                                        OnClick="MaintainCreditNoteButton_Click" />
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
    <asp:UpdatePanel ID="NewCreditNoteUpdatePanel" runat="server" UpdateMode="Conditional">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="NewCreditNoteButton" />
            <asp:AsyncPostBackTrigger ControlID="MaintainCreditNoteButton" />
        </Triggers>
        <ContentTemplate>
            <uc2:MaintainCreditNote ID="MaintainCreditNote" runat="server" />
            <uc1:NewCreditNote ID="NewCreditNote" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
