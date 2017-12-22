using PlacetoPay.Integrations.Library.CSharp.Contracts;

namespace PlacetoPay.Integrations.Library.CSharp.Entities
{
    public class Subscription : Entity
    {
        private string reference;
        private string description;

        public Subscription(string reference, string description)
        {
            this.reference = reference;
            this.description = description;
        }

        public string Reference
        {
            get
            {
                return reference;
            }

            set
            {
                reference = value;
            }
        }

        public string Description
        {
            get
            {
                return description;
            }

            set
            {
                description = value;
            }
        }

    }
}
