using System.Collections.Generic;

namespace PlacetoPay.Integrations.Library.CSharp.Entities.ModelSubscription
{
    public class ProcessorFields
    {
        public List<NameValuePair> item { get; set; }

        public ProcessorFields(List<NameValuePair> item)
        {
            this.item = item;
        }
    }
}
