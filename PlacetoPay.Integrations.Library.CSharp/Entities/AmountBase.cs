using PlacetoPay.Integrations.Library.CSharp.Contracts;

namespace PlacetoPay.Integrations.Library.CSharp.Entities
{
    public class AmountBase : Entity
    {
        private string currency;
        private float total;

        public AmountBase(float total, string currency)
        {
            this.currency = currency;
            this.total = total;
        }

        public string Currency { get => currency; set => currency = value; }
        public float Total { get => total; set => total = value; }
    }
}
