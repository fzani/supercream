<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" StylesheetTheme="SuperCream"
    AutoEventWireup="true" CodeFile="YourCompanyDetails.aspx.cs" Inherits="Admin_YourCompanyDetails" %>

<%@ Register Src="../Controls/ErrorView.ascx" TagName="ErrorView" TagPrefix="Alterax" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="AddFoundationFacilityPanel" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <div class="ErrorOutput">
                <Alterax:ErrorView ID="ErrorViewControl" Visible="false" runat="server" />
            </div>
            <div class="FormInput">
                <asp:Panel ID="NewFoundationFacilityPanel" DefaultButton="SaveCompanyDetailsButton"
                    runat="server">
                    <fieldset id="VarInputLegend">
                        <legend>
                            <h3>
                                Enter New Customer</h3>
                        </legend>
                        <table style="width: 100%">
                            <tr>
                                <td>
                                    <asp:Label ID="CustomerNameLabel" Text="Customer Name" runat="server"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="CompanyNameTextBox" TabIndex="1" runat="server" MaxLength="40" Width="400px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ControlToValidate="CompanyNameTextBox"
                                        ErrorMessage="Company Name is a required rfield" InitialValue="" Text="Required"
                                        runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Vat Registration No.
                                </td>
                                <td>
                                    <asp:TextBox ID="VatRegistrationNumberTextBox" runat="server" TabIndex="2" MaxLength="20"
                                        Width="400px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" Display="Dynamic" ControlToValidate="VatRegistrationNumberTextBox"
                                        ErrorMessage="Vat Registration Number is a required field" InitialValue="" Text="Required"
                                        runat="server" />
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" Display="Dynamic"
                                        ControlToValidate="VatRegistrationNumberTextBox" ValidationExpression="^([GB])*(([1-9]\d{8})|([1-9]\d{11}))$"
                                        ErrorMessage="Invalid Vat Registration Number" Text="Format Error" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Office Phone Number
                                </td>
                                <td>
                                    <asp:TextBox ID="OfficePhoneNumber1TextBox" runat="server" MaxLength="20" TabIndex="3"
                                        Width="400px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="OfficePhoneNumber1TextBox"
                                        ErrorMessage="Office Phone Number 1 is a required field" InitialValue="" Display="Dynamic"
                                        Text="Required" runat="server" TabIndex="3" />
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="OfficePhoneNumber1TextBox"
                                        ErrorMessage="Invalid UK phone number" Text="Format Error" Display="Dynamic"
                                        ValidationExpression="^(\(?\+?[0-9]*\)?)?[0-9_\- \(\)]*$"></asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Alternative Office Phone Number
                                </td>
                                <td>
                                    <asp:TextBox ID="OfficePhoneNumber2TextBox" runat="server" MaxLength="20" Width="400px"
                                        TabIndex="4"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RequiredFieldValidatorOfficePhone2" Display="Dynamic"
                                        runat="server" ControlToValidate="OfficePhoneNumber2TextBox" ErrorMessage="Invalid UK phone number"
                                        Text="Format Error" ValidationExpression="^(\(?\+?[0-9]*\)?)?[0-9_\- \(\)]*$"></asp:RegularExpressionValidator>
                                </td>
                                <tr>
                                    <td>
                                        Adddress Line 1
                                    </td>
                                    <td>
                                        <asp:TextBox ID="AddressLine1TextBox" runat="server" MaxLength="45" Width="400px"
                                            TabIndex="5"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="AddressLine1TextBox"
                                            ErrorMessage="Address Line 1 is a required field" InitialValue="" Text="Required"
                                            runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Adddress Line 2
                                    </td>
                                    <td>
                                        <asp:TextBox ID="AdressLine2TextBox" runat="server" MaxLength="45" Width="400px"
                                            TabIndex="6"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        City/Town
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TownTextBox" runat="server" MaxLength="30" Width="400px" TabIndex="7"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="TownTextBox"
                                            ErrorMessage="Town is a required rfield" InitialValue="" Text="Required" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        County
                                    </td>
                                    <td>
                                        <asp:TextBox ID="CountyTextBox" runat="server" MaxLength="30" Width="400px" TabIndex="8"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="CountyTextBox"
                                            ErrorMessage="County is a required rfield" InitialValue="" Text="Required" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Post Code
                                    </td>
                                    <td>
                                        <asp:TextBox ID="PostCodeTextBox" runat="server" MaxLength="8" Width="100px" TabIndex="9"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ControlToValidate="PostCodeTextBox"
                                            ErrorMessage="Post Code is a required rfield" Text="Required" runat="server" />
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidatorPostCodeTextBox" ValidationExpression="^([Gg][Ii][Rr] 0[Aa]{2})|((([A-Za-z][0-9]{1,2})|(([A-Za-z][A-Ha-hJ-Yj-y][0-9]{1,2})|(([A-Za-z][0-9][A-Za-z])|([A-Za-z][A-Ha-hJ-Yj-y][0-9]?[A-Za-z])))) {0,1}[0-9][A-Za-z]{2})$"
                                            ControlToValidate="PostCodeTextBox" Text="Format Error" ErrorMessage="Invalid UK phone number"
                                            Display="Dynamic" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        EMail Address
                                    </td>
                                    <td>
                                        <asp:TextBox ID="EMailTextBox" runat="server" MaxLength="40" Width="300px" TabIndex="10"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="EMailTextBox"
                                            ErrorMessage="EMail is a required field" Text="Required" Display="Dynamic" runat="server" />
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ValidationExpression=".+@[^\.].*\.[a-z]{2,}"
                                            ControlToValidate="EMailTextBox" Text="Format Error" ErrorMessage="Invalid EMail Address"
                                            Display="Dynamic" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td>
                                        <table class="progressupdate">
                                            <tr>
                                                <td>
                                                    <asp:Button ID="AddFoundationFacilityButton" Text="Add Your Company Details" runat="server"
                                                        OnClick="AddCompanyDetails_Click" TabIndex="11" />
                                                    <asp:Button ID="SaveCompanyDetailsButton" runat="server" OnClick="SaveCompanyDetailsButton_Click"
                                                        TabIndex="12" Text="Save Your Company Details" />
                                                </td>
                                                <td>
                                                    <div class="progressupdate">
                                                        <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="AddFoundationFacilityPanel"
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
    <asp:UpdatePanel ID="VatCodeGridUpdatePanel" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
