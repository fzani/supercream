<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SaveCreditNoteControl.ascx.cs"
    Inherits="Controls_SaveCreditNoteControl" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<div class="FormInput">
    <fieldset id="Fieldset3">
        <asp:Panel ID="CreditNoteSavePanel" DefaultButton="SaveButton" runat="server">
            <h2>
                Credit Note &nbsp;
                <asp:Label ID="creditNoteLabel" Text="<>" runat="server"></asp:Label>
            </h2>
            <legend>
                <h3>
                    Save Credit Note</h3>
            </legend>
            <table style="width: 100%">
                <tr>
                    <td style="width: 30%">
                        Total Invoice Amount
                    </td>
                    <td style="width: 70%">
                        <asp:Label ID="TotalInvoiceAmountLabel" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        Invoice Amount so far credited
                    </td>
                    <td>
                        <asp:Label ID="InvoiceAmountCreditedLabel" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        Invoice Amount available to be credited
                    </td>
                    <td>
                        <asp:Label ID="AmountAvailableToBeCreditedLabel" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        Amount to credit
                    </td>
                    <td>
                        <asp:TextBox ID="AmountToCreditTextBox" runat="server" MaxLength="8" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ValidationGroup="SaveCreditNoteGroup"
                            ControlToValidate="AmountToCreditTextBox" ErrorMessage="Amount to credit is a required field"
                            InitialValue="" Text="Required" runat="server" />
                        <ajaxToolkit:FilteredTextBoxExtender TargetControlID="AmountToCreditTextBox" FilterType="Custom, Numbers"
                            ValidChars="£,." runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        Vat Exempt
                    </td>
                    <td>
                        <asp:CheckBox ID="VatExemptCheckBox" runat="server" MaxLength="8" />
                    </td>
                </tr>
                <tr>
                    <td>
                        Reason
                    </td>
                    <td>
                        <asp:TextBox ID="ReasonTextBox" Width="90%" Rows="6" TextMode="MultiLine" runat="server" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="SaveCreditNoteGroup"
                            ControlToValidate="ReasonTextBox" ErrorMessage="Reason is a required field" InitialValue=""
                            Text="Required" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        <asp:Button ID="SaveButton" runat="server" ValidationGroup="SaveCreditNoteGroup"
                            Text="Save" Width="20%" OnClick="SaveButton_Click" />
                        <asp:Button ID="DeleteButton" runat="server" ValidationGroup="SaveCreditNoteGroup"
                            Text="Delete" Width="20%" OnClick="DeleteButton_Click" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </fieldset>
</div>
