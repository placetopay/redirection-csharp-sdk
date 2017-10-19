using PlacetoPay.Integrations.Library.CSharp.Contracts;
using PlacetoPay.Integrations.Library.CSharp.Entities;
using System.Collections.Generic;

namespace PlacetoPay.Integrations.Library.CSharp.Message
{
    public class RedirectInformationSOAP : Entity
    {
        protected int requestId;
        protected Status status;
        protected RedirectRequest request;
        protected List<TransactionSOAP> payment;
        protected SubscriptionInfomationSOAP subscription;

        public RedirectInformationSOAP (int requestId, Status status, RedirectRequest request, List<TransactionSOAP> payment, SubscriptionInfomationSOAP subscription)
        {
            this.requestId = requestId;
            this.status = status;
            this.request = request;
            this.Payment = payment;
            this.Subscription = subscription;
        }

        public int RequestId { get => requestId; set => requestId = value; }
        public Status Status { get => status; set => status = value; }
        public RedirectRequest Request { get => request; set => request = value; }
        public List<TransactionSOAP> Payment { get => payment; set => payment = value; }
        internal SubscriptionInfomationSOAP Subscription { get => subscription; set => subscription = value; }

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

    }
}
