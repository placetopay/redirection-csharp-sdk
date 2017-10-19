namespace PlacetoPay.Integrations.Library.CSharp.Entities
{
    public class SubscriptionInfomationSOAP
    {
        private string type;
        private Status status;
        private ModelSubscription.Instrument instrument;

        public SubscriptionInfomationSOAP(string type, Status status, ModelSubscription.Instrument instrument)
        {
            this.type = type;
            this.status = status;
            this.instrument = instrument;
        }

        public string Type { get => type; set => type = value; }
        public Status Status { get => status; set => status = value; }
        public ModelSubscription.Instrument Instrument { get => instrument; set => instrument = value; }
    }
}
