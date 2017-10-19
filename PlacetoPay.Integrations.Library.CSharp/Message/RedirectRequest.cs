using PlacetoPay.Integrations.Library.CSharp.Contracts;
using PlacetoPay.Integrations.Library.CSharp.Entities;

namespace PlacetoPay.Integrations.Library.CSharp.Message
{
    public class RedirectRequest : Entity
    {
        protected string locale;
        protected Person payer;
        protected Person buyer;
        protected Payment payment;
        protected Subscription subscription;
        protected string returnUrl;
        protected string paymentMethod;
        protected string cancelUrl;
        protected string ipAddress;
        protected string userAgent;
        protected string expiration;
        protected bool captureAddress;
        protected bool skipResult = false;
        protected bool noBuyerFill = false;
        protected Fields fields;

        public RedirectRequest(Payment payment, string returnUrl, string ipAddress, string userAgent, string expiration, string paymentMethod = null, string cancelUrl = null, bool captureAddress = false, bool skipResult = false, bool noBuyerFill= false, Person payer = null, Person buyer = null, string locale = "es_CO")
        {
            this.payment = payment;
            this.SetProperties(returnUrl, ipAddress, userAgent, expiration, paymentMethod, cancelUrl, captureAddress, skipResult, noBuyerFill, payer, buyer, locale);
        }

        public RedirectRequest(Subscription subscription, string returnUrl, string ipAddress, string userAgent, string expiration, string paymentMethod = null, string cancelUrl = null, bool captureAddress = false, bool skipResult = false, bool noBuyerFill = false, Person payer = null, Person buyer = null, string locale = "es_CO")
        {
            this.subscription = subscription;
            this.SetProperties(returnUrl, ipAddress, userAgent, expiration, paymentMethod, cancelUrl, captureAddress, skipResult, noBuyerFill, payer, buyer, locale);
        }

        public RedirectRequest()
        {
        }

        private void SetProperties(string returnUrl, string ipAddress, string userAgent, string expiration, string paymentMethod, string cancelUrl, bool captureAddress, bool skipResult, bool noBuyerFill, Person payer, Person buyer, string locale)
        {
            this.locale = locale;
            this.payer = payer;
            this.buyer = buyer;
            this.returnUrl = returnUrl;
            this.paymentMethod = paymentMethod;
            this.cancelUrl = cancelUrl;
            this.ipAddress = ipAddress;
            this.userAgent = userAgent;
            this.expiration = expiration;
            this.captureAddress = captureAddress;
            this.skipResult = skipResult;
            this.noBuyerFill = noBuyerFill;
        }

        public string Locale { get => locale; set => locale = value; }
        public Person Payer { get => payer; set => payer = value; }
        public Person Buyer { get => buyer; set => buyer = value; }
        public Payment Payment { get => payment; set => payment = value; }
        public Subscription Subscription { get => subscription; set => subscription = value; }
        public string ReturnUrl { get => returnUrl; set => returnUrl = value; }
        public string PaymentMethod { get => paymentMethod; set => paymentMethod = value; }
        public string CancelUrl { get => cancelUrl; set => cancelUrl = value; }
        public string IpAddress { get => ipAddress; set => ipAddress = value; }
        public string UserAgent { get => userAgent; set => userAgent = value; }
        public string Expiration { get => expiration; set => expiration = value; }
        public bool CaptureAddress { get => captureAddress; set => captureAddress = value; }
        public bool SkipResult { get => skipResult; set => skipResult = value; }
        public bool NoBuyerFill { get => noBuyerFill; set => noBuyerFill = value; }
        public Fields Fields { get => fields; set => fields = value; }

        public string Language()
        {
            return this.locale.Substring(0, 2).ToUpper();
        }

        public string Reference()
        {
            return payment.Reference ?? subscription.Reference;
        }

    }
}
