using PlacetoPay.Integrations.Library.CSharp.Carrier;
using PlacetoPay.Integrations.Library.CSharp.Message;

namespace PlacetoPay.Integrations.Library.CSharp.Contracts
{
    public abstract class Carrier
    {
        private Authentication authentication;
        private Configuration config;

        public Carrier(Authentication authentication, Configuration config)
        {
            this.authentication = authentication;
            this.config = config;
        }

        protected Authentication Authentication
        {
            get
            {
                return authentication;
            }

            set
            {
                authentication = value;
            }
        }

        protected Configuration Config
        {
            get
            {
                return config;
            }

            set
            {
                config = value;
            }
        }

        public abstract RedirectResponse Request(RedirectRequest redirectRequest);

        public abstract RedirectInformation Query(string requestId);

        public abstract RedirectInformation Collect(CollectRequest collectRequest);

        public abstract ReverseResponse Reverse(string transactionId);
    }
}
