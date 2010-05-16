<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ListOrderCreditNote.ascx.cs"
    Inherits="Controls_ListOrderCreditNote" %>
<div class="FormInput">
    <fieldset id="Fieldset3" style="padding: 10px 0px 10px 0px;">
        <asp:ListView ID="lvItemsTable" runat="server" DataSourceID="ObjectDataSource1" ItemContainerID="layoutTableTemplate"
            OnItemDataBound="lvItemsTable_ItemDataBound">
            <LayoutTemplate>
                <div class="blackborder" style="width: 100%;">
                    <table cellpadding="5">
                        <thead style="position: relative;">
                            <tr class="gridheader" style="height: 30px;">
                                <th style="position: relative; width: 25%;">
                                    Reference
                                </th>
                                <th style="position: relative; width: 15%;">
                                    DateCreated
                                </th>
                                <th style="position: relative; width: 15%;">
                                    DueDate
                                </th>
                                <th style="width: 45%;">
                                </th>
                        </thead>
                        <tbody id="layoutTableTemplate" runat="server" style="height: 470px; overflow: scroll;
                            overflow-x: hidden;">
                            <tr runat="server" id="itemPlaceholder">
                            </tr>
                        </tbody>
                    </table>
                </div>
            </LayoutTemplate>
            <ItemTemplate>
                <tr style="height: 0px;">
                    <td valign="top">
                        <%# Eval("Reference")%>
                    </td>
                    <td valign="top">
                        <%# Eval("DateCreated","{0:d}")%>
                    </td>
                    <td valign="top">
                        <%# Eval("DueDate","{0:d}")%>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td colspan="3">
                        <asp:Repeater ID="OrderCreditNoteDetailsRepeater" OnItemDataBound="OrderCreditNoteDetailsRepeater_OnItemDataBound"
                            runat="server">
                            <HeaderTemplate>
                                <table id="headerRepeaterTable" style="width: 100%; background: #eaeaea; margin: 0px;
                                    padding: 0px;" cellpadding="0" cellspacing="0" runat="server">
                                    <tr>
                                        <td style="width: 70%;">
                                            <b>Product</b>
                                        </td>
                                        <td style="width: 15%;">
                                            <b>No Of Units</b>
                                        </td>
                                        <td style="width: 15%;">
                                            <b>Price</b>
                                        </td>
                                    </tr>
                                </table>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <table style="width: 100%; background: #FFFFD4; margin: 0px; padding: 0px;" cellpadding="0"
                                    cellspacing="0">
                                    <tr>
                                        <td style="width: 70%;">
                                            <asp:Label ID="ProductNameLabel" runat="server"></asp:Label>
                                        </td>
                                        <td style="width: 15%; text-align: center;">
                                            <%# Eval("NoOfUnits","{0:d}")%>
                                        </td>
                                        <td style="width: 15%; text-align: center;">
                                            <%# Eval("Price","{0:c}")%>
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                            <AlternatingItemTemplate>
                                <table style="width: 100%; background: #ffffff margin: 0px; padding: 0px;" cellpadding="0"
                                    cellspacing="0">
                                    <tr>
                                        <td style="width: 70%;">
                                            <asp:Label ID="ProductNameLabel" runat="server"></asp:Label>
                                        </td>
                                        <td style="width: 15%; text-align: center;">
                                            <%# Eval("NoOfUnits","{0:d}")%>
                                        </td>
                                        <td style="width: 15%; text-align: center;">
                                            <%# Eval("Price","{0:c}")%>
                                        </td>
                                    </tr>
                                </table>
                            </AlternatingItemTemplate>
                        </asp:Repeater>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}"
            OnSelecting="ObjectDataSource1_Selecting" SelectMethod="GetOrderCreditNotesByOrderId"
            TypeName="OrderCreditNoteUI">
            <SelectParameters>
                <asp:Parameter Name="orderId" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </fieldset>
</div>
