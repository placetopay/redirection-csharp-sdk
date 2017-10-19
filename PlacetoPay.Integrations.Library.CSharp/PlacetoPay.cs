using System;
using PlacetoPay.Integrations.Library.CSharp.Contracts;
using PlacetoPay.Integrations.Library.CSharp.Message;
using PlacetoPay.Integrations.Library.CSharp.Carrier;
using System.Collections.Generic;
using PlacetoPay.Integrations.Library.CSharp.Entities;

namespace PlacetoPay.Integrations.Library.CSharp
{
    public class PlacetoPay : Gateway
    {
        public PlacetoPay(string login, string  trankey, Uri url, string type = null) :
            base(login, trankey, url, type)
        { }

        private Contracts.Carrier Carrier()
        {
            if(this.carrier != null)
                return this.carrier;

            Authentication authentication = new Authentication(this.config.Login, this.config.TranKey, this.config.Auth);

            if (this.config.Type.Equals(TP_SOAP))
            {
                this.config.Wsdl = this.config.Url.ToString() + "/soap/redirect/?wsdl";
                this.config.Location = this.config.Url.ToString() + "/soap/redirect";
                this.carrier = new SoapCarrier(authentication, this.config);
            }
            else
            {
                this.carrier = new RestCarrier(authentication, this.config);
            }

            return this.carrier;
        }

        public override RedirectInformation Collect(CollectRequest collectRequest)
        {
            return this.Carrier().Collect(collectRequest);
        }

        public override RedirectInformation Query(string requestId)
        {
            return this.Carrier().Query(requestId);
        }

        public override RedirectResponse Request(RedirectRequest redirectRequest)
        {
            return this.Carrier().Request(redirectRequest);
        }

        public override ReverseResponse Reverse(string internalReference)
        {
            return this.Carrier().Reverse(internalReference);
        }
    }
}