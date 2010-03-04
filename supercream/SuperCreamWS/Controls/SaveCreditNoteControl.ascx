<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SaveCreditNoteControl.ascx.cs"
    Inherits="Controls_SaveCreditNoteControl" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

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
                        <asp:Label ID="InvoiceAmountCreditedLabel" runat="server" />
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
                        <ajaxToolkit:FilteredTextBoxExtender  TargetControlID="AmountToCreditTextBox" FilterType="Custom, Numbers"
                            ValidChars="£,." runat="server" />

                    </td>
                </tr>
                <tr>
                    <td>
                        Reason
                    </td>
                    <td>
                        <asp:TextBox ID="ReasonTextBox" Width="60%" Rows="6" TextMode="MultiLine" runat="server" />
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="SaveCreditNoteGroup"
                            ControlToValidate="ReasonTextBox" ErrorMessage="Reason is a required field"
                            InitialValue="" Text="Required" runat="server" />                 
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        <asp:Button ID="SaveButton" runat="server" ValidationGroup="SaveCreditNoteGroup"
                            Text="Save" Width="20%" onclick="SaveButton_Click" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </fieldset>
</div>
