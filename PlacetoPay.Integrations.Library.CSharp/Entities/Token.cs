namespace PlacetoPay.Integrations.Library.CSharp.Entities
{
    public class Token
    {
        private Status status;
        public string token { get; private set; }
        private string subtoken;
        private string franchiseName;
        private string issuerName;
        private string lastDigits;
        private string validUntil;
        private string cvv;
        private string installments;

        public Token(string token, Status status = null, string subtoken = null, string franchiseName = null, string issuerName = null, string lastDigits = null, string validUntil = null, string cvv = null, string installments = null)
        {
            this.status = status;
            this.token = token;
            this.subtoken = subtoken;
            this.franchiseName = franchiseName;
            this.issuerName = issuerName;
            this.lastDigits = lastDigits;
            this.validUntil = validUntil;
            this.cvv = cvv;
            this.installments = installments;
        }

        public Status Status { get => status; private set {} }
        public string Subtoken { get => subtoken; private set { } }
        public string FranchiseName { get => franchiseName; private set { } }
        public string IssuerName { get => issuerName; private set { } }
        public string LastDigits { get => lastDigits; private set { } }
        public string ValidUntil { get => validUntil; private set { } }
        public string Cvv { get => cvv; private set { } }
        public string Installments { get => installments; private set { } }

        public bool IsSuccessful()
        {
            return this.status.status.Equals(Status.ST_OK);
        } 

       
    }
}
