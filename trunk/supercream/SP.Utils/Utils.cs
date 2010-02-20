using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Web.UI.WebControls;

namespace SP.Util
{
    public class Utils
    {       
        public static string GetPrePostFix(int id, EntityType entityType)
        {
            // Read whether or not Prefix or Post Fix Type and PrePostFix value from Database
            // using EntityType.

            string prePostFixValue = "L";
            string aphaID = String.Empty;
            PrePostFixType pType = PrePostFixType.CustomerPrefix;

            switch (pType)
            {
                case PrePostFixType.CustomerPrefix:
                case PrePostFixType.OutletStorePrefix:
                    aphaID = prePostFixValue + id.ToString();
                    break;
                case PrePostFixType.CustomerPostfix:
                case PrePostFixType.OutletStorePostfix:
                    aphaID = id.ToString() + prePostFixValue;
                    break; 
                default:
                    break;

            }
            return aphaID;
        }

        public static List<String> ConvertAddressLinesFromXml(string addressLines)
        {
            List<string> addressLineList = new List<string>();
            MemoryStream mem = new MemoryStream();
            StringReader r = new StringReader(addressLines);

            XmlSerializer serialiser = new XmlSerializer(typeof(List<string>));
            addressLineList = (List<string>)serialiser.Deserialize(r);
            r.Close();

            return addressLineList;
        }

        public static string ConvertAddressLinesToXml(TextBox addressLine1, TextBox addressLine2)
        {
            List<string> addressLines = new List<string>();
            addressLines.Add(addressLine1.Text);
            if (addressLine2.Text.Length != 0)
                addressLines.Add(addressLine2.Text);

            MemoryStream mem = new MemoryStream();
            XmlSerializer serialiser = new XmlSerializer(typeof(List<string>));
            serialiser.Serialize(mem, addressLines);

            mem.Position = 0;
            TextReader r = new StreamReader(mem);
            return r.ReadToEnd();
        }

        public static string ConvertAddressLinesToXml(string addressLine1, string addressLine2)
        {
            List<string> addressLines = new List<string>();
            addressLines.Add(addressLine1);
            if (addressLine2.Length != 0)
                addressLines.Add(addressLine2);

            MemoryStream mem = new MemoryStream();
            XmlSerializer serialiser = new XmlSerializer(typeof(List<string>));
            serialiser.Serialize(mem, addressLines);

            mem.Position = 0;
            TextReader r = new StreamReader(mem);
            return r.ReadToEnd();
        }
    }
}

