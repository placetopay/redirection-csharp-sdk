using PlacetoPay.Integrations.Library.CSharp.Contracts;

namespace PlacetoPay.Integrations.Library.CSharp.Entities
{
    public class TaxDetail : Entity
    {
        private string kind;
        private string amount;
        private string baseAmount;

        public TaxDetail(string kind, string amount, string baseAmount)
        {
            this.kind = kind;
            this.amount = amount;
            this.baseAmount = baseAmount;
        }

        public string Kind { get => kind; set => kind = value; }
        public string Amount { get => amount; set => amount = value; }
        public string BaseAmount { get => baseAmount; set => baseAmount = value; }
    }
}
