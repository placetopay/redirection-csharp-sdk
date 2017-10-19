using PlacetoPay.Integrations.Library.CSharp.Contracts;
using PlacetoPay.Integrations.Library.CSharp.Entities;
using System.Collections.Generic;

namespace PlacetoPay.Integrations.Library.CSharp.Message
{
    public class CollectRequest : Entity
    {
        protected string locale;
        protected Person payer;
        protected Person buyer;
        protected Payment payment;
        protected Instrument instrument;
        protected List<NameValuePair> fields;

        public CollectRequest(Person payer, Payment payment, Instrument instrument, string locale = "es_CO", Person buyer = null)
        {
            this.locale = locale;
            this.payer = payer;
            this.buyer = buyer;
            this.payment = payment;
            this.instrument = instrument;
        }

        public string Locale { get => locale; set => locale = value; }
        public Person Payer { get => payer; set => payer = value; }
        public Person Buyer { get => buyer; set => buyer = value; }
        public Payment Payment { get => payment; set => payment = value; }
        public Instrument Instrument { get => instrument; set => instrument = value; }
        public List<NameValuePair> Fields { get => fields; set => fields = value; }

        public string Language()
        {
            return locale.Substring(0, 2).ToUpper();
        }

    }
}
