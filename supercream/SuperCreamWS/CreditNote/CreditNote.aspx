<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="CreditNote.aspx.cs" StylesheetTheme="SuperCream" Inherits="CreditNote_CreditNote" %>

<%@ Register Src="~/Controls/ErrorView.ascx" TagName="ErrorView" TagPrefix="Alterax" %>
<%@ Register Src="../Controls/NewCreditNote.ascx" TagName="NewCreditNote" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainPlaceholder" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <asp:UpdatePanel ID="ErrorUpdatePanel" runat="server" UpdateMode="Conditional">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="NewCreditNote" />
        </Triggers>
        <ContentTemplate>
            <div class="ErrorOutput">
                <alterax:errorview id="ErrorViewControl" visible="false" runat="server" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="NewCreditNoteUpdatePanel" runat="server" UpdateMode="Conditional">
        <Triggers>
        </Triggers>
        <ContentTemplate>
            <uc1:NewCreditNote ID="NewCreditNote" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
