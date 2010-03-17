using System;
using System.Collections.Generic;
using System.Text;
using SP.Core.Domain;

namespace SP.Core.DataInterfaces
{
    public interface IAutogenDao : IDao<AutoGen, int>
    {
        int Generate(string type);
    }
}
