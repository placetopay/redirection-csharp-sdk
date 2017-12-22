using System.Collections.Generic;

namespace PlacetoPay.Integrations.Library.CSharp.Entities
{
    public class Amount : AmountBase
    {
        private List<TaxDetail> taxes;
        private List<AmountDetail> details;
        private float taxAmount = 0;
        private float vatDevolutionBase = 0;
        private float subtotal = 0;

        public Amount(float total, string currency = "COP", List<TaxDetail> taxes = null, List<AmountDetail> details = null, float taxAmount = 0, float vatDevolutionBase = 0, float subtotal = 0) : base(total, currency)
        {
            this.taxes = taxes;
            this.details = details;
            this.taxAmount = taxAmount;
            this.vatDevolutionBase = vatDevolutionBase;
            this.subtotal = subtotal;
        }

        public float TaxAmount
        {
            get { return taxAmount; }
            set { taxAmount = value; }
        }

        public float VatDevolutionBase
        {
            get { return vatDevolutionBase; }
            set { vatDevolutionBase = value; }
        }

        public List<TaxDetail> Taxes
        {
            get { return taxes; }
            set { taxes = value; }
        }

        public List<AmountDetail> Details
        {
            get { return details; }
            set { details = value; }
        }

        public float GetSubtotal()
        {
            if(subtotal == 0)
            {
                return base.Total - this.taxAmount;
            }

            return subtotal;
        }

        public void SetSubtotal(float value)
        {
            this.taxAmount = value;
        }
    }
}
