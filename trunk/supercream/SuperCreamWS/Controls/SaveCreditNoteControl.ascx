<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SaveCreditNoteControl.ascx.cs"
    Inherits="Controls_SaveCreditNoteControl" %>
<div class="FormInput">
    <fieldset id="Fieldset3">
        <asp:Panel ID="CreditNoteSavePanel" DefaultButton="SaveButton" runat="server">
            <legend>
                <h3>
                    Save Credit Note</h3>
            </legend>
            <table style="width: 100%">
                <tr>
                    <td style="width: 25%">
                        Total Invoice Amount
                    </td>
                    <td style="width: 75%">
                        <asp:Label ID="TotalInvoiceAmountLabel" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        Invoice Amount so far credited
                    </td>
                    <td>
                        <asp:Label ID="InvoiceAnountCreditedLabel" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        Amount to credit
                    </td>
                    <td>
                        <asp:TextBox ID="AmountToCreditTextBox" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        Reason
                    </td>
                    <td>
                        <asp:TextBox ID="ReasonTextBox" Width="60%" Rows="6" TextMode="MultiLine" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        <asp:Button ID="SaveButton" runat="server" Text="Save" Width="20%" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </fieldset>
</div>
