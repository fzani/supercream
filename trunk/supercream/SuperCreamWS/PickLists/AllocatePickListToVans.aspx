<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AllocatePickListToVans.aspx.cs"
    MasterPageFile="~/MasterPage.master" StylesheetTheme="SuperCream" Inherits="PickLists_AllocatePickListToVans" %>

<%@ Register Src="~/Controls/ErrorView.ascx" TagName="ErrorView" TagPrefix="Alterax" %>
<%@ Register Src="../Controls/MaintainCompletedInvoices.ascx" TagName="MaintainCompletedInvoices"
    TagPrefix="uc1" %>
<%@ Register Src="../Controls/AllocateToVansControl.ascx" TagName="AllocateToVansControl"
    TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainPlaceholder" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <asp:UpdatePanel ID="ErrorUpdatePanel" runat="server" UpdateMode="Conditional">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="AllocateToVansControl" />
        </Triggers>
        <ContentTemplate>
            <div class="ErrorOutput">
                <Alterax:ErrorView ID="ErrorViewControl" Visible="false" runat="server" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="AlocateToVans" runat="server" UpdateMode="Conditional">
        <Triggers>
        </Triggers>
        <ContentTemplate>
            <uc2:AllocateToVansControl ID="AllocateToVansControl" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
