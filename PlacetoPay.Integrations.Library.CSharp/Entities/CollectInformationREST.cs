using PlacetoPay.Integrations.Library.CSharp.Message;
using System.Collections.Generic;

namespace PlacetoPay.Integrations.Library.CSharp.Entities
{
    public class CollectInformationREST
    {
        private int requestId;
        private Status status;
        private RedirectRequest request;
        private List<Transaction> payment;
        private SubscriptionInformation subscription;

        public CollectInformationREST(int requestId, Status status, RedirectRequest request, List<Transaction> payment, SubscriptionInformation subscription)
        {
            this.requestId = requestId;
            this.status = status;
            this.request = request;
            this.payment = payment;
            this.subscription = subscription;
        }

        public Transaction FirstTransaction()
        {
            if (this.payment == null)
                return null;

            return this.payment[0];
        }

        public int RequestId
        {
            get
            {
                return requestId;
            }

            set
            {
                requestId = value;
            }
        }

        public Status Status
        {
            get
            {
                return status;
            }

            set
            {
                status = value;
            }
        }

        public RedirectRequest Request
        {
            get
            {
                return request;
            }

            set
            {
                request = value;
            }
        }

        public List<Transaction> Payment
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

        public SubscriptionInformation Subscription
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
    }
}
