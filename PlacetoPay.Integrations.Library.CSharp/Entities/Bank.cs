using Newtonsoft.Json;
using PlacetoPay.Integrations.Library.CSharp.Contracts;

namespace PlacetoPay.Integrations.Library.CSharp.Entities
{
    public class Bank : Entity
    {
        public const int INT_PUBLIC = 0;
        public const int INT_BUSINESS = 1;

        [JsonProperty(PropertyName = "interface")]
        private int einterface;
        private string code;
        private string name;

        public Bank(string code, string name, int einterface = 0)
        {
            this.einterface = einterface;
            this.code = code;
            this.name = name;
        }
        public int Einterface
        {
            get { return einterface; }
            set { einterface = value; }
        }

        public string Code
        {
            get { return code; }
            set { code = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
    }
}
