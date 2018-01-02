using PlacetoPay.Integrations.Library.CSharp.Contracts;

namespace PlacetoPay.Integrations.Library.CSharp.Entities
{
    public class Person : Entity
    {
        private string document;
        private string documentType;
        private string name;
        private string surname;
        private string company;
        private string email;
        private Address address;
        private string mobile;

        public Person(string document, string documentType, string name, string surname, string email, Address address = null, string company = null, string mobile = null)
        {
            this.document = document;
            this.documentType = documentType;
            this.name = name;
            this.surname = surname;
            this.company = company;
            this.email = email;
            this.address = address;
            this.mobile = mobile;
        }

        public string Document
        {
            get { return document; }
            set { document = value; }
        }

        public string DocumentType
        {
            get { return documentType; }
            set { documentType = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }

        public string Company
        {
            get { return company; }
            set { company = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string Mobile
        {
            get { return mobile; }
            set { mobile = value; }
        }

        internal Address Address
        {
            get { return address; }
            set { address = value; }
        }

    }
}
