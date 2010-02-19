using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Text;
using SP.Core.Domain;
using SP.Core.DataInterfaces;

namespace SP.Data.LTS
{
    /// <summary>
    /// Simple class to implement DataContext singleton.
    /// </summary>
    public sealed class LTSDataContextManager
    {
        private LTSDataContext db;

        #region Thread-safe, lazy Singleton

        /// <summary>
        /// This is a thread-safe, lazy singleton.  
        /// See http://www.yoda.arachsys.com/csharp/singleton.html
        /// for more details about its implementation.
        /// </summary>
        public static LTSDataContextManager Instance
        {
            get
            {
                return Nested.dataContextManager;
            }
        }

        /// <summary>
        /// Initializes BoPDataContext.
        /// </summary>
        private LTSDataContextManager()
        {
            InitDB();
        }

        /// <summary>
        /// Assists with ensuring thread-safe, lazy singleton
        /// </summary>
        private class Nested
        {
            static Nested() { }
            internal static readonly LTSDataContextManager dataContextManager =
                new LTSDataContextManager();
        }

        #endregion

        private void InitDB()
        {

            db = new LTSDataContext();
            DataLoadOptions dlo = new DataLoadOptions();
            dlo.LoadWith<FoundationFacility>(r => r.Address);
            dlo.LoadWith<Customer>(o => o.Note);
            dlo.LoadWith<Phone>(o => o.PhoneNoType);
            db.LoadOptions = dlo;
        //    db.Log = Console.Out;
           // db.ObjectTrackingEnabled = false;
        }

        public LTSDataContext GetContext()
        {
            return db;

        }

    }

}


