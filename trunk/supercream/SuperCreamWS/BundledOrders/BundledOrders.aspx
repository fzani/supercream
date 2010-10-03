<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="BundledOrders.aspx.cs" StylesheetTheme="SuperCream" Inherits="Ordering_Orders" %>

<%@ Register Src="~/Controls/ErrorView.ascx" TagName="ErrorView" TagPrefix="Alterax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainPlaceholder" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <asp:UpdatePanel ID="ErrorUpdatePanel" runat="server" UpdateMode="Conditional">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="NewBundledOrderButton" />
            <asp:AsyncPostBackTrigger ControlID="MaintainBundledOrdersButton" />
            <asp:AsyncPostBackTrigger ControlID="MaintainBundledOrdersButton" />
        </Triggers>
        <ContentTemplate>
            <div class="ErrorOutput">
                <Alterax:ErrorView ID="ErrorViewControl" Visible="false" runat="server" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="OrderUpdatePanel" runat="server" UpdateMode="Conditional">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="NewBundledOrderButton" />
        </Triggers>
        <ContentTemplate>
            <asp:Panel ID="BundledOrderMenuPanel" Visible="true" runat="server">
                <div class="FormHeader">
                    <div class="HeaderContainerPanel">
                        <table class="ContentHeader" cellpadding="0" cellspacing="0">
                            <tr>
                                <td class="Right">
                                    <asp:Panel ID="GeneralPanel" DefaultButton="NewBundledOrderButton" runat="server"
                                        Width="100%" Visible="true">
                                        <table class="ContentHeader" cellpadding="0">
                                            <tr>
                                                <td style="width: 30%; text-align: left;">
                                                    <span class="RequiredFieldMessage">*</span> <i>indicates a required field</i>
                                                </td>
                                                <td class="Right" style="width: 70%;">
                                                    <asp:LinkButton ID="MaintainOfferLinkButton" Text="Maintain Offers" runat="server" />
                                                    &nbsp; |
                                                    <asp:LinkButton ID="NewBundledOrderButton" Text="New Bundled Order" runat="server"
                                                        OnClick="NewBundledOrderButton_Click" />
                                                    &nbsp; |
                                                    <asp:LinkButton ID="MaintainBundledOrdersButton" Text="Modify Bundled Order" runat="server"
                                                        OnClick="MaintainBundledOrdersButton_Click" />
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
    <asp:UpdatePanel ID="NewBundledOrderUpdatePanel" runat="server" UpdateMode="Conditional">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="NewBundledOrderButton" />
            <asp:AsyncPostBackTrigger ControlID="MaintainBundledOrdersButton" />
        </Triggers>
        <ContentTemplate>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="ModifyOrderUpdatePanel" runat="server" UpdateMode="Conditional">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="NewBundledOrderButton" />
            <asp:AsyncPostBackTrigger ControlID="MaintainBundledOrdersButton" />
            <asp:AsyncPostBackTrigger ControlID="NewBundledOrderButton" />
        </Triggers>
        <ContentTemplate>
            <Alterax:ErrorView ID="ErrorView2" Visible="false" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
