namespace PlacetoPay.Integrations.Library.CSharp.Entities
{
    public class Item
    {
        protected string sku;
        protected string name;
        protected string category;
        protected int qty;
        protected float price;
        protected float tax;

        public Item(string sku, string name, string category, int qty, float price, float tax)
        {
            this.sku = sku;
            this.name = name;
            this.category = category;
            this.qty = qty;
            this.price = price;
            this.tax = tax;
        }

        public string Sku
        {
            get { return sku; }
            set { sku = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Category
        {
            get { return category; }
            set { category = value; }
        }

        public int Qty
        {
            get { return qty; }
            set { qty = value; }
        }

        public float Price
        {
            get { return price; }
            set { price = value; }
        }

        public float Tax
        {
            get { return tax; }
            set { tax = value; }
        }

    }
}
