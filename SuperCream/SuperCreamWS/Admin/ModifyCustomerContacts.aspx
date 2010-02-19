<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" StylesheetTheme="SuperCream"
    AutoEventWireup="true" CodeFile="ModifyCustomerContacts.aspx.cs" Inherits="Modify_CustomerContacts" %>

<%@ Register Src="../Controls/ErrorView.ascx" TagName="ErrorView" TagPrefix="Alterax" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="AddCustomerContactUpdatePanel" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <div class="ErrorOutput">
                <Alterax:ErrorView ID="ErrorViewControl" Visible="false" runat="server" />
            </div>
            <div class="FormInput">
                <asp:Panel ID="AddCustomerContactPanel" runat="server">
                    <fieldset id="VarInputLegend">
                        <legend>
                            <h3>
                                Modify Customer Contacts</h3>
                        </legend>
                        <table style="width: 100%">
                            <tr>
                                <td>
                                    Name
                                </td>
                                <td>
                                    <asp:TextBox ID="CustomerContactNameTextBox" runat="server" ValidationGroup="NewCustomerGroup"
                                        MaxLength="40" Width="500px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="CCRequiredFieldValidator2" ValidationGroup="NewCustomerGroup"
                                        ControlToValidate="CustomerContactNameTextBox" ErrorMessage="Name is a required Text Box"
                                        InitialValue="" Text="Required" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Price List
                                </td>
                                <td>
                                    <asp:DropDownList ID="CustomerContactPriceListDropDownList" Width="300px" runat="server">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                    <table class="progressupdate">
                                        <tr>
                                            <td colspan="1">
                                                <table class="progressupdate">
                                                    <tr>
                                                        <td>
                                                            <asp:Button ID="AddNewContactButton" Text="Add Contact" runat="server" OnClick="AddNewContactButton_Click" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td>
                                                <div class="progressupdate">
                                                    <asp:UpdateProgress ID="CCUpdateProgress1" runat="server" AssociatedUpdatePanelID="AddCustomerContactUpdatePanel"
                                                        DisplayAfter="1">
                                                        <ProgressTemplate>
                                                            <asp:Image ID="aspImg1" runat="server" ImageUrl="~/images/progress3.gif"></asp:Image>
                                                        </ProgressTemplate>
                                                    </asp:UpdateProgress>
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                </asp:Panel>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="AddContactDetailUpdatePanel" runat="server" UpdateMode="Conditional">
        <Triggers>
            <asp:PostBackTrigger ControlID="AddNewContactButton" />
        </Triggers>
        <ContentTemplate>
            <asp:Panel ID="AddContactPanel" DefaultButton="AddContactButton" Visible="false"
                runat="server">
                <div class="FormInput">
                    <fieldset id="Fieldset2">
                        <legend>
                            <h3>
                                Enter New Contact</h3>
                        </legend>
                        <table>
                            <tr>
                                <td style="width: 25%">
                                </td>
                                <td style="width: 25%">
                                </td>
                                <td style="width: 15%">
                                </td>
                                <td style="width: 35%">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Job Role
                                </td>
                                <td colspan="3">
                                    <asp:TextBox ID="JobRoleTextBox" runat="server" ValidationGroup="NewContactGroup"
                                        MaxLength="35" Width="300px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="CCRequiredFieldValidator7" ValidationGroup="NewContactGroup"
                                        ControlToValidate="JobRoleTextBox" ErrorMessage="Name is a required Text Box"
                                        InitialValue="" Text="Required" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Title
                                </td>
                                <td colspan="3">
                                    <asp:TextBox ID="TitleTextBox" runat="server" ValidationGroup="NewContactGroup" MaxLength="35"
                                        Width="300px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="CCRequiredFieldValidator3" ValidationGroup="NewContactGroup"
                                        ControlToValidate="TitleTextBox" ErrorMessage="Name is a required Text Box" InitialValue=""
                                        Text="Required" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    First Name
                                </td>
                                <td colspan="3">
                                    <asp:TextBox ID="FirstNameTextBox" runat="server" ValidationGroup="NewContactGroup"
                                        MaxLength="35" Width="300px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="CCRequiredFieldValidator4" ValidationGroup="NewContactGroup"
                                        ControlToValidate="FirstNameTextBox" ErrorMessage="Name is a required Text Box"
                                        InitialValue="" Text="Required" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Last Name
                                </td>
                                <td colspan="3">
                                    <asp:TextBox ID="LastNameTextBox" runat="server" ValidationGroup="NewContactGroup"
                                        MaxLength="35" Width="300px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="CCRequiredFieldValidator11" ValidationGroup="NewContactGroup"
                                        ControlToValidate="FirstNameTextBox" ErrorMessage="Name is a required Text Box"
                                        InitialValue="" Text="Required" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Daytime Telephone No.
                                </td>
                                <td colspan="3">
                                    <asp:TextBox ID="DayTimeTelephoneNoTextBox" runat="server" ValidationGroup="NewContactGroup"
                                        MaxLength="20" Width="300px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="CCRequiredFieldValidator14" ValidationGroup="NewContactGroup"
                                        ControlToValidate="DayTimeTelephoneNoTextBox" ErrorMessage="Day Time Telephone No is Required"
                                        InitialValue="" Text="Required" Display="Dynamic" runat="server" />
                                    <asp:RegularExpressionValidator ID="CCRegularExpressionValidator" runat="server"
                                        ControlToValidate="DayTimeTelephoneNoTextBox" ErrorMessage="Invalid UK phone number"
                                        Text="Format Error" Display="Dynamic" ValidationExpression="^(\(?\+?[0-9]*\)?)?[0-9_\- \(\)]*$">
                                    </asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Home Phone No.
                                </td>
                                <td colspan="3">
                                    <asp:TextBox ID="HomePhoneNoTextBox" runat="server" ValidationGroup="NewContactGroup"
                                        MaxLength="20" Width="300px"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="CCRegularExpressionValidator1" runat="server"
                                        ControlToValidate="HomePhoneNoTextBox" ErrorMessage="Invalid UK phone number"
                                        Text="Format Error" Display="Dynamic" ValidationExpression="^(\(?\+?[0-9]*\)?)?[0-9_\- \(\)]*$"></asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Mobile No.
                                </td>
                                <td colspan="3">
                                    <asp:TextBox ID="MobileNoTextBox" runat="server" ValidationGroup="NewContactGroup"
                                        MaxLength="20" Width="300px"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="MobileNoTextBox"
                                        ErrorMessage="Invalid UK phone number" Text="Format Error" Display="Dynamic"
                                        ValidationExpression="^(\(?\+?[0-9]*\)?)?[0-9_\- \(\)]*$"></asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td style="vertical-align: top;">
                                    Notes
                                </td>
                                <td colspan="3">
                                    <asp:TextBox ID="NotesTextBox" runat="server" ValidationGroup="NewContactGroup" TextMode="MultiLine"
                                        MaxLength="20" Height="150px" Width="70%"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <table class="progressupdate">
                                        <tr>
                                            <td style="width: 5%;">
                                                <asp:Button ID="AddContactButton" Text="Add Contact" ValidationGroup="NewContactGroup"
                                                    runat="server" OnClick="AddContactButton_Click" />
                                            </td>
                                            <td style="width: 95%;">
                                                &nbsp;
                                                <asp:Button ID="CancelAddContactButton" Text="Cancel" runat="server" OnClick="CancelAddContactButton_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td colspan="2">
                                    <div class="progressupdate">
                                        <asp:UpdateProgress ID="UpdateProgress2" runat="server" AssociatedUpdatePanelID="AddContactDetailUpdatePanel"
                                            DisplayAfter="1">
                                            <ProgressTemplate>
                                                <asp:Image ID="ProgressImg2" runat="server" ImageUrl="~/images/progress3.gif"></asp:Image>
                                            </ProgressTemplate>
                                        </asp:UpdateProgress>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                </div>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="ModifyExistingCustomersUpdatePanel" runat="server" UpdateMode="Conditional">
        <Triggers>
            <asp:PostBackTrigger ControlID="AddContactButton" />
        </Triggers>
        <ContentTemplate>
            <div class="DataList">
                <asp:DataList ID="ContactDetailDataList" runat="server" 
                     OnItemCommand="ContactDetailDataList_ItemCommand"
                    OnItemDataBound="ContactDetailDataList_ItemDataBound" DataSourceID="ContactDetailObjectDataSource">
                    <HeaderTemplate>
                        <table class="datalist" cellpadding="0" cellspacing="0">
                            <tr>
                                <th style="width: 2%">
                                </th>
                                <th style="width: 38%">
                                    Name
                                </th>
                                <th style="width: 50%">
                                    Job Role
                                </th>
                                <th style="width: 10%">
                                </th>
                            </tr>
                        </table>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <table class="datalist" cellpadding="0" cellspacing="0">
                            <tr class="row-a">
                                <td width="2%">
                                    <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/images/btn_expand.gif"
                                        CommandName="Select" AlternateText="Click to view orders"></asp:ImageButton>
                                </td>
                                <td style="width: 38%">
                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("FirstName") %>'></asp:Label>
                                    &nbsp;
                                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("LastName") %>'></asp:Label>
                                </td>
                                <td style="width: 50%">
                                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("JobRole") %>'></asp:Label>
                                </td>
                                <td style="width: 10%">
                                    <asp:Button ID="SelectButton" runat="server" CommandName="Delete" CommandArgument='<%# Bind("ID") %>'
                                        Text="Delete" />
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                    <AlternatingItemTemplate>
                        <table class="datalist" cellpadding="0" cellspacing="0">
                            <tr class="row-b">
                                <td width="2%">
                                    <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/images/btn_expand.gif"
                                        CommandName="Select" AlternateText="Click to view orders"></asp:ImageButton>
                                </td>
                                <td style="width: 38%">
                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("FirstName") %>'></asp:Label>
                                    &nbsp;
                                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("LastName") %>'></asp:Label>
                                </td>
                                <td style="width: 50%">
                                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("JobRole") %>'></asp:Label>
                                </td>
                                <td style="width: 10%">
                                    <asp:Button ID="SelectButton" runat="server" CommandName="Delete" CommandArgument='<%# Bind("ID") %>'
                                        Text="Delete" />
                                </td>
                            </tr>
                        </table>
                    </AlternatingItemTemplate>
                    <SelectedItemTemplate>
                        <asp:Panel ID="SelectedPanel" runat="server">
                            <legend>
                                <h3>
                                    Modify Existing Contact Details</h3>
                            </legend>
                            <fieldset id="Fieldset2">
                                <asp:Label ID="IDLabel" runat="server" Visible="false" MaxLength="40" Width="350px"></asp:Label>
                                <table class="datalist" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td colspan="4">
                                            <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/images/btn_minimise.gif"
                                                CommandName="UnSelect" AlternateText="Click to view orders"></asp:ImageButton>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Job Role
                                        </td>
                                        <td colspan="3">
                                            <asp:TextBox ID="JobRoleTextBox" runat="server" ValidationGroup="NewContactGroup"
                                                MaxLength="35" Width="300px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="CCDDRequiredFieldValidator4" ValidationGroup="NewContactGroup"
                                                ControlToValidate="JobRoleTextBox" ErrorMessage="Job Role is a required field"
                                                InitialValue="" Text="Required" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Title
                                        </td>
                                        <td colspan="3">
                                            <asp:TextBox ID="TitleTextBox" runat="server" ValidationGroup="NewContactGroup" MaxLength="35"
                                                Width="300px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="CCDDRequiredFieldValidator1" ValidationGroup="NewContactGroup"
                                                ControlToValidate="TitleTextBox" ErrorMessage="Address Line is a required field"
                                                InitialValue="" Text="Required" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            First Name
                                        </td>
                                        <td colspan="3">
                                            <asp:TextBox ID="FirstNameTextBox" runat="server" ValidationGroup="NewContactGroup"
                                                MaxLength="35" Width="300px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="CCDDRequiredFieldValidator13" ValidationGroup="NewContactGroup"
                                                ControlToValidate="FirstNameTextBox" ErrorMessage="First Name is a required field"
                                                InitialValue="" Text="Required" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Last Name
                                        </td>
                                        <td colspan="3">
                                            <asp:TextBox ID="LastNameTextBox" runat="server" ValidationGroup="NewContactGroup"
                                                MaxLength="35" Width="300px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="CCDDRequiredFieldValidator8" ValidationGroup="NewContactGroup"
                                                ControlToValidate="LastNameTextBox" ErrorMessage="Last Name is a required field"
                                                InitialValue="" Text="Required" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Day Time Telephone No
                                        </td>
                                        <td colspan="3">
                                            <asp:TextBox ID="DayTimeTelephoneNoTextBox" runat="server" ValidationGroup="NewContactGroup"
                                                MaxLength="20" Width="300px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="CCDDRequiredFieldValidator9" ValidationGroup="NewContactGroup"
                                                ControlToValidate="DayTimeTelephoneNoTextBox" ErrorMessage="Day Time Telephone No is a required field"
                                                InitialValue="" Text="Required" runat="server" />
                                            <asp:RegularExpressionValidator ID="CCRegularExpressionValidator" runat="server"
                                                ControlToValidate="DayTimeTelephoneNoTextBox" ErrorMessage="Invalid UK phone number"
                                                Text="Format Error" Display="Dynamic" ValidationExpression="^(\(?\+?[0-9]*\)?)?[0-9_\- \(\)]*$" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Home Telephone No
                                        </td>
                                        <td colspan="3">
                                            <asp:TextBox ID="HomeTelephoneNoTextBox" runat="server" ValidationGroup="NewContactGroup"
                                                MaxLength="20" Width="300px"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="HomeTelephoneNoTextBox"
                                                ErrorMessage="Invalid UK phone number" Text="Format Error" Display="Dynamic"
                                                ValidationExpression="^(\(?\+?[0-9]*\)?)?[0-9_\- \(\)]*$" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Mobile Telephone No
                                        </td>
                                        <td colspan="3">
                                            <asp:TextBox ID="MobileTelephoneTextBox" runat="server" ValidationGroup="NewContactGroup"
                                                MaxLength="20" Width="300px"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="MobileTelephoneTextBox"
                                                ErrorMessage="Invalid UK phone number" Text="Format Error" Display="Dynamic"
                                                ValidationExpression="^(\(?\+?[0-9]*\)?)?[0-9_\- \(\)]*$">
                                            </asp:RegularExpressionValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="vertical-align: top; width: 15%;">
                                            Notes
                                        </td>
                                        <td style="vertical-align: top; width: 35%;" colspan="3">
                                            <asp:TextBox ID="NotesTextBox" runat="server" ValidationGroup="NewContactGroup" TextMode="MultiLine"
                                                MaxLength="20" Height="150px" Width="60%"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            <table class="progressupdate">
                                                <tr>
                                                    <td>
                                                        <asp:Button ID="AddContactButton" Text="Modify Contact" CommandName="Update" CommandArgument='<%# Bind("ID") %>'
                                                            ValidationGroup="NewContactGroup" runat="server" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </fieldset>
                        </asp:Panel>
                    </SelectedItemTemplate>
                </asp:DataList>
            </div>
            <table>
                <tr>
                    <td>
                        <asp:ObjectDataSource ID="ContactDetailObjectDataSource" runat="server" TypeName="CustomerUI"
                            SelectMethod="GetContactDetailsByCustomerID">
                            <SelectParameters>
                                <asp:QueryStringParameter Name="id" QueryStringField="ID" Type="Int32" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                    </td>
                    <td id="CustomerUpdateTD">
                        <asp:Button ID="CustomerSaveButton" Text="Save" runat="server" OnClick="CustomerSaveButton_Click" />
                    </td>
                </tr>
            </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
