/**************************************************************
 * Project: National Westminster Council Proccurement System.
 * Filename: UrlParameterPasser.cs
 * Namespace: N/A 
 * Class: UrlParameterPasser
 * 
 * Description: Provides Class for passing URL Parameters between
 *              page requests.
 * 
 * Version History
 * Version    Date        Initials    Description
 * ------------------------------------------------------------
 * 1.0        31/10/2008  JC         Initial version.
 **************************************************************/

using System;
using System.Web;
using System.Collections;

/// <summary>
/// Provides Class for passing URL Parameters between
/// page requests.
/// </summary>
/// 
namespace SP.Util
{
    public class UrlParameterPasser : BaseParameterPasser
    {
        #region Member Variables
        private SortedList localQueryString = null;
        #endregion

        #region Constructors
        public UrlParameterPasser() : base() { }
        public UrlParameterPasser(string Url) : base(Url) { }
        #endregion

        #region Methods
        /// <summary>
        /// Constructs Query String and calls Response.Redirect for provided URL.
        /// </summary>		
        /// <returns>void</returns>
        public override void PassParameters()
        {
            // add parameters, if any exist
            if (localQueryString.Count > 0)
            {
                // see if we need to add the ?
                if (base.Url.IndexOf("?") == -1)
                    base.Url += "?";
                else
                    base.Url += "&";

                bool firstOne = true;
                foreach (DictionaryEntry o in localQueryString)
                {
                    if (!firstOne)
                        base.Url += "&";
                    else
                        firstOne = false;

                    base.Url += string.Concat(HttpContext.Current.Server.UrlEncode(o.Key.ToString()), "=", HttpContext.Current.Server.UrlEncode(o.Value.ToString()));
                }
            }

            base.PassParameters();
        }
        #endregion

        #region Properties
        public override string this[string name]
        {
            get
            {
                if (localQueryString == null)
                {
                    if (HttpContext.Current != null)
                        return HttpContext.Current.Request.QueryString[name];
                    else
                        return null;
                }
                else
                    return localQueryString[name].ToString();
            }
            set
            {
                if (localQueryString == null)
                    localQueryString = new SortedList();

                // add if it is new, or replace the old value
                if ((localQueryString[name]) == null)
                    localQueryString.Add(name, value);
                else
                    localQueryString[name] = value;
            }
        }

        public override ICollection Keys
        {
            get
            {
                if (localQueryString == null)
                {
                    if (HttpContext.Current != null)
                        return HttpContext.Current.Request.QueryString.Keys;
                    else
                        return null;
                }
                else
                    return localQueryString.Keys;
            }
        }

        public virtual void Add(string key, string value)
        {
            if (localQueryString == null)
                localQueryString = new SortedList();

            // add if it is new, or replace the old value
            if ((localQueryString[key]) == null)
                localQueryString.Add(key, value);
            else
                localQueryString[key] = value;
        }

        #endregion
    }
}

