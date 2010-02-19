using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ProductSearchEventArgs
/// </summary>
/// 

public delegate void ErrorMessageEventHandler(object sender, ErrorMessageEventArgs e);

public class ErrorMessageEventArgs : EventArgs
{
    private List<string> errorMessages;

    public ErrorMessageEventArgs()
    {
        errorMessages = new List<string>();
    }

    public List<String> ErrorMessages
    {
        get { return errorMessages; }
        set { errorMessages = value; }
    }

    public void AddErrorMessages(string errorMessage)
    {
        errorMessages.Add(errorMessage);
    }
    public void ClearErrorMessages()
    {
        errorMessages.Clear();
    }
}
