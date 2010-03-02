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
                    <asp:DropDownList ID="VanAllocatedFrom" Width="100%" runat="server" 
                        AutoPostBack="True" 
                        onselectedindexchanged="VanAllocatedFrom_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
                <td>
                </td>
                <td>
                    <asp:DropDownList ID="VanAllocatedTo" Width="100%" runat="server" 
                        AutoPostBack="True" 
                        onselectedindexchanged="VanAllocatedTo_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:ListBox ID="VanAllocatedFromListBox" DataTextField="InvoiceNo" DataValueField="ID"
                        Height="200px" Width="100%" runat="server" 
                        DataSourceID="VanAllocatedFromObjectDataSource"></asp:ListBox>
                    <div style="text-align: left">
                        <ajaxToolkit:ListSearchExtender ID="ListSearchExtender1" runat="server" QueryTimeout="2000"
                            QueryPattern="Contains" TargetControlID="VanAllocatedFromListBox" PromptCssClass="ListSearchExtenderPrompt"
                            IsSorted="true">
                        </ajaxToolkit:ListSearchExtender>
                        <asp:ObjectDataSource ID="VanAllocatedFromObjectDataSource" runat="server" 
                            OldValuesParameterFormatString="original_{0}" 
                            onselecting="VanAllocatedFromObjectDataSource_Selecting" 
                            SelectMethod="GetInvoicesByVanAndDate" TypeName="OrderNotesStatusUI">
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
                                    <asp:Button ID="MoveToButton" Text=">>" runat="server" 
                                        onclick="MoveToButton_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Button ID="MoveFromButton" Text="<<" runat="server" 
                                        onclick="MoveFromButton_Click" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
                <td>
                    <asp:ListBox ID="VanAllocatedToListBox" DataTextField="InvoiceNo" DataValueField="ID"
                        Height="200px" Width="100%" runat="server" 
                        DataSourceID="VanAllocatedToObjectDataSource"></asp:ListBox>
                    <div style="text-align: left">
                        <ajaxToolkit:ListSearchExtender ID="ListSearchExtender2" runat="server" QueryTimeout="2000"
                            QueryPattern="Contains" TargetControlID="VanAllocatedToListBox" PromptCssClass="ListSearchExtenderPrompt"
                            IsSorted="true">
                        </ajaxToolkit:ListSearchExtender>
                        <asp:ObjectDataSource ID="VanAllocatedToObjectDataSource" runat="server" 
                            OldValuesParameterFormatString="original_{0}" 
                            onselecting="VanAllocatedToObjectDataSource_Selecting" 
                            SelectMethod="GetInvoicesByVanAndDate" TypeName="OrderNotesStatusUI">
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
</div>
