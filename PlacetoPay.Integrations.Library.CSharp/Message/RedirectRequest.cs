using PlacetoPay.Integrations.Library.CSharp.Contracts;
using PlacetoPay.Integrations.Library.CSharp.Entities;

namespace PlacetoPay.Integrations.Library.CSharp.Message
{
    public class RedirectRequest : Entity
    {
        private string locale;
        private Person payer;
        private Person buyer;
        private Payment payment;
        private Subscription subscription;
        private string returnUrl;
        private string paymentMethod;
        private string cancelUrl;
        private string ipAddress;
        private string userAgent;
        private string expiration;
        private bool captureAddress;
        private bool skipResult = false;
        private bool noBuyerFill = false;
        private Fields fields;

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

        public string Language()
        {
            return this.locale.Substring(0, 2).ToUpper();
        }

        public string Reference()
        {
            return payment.Reference ?? subscription.Reference;
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

        public Subscription Subscription
        {
            get
            {
                return subscription;
            }

            set
            {
                subscription = value;
            }
        }

        public string ReturnUrl
        {
            get
            {
                return returnUrl;
            }

            set
            {
                returnUrl = value;
            }
        }

        public string PaymentMethod
        {
            get
            {
                return paymentMethod;
            }

            set
            {
                paymentMethod = value;
            }
        }

        public string CancelUrl
        {
            get
            {
                return cancelUrl;
            }

            set
            {
                cancelUrl = value;
            }
        }

        public string IpAddress
        {
            get
            {
                return ipAddress;
            }

            set
            {
                ipAddress = value;
            }
        }

        public string UserAgent
        {
            get
            {
                return userAgent;
            }

            set
            {
                userAgent = value;
            }
        }

        public string Expiration
        {
            get
            {
                return expiration;
            }

            set
            {
                expiration = value;
            }
        }

        public bool CaptureAddress
        {
            get
            {
                return captureAddress;
            }

            set
            {
                captureAddress = value;
            }
        }

        public bool SkipResult
        {
            get
            {
                return skipResult;
            }

            set
            {
                skipResult = value;
            }
        }

        public bool NoBuyerFill
        {
            get
            {
                return noBuyerFill;
            }

            set
            {
                noBuyerFill = value;
            }
        }

        public Fields Fields
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
