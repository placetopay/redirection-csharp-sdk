using System.Collections.Generic;

namespace PlacetoPay.Integrations.Library.CSharp.Entities
{
    public class Fields
    {
        private List<NameValuePair> item;

        public Fields(List<NameValuePair> item)
        {
            this.Item = item;
        }

        public List<NameValuePair> Item
        {
            get
            {
                return item;
            }

            set
            {
                item = value;
            }
        }
    }
}
