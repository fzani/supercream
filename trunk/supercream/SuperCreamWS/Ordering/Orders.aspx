<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Orders.aspx.cs" StylesheetTheme="SuperCream" Inherits="Ordering_Orders" %>

<%@ Register Src="../Controls/ProductSearch.ascx" TagName="ProductSearch" TagPrefix="uc1" %>
<%@ Register Src="~/Controls/ErrorView.ascx" TagName="ErrorView" TagPrefix="Alterax" %>
<%@ Register Src="../Controls/NewOrder.ascx" TagName="NewOrder" TagPrefix="uc2" %>
<%@ Register Src="../Controls/ModifyOrder.ascx" TagName="ModifyOrder" TagPrefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainPlaceholder" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <asp:UpdatePanel ID="ErrorUpdatePanel" runat="server" UpdateMode="Conditional">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="NewOrder" />
            <asp:AsyncPostBackTrigger ControlID="MaintainOrdersButton" />
            <asp:AsyncPostBackTrigger ControlID="NewOrder" />
            <asp:AsyncPostBackTrigger ControlID="ModifyOrder" />
        </Triggers>
        <ContentTemplate>
            <div class="ErrorOutput">
                <Alterax:ErrorView ID="ErrorViewControl" Visible="false" runat="server" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="OrderUpdatePanel" runat="server" UpdateMode="Conditional">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="NewOrder" />
        </Triggers>
        <ContentTemplate>
            <asp:Panel ID="OrderMenuPanel" Visible="true" runat="server">
                <div class="FormHeader">
                    <div class="HeaderContainerPanel">
                        <table class="ContentHeader" cellpadding="0" cellspacing="0">
                            <tr>
                                <td class="Right">
                                    <asp:Panel ID="GeneralPanel" DefaultButton="NewOrderButton" runat="server" Width="100%"
                                        Visible="true">
                                        <table class="ContentHeader" cellpadding="0">
                                            <tr>
                                                <td style="width: 30%; text-align: left;">
                                                    <span class="RequiredFieldMessage">*</span> <i>indicates a required field</i>
                                                </td>
                                                <td class="Right" style="width: 70%;">
                                                    <asp:LinkButton ID="NewOrderButton" Text="New Order" runat="server" OnClick="NewOrderButton_Click" />
                                                    &nbsp; |
                                                    <asp:LinkButton ID="MaintainOrdersButton" Text="Modify Orders" runat="server" OnClick="MaintainOrdersButton_Click" />
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
    <asp:UpdatePanel ID="NewOrderUpdatePanel" runat="server" UpdateMode="Conditional">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="NewOrderButton" />
            <asp:AsyncPostBackTrigger ControlID="MaintainOrdersButton" />
        </Triggers>
        <ContentTemplate>
            <uc2:NewOrder ID="NewOrder" runat="server" Visible="false" />
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="ModifyOrderUpdatePanel" runat="server" UpdateMode="Conditional">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="NewOrderButton" />
            <asp:AsyncPostBackTrigger ControlID="MaintainOrdersButton" />
            <asp:AsyncPostBackTrigger ControlID="NewOrder" />
        </Triggers>
        <ContentTemplate>
            <uc3:ModifyOrder ID="ModifyOrder" Visible="false" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
