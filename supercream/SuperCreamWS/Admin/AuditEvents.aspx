<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" StylesheetTheme="SuperCream" AutoEventWireup="true" CodeFile="AuditEvents.aspx.cs" Inherits="Admin_AuditEvents" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>
<%@ Register Src="~/Controls/ErrorView.ascx" TagName="ErrorView" TagPrefix="Alterax" %>
<%@ Register Assembly="AlteraxWebControls" Namespace="AlteraxWebControls" TagPrefix="Alterax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainPlaceholder" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="ErrorUpdatePanel" runat="server" UpdateMode="Conditional">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="AuditEventsGridView" />
            <asp:AsyncPostBackTrigger ControlID="SearchButton" />
            <asp:AsyncPostBackTrigger ControlID="LoginIDDropDownList" />
            <asp:AsyncPostBackTrigger ControlID="DescriptionDropDownList" />
        </Triggers>
        <ContentTemplate>
            <div class="ErrorOutput">
                <Alterax:ErrorView ID="ErrorViewControl" Visible="false" runat="server" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="AuditEventsUpdatePanel" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="HeaderPanel" DefaultButton="SearchButton" runat="server">
                <div class="FormHeader">
                    <div class="HeaderContainerPanel">
                        <table style="width: 100%">
                            <tr>
                                <td style="width: 30%; vertical-align: top; text-align: left;">
                                    <span class="RequiredFieldMessage">*</span> <i>indicates a required field</i>
                                </td>
                                <td class="Right">
                                    <table>
                                        <tr>
                                            <td>
                                                <i>Username</i>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="LoginIDDropDownList" Width="300px" Style="margin-right: 20px"
                                                    runat="server" AutoPostBack="True" OnSelectedIndexChanged="LoginIDDropDownList_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <i>Description</i>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="DescriptionDropDownList" Width="300px" Style="margin-right: 20px"
                                                    runat="server" AutoPostBack="True" OnSelectedIndexChanged="DescriptionDropDownList_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <i>Created Date</i>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="CreatedDateTextBox" MaxLength="8" Style="vertical-align: middle;"
                                                    Width="297px" runat="server"></asp:TextBox>
                                                <asp:Image runat="Server" Style="vertical-align: middle;" ID="Image1" ImageUrl="~/images/Calendar_scheduleHS.png"
                                                    AlternateText="Click to show calendar" />
                                                <ajaxtoolkit:CalendarExtender ID="calendarButtonExtender" Format="dd/MM/yyyy" runat="server"
                                                    TargetControlID="CreatedDateTextBox" PopupButtonID="Image1" />
                                                <ajaxtoolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="CreatedDateTextBox"
                                                    Mask="99/99/9999" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                                                    OnInvalidCssClass="MaskedEditError" MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:LinkButton ID="SearchButton" Text="Search" runat="server" OnClick="SearchButton_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </asp:Panel>
            <div class="FormHeader">
                <h3>
                    View Audit Trail</h3>
            </div>
            <div class="FormInput">
                <Alterax:PagingGridView ID="AuditEventsGridView" runat="server" AllowPaging="True"
                    PageSize="8" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" 
                    PagerSettings-PageButtonCount="5"
                    PagerSettings-Visible="true" 
                    PagerSettings-Position="TopAndBottom" 
                    PagerSettings-Mode="NumericFirstLast"
                    Width="100%" OnRowDataBound="AuditEventsGridView_RowDataBound">
                    <EmptyDataTemplate>
                        No records found
                    </EmptyDataTemplate>
                    <Columns>
                        <asp:TemplateField HeaderText="Created Date/Time" SortExpression="CreatedDate">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("CreatedDate") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <table cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td style="margin: 0px; padding: 0px;">
                                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("CreatedDate", "{0:d}") %>'></asp:Label>
                                        </td>
                                        <td style="margin: 0px; padding: 0px;">
                                            &nbsp;<asp:Label ID="DateTimeLabel" runat="server" Text='<%# ((DateTime)Eval("CreatedDate")).ToShortTimeString() %>'></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                            <ItemStyle Width="20%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Creator" SortExpression="Creator">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Creator") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="GridLabel" runat="server" Text='<%# Bind("Creator") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="20%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Description" SortExpression="Description">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Description") %>'></asp:TextBox><br />
                                <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("OperatingOn") %>'></asp:TextBox><br />
                                <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("PageName") %>'></asp:TextBox><br />
                            </EditItemTemplate>
                            <ItemTemplate>
                                <b><i>Description</i></b>
                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("Description") %>'></asp:Label><br />
                                <b><i>Operating On</i></b>
                                <asp:Label ID="Label4" runat="server" Text='<%# Bind("OperatingOn") %>'></asp:Label><br />
                                <b><i>Page Name</i></b>
                                <asp:Label ID="Label5" runat="server" Text='<%# Bind("PageName") %>'></asp:Label><br />
                            </ItemTemplate>
                            <ItemStyle Width="60%" />
                        </asp:TemplateField>
                    </Columns>
                    <PagerStyle CssClass="HeaderGrade" />
                </Alterax:PagingGridView>
                
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetAllAuditEvents"
                    TypeName="AuditEventsUI" OnSelecting="ObjectDataSource1_Selecting">
                    <SelectParameters>
                        <asp:Parameter Name="description" Type="String" />
                        <asp:Parameter Name="creator" Type="String" />
                        <asp:Parameter Name="createdDate" Type="DateTime" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

