<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="CreditNote.aspx.cs" StylesheetTheme="SuperCream" Inherits="CreditNote_CreditNote" %>

<%@ Register Src="~/Controls/ErrorView.ascx" TagName="ErrorView" TagPrefix="Alterax" %>
<%@ Register Src="../Controls/NewCreditNote.ascx" TagName="NewCreditNote" TagPrefix="uc1" %>

<%@ Register src="../Controls/MaintainCreditNote.ascx" tagname="MaintainCreditNote" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainPlaceholder" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
           
    <asp:UpdatePanel ID="ErrorUpdatePanel" runat="server" UpdateMode="Conditional">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="NewCreditNote" />
            <asp:AsyncPostBackTrigger ControlID="MaintainCreditNote" />  
        </Triggers>
        <ContentTemplate>
            <div class="ErrorOutput">
                <alterax:errorview id="ErrorViewControl" visible="false" runat="server" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    
     <asp:UpdatePanel ID="CreditNoteUpdatePanel" runat="server" UpdateMode="Conditional">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="NewCreditNote" />
            <asp:AsyncPostBackTrigger ControlID="MaintainCreditNote" />            
        </Triggers>
        <ContentTemplate>
            <asp:Panel ID="CreditNoteMenuPanel" DefaultButton="NewCreditNoteButton" runat="server">
                <div class="FormInput" style="text-align: center;">
                    <fieldset id="Fieldset1">
                        <legend>
                            <h3>
                                Credit Note Maintenance</h3>
                        </legend>
                        <table style="width: 100%">
                            <tr>
                                <td>
                                    <asp:Button ID="NewCreditNoteButton" Text="New Credit Note" runat="server" 
                                        onclick="NewCreditNoteButton_Click" />
                                </td>
                                <td>
                                    <asp:Button ID="MaintainCreditNoteButton" Text="Modify Credit Note" 
                                        runat="server" onclick="MaintainCreditNoteButton_Click"  />
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                </div>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    
    <asp:UpdatePanel ID="NewCreditNoteUpdatePanel" runat="server" UpdateMode="Conditional">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="NewCreditNoteButton" />
             <asp:AsyncPostBackTrigger ControlID="MaintainCreditNoteButton" />
        </Triggers>
        <ContentTemplate>           
            <uc2:MaintainCreditNote ID="MaintainCreditNote" runat="server" />
            <uc1:NewCreditNote ID="NewCreditNote" runat="server" />           
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
