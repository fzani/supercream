using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Configuration;

namespace SP.Mvp.FitnesseTests
{
    public static class Connection
    {
        public static string SuperCreamConnection
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["SuperCreamDBConnectionString"].ToString();
            }
        }
    }
}
