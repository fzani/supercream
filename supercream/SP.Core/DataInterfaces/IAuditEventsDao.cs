using System;
using System.Collections.Generic;
using SP.Core.Domain;

namespace SP.Core.DataInterfaces
{
    public interface IAuditEventsDao : IDao<AuditEvents, int>
    {
        void ArchiveAuditEvents();
        List<AuditEvents> GetAllAuditEvents(string description, string creator, DateTime createdDate);
        List<string> Descriptions();
    }
}