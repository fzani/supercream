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
                    <asp:DropDownList ID="VanAllocatedFrom" Width="100%" runat="server">
                    </asp:DropDownList>
                </td>
                <td>
                </td>
                <td>
                    <asp:DropDownList ID="VanAllocatedTo" Width="100%" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:ListBox ID="VanAllocatedFromListBox" DataTextField="Description" DataValueField="ID"
                        Height="200px" Width="100%" runat="server"></asp:ListBox>
                    <div style="text-align: left">
                        <ajaxToolkit:ListSearchExtender ID="ListSearchExtender1" runat="server" QueryTimeout="2000"
                            QueryPattern="Contains" TargetControlID="VanAllocatedFromListBox" PromptCssClass="ListSearchExtenderPrompt"
                            IsSorted="true">
                        </ajaxToolkit:ListSearchExtender>
                    </div>
                </td>
                <td>
                    <div style="vertical-align: middle">
                        <table>
                            <tr>
                                <td>
                                    <asp:Button ID="MoveToButton" Text=">>" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Button ID="MoveFromButton" Text="<<" runat="server" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
                <td>
                    <asp:ListBox ID="VanAllocatedToListBox" DataTextField="Description" DataValueField="ID"
                        Height="200px" Width="100%" runat="server"></asp:ListBox>
                    <div style="text-align: left">
                        <ajaxToolkit:ListSearchExtender ID="ListSearchExtender2" runat="server" QueryTimeout="2000"
                            QueryPattern="Contains" TargetControlID="VanAllocatedToListBox" PromptCssClass="ListSearchExtenderPrompt"
                            IsSorted="true">
                        </ajaxToolkit:ListSearchExtender>
                    </div>
                </td>
            </tr>
        </table>
    </fieldset>
</div>
