using System;
using System.Security.Cryptography;
using System.Text;
using System.Xml;

namespace PlacetoPay.Integrations.Library.CSharp
{
    public class Utils
    {
        public static byte[] Sha1(string input)
        {
            using (SHA1Managed sha1 = new SHA1Managed())
            {
                return sha1.ComputeHash(Encoding.ASCII.GetBytes(input));
            }
        }

        public static string Base64(byte[] input)
        {
            return Convert.ToBase64String(input);
        }

        // XML NULL FIELD REMOVAL
        // Removes all Null fields (both with nil=true) from a XmlDoc

        public static XmlDocument RemoveNullFields(XmlDocument xmldoc)
        {
            XmlNamespaceManager mgr = new XmlNamespaceManager(xmldoc.NameTable);
            mgr.AddNamespace("xsi", "http://www.w3.org/2001/XMLSchema-instance");

            XmlNodeList nullFields = xmldoc.SelectNodes("//*[@xsi:nil='true']", mgr);

            if (nullFields != null && nullFields.Count > 0)
            {
                for (int i = 0; i < nullFields.Count; i++)
                {
                    nullFields[i].ParentNode.RemoveChild(nullFields[i]);
                }
            }

            return xmldoc;
        }
    }
}
