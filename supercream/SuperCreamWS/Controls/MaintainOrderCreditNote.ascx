<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MaintainOrderCreditNote.ascx.cs"
    Inherits="Controls_MaintainOrderCreditNote" %>
<%@ Register Src="OrderCreditNoteSearch.ascx" TagName="CreditNoteSearch" TagPrefix="uc1" %>
<%@ Register Src="OrderCreditNoteHeader.ascx" TagName="OrderCreditNoteHeader" TagPrefix="uc2" %>
<%@ Register Src="ModifyOrderCreditNoteLines.ascx" TagName="ModifyOrderCreditNoteLines"
    TagPrefix="uc3" %>
<uc1:CreditNoteSearch ID="CreditNoteSearch" runat="server" />
<uc2:OrderCreditNoteHeader ID="OrderCreditNoteHeader" runat="server" />
<uc3:ModifyOrderCreditNoteLines ID="ModifyOrderCreditNoteLines" runat="server" />
<div class="FormInput">
    <fieldset id="Fieldset3" style="padding: 10px 0px 10px 0px;">
        <asp:Button ID="CancelButton" Text="Cancel" Width="200px" runat="server" OnClick="CancelButton_Click" />
    </fieldset>
</div>
