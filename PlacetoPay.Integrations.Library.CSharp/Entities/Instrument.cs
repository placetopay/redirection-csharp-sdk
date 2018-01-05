using Newtonsoft.Json;
using PlacetoPay.Integrations.Library.CSharp.Contracts;

namespace PlacetoPay.Integrations.Library.CSharp.Entities
{
    public class Instrument :  Entity
    {
        private Bank bank;
        private Card card;
        private Token token;
        private string pin;
        private string password;

        [JsonConstructor]
        public Instrument(Bank bank, Card card, Token token, string pin, string password)
        {
            this.bank = bank;
            this.card = card;
            this.token = token;
            this.pin = pin;
            this.password = password;
        }

        public Instrument(Token token)
        {
            this.token = token;
        }

        public Bank Bank
        {
            get { return bank; }
            set { bank = value; }
        }

        public Card Card
        {
            get { return card; }
            set { card = value; }
        }

        public Token Token
        {
            get { return token; }
            set { token = value; }
        }

        public string Pin
        {
            get { return pin; }
            set { pin = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

    }
}
