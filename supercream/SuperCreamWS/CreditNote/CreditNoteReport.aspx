<%@ Page Title="" Language="C#" MasterPageFile="~/SingleColumnMasterPage.master" AutoEventWireup="true" StylesheetTheme="SuperCreamReports"
     CodeFile="CreditNoteReport.aspx.cs" Inherits="CreditNote_CreditNoteReport" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainPlaceholder" Runat="Server">   
    <rsweb:ReportViewer ID="CreditNoteReportViewer" Style="width: 100%;" runat="server"
        Font-Names="Verdana" Font-Size="8pt" Height="400px" Width="400px">
        <LocalReport ReportPath="PrintArbitraryCreditNote.rdlc">            
        </LocalReport>
    </rsweb:ReportViewer>
</asp:Content>

