<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ErrorView.ascx.cs" Inherits="Controls_ErrorView" %>
<div class="mError">
    <h3>
        Error Message
    </h3>
    <asp:Repeater ID="ErrorMesssages" runat="server" EnableViewState="False">
        <HeaderTemplate>
            <ul class="mError">
        </HeaderTemplate>
        <ItemTemplate>
            <li>
                <%# Eval("Description") %>
            </li>
        </ItemTemplate>
        <FooterTemplate>
            </ul></FooterTemplate>
    </asp:Repeater>
</div>
