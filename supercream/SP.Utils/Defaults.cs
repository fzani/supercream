using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SP.Utils
{
    public class Defaults
    {
        public static DateTime MinDateTime
        {
            get
            {
                return new DateTime(1800, 1, 1);
            }
        }
    }
}
