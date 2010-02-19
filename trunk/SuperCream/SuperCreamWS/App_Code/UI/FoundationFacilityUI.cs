using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using WcfFoundationService;

/// <summary>
/// Summary description for FoundationFacility
/// </summary>
public class FoundationFacilityUI : IDisposable
{
    private WcfFoundationService.FoundationServiceClient _proxy;

    public FoundationFacilityUI()
    {
        _proxy = new WcfFoundationService.FoundationServiceClient();
    }

    public void SaveFoundationFacility(FoundationFacility foundationFacility)
    {
        _proxy.SaveFoundationFacility(foundationFacility);
    }

    public void UpdateFoundationFacility(FoundationFacility newFoundationFacility, FoundationFacility origFoundationFacility)
    {
        // Deal with getting rid of circular references
        origFoundationFacility.Address.FoundationFacility = null;
        _proxy.UpdateFoundationFacility(newFoundationFacility, origFoundationFacility);
      //  _proxy.UpdateFoundationFacility(newFoundationFacility);
    }

    public bool Exists()
    {
        return _proxy.FoundationFacilityExists();
    }

    public FoundationFacility Get()
    {
        return _proxy.GetFoundationFacility();
    }

    #region IDisposable Members

    public void Dispose()
    {
        _proxy.Close();
    }

    #endregion

    ~FoundationFacilityUI()
    {
        if(_proxy != null)
            _proxy.Close();
    }
}
