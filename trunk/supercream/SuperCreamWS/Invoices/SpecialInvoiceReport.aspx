<%@ Page Title="" Language="C#" MasterPageFile="~/SingleColumnMasterPage.master" AutoEventWireup="true" 
    CodeFile="SpecialInvoiceReport.aspx.cs" StylesheetTheme="SuperCreamReports" Inherits="Invoices_SpecialInvoiceReport" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainPlaceholder" Runat="Server">
    
     
    
    <rsweb:ReportViewer ID="SpecialInvoiceReportViewer" style="width:100%;" runat="server" 
        Font-Names="Verdana" Font-Size="8pt" Height="400px" Width="400px">
        <LocalReport ReportPath="SpecialInvoice.rdlc">
            <DataSources>
                <rsweb:ReportDataSource DataSourceId="SpecialInvoiceObjectDataSource" 
                    Name="SuperCreamDBDataSet_rptGetSpecialInvoiceDetails" />
            </DataSources>
        </LocalReport>
    </rsweb:ReportViewer>
    
     
    
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
        SelectMethod="GetData" TypeName="SuperCreamDBDataSetTableAdapters.">
    </asp:ObjectDataSource>
    
     
    
</asp:Content>

