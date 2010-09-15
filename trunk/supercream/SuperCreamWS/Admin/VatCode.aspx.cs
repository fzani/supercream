using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Threading;

using WcfFoundationService;

public partial class Admin_VatCode : System.Web.UI.Page
{
    #region private Event Handlers

    private EventHandler<EventArgs> ChangeState;

    #endregion

    #region Page Load Event

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ChangeState += new EventHandler<EventArgs>(PageDefaultLoadState);
            ChangeState(this, e);

            PopulateDropDownList();

            DataBind();
        }
        else
        {
            ErrorViewControl.Visible = false;
        }
    }

    #endregion

    #region General Event Handlers

    protected void AddVatCodeButton_Click(object sender, EventArgs e)
    {
        try
        {
            using (VatCodeUI ui = new VatCodeUI())
            {
                VatCode cd = new VatCode();

                cd.Code = this.CodeTestBox.Text;
                cd.Description = DescriptionTextBox.Text;
                cd.PercentageValue = (VatExemptableCode.Checked) ? 0 : Convert.ToSingle(PercentageTextBox.Text);
                cd.VatExemptible = VatExemptableCode.Checked;

                AuditEventsUI.LogEvent("Create Vat Code", cd.Description, Page.ToString(),
                   AuditEventsUI.AuditEventType.Creating);

                ui.SaveVatCode(cd);

                Util.ClearFields(this.Page);

                ChangeState += new EventHandler<EventArgs>(PageDefaultLoadState);
                ChangeState(this, e);

                DataBind();
            }
        }
        catch (Exception ex)
        {
            ErrorViewControl.AddError(ex.Message);
            ErrorViewControl.DataBind();
            ErrorViewControl.Visible = true;
        }
    }

    protected void VatExemptableCode_CheckedChanged(object sender, EventArgs e)
    {
        PercentageTextBox.Text = "0";
    }

    protected void SaveSelectionButton_Click(object sender, EventArgs e)
    {
        if (SelectStandardVatRateDropDownList.SelectedValue != "-1")
        {
            StandardVatCodeUI ui = new StandardVatCodeUI();

            AuditEventsUI.LogEvent("Create Standard Vat Code", "vat", Page.ToString(),
                 AuditEventsUI.AuditEventType.Creating);
            ui.SaveStandardVatCode(new StandardVatRate { ID = -1, VatCodeID = Convert.ToInt32(SelectStandardVatRateDropDownList.SelectedItem.Value) });

            PopulateDropDownList();
        }
    }

    #endregion

    #region Grid Event Handlers

    protected void VatCodeGridView_RowUpdated(object sender, GridViewUpdatedEventArgs e)
    {
        AuditEventsUI.LogEvent("Updating Vat Code", "vat", Page.ToString(),
                AuditEventsUI.AuditEventType.Modifying);

        Exception ex = e.Exception;
        if (ex != null)
        {
            HandleException(ex, e);
            e.KeepInEditMode = true;
        }
        else
        {
            ChangeState += new EventHandler<EventArgs>(PageDefaultLoadState);
            ChangeState(this, e);
            DataBind();
        }

        PopulateDropDownList();
    }

    protected void VatCodeGridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Image img = e.Row.FindControl("Image1") as Image;
            GridViewRow drv = e.Row.DataItem as GridViewRow;

            bool? vatxEmptibleStatus = DataBinder.Eval(e.Row.DataItem, "VatExemptible") as bool?;
            if (vatxEmptibleStatus == false)
            {
                img.ImageUrl = "~/images/12-em-check.png";
            }
            else
            {
                img.ImageUrl = "~/images/16-circle-green.png";
                // Not sure about this I think an error should be shown when
                // Product record exists, this will violate foreign key constraint
                //Button button = e.Row.FindControl("DeleteButton") as Button;
                //button.Visible = false;
            }
        }
    }

    protected void VatCodeGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        ChangeState += new EventHandler<EventArgs>(PageDefaultLoadState);
        ChangeState(this, e);

        DataBind();
    }

    protected void VatCodeGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        AuditEventsUI.LogEvent("Deleting Vat Code", "vat", Page.ToString(),
                AuditEventsUI.AuditEventType.Deleting);

        PopulateDropDownList();

        ErrorViewControl.Visible = false;
    }

    #endregion

    #region Object Data Source Events

    /***************************************************************************
     * Object Data Source Events
     **************************************************************************/
    protected void VatCodeObjectDataSource_Updating(object sender, ObjectDataSourceMethodEventArgs e)
    {
        string code = e.InputParameters[0] as string;
        string description = e.InputParameters[1] as string;
        float percentageValue;
        if (!float.TryParse(e.InputParameters[2] as string, out percentageValue))
        {
            throw new ApplicationException("Percentage value input format invalid");
        }

        int id = Convert.ToInt32(e.InputParameters[3]);

        VatCode updatedCatCode = new VatCode
        {
            ID = id,
            Code = code,
            Description = description,
            PercentageValue = percentageValue
        };

        using (VatCodeUI ui = new VatCodeUI())
        {
            ui.UpdateVatCode(updatedCatCode);
        }
    }

    protected void VatCodeObjectDataSource_Deleted(object sender, ObjectDataSourceStatusEventArgs e)
    {
        Exception ex = e.Exception;
        if (ex != null)
            HandleException(ex, e);

        VatCodeUI ui = new VatCodeUI();
        VatExemptableCode.Visible = (ui.ExemptVatCodeExist() == true) ? false : true;

        DataBind();
    }

    protected void VatCodeObjectDataSource_Selected(object sender, ObjectDataSourceStatusEventArgs e)
    {
        Exception ex = e.Exception;
        if (ex != null)
            HandleException(ex, e);
    }

    #endregion

    #region General Exception Handlers

    /**************************************************************************
    * General Exception handlers
    ***************************************************************************/
    private void HandleException(Exception ex, ObjectDataSourceStatusEventArgs e)
    {
        e.ExceptionHandled = true;
        ErrorViewControl.AddError(ex.InnerException.Message);
        ErrorViewControl.Visible = true;
    }

    private void HandleException(Exception ex, GridViewUpdatedEventArgs e)
    {
        e.ExceptionHandled = true;
        if (ex.InnerException != null)
            ErrorViewControl.AddError(ex.InnerException.Message);
        else ErrorViewControl.AddError(ex.Message);

        ErrorViewControl.Visible = true;
        ErrorViewControl.DataBind();
    }

    #endregion

    #region Page States

    /***************************************************************************
     * Page Event States
     ***************************************************************************/
    private void PageDefaultLoadState(object sender, EventArgs args)
    {
        using (VatCodeUI ui = new VatCodeUI())
        {
            VatExemptableCode.Visible = (ui.ExemptVatCodeExist() == true) ? false : true;
            VatExemptableCode.Checked = false;
            ErrorViewControl.Visible = false;
            Util.ClearFields(this.Page);
        }
    }

    #endregion

    #region Private Helpers

    private void PopulateDropDownList()
    {
        VatCodeUI vatCodeUI = new VatCodeUI();
        List<VatCode> vatCodeList = new List<VatCode>();

        SelectStandardVatRateDropDownList.Items.Clear();
        SelectStandardVatRateDropDownList.Items.Add
        (
            new ListItem
            {
                Value = "-1",
                Text = "-- No Item Selected"
            }
        );

        vatCodeList = vatCodeUI.GetAllVatCodes()
            .Where(q => q.PercentageValue != 0)
            .ToList<VatCode>();
        if (vatCodeList.Count > 0)
        {
            Action<VatCode> vatCodeAction = new Action<VatCode>
            (
                q =>
                {
                    ListItem item = new ListItem
                    {
                        Value = q.ID.ToString(),
                        Text = q.Description
                    };

                    SelectStandardVatRateDropDownList.Items.Add(item);
                }
            );

            vatCodeList.ForEach(vatCodeAction);

            StandardVatCodeUI standardVatCodeUI = new StandardVatCodeUI();
            if (standardVatCodeUI.Exists())
            {
                StandardVatRate standardVatRate = standardVatCodeUI.GetStandardVatCode();
                SelectStandardVatRateDropDownList.SelectedValue = standardVatRate.VatCodeID.ToString();
            }

            SetDropDownListState();

        }
    }

    #endregion

    protected void SelectStandardVatRateDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        SetDropDownListState();
    }

    private void SetDropDownListState()
    {
        if (SelectStandardVatRateDropDownList.SelectedValue == "-1")
        {
            SaveSelectionButton.Enabled = false;
        }
        else
        {
            SaveSelectionButton.Enabled = true;
        }
    }
}
