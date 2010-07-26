<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="About.aspx.cs" Inherits="About" StylesheetTheme="SuperCream" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainPlaceholder" runat="Server">
    <p>
        The SuperCream Order Processing System was developed during the first quater of
        2009. The system has been developed using ASP.net 3.5 and uses LINQ to SQL for it's
        database access. All intellectual property rights remain the sole property of Alterax
        Ltd.
    </p>
    <asp:Image ID="Image1" ImageUrl="~/images/INPE0780.jpg" runat="server" Style="float: right; margin: 10px;" />
    <blockquote>
        <p>
            Alterax is a consultancy based software company based in the Midlands and specialising
            in ASP.net technologies. The Company has been in operation since 2008 and provides
            bespoke and freelance services to various companies throughout the U.K.
        </p>
    </blockquote>
</asp:Content>
