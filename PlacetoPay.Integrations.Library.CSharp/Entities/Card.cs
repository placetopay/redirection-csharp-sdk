using PlacetoPay.Integrations.Library.CSharp.Contracts;
using System;

namespace PlacetoPay.Integrations.Library.CSharp.Entities
{
    public class Card : Entity
    {
        public const string TP_CREDIT = "C";
        public const string TP_DEBIT_SAVINGS = "A";
        public const string TP_DEBIT_CURRENT = "R";

        private string name;
        private string number;
        private string cvv;
        private string expirationMonth;
        private string expirationYear;
        private int installments;
        private string kind;

        public Card(string name, string number, string cvv, string expirationMonth, string expirationYear, int installments, string kind = TP_CREDIT)
        {
            this.name = name;
            this.number = number;
            this.cvv = cvv;
            this.expirationMonth = expirationMonth;
            this.expirationYear = expirationYear;
            this.installments = installments;
            this.kind = kind;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Number
        {
            get { return number; }
            set { number = value; }
        }

        public string Cvv
        {
            get { return cvv; }
            set { cvv = value; }
        }

        public string ExpirationMonth
        {
            get { return expirationMonth; }
            set { expirationMonth = value; }
        }

        public int Installments
        {
            get { return installments; }
            set { installments = value; }
        }

        public string Kind
        {
            get { return kind; }
            set { kind = value; }
        }

        public string GetExpirationYear()
        {
            if(expirationYear.Length == 4)
            {
                expirationYear = "20" + expirationYear;
            }

            return expirationYear;
        }

        public void SetExpirationYear(string value)
        {
            expirationYear = value;
        }

        public string GetExpirationYearShort()
        {
            if (expirationYear.Length == 4)
            {
                expirationYear = expirationYear.Substring(2, 2);
            }

            return expirationYear;
        }

        public string GetExpirationMonth()
        {
            return String.Format("%1$" + 2 + "s", this.expirationMonth).Replace(" ", "0");
        }


    }
}
