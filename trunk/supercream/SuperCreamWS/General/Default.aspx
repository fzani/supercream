<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="_Default" StylesheetTheme="SuperCream" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainPlaceholder" runat="Server">
    <a name="General Info"></a>
    <h2>
        <a href="Default.aspx">Welcome to Super Cream Order Processing</a></h2>
    <p>
        <asp:Image ImageUrl="~/images/IceCream.jpg" Style="float: left; margin: 5px;" runat="server" />
        <strong>Super Cream Order Processing 1.2</strong> is a bespoke order Processing
        System designed for use by <strong><a href="http://www.styleshout.com/">Alterax.com</a></strong>.
        This work is distributed for express and sole use for SuperCream. The system provides
        Sales Order Processing services for an SME based Ice Cream Company, dealing with
        Ordering, Invoicing and Customer Mangement.
    </p>
    <p>
        The system has been developed by Alterax, a company specialising in bespoke and
        consultancy services for various companies throughout the U.K. and is supported
        by Spring Computers. Please look use the Support menu item for contact details.</p>
    <p>
        The system has been fully tested against Internet Explorer versions 7. and 8. and
        as such is recommended for use against these versions.
    </p>
    <blockquote>
        <asp:Image ID="Image1" ImageUrl="~/images/SuperCreamWayForWard.jpg" Style="float: right;
            margin: 20px;" runat="server" />
        <p>
            Please note:- The current release is a Release Candidate 2 version of this system,
            and as such does not represent the final version of this product. Please note the
            next release is imminent and will constitute the final release version of the product.
        </p>
        <p>
            The current version is therefore to be treated as a test release version, all data
            entered will be wound back on confirmation of delivery.
        </p>
    </blockquote>
</asp:Content>
