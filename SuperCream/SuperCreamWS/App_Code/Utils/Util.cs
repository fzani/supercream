using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Globalization;
using System.Threading;

/// <summary>
/// Summary description for Util
/// </summary>
public class Util
{
    public Util()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static void ClearFields(System.Web.UI.Page currPage)
    {
        foreach (Control myControl in currPage.Controls)
        {
            foreach (Control formControl in myControl.Controls)
            {
                ClearControls(formControl);
            }
        }
    }

    public static void ClearControls(Control c)
    {
        if (c.Controls.Count > 0)
        {
            foreach (Control ci in c.Controls)
            {
                ClearControls(ci);
            }
        }
        else
            ClearControl(c);
    }

    private static void ClearControl(Control theControl)
    {
        if (theControl is System.Web.UI.WebControls.TextBox)
            ((TextBox)theControl).Text = String.Empty;
        else if (theControl is System.Web.UI.WebControls.DropDownList && ((DropDownList)theControl).SelectedIndex > -1)
            ((DropDownList)theControl).SelectedIndex = 0;
        //else if (theControl is System.Web.UI.WebControls.CheckBox)
        //    ((CheckBox)theControl).Checked = false;

        //else if (theControl is System.Web.UI.WebControls.RadioButtonList)
        //    ((RadioButtonList)theControl).Enabled = newState;

        //else if (theControl is System.Web.UI.WebControls.RadioButton)
        //    ((RadioButton)theControl).Enabled = newState;

        //else if (theControl is System.Web.UI.WebControls.CheckBoxList)
        //    ((CheckBoxList)theControl).Enabled = newState;       
        //else if (theControl is System.Web.UI.WebControls.LinkButton)
        //    ((LinkButton)theControl).Enabled = newState;
    }

    public static DateTime ConvertToDateTime(string dateTime)
    {
        DateTime outDateTime;
        if (!String.IsNullOrEmpty(dateTime))
        {
            if (!DateTime.TryParse(dateTime, out outDateTime))
            {
                return DateTime.MinValue;
            }
            else
            {
                return Convert.ToDateTime(dateTime);
            }
        }
        else
        {
            return DateTime.MinValue;
        }
    }

    public static decimal ConvertStringToDecimal(string value)
    {
        // Create a CultureInfo object for another culture. Use
        // [Dutch - The Netherlands] unless the current culture
        // is Dutch language. In that case use [English - U.S.].
        CultureInfo ukCulture = new CultureInfo("en-GB", false);
        return decimal.Parse(value, System.Globalization.NumberStyles.Any);
    }

    public static string ConvertDecimalToString(decimal value)
    {
        // Create a CultureInfo object for another culture. Use
        // [Dutch - The Netherlands] unless the current culture
        // is Dutch language. In that case use [English - U.S.].
        Thread.CurrentThread.CurrentCulture = new CultureInfo("en-GB", false);
        return String.Format("{0:c}", value);
    }
}
