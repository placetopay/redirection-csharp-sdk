using PlacetoPay.Integrations.Library.CSharp.Contracts;

namespace PlacetoPay.Integrations.Library.CSharp.Entities
{
    public class AmountDetail :  Entity
    {
        private string kind;
        private float amount;

        public AmountDetail(string kind, float amount)
        {
            this.kind = kind;
            this.amount = amount;
        }

        public string Kind
        {
            get { return kind; }
            set { kind = value; }
        }

        public float Amount
        {
            get { return amount; }
            set { amount = value; }
        }
    }
}
