using PlacetoPay.Integrations.Library.CSharp.Carrier;
using System;
using System.Collections.Generic;

namespace PlacetoPay.Integrations.Library.CSharp.Contracts
{
    public class Configuration
    {
        public const int SOAP_1_1 = 1;
        public const int SOAP_1_2 = 2;

        private string login;
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

        public string Login { get => login; set => login = value; }
        public string TranKey { get => tranKey; set => tranKey = value; }
        public Uri Url { get => url; set => url = value; }
        public string Type { get => type; set => type = value; }
        public Dictionary<string, string> Additional { get => additional; set => additional = value; }
        public Authentication.Auth Auth { get => auth; set => auth = value; }
        public string Wsdl { get => wsdl; set => wsdl = value; }
        public string Location { get => location; set => location = value; }
        public int SoapVersion { get => soapVersion; set => soapVersion = value; }
    }
}


