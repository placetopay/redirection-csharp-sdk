using System.Collections.Generic;

namespace PlacetoPay.Integrations.Library.CSharp.Entities
{
    public class Transaction
    {
        private Status status;
        private string reference;
        private int internalReference;
        private string paymentMethod;
        private string paymentMethodName;
        private string issuerName;
        private AmountConversion amount;
        private string authorization;
        private long receipt;
        private string franchise;
        private bool refunded = false;
        public List<NameValuePair> processorFields { get; set; }

        public Transaction(Status status, string reference, int internalReference, string paymentMethod, string paymentMethodName, string issuerName, AmountConversion amount, string authorization, long receipt, string franchise, bool refunded, List<NameValuePair> processorFields)
        {
            this.status = status;
            this.reference = reference;
            this.internalReference = internalReference;
            this.paymentMethod = paymentMethod;
            this.paymentMethodName = paymentMethodName;
            this.issuerName = issuerName;
            this.amount = amount;
            this.authorization = authorization;
            this.receipt = receipt;
            this.franchise = franchise;
            this.refunded = refunded;
            this.processorFields = processorFields;
        }

        public Status Status
        {
            get { return status; }
            set { status = value; }
        }

        public string Reference
        {
            get { return reference; }
            set { reference = value; }
        }

        public int InternalReference
        {
            get { return internalReference; }
            set { internalReference = value; }
        }

        public string PaymentMethod
        {
            get { return paymentMethod; }
            set { paymentMethod = value; }
        }

        public string PaymentMethodName
        {
            get { return paymentMethodName; }
            set { paymentMethodName = value; }
        }

        public string IssuerName
        {
            get { return issuerName; }
            set { issuerName = value; }
        }

        public AmountConversion Amount
        {
            get { return amount; }
            set { amount = value; }
        }

        public string Authorization
        {
            get { return authorization; }
            set { authorization = value; }
        }

        public long Receipt
        {
            get { return receipt; }
            set { receipt = value; }
        }

        public string Franchise
        {
            get { return franchise; }
            set { franchise = value; }
        }

        public bool Refunded
        {
            get { return refunded; }
            set { refunded = value; }
        }


        public bool IsSuccessful()
        {
            return (this.status != null) && (!this.status.status.Equals(Status.ST_ERROR));
        }

        public bool IsApproved()
        {
            return (this.status != null) && (!this.status.status.Equals(Status.ST_APPROVED));
        }

    }
}
