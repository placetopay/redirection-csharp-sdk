using PlacetoPay.Integrations.Library.CSharp.Contracts;

namespace PlacetoPay.Integrations.Library.CSharp.Entities
{
    public class Address : Entity
    {
        private string street;
        private string city;
        private string state;
        private string postalCode;
        private string country;
        private string phone;

        public string Street { get => street; set => street = value; }
        public string City { get => city; set => city = value; }
        public string State { get => state; set => state = value; }
        public string PostalCode { get => postalCode; set => postalCode = value; }
        public string Country { get => country; set => country = value; }
        public string Phone { get => phone; set => phone = value; }

        public Address(string street, string city, string state, string postalCode, string country, string phone)
        {
            this.street = street;
            this.city = city;
            this.state = state;
            this.postalCode = postalCode;
            this.country = country;
            this.phone = phone;
        }
    }
}
