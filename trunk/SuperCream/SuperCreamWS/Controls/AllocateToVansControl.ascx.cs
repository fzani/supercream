using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WcfFoundationService;

public partial class Controls_AllocateToVansControl : System.Web.UI.UserControl
{
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

    }

    #endregion
}
