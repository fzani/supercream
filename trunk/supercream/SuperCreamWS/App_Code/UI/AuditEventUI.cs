using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

using WcfFoundationService;

using System.Diagnostics;

[System.ComponentModel.DataObject]
public class AuditEventsUI : IDisposable
{
    private WcfFoundationService.FoundationServiceClient _proxy;

    public enum AuditEventType : short
    {
        Creating,
        Modifying,
        Deleting,
        Querying
    }

    public AuditEventsUI()
    {
    }

    public void ArchiveAuditEvents()
    {
        using (_proxy = new WcfFoundationService.FoundationServiceClient())
        {
            _proxy.ArchiveAuditEvents();
        }
    }

    public static void LogEvent(string description, string operatingOn, string page, AuditEventType eventType)
    {
        AuditEvents ae = new AuditEvents
        {
            ID = -1,
            CreatedDate = DateTime.Now,
            Creator = Util.GetCurrentUser(),
            Description = description,
            OperatingOn = operatingOn,
            EventType = Convert.ToInt16(eventType),
            PageName = page
        };

        LogAuditEvent(ae);
    }

    private static void LogAuditEvent(AuditEvents ae)
    {
        using (var proxy = new WcfFoundationService.FoundationServiceClient())
        {
            proxy.SaveAuditEvents(ae);
        }
    }

    public void SaveAuditEvents(AuditEvents AuditEvents)
    {
        using (_proxy = new WcfFoundationService.FoundationServiceClient())
        {
            _proxy.SaveAuditEvents(AuditEvents);
        }
    }

    public void UpdateAuditEvents(AuditEvents AuditEvents)
    {
        using (_proxy = new WcfFoundationService.FoundationServiceClient())
        {
            AuditEvents origAuditEvents = _proxy.GetAuditEvents(AuditEvents.ID);
            AuditEvents.Version = origAuditEvents.Version;
            _proxy.UpdateAuditEvents(AuditEvents, origAuditEvents);
        }
    }

    public AuditEvents GetByID(int id)
    {
        using (_proxy = new WcfFoundationService.FoundationServiceClient())
        {
            return _proxy.GetAuditEvents(id);
        }
    }

    public List<string> AuditEventDescriptions()
    {
        using (_proxy = new WcfFoundationService.FoundationServiceClient())
        {
            return _proxy.AuditEventDescriptions().ToList<string>();
        }
    }

    public void DeleteAuditEvents(AuditEvents AuditEvents)
    {
        using (_proxy = new WcfFoundationService.FoundationServiceClient())
        {
            AuditEvents = _proxy.GetAuditEvents(AuditEvents.ID);
            _proxy.DeleteAuditEvents(AuditEvents);
        }
    }

    public List<AuditEvents> GetAuditEvents()
    {
        using (_proxy = new WcfFoundationService.FoundationServiceClient())
        {
            return _proxy.GetAllAuditEventss().OrderByDescending(q => q.CreatedDate).ToList<AuditEvents>();
        }
    }

    public List<AuditEvents> GetAllAuditEvents(string description, string creator, DateTime createdDate)
    {
        using (_proxy = new WcfFoundationService.FoundationServiceClient())
        {
            return _proxy.GetAllAuditEvents(description, creator, createdDate)
                .OrderByDescending(q => q.CreatedDate)
                .ToList<AuditEvents>();
        }
    }

    #region IDisposable Members

    public void Dispose()
    {
        _proxy.Close();
        _proxy = null;
    }

    #endregion

    ~AuditEventsUI()
    {
        if (_proxy != null)
            _proxy.Close();
    }
}