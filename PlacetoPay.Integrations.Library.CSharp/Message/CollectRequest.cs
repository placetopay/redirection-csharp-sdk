using PlacetoPay.Integrations.Library.CSharp.Contracts;
using PlacetoPay.Integrations.Library.CSharp.Entities;
using System.Collections.Generic;

namespace PlacetoPay.Integrations.Library.CSharp.Message
{
    public class CollectRequest : Entity
    {
        private string locale;
        private Person payer;
        private Person buyer;
        private Payment payment;
        private Instrument instrument;
        private List<NameValuePair> fields;

        public CollectRequest(Person payer, Payment payment, Instrument instrument, string locale = "es_CO", Person buyer = null)
        {
            this.locale = locale;
            this.payer = payer;
            this.buyer = buyer;
            this.payment = payment;
            this.instrument = instrument;
        }

        public string Language()
        {
            return locale.Substring(0, 2).ToUpper();
        }

        public string Locale
        {
            get
            {
                return locale;
            }

            set
            {
                locale = value;
            }
        }

        public Person Payer
        {
            get
            {
                return payer;
            }

            set
            {
                payer = value;
            }
        }

        public Person Buyer
        {
            get
            {
                return buyer;
            }

            set
            {
                buyer = value;
            }
        }

        public Payment Payment
        {
            get
            {
                return payment;
            }

            set
            {
                payment = value;
            }
        }

        public Instrument Instrument
        {
            get
            {
                return instrument;
            }

            set
            {
                instrument = value;
            }
        }

        public List<NameValuePair> Fields
        {
            get
            {
                return fields;
            }

            set
            {
                fields = value;
            }
        }

    }
}
