using PlacetoPay.Integrations.Library.CSharp.Entities;
using System.Collections.Generic;

namespace PlacetoPay.Integrations.Library.CSharp.Message
{
    public class RedirectInformation
    {
        private int requestId;
        private Status status;
        private RedirectRequest request;
        private List<Transaction> payment;
        private SubscriptionInformation subscription;

        public RedirectInformation(int requestId, Status status, RedirectRequest request, List<Transaction> payment, SubscriptionInformation subscription)
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

        public bool IsSuccessful()
        {
            return !this.status.status.Equals(Status.ST_ERROR);
        }

        public bool IsApproved()
        {
            return this.status.status.Equals(Status.ST_APPROVED);
        }

        public bool IsRejected()
        {
            return this.status.status.Equals(Status.ST_REJECTED);
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
