<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MaintainSpecialInvoiceCreditNote.ascx.cs"
    Inherits="Controls_MaintainSpecialInvoiceCreditNote" %>
<%@ Register Src="SpecialInvoiceCreditNoteSearch.ascx" TagName="SpecialInvoiceCreditNoteSearch"
    TagPrefix="uc1" %>
<%@ Register Src="SaveSpecialInvoiceCreditNoteControl.ascx" TagName="SaveSpecialInvoiceCreditNoteControl" TagPrefix="uc2" %>
<uc1:SpecialInvoiceCreditNoteSearch ID="SpecialInvoiceCreditNoteSearch" runat="server" />
<uc2:SaveSpecialInvoiceCreditNoteControl ID="SaveSpecialInvoiceCreditNoteControl" runat="server" />
<div class="FormInput">
    <fieldset id="Fieldset3" style="padding: 10px 0px 10px 0px;">
        <asp:Button ID="CancelButton" Text="Cancel" Width="200px" runat="server" OnClick="CancelButton_Click" />
    </fieldset>
</div>
