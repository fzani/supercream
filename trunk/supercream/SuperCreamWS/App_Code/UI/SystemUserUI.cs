using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Linq;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Transactions;

using WcfFoundationService;

/// <summary>
/// Summary description for OrderListUI
/// </summary>
[System.ComponentModel.DataObject]
public class SystemUserUI
{  
    public List<string> GetAllSystemUsers()
    {
        var userNames = new List<string>();
              
        userNames.AddRange(from MembershipUser membershipUser in Membership.GetAllUsers() 
                           select membershipUser.UserName);
        return userNames;
    }
}
