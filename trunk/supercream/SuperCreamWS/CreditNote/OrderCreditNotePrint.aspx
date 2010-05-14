<%@ Page Title="" Language="C#" MasterPageFile="~/SingleColumnMasterPage.master"
    AutoEventWireup="true" StylesheetTheme="SuperCreamReports" CodeFile="OrderCreditNotePrint.aspx.cs"
    Inherits="OrderCreditNote_Print" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainPlaceholder" runat="Server">
    <div style="text-align: right; padding-right: 20px; font-size: 14px;">
        <asp:HyperLink ID="RedirectLinkButton" Text="Return to main menu" NavigateUrl="~/Default.aspx"
            runat="server"></asp:HyperLink>
    </div>
    <rsweb:ReportViewer ID="CreditNoteReportViewer" Style="width: 100%;" runat="server"
        Font-Names="Verdana" Font-Size="8pt" Height="400px" Width="400px">
        <LocalReport ReportPath="OrderCreditNote.rdlc">
        </LocalReport>
    </rsweb:ReportViewer>
</asp:Content>
