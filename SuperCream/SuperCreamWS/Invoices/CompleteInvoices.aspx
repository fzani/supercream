<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master"
    StylesheetTheme="SuperCream" CodeFile="CompleteInvoices.aspx.cs" Inherits="CompleteInvoices" %>

<%@ Register Src="~/Controls/ErrorView.ascx" TagName="ErrorView" TagPrefix="Alterax" %>
<%@ Register Src="../Controls/MaintainCompletedInvoices.ascx" TagName="MaintainCompletedInvoices"
    TagPrefix="uc1" %>
    
<asp:Content ID="Content1" ContentPlaceHolderID="MainPlaceholder" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <asp:UpdatePanel ID="ErrorUpdatePanel" runat="server" UpdateMode="Conditional">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="MaintainCompletedInvoices1" />
        </Triggers>
        <ContentTemplate>
            <div class="ErrorOutput">
                <alterax:errorview id="ErrorViewControl" visible="false" runat="server" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="OrderUpdatePanel" runat="server" UpdateMode="Conditional">
        <Triggers>
        </Triggers>
        <ContentTemplate>
            <uc1:MaintainCompletedInvoices ID="MaintainCompletedInvoices1" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
