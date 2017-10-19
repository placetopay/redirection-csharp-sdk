using PlacetoPay.Integrations.Library.CSharp.Contracts;
using System.Collections.Generic;

namespace PlacetoPay.Integrations.Library.CSharp.Entities
{
    public class SubscriptionInformation : Entity
    {
        private string type;
        private Status status;
        private List<NameValuePair> instrument;

        public SubscriptionInformation(string type, Status status, List<NameValuePair> instrument)
        {
            this.type = type;
            this.status = status;
            this.Instrument = instrument;
        }

        public string Type { get => type; set => type = value; }
        public Status Status { get => status; set => status = value; }
        public List<NameValuePair> Instrument { get => instrument; set => instrument = value; }
    }
}
