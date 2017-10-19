using System.Collections.Generic;

namespace PlacetoPay.Integrations.Library.CSharp.Entities.ModelSubscription
{
    public class Instrument
    {
        public List<NameValuePair> item { get; set; }

        public Instrument(List<NameValuePair> item)
        {
            this.item = item;
        }
    }
}
