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
using System.Transactions;

using WcfFoundationService;

/// <summary>
/// Summary description for OrderListUI
/// </summary>
[System.ComponentModel.DataObject]
public class VatCodeUI : IDisposable
{
    private WcfFoundationService.FoundationServiceClient _proxy;

    public VatCodeUI()
    {
        _proxy = new WcfFoundationService.FoundationServiceClient();
    }

    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
    public List<VatCode> GetAllVatCodes()
    {
        return _proxy.GetAllVatCodes() as List<VatCode>;
    }

    public void SaveVatCode(VatCode code)
    {
        if(_proxy.VatCodeExists(code.Code))
            throw new ApplicationException("Cannot add a Vat Code that already exists");
        _proxy.SaveVatCode(code);
    }

    public void DeleteVatCode(int id)
    {
        using (TransactionScope ts = new TransactionScope())
        {
            VatCode code = _proxy.GetVatCode(id);
            _proxy.DeleteVatCode(code);
        }
    }

    public void UpdateVatCode(int id, string code, string description, float percentagevalue)
    {
        using (TransactionScope ts = new TransactionScope())
        {
            VatCode origVatCode = _proxy.GetVatCode(id);
            VatCode newVatCode = new VatCode
            {
            };
        }
    }

    public void UpdateVatCode(VatCode newVatCode)
    {
        VatCode origVatCode = _proxy.GetVatCode(newVatCode.ID);
        if (origVatCode.VatExemptible)
            if (newVatCode.PercentageValue < 0 || newVatCode.PercentageValue > 0)
                throw new ApplicationException("You cannot update Percentage value on a Vat Exemptible type. Value must be Zero.");

        newVatCode.VatExemptible = origVatCode.VatExemptible;   // Fudge VatExemptible status back in 
        // as we don't want this to be modifible.
        newVatCode.Version = origVatCode.Version;
        _proxy.UpdateVatCode(newVatCode, origVatCode);
    }

    public bool ExemptVatCodeExist()
    {
        return _proxy.ExemptCodeExists();
    }

    public VatCode GetByID(int id)
    {
        return _proxy.GetVatCode(id);
    }

    #region IDisposable Members

    public void Dispose()
    {
        _proxy.Close();
    }

    #endregion

    ~VatCodeUI()
    {
        if (_proxy != null)
            _proxy.Close();
    }
}
