<%@ Control Language="C#" AutoEventWireup="true" CodeFile="NewSpecialInvoiceCreditNote.ascx.cs"
    Inherits="Controls_NewSpecialInvoiceCreditNote" %>
<%@ Register Src="SaveSpecialInvoiceCreditNoteControl.ascx" TagName="SaveSpecialInvoiceCreditNoteControl"
    TagPrefix="uc2" %>
<%@ Register Src="NewSpecialInvoiceCreditNoteSearch.ascx" TagName="NewSpecialInvoiceCreditNoteSearch"
    TagPrefix="uc3" %>
<uc3:NewSpecialInvoiceCreditNoteSearch ID="NewSpecialInvoiceCreditNoteSearch" runat="server" />
<uc2:SaveSpecialInvoiceCreditNoteControl ID="SaveSpecialInvoiceCreditNoteControl"
    runat="server" />
<div class="FormInput">
    <fieldset id="Fieldset3" style="padding: 10px 0px 10px 0px;">
        <asp:Button ID="CancelButton" Text="Cancel" Width="200px" runat="server" OnClick="CancelButton_Click" />
    </fieldset>
</div>
