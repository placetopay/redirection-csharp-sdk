namespace PlacetoPay.Integrations.Library.CSharp.Entities
{
    public class Account
    {
        private Status status;
        private string bankCode;
        private string bankName;
        private string accountType;
        private string accountNumber;

        public Account(Status status, string bankCode, string bankName, string accountType, string accountNumber)
        {
            this.status = status;
            this.bankCode = bankCode;
            this.bankName = bankName;
            this.accountType = accountType;
            this.accountNumber = accountNumber;
        }

        public string BankCode
        {
            get { return bankCode; }
            set { bankCode = value; }
        }

        public string BankName {
            get { return bankName; }
            set { bankName = value; }
        }

        public string AccountType {
            get { return accountType; }
            set { accountType = value; }
        }

        public string AccountNumber {
            get { return accountNumber; }
            set { accountNumber = value; }
        }

        public Status Status {
            get { return status; }
            set { status = value; }
        }

        public string Franchise()
        {
            return "_" + bankCode + "_";
        }

        public string Type()
        {
            return "account";
        }

        public string LastDigits()
        {
            return accountNumber.Substring(accountNumber.Length - 4);
        }
    }
}
