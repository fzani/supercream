using System;
using System.Collections.Generic;
using System.Text;
using SP.Core.Domain;

namespace SP.Core.DataInterfaces
{
    public interface IFoundationFacilityDao : IDao<FoundationFacility, int>
    {
        bool Exists();
        FoundationFacility Get();
    }
}
