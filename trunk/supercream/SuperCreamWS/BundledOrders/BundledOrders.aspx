<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="BundledOrders.aspx.cs" StylesheetTheme="SuperCream" Inherits="Ordering_Orders" %>

<%@ Register Src="~/Controls/ErrorView.ascx" TagName="ErrorView" TagPrefix="Alterax" %>
<%@ Register Src="../Controls/EditBundledOrder.ascx" TagName="EditBundledOrder" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="../Controls/MaintainOfferQualiicationItems.ascx" TagName="MaintainOfferQualiicationItems"
    TagPrefix="uc2" %>
<%@ Register Src="../Controls/MaintainOfferItems.ascx" TagName="MaintainOfferItems"
    TagPrefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainPlaceholder" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <asp:UpdatePanel ID="ErrorUpdatePanel" runat="server" UpdateMode="Conditional">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="TabContainer" />
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
            <asp:Panel ID="BundledOrderMenuPanel" Visible="true" runat="server">
                <div class="FormHeader">
                    <div class="HeaderContainerPanel">
                        <table class="ContentHeader" cellpadding="0" cellspacing="0">
                            <tr>
                                <td class="Right">
                                    <asp:Panel ID="GeneralPanel" runat="server" Width="100%" Visible="true">
                                        <table class="ContentHeader" cellpadding="0">
                                            <tr>
                                                <td style="width: 30%; text-align: left;">
                                                    <span class="RequiredFieldMessage">*</span> <i>indicates a required field</i>
                                                </td>
                                                <td class="Right" style="width: 70%;">
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
    <asp:UpdatePanel ID="MaintainBundledOrderUpdatePanel" runat="server" UpdateMode="Conditional">
        <Triggers>
        </Triggers>
        <ContentTemplate>
            <cc1:TabContainer ID="TabContainer" CssClass="CustomTabStyle" runat="server" ActiveTabIndex="0">
                <cc1:TabPanel ID="TabPanel1" runat="server">
                    <HeaderTemplate>
                        <table style="background-color: #93BC0C; color: White; font-size: medium; padding: 10px;">
                            <tr>
                                <td style="padding: 10px;">
                                    <b>Create Bundled Offer</b>
                                </td>
                            </tr>
                        </table>
                    </HeaderTemplate>
                    <ContentTemplate>
                        <uc1:EditBundledOrder ID="EditBundledOrder" runat="server" />
                    </ContentTemplate>
                </cc1:TabPanel>
                <cc1:TabPanel ID="TabPanel2" runat="server">
                    <HeaderTemplate>
                        <table style="background-color: #93BC0C; color: White; font-size: medium;">
                            <tr>
                                <td style="padding: 10px;">
                                    <b>Maintain Offer Qualification Items</b>
                                </td>
                            </tr>
                        </table>
                    </HeaderTemplate>
                    <ContentTemplate>
                        <uc2:MaintainOfferQualiicationItems ID="MaintainOfferQualiicationItems" runat="server" />
                    </ContentTemplate>
                </cc1:TabPanel>
                <cc1:TabPanel ID="TabPanel3" runat="server">
                    <HeaderTemplate>
                        <table style="background-color: #93BC0C; color: White; font-size: medium; padding: 10px;">
                            <tr>
                                <td style="padding: 10px;">
                                    <b>Maintain Offer Items</b>
                                </td>
                            </tr>
                        </table>
                    </HeaderTemplate>
                    
                    <ContentTemplate>
                        <uc3:MaintainOfferItems ID="MaintainOfferItems" runat="server" />
                    </ContentTemplate>
                </cc1:TabPanel>
            </cc1:TabContainer>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
