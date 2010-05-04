<%@ Control Language="C#" AutoEventWireup="true" CodeFile="NewOrderCreditNote.ascx.cs"
    Inherits="Controls_NewOrderCreditNote" %>
<%@ Register Src="OrderCreditNoteHeader.ascx" TagName="OrderCreditNoteHeader" TagPrefix="uc2" %>
<%@ Register Src="NewCreditNoteSearch.ascx" TagName="NewCreditNoteSearch" TagPrefix="uc3" %>
<%@ Register Src="ModifyOrderCreditNoteLines.ascx" TagName="ModifyOrderCreditNoteLines"
    TagPrefix="uc1" %>
<uc3:NewCreditNoteSearch ID="NewCreditNoteSearch" runat="server" />
<uc2:OrderCreditNoteHeader ID="OrderCreditNoteHeader" runat="server" />
<uc1:ModifyOrderCreditNoteLines ID="ModifyOrderCreditNoteLines" runat="server"></uc1:ModifyOrderCreditNoteLines>
<div class="FormInput">
    <fieldset id="Fieldset3" style="padding: 10px 0px 10px 0px;">
        <asp:Button ID="CancelButton" Text="Cancel" Width="200px" runat="server" OnClick="CancelButton_Click" />
    </fieldset>
</div>
