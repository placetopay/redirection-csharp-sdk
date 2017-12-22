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

        public string Street {
            get { return street; }
            set { street = value; }
        }

        public string City {
            get { return city; }
            set { city = value; }
        }
        
        public string State {
            get { return state; }
            set { state = value; }
            }
        
        public string PostalCode {
            get { return postalCode; }
            set { postalCode = value; }
        }
        
        public string Country {
            get { return country; }
            set { country = value; }
        }
        
        public string Phone {
            get { return phone; }
            set { phone = value; }
        }

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
