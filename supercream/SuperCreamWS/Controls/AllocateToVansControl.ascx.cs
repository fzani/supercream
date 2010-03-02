using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WcfFoundationService;

public partial class Controls_AllocateToVansControl : System.Web.UI.UserControl
{
    #region Public Events

    public event ErrorMessageEventHandler ErrorMessageEventHandler;

    #endregion

    #region Page Load Events

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.SelectedDateCalendar.SelectedDate = DateTime.Today;

            VanUI ui = new VanUI();
            List<ListItem> vans = new List<ListItem>();
            Action<Van> vanAction = new Action<Van>((v) => vans.Add(new ListItem(v.Description, v.ID.ToString())));

            ui.GetAllVans().ForEach(vanAction);

            vans.ForEach((l) => VanAllocatedFrom.Items.Add(l));
            vans.ForEach((l) => VanAllocatedTo.Items.Add(l));

            DataBind();
        }
    }

    #endregion

    #region General Events

    protected void SelectedDateCalendar_SelectionChanged(object sender, EventArgs e)
    {
        DataBind();
    }

    protected void MoveToButton_Click(object sender, EventArgs e)
    {
        if (this.VanAllocatedFrom.SelectedValue.ToString() == this.VanAllocatedTo.SelectedValue.ToString())
        {
            this.SameVanError();           
            return;
        }

        if (VanAllocatedFromListBox.SelectedItem != null)
        {
            VanAllocatedToListBox.Items.Add(VanAllocatedFromListBox.SelectedItem);
            ListItem listItem = VanAllocatedToListBox.SelectedItem;
            listItem.Selected = false;
            VanAllocatedFromListBox.Items.Remove(listItem);          
        }
    }

    protected void MoveFromButton_Click(object sender, EventArgs e)
    {
        if (this.VanAllocatedFrom.SelectedValue.ToString() == this.VanAllocatedTo.SelectedValue.ToString())
        {
            this.SameVanError();            
            return;
        }

        if (VanAllocatedToListBox.SelectedItem != null)
        {
            VanAllocatedFromListBox.Items.Add(VanAllocatedToListBox.SelectedItem);
            ListItem listItem = VanAllocatedFromListBox.SelectedItem;
            listItem.Selected = false;
            VanAllocatedToListBox.Items.Remove(listItem);
        }
       
    }

    #endregion

    #region Object Data Source Events

    protected void VanAllocatedFromObjectDataSource_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        e.InputParameters[0] = this.SelectedDateCalendar.SelectedDate;
        e.InputParameters[1] = this.VanAllocatedFrom.SelectedValue.ToString();
    }
    protected void VanAllocatedToObjectDataSource_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        e.InputParameters[0] = this.SelectedDateCalendar.SelectedDate;
        e.InputParameters[1] = this.VanAllocatedTo.SelectedValue.ToString();
    }

    protected void VanAllocatedFrom_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataBind();
    }

    protected void VanAllocatedTo_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataBind();
    }

    #endregion

    #region  Private Helper methods

    private void SameVanError()
    {
        ErrorMessageEventArgs arg = new ErrorMessageEventArgs();
        arg.AddErrorMessages("Cannot transfer item to the same selected van");
        this.ErrorMessageEventHandler(this, arg);
    }

    #endregion    
}
