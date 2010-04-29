<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MaintainOrderCreditNote.ascx.cs"
    Inherits="Controls_MaintainOrderCreditNote" %>
<%@ Register Src="CreditNoteSearch.ascx" TagName="CreditNoteSearch" TagPrefix="uc1" %>
<%@ Register Src="SaveCreditNoteControl.ascx" TagName="SaveCreditNoteControl" TagPrefix="uc2" %>

<uc1:CreditNoteSearch ID="CreditNoteSearch" runat="server" />

<uc2:SaveCreditNoteControl ID="SaveCreditNoteControl" runat="server" />
<div class="FormInput">
    <fieldset id="Fieldset3" style="padding: 10px 0px 10px 0px;">
        <asp:Button ID="CancelButton" Text="Cancel" Width="200px" runat="server" OnClick="CancelButton_Click" />
    </fieldset>
</div>
