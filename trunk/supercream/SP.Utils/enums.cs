using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SP.Util
{
    public enum EntityType
    {
        Customer, 
        Order,
        OutletStore
    }

    public enum PrePostFixType
    {
        CustomerPrefix,
        CustomerPostfix,
        OutletStorePrefix,
        OutletStorePostfix
    }
}
