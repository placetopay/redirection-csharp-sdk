﻿using PlacetoPay.Integrations.Library.CSharp.Contracts;

namespace PlacetoPay.Integrations.Library.CSharp.Entities
{
    public class Person : Entity
    {
        private long document;
        private string documentType;
        private string name;
        private string surname;
        private string company;
        private string email;
        private Address address;
        private string mobile;

        public Person(long document, string documentType, string name, string surname, string email, Address address = null, string company = null, string mobile = null)
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

        public long Document { get => document; set => document = value; }
        public string DocumentType { get => documentType; set => documentType = value; }
        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }
        public string Company { get => company; set => company = value; }
        public string Email { get => email; set => email = value; }
        public string Mobile { get => mobile; set => mobile = value; }
        internal Address Address { get => address; set => address = value; }
    }
}
