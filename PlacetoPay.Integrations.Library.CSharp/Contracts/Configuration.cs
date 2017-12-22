using PlacetoPay.Integrations.Library.CSharp.Carrier;
using System;
using System.Collections.Generic;

namespace PlacetoPay.Integrations.Library.CSharp.Contracts
{
    public class Configuration
    {
        public const int SOAP_1_1 = 1;
        public const int SOAP_1_2 = 2;

        public string login;
        private string tranKey;
        private Uri url;
        private string type;
        private Dictionary<string, string> additional;
        private Authentication.Auth auth;
        private string wsdl;
        private string location;
        private int soapVersion = SOAP_1_1;

        public Configuration(string login, string tranKey, Uri url, string type, Dictionary<string, string> additional = null, Authentication.Auth auth = null)
        {
            this.login = login;
            this.tranKey = tranKey;
            this.url = url;
            this.type = type;
            this.additional = additional;
            this.auth = auth;
        }
        
        public string Login
        {
            get { return login; }
            set { login = value; }
        }
        public string TranKey
        {
            get { return tranKey; }
            set { tranKey = value; }
        }
        public Uri Url
        {
            get { return url; }
            set { url = value; }
        }
        public string Type
        {
            get { return type; }
            set { type = value; }
        }
        public Dictionary<string, string> Additional
        {
            get { return additional; }
            set { additional = value; }
        }
        public Authentication.Auth Auth
        {
            get { return auth; }
            set { auth = value; }
        }
        public string Wsdl
        {
            get { return wsdl; }
            set { wsdl = value; }
        }
        public string Location
        {
            get { return location; }
            set { location = value; }
        }
        public int SoapVersion
        {
            get { return soapVersion; }
            set { soapVersion = value; }
        }
    }
}


