<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Invoices.aspx.cs" StylesheetTheme="SuperCream" Inherits="Invoices_Invoices" %>

<%@ Register Src="~/Controls/ErrorView.ascx" TagName="ErrorView" TagPrefix="Alterax" %>
<%@ Register Src="../Controls/MaintainInvoice.ascx" TagName="MaintainInvoice" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainPlaceholder" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <asp:UpdatePanel ID="ErrorUpdatePanel" runat="server" UpdateMode="Conditional">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="MaintainInvoice1" />
        </Triggers>
        <ContentTemplate>
            <div class="ErrorOutput">
                <Alterax:ErrorView ID="ErrorViewControl" Visible="false" runat="server" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="OrderUpdatePanel" runat="server" UpdateMode="Conditional">
        <Triggers>
        </Triggers>
        <ContentTemplate>
            <uc1:MaintainInvoice ID="MaintainInvoice1" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
