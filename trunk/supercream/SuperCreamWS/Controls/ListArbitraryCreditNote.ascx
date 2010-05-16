<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ListArbitraryCreditNote.ascx.cs"
    Inherits="Controls_ListArbitraryCreditNote" %>
<div class="FormInput">
    <fieldset id="Fieldset3" style="padding: 10px 0px 10px 0px;">
        <asp:ListView ID="lvItemsTable" runat="server" DataSourceID="ObjectDataSource1" ItemContainerID="layoutTableTemplate"
            OnItemDataBound="lvItemsTable_ItemDataBound">
            <LayoutTemplate>
                <div class="blackborder" style="width: 100%;">
                    <table cellpadding="5">
                        <thead style="position: relative;">
                            <tr class="gridheader" style="height: 30px;">
                                <th style="position: relative">
                                    Reference
                                </th>
                                <th style="position: relative">
                                    DateCreated
                                </th>
                                <th style="position: relative">
                                    DueDate
                                </th>
                                <th>
                                    Credit Net Amount
                                </th>
                                <th>
                                    VatExempt
                                </th>
                                <th>
                                    Credit Amount
                                </th>
                            </tr>
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
                    <td valign="top">
                        <%# Eval("CreditAmount","{0:c}")%>
                    </td>
                    <td valign="top">
                        <asp:Label ID="VatExemptLabel" runat="server"></asp:Label>
                    </td>
                    <td valign="top">
                        <asp:Label ID="TotalCreditAmountLabel" runat="server"></asp:Label>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}"
            OnSelecting="ObjectDataSource1_Selecting" SelectMethod="GetCreditNotesByOrderId"
            TypeName="CreditNoteUI">
            <SelectParameters>
                <asp:Parameter Name="orderId" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </fieldset>
</div>
