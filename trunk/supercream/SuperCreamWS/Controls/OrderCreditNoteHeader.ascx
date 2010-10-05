<%@ Control Language="C#" AutoEventWireup="true" CodeFile="OrderCreditNoteHeader.ascx.cs" Inherits="Controls_OrderCreditNoteHeader" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<div class="FormInput">
    <fieldset id="Fieldset3">
        <asp:Panel ID="OrderCreditNoteHeaderPanel" DefaultButton="ContinueButton" runat="server">
            <h2>
                Credit Note &nbsp;
                <asp:Label ID="creditNoteLabel" Text="<>" runat="server"></asp:Label>
            </h2>
            <legend>
                <h3>
                   Credit Note Header Details</h3>
            </legend>
            <table style="width: 100%">
                <tr>
                    <td style="width: 40%">
                        Total Invoice Amount
                    </td>
                    <td style="width: 60%">
                        <asp:Label ID="TotalInvoiceAmountLabel" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        Invoice Amount so far credited (incl Vat.)
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
                        Credit Note Raised Date
                    </td>
                    <td>
                        <asp:TextBox ID="DueDateTextBox" Style="vertical-align: middle;" runat="server" ValidationGroup="SaveCreditNoteGroup"
                            MaxLength="100" Width="100px"></asp:TextBox>
                        <asp:Image runat="Server" Style="vertical-align: middle;" ID="Image1" ImageUrl="~/images/Calendar_scheduleHS.png"
                            AlternateText="Click to show calendar" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="SaveCreditNoteGroup"
                            ControlToValidate="DueDateTextBox" ErrorMessage="Due Date is required" InitialValue=""
                            Text="Required" runat="server" />
                        <ajaxToolkit:CalendarExtender ID="calendarButtonExtender" Format="dd/MM/yyyy" runat="server"
                            TargetControlID="DueDateTextBox" PopupButtonID="Image1" />
                         <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="DueDateTextBox"
                                            Mask="99/99/9999" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                                            OnInvalidCssClass="MaskedEditError" MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" />
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
                        <asp:Button ID="ContinueButton" runat="server" ValidationGroup="SaveCreditNoteGroup"
                            Text="Continue" Width="20%" OnClick="ContinueButton_Click" />                      
                        <asp:Button ID="DeleteButton" runat="server" ValidationGroup="SaveCreditNoteGroup"
                            Text="Delete" Width="20%" OnClick="DeleteButton_Click" />
                        <asp:Button ID="PrintButton" OnClick="PrintButton_Click" runat="server" Text="Print" Visible="false" Width="20%" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
        
        <asp:Button ID="btnTrigger1" runat="server" Style="display: none" />
        <ajaxToolkit:ModalPopupExtender ID="ReasonForVoidingPopupExtenderInvoice" DropShadow="true"
                                runat="server" TargetControlID="btnTrigger1" PopupControlID="ReasonForVoidingPanelMessage"
                                CancelControlID="CancelReasonorVoidingButton" BackgroundCssClass="XPopUpBackGround" />
       
        <asp:Panel Style="display: none" DefaultButton="ReasonforVoidingButton" Width="700px"
            ID="ReasonForVoidingPanelMessage" runat="server" CssClass="modalPopup">
            <table>
                <tr>
                    <td style="width: 30%">
                        <h3>
                            Reason for Voiding Credit Note</h3>
                    </td>
                    <td>
                        <asp:TextBox ID="ReasonforVoidingTextBox" Width="100%" Height="300px" TextMode="MultiLine"
                            runat="server" ValidationGroup="VoidOrderDetailsGroup"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1ReasonForVoiding" Display="Dynamic"
                            ValidationGroup="VoidOrderDetailsGroup" ControlToValidate="ReasonforVoidingTextBox"
                            InitialValue="" ErrorMessage="Invoice to is a required Field" Text="*" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="ReasonforVoidingButton" CommandArgument='<%# OrderID %>' Text="Void Order"
                            runat="server" OnClick="VoidOrderButton_Click" ValidationGroup="VoidOrderDetailsGroup" />
                        <asp:Button ID="CancelReasonorVoidingButton" Text="Cancel" CausesValidation="false"
                            runat="server" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </fieldset>
</div>
