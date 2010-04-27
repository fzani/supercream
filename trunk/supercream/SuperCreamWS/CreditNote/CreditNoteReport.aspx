<%@ Page Title="" Language="C#" MasterPageFile="~/SingleColumnMasterPage.master" AutoEventWireup="true" CodeFile="CreditNoteReport.aspx.cs" Inherits="CreditNote_CreditNoteReport" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainPlaceholder" Runat="Server">
    <rsweb:ReportViewer ID="ReportViewer1" runat="server">
    </rsweb:ReportViewer>
</asp:Content>

