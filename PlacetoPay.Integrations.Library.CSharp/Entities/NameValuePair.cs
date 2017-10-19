namespace PlacetoPay.Integrations.Library.CSharp.Entities
{
    public class NameValuePair
    {
        public string keyword { get; set; }
        public string value { get; set; }
        public string displayOn { get; set; }

        public NameValuePair(string keyword, string value, string displayOn)
        {
            this.keyword = keyword;
            this.value = value;
            this.displayOn = displayOn;
        }

        public NameValuePair()
        {
        }

    }
}