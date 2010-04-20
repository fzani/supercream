﻿<%@ Control Language="C#" AutoEventWireup="true" CodeFile="NewCreditNote.ascx.cs"
    Inherits="Controls_NewCreditNote" %>

<%@ Register Src="SaveCreditNoteControl.ascx" TagName="SaveCreditNoteControl"
    TagPrefix="uc2" %>    
<%@ Register src="NewCreditNoteSearch.ascx" tagname="NewCreditNoteSearch" tagprefix="uc3" %>
    
<uc3:NewCreditNoteSearch ID="NewCreditNoteSearch" runat="server" />
<uc2:SaveCreditNoteControl ID="SaveCreditNoteControl" runat="server" />

<div class="FormInput">
    <fieldset id="Fieldset3" style="padding: 10px 0px 10px 0px;">
        <asp:Button ID="CancelButton" Text="Cancel" Width="200px" runat="server" 
            onclick="CancelButton_Click" />
    </fieldset>
</div>