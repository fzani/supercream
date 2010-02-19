using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;

using WcfFoundationService;

using System.Xml;
using System.Xml.Serialization;
using System.IO;

public partial class Admin_YourCompanyDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        InitFields();

        if (!IsPostBack)
        {
            try
            {
                FoundationFacilityUI ui = new FoundationFacilityUI();
                if (ui.Exists())
                {
                    FoundationFacility ff = ui.Get();

                    CompanyNameTextBox.Text = ff.CompanyName;
                    VatRegistrationNumberTextBox.Text = ff.VatRegistrationNumber;
                    OfficePhoneNumber1TextBox.Text = ff.OfficePhoneNumber1;
                    OfficePhoneNumber2TextBox.Text = ff.OfficePhoneNumber2;
                    TownTextBox.Text = ff.Address.Town;
                    CountyTextBox.Text = ff.Address.County;
                    EMailTextBox.Text = ff.EMailAddress;
                    PostCodeTextBox.Text = ff.Address.PostCode;
                    SaveCompanyDetailsButton.Visible = true;
                   
                    // Deal with converting Address Lines back from XML
                    List<String> addressLines = this.ConvertAddressLinesFromXml(ff.Address.AddressLines);
                    if (addressLines[0] != null)
                        AddressLine1TextBox.Text = addressLines[0];
                    if (addressLines[1] != null)
                        AdressLine2TextBox.Text = addressLines[1];
                }
                else
                    AddFoundationFacilityButton.Visible = true;
            }
            catch (Exception ex)
            {
                ErrorViewControl.AddError(ex.Message);
                ErrorViewControl.Visible = true;
            }
        }
    }

    private void InitFields()
    {
        ErrorViewControl.Visible = false;
        AddFoundationFacilityButton.Visible = false;
        SaveCompanyDetailsButton.Visible = false;
    }

    protected void AddCompanyDetails_Click(object sender, EventArgs e)
    {
        try
        {
            FoundationFacility ff = new FoundationFacility()
            {

                CompanyName = this.CompanyNameTextBox.Text,
                OfficePhoneNumber1 = this.OfficePhoneNumber1TextBox.Text,
                OfficePhoneNumber2 = this.OfficePhoneNumber2TextBox.Text,
                VatRegistrationNumber = this.VatRegistrationNumberTextBox.Text,
                EMailAddress = this.EMailTextBox.Text,
                Address = new Address
                {
                    AddressLines = ConvertAddressLinesToXml(),
                    AddressType = 0,
                    County = this.CountyTextBox.Text,
                    Town = this.TownTextBox.Text,
                    PostCode = this.PostCodeTextBox.Text
                }
            };
            FoundationFacilityUI ui = new FoundationFacilityUI();
            ui.SaveFoundationFacility(ff);

            AddFoundationFacilityButton.Visible = false;
            SaveCompanyDetailsButton.Visible = true;
        }
        catch (Exception ex)
        {
            ErrorViewControl.AddError(ex.Message);
            ErrorViewControl.Visible = true;
        }
    }

    protected void SaveCompanyDetailsButton_Click(object sender, EventArgs e)
    {
        try
        {
            FoundationFacilityUI ui = new FoundationFacilityUI();
            FoundationFacility ffOrig = ui.Get();

            FoundationFacility ffNew = new FoundationFacility
            {
                ID = ffOrig.ID,
                CompanyName = this.CompanyNameTextBox.Text,
                OfficePhoneNumber1 = this.OfficePhoneNumber1TextBox.Text,
                OfficePhoneNumber2 = this.OfficePhoneNumber2TextBox.Text,
                VatRegistrationNumber = this.VatRegistrationNumberTextBox.Text,
                EMailAddress = this.EMailTextBox.Text,
                AddressID = ffOrig.AddressID,
                Address = new Address
                {
                    ID = ffOrig.AddressID,
                    AddressLines = ConvertAddressLinesToXml(),
                    AddressType = 0,
                    County = this.CountyTextBox.Text,
                    Town = this.TownTextBox.Text,
                    PostCode = this.PostCodeTextBox.Text
                }
            };

            ui.UpdateFoundationFacility(ffNew, ffOrig);

            AddFoundationFacilityButton.Visible = false;
            SaveCompanyDetailsButton.Visible = true;
        }
        catch (Exception ex)
        {
            ErrorViewControl.AddError(ex.Message);
            ErrorViewControl.Visible = true;
            SaveCompanyDetailsButton.Visible = true;
        }
    }

    private string ConvertAddressLinesToXml()
    {
        List<string> addressLines = new List<string>();
        addressLines.Add(this.AddressLine1TextBox.Text);
        if (this.AdressLine2TextBox.Text.Length != 0)
            addressLines.Add(AdressLine2TextBox.Text);

        MemoryStream mem = new MemoryStream();
        XmlSerializer serialiser = new XmlSerializer(typeof(List<string>));
        serialiser.Serialize(mem, addressLines);

        mem.Position = 0;
        TextReader r = new StreamReader(mem);
        return r.ReadToEnd();
    }

    private List<String> ConvertAddressLinesFromXml(string addressLines)
    {
        List<string> addressLineList = new List<string>();
        MemoryStream mem = new MemoryStream();
        StringReader r = new StringReader(addressLines);

        XmlSerializer serialiser = new XmlSerializer(typeof(List<string>));
        addressLineList = (List<string>)serialiser.Deserialize(r);
        r.Close();

        return addressLineList;
    }
}
