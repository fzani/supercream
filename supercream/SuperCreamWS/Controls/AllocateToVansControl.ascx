<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AllocateToVansControl.ascx.cs"
    Inherits="Controls_AllocateToVansControl" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<div class="FormInput">
    <fieldset id="Fieldset3">
        <legend><b>Van Realocation for Pick Lists</b></legend>
        <table style="width: 95%">
            <tr>
                <td colspan="3">
                    <b>Select Date</b>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:Calendar ID="SelectedDateCalendar" runat="server" OnSelectionChanged="SelectedDateCalendar_SelectionChanged">
                    </asp:Calendar>
                </td>
            </tr>
            <tr>
                <td style="width: 45%">
                    <b>Van Allocation From</b>
                </td>
                <td style="width: 10%">
                </td>
                <td style="width: 45%">
                    <b>Van Allocation To</b>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:DropDownList ID="VanAllocatedFrom" Width="100%" runat="server" AutoPostBack="True"
                        OnSelectedIndexChanged="VanAllocatedFrom_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
                <td>
                </td>
                <td>
                    <asp:DropDownList ID="VanAllocatedTo" Width="100%" runat="server" AutoPostBack="True"
                        OnSelectedIndexChanged="VanAllocatedTo_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:ListBox ID="VanAllocatedFromListBox" DataTextField="InvoiceNo" DataValueField="ID"
                        Height="200px" Width="100%" runat="server" DataSourceID="VanAllocatedFromObjectDataSource">
                    </asp:ListBox>
                    <div style="text-align: left">
                        <ajaxToolkit:ListSearchExtender ID="ListSearchExtender1" runat="server" QueryTimeout="2000"
                            QueryPattern="Contains" TargetControlID="VanAllocatedFromListBox" PromptCssClass="ListSearchExtenderPrompt"
                            IsSorted="true">
                        </ajaxToolkit:ListSearchExtender>
                        <asp:ObjectDataSource ID="VanAllocatedFromObjectDataSource" runat="server" OldValuesParameterFormatString="original_{0}"
                            OnSelecting="VanAllocatedFromObjectDataSource_Selecting" SelectMethod="GetInvoicesByVanAndDate"
                            TypeName="OrderNotesStatusUI">
                            <SelectParameters>
                                <asp:Parameter Name="deliveryDate" Type="DateTime" />
                                <asp:Parameter Name="vanId" Type="Int32" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                    </div>
                </td>
                <td>
                    <div style="vertical-align: middle">
                        <table>
                            <tr>
                                <td>
                                    <asp:Button ID="MoveToButton" Text=">>" runat="server" OnClick="MoveToButton_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Button ID="MoveFromButton" Text="<<" runat="server" OnClick="MoveFromButton_Click" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
                <td>
                    <asp:ListBox ID="VanAllocatedToListBox" DataTextField="InvoiceNo" DataValueField="ID"
                        Height="200px" Width="100%" runat="server" DataSourceID="VanAllocatedToObjectDataSource">
                    </asp:ListBox>
                    <div style="text-align: left">
                        <ajaxToolkit:ListSearchExtender ID="ListSearchExtender2" runat="server" QueryTimeout="2000"
                            QueryPattern="Contains" TargetControlID="VanAllocatedToListBox" PromptCssClass="ListSearchExtenderPrompt"
                            IsSorted="true">
                        </ajaxToolkit:ListSearchExtender>
                        <asp:ObjectDataSource ID="VanAllocatedToObjectDataSource" runat="server" OldValuesParameterFormatString="original_{0}"
                            OnSelecting="VanAllocatedToObjectDataSource_Selecting" SelectMethod="GetInvoicesByVanAndDate"
                            TypeName="OrderNotesStatusUI">
                            <SelectParameters>
                                <asp:Parameter Name="deliveryDate" Type="DateTime" />
                                <asp:Parameter Name="vanId" Type="Int32" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                    </div>
                </td>
            </tr>
        </table>
    </fieldset>
    
    <fieldset>
        <h2>
            <legend>Invoices currently loaded for Van </legend>
        </h2>
        <asp:DataList ID="DataList1" runat="server" DataSourceID="VanCountObjectDataSource"
            Width="100%" RepeatDirection="Horizontal">
            <ItemTemplate>
                <asp:Label ID="VanDescriptionLabel" Font-Bold="true" runat="server" Text='<%# Eval("VanDescription") %>' />
                &nbsp;
                <i>Invoice count = </i>&nbsp;
                <asp:Label ID="Label1" runat="server" Text='<%# Eval("InvoiceCount") %>' />
            </ItemTemplate>
        </asp:DataList>
        <asp:ObjectDataSource ID="VanCountObjectDataSource" runat="server" OnSelecting="VanCountObjectDataSource_Selecting"
            SelectMethod="GetInvoiceCounts" TypeName="OrderNotesStatusUI">
            <SelectParameters>
                <asp:Parameter Name="deliveryDate" Type="DateTime" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </fieldset>
</div>
