using PlacetoPay.Integrations.Library.CSharp.Entities.ModelSubscription;

namespace PlacetoPay.Integrations.Library.CSharp.Entities
{
    public class TransactionSOAP
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
        private ProcessorFields processorFields;

        public TransactionSOAP(Status status, string reference, int internalReference, string paymentMethod, string paymentMethodName, string issuerName, AmountConversion amount, string authorization, long receipt, string franchise, bool refunded, ModelSubscription.ProcessorFields processorFields)
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
            this.ProcessorFields = processorFields;
        }

        public Status Status { get => status; set => status = value; }
        public string Reference { get => reference; set => reference = value; }
        public int InternalReference { get => internalReference; set => internalReference = value; }
        public string PaymentMethod { get => paymentMethod; set => paymentMethod = value; }
        public string PaymentMethodName { get => paymentMethodName; set => paymentMethodName = value; }
        public string IssuerName { get => issuerName; set => issuerName = value; }
        public AmountConversion Amount { get => amount; set => amount = value; }
        public string Authorization { get => authorization; set => authorization = value; }
        public long Receipt { get => receipt; set => receipt = value; }
        public string Franchise { get => franchise; set => franchise = value; }
        public bool Refunded { get => refunded; set => refunded = value; }
        public ProcessorFields ProcessorFields { get => processorFields; set => processorFields = value; }

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
