﻿using PlacetoPay.Integrations.Library.CSharp.Contracts;
using PlacetoPay.Integrations.Library.CSharp.Entities;

namespace PlacetoPay.Integrations.Library.CSharp.Message
{
    public class ReverseResponse : Entity
    {
        private Transaction payment;
        private Status status;

        public ReverseResponse(Transaction payment, Status status)
        {
            this.payment = payment;
            this.status = status;
        }

        public Status Status { get => status; set => status = value; }
        public Transaction Payment { get => payment; set => payment = value; }

        public bool IsSuccessful()
        {
            return !this.status.status.Equals(Status.ST_ERROR);
        }

    }
}
