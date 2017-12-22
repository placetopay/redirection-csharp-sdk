using PlacetoPay.Integrations.Library.CSharp.Contracts;
using System.Collections.Generic;

namespace PlacetoPay.Integrations.Library.CSharp.Entities
{
    public class Payment : Entity
    {
        private string reference;
        private string description;
        private Amount amount;
        private bool allowPartial = false;
        private Person shipping;
        private List<Item> items;
        private Recurring recurring;
        private Instrument instrument;
        private Transaction transaction { get; set; }

        public Payment(string reference, string description, Amount amount, bool allowPartial = false, Person shipping = null, List<Item> items = null, Recurring recurring = null, Instrument instrument = null, Transaction transaction = null)
        {
            this.reference = reference;
            this.description = description;
            this.amount = amount;
            this.allowPartial = allowPartial;
            this.shipping = shipping;
            this.items = items;
            this.recurring = recurring;
            this.instrument = instrument;
            this.transaction = transaction;
        }

        public string Reference
        {
            get { return reference; }
            set { reference = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public Amount Amount
        {
            get { return amount; }
            set { amount = value; }
        }

        public bool AllowPartial
        {
            get { return allowPartial; }
            set { allowPartial = value; }
        }

        public Person Shipping
        {
            get { return shipping; }
            set { shipping = value; }
        }

        public List<Item> Items
        {
            get { return items; }
            set { items = value; }
        }

        public Recurring Recurring
        {
            get { return recurring; }
            set { recurring = value; }
        }

        public Instrument Instrument
        {
            get { return instrument; }
            set { instrument = value; }
        }

        public Transaction Transaction
        {
            get { return transaction; }
            set { transaction = value; }
        }

    }
}
