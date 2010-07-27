<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="SetupPrinter.aspx.cs" Inherits="Admin_SetupPrinter" StylesheetTheme="SuperCream" %>

<%@ Register Src="../Controls/ErrorView.ascx" TagName="ErrorView" TagPrefix="Alterax" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainPlaceholder" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="ErrorUpdatePanel" runat="server" UpdateMode="Conditional">
        <Triggers>
            <asp:PostBackTrigger ControlID="UpdateButton" />
        </Triggers>
        <ContentTemplate>
            <div class="ErrorOutput">
                <Alterax:ErrorView ID="ErrorViewControl" Visible="false" runat="server" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="SetPrinterUpdatePanel" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <asp:Panel ID="SetPrinterPanel" DefaultButton="UpdateButton" Visible="true" runat="server">
                <div class="FormHeader">
                    <fieldset>
                        <legend>
                            <h3>
                                Setup Printer
                            </h3>
                        </legend>
                        <table style="width: 100%">
                            <tr>
                                <td style="width: 20%">
                                    <asp:Label Text="Printer Name" runat="server"></asp:Label>
                                </td>
                                <td style="width: 80%">
                                    <asp:TextBox ID="PrinterNameTextBox" Width="400px" MaxLength="50" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                    <asp:Button ID="UpdateButton" Text="Update" Width="150px" runat="server" OnClick="UpdateButton_Click" />
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                </div>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
