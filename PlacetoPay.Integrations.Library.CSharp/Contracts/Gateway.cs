using PlacetoPay.Integrations.Library.CSharp.Exceptions;
using PlacetoPay.Integrations.Library.CSharp.Message;
using System;
using System.Linq;

namespace PlacetoPay.Integrations.Library.CSharp.Contracts
{
    public abstract class Gateway
    {
        public const string TP_SOAP = "SOAP";
        public const string TP_REST = "REST";

        public string type;
        public Carrier carrier;
        public Configuration config;

        public Gateway(string login, string trankey, Uri url, string type = TP_REST)
        {
            if (login == null || trankey == null)
                throw new PlacetoPayException("No login or trankey provided on gateway");

            if (url == null)
                throw new PlacetoPayException("No service URL provided on gateway");

            if (this.IsExistType(type))
                this.type = type;

            this.config = new Configuration(login, trankey, url, type);
        }

        public void Using(string type)
        {
            if(this.IsExistType(type))
            {
                this.type = type;
                this.carrier = null;
            }
            else
            {
                throw new PlacetoPayException("The only connection methods are SOAP or REST");
            }
        }

        public bool IsExistType(string type)
        {
            string[] types = new string[] { TP_REST, TP_SOAP };

            return types.Contains(type);
        }

        public Notification ReadNotification(string content)
        {
            if(content == null)
            {
                throw new BadPlacetoPayException("The notification content is empty");
            }

            try
            {
                // return new Notification(content, );
            }
            catch
            {

            }

            return null;
        }

        public Gateway AddAuthenticationHeader()
        {
            return null;
        }

        public abstract RedirectResponse Request(RedirectRequest redirectRequest);
        public abstract RedirectInformation Query(String requestId);
        public abstract RedirectInformation Collect(CollectRequest collectRequest);
        public abstract ReverseResponse Reverse(string internalReference);
    }
}
