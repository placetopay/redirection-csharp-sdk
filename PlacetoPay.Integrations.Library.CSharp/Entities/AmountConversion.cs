using PlacetoPay.Integrations.Library.CSharp.Contracts;

namespace PlacetoPay.Integrations.Library.CSharp.Entities
{
    public class AmountConversion : Entity
    {
        private AmountBase from;
        private AmountBase to;
        private float factor;

        public AmountConversion(AmountBase from, AmountBase to, float factor)
        {
            this.from = from;
            this.to = to;
            this.factor = factor;
        }

        public float Factor
        {
            get { return factor; }
            set { factor = value; }
        }

        public AmountBase From
        {
            get { return from; }
            set { from = value; }
        }

        public AmountBase To
        {
            get { return to; }
            set { to = value; }
        }
    }
}
