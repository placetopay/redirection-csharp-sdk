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
            this.instrument = instrument;
        }

        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        public Status Status
        {
            get { return status; }
            set { status = value; }
        }

        public List<NameValuePair> Instrument
        {
            get { return instrument; }
            set { instrument = value; }
        }

    }
}
