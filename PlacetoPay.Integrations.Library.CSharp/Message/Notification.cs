using PlacetoPay.Integrations.Library.CSharp.Contracts;
using PlacetoPay.Integrations.Library.CSharp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlacetoPay.Integrations.Library.CSharp.Message
{
    public class Notification : Entity
    {
        private int requestId;
        private string reference;
        private string signature;
        private Status status;
        private string tranKey;

        public Notification(int requestId, string reference, string signature, Status status, string tranKey)
        {
            this.requestId = requestId;
            this.reference = reference;
            this.signature = signature;
            this.status = status;
            this.tranKey = tranKey;
        }

        public bool IsApproved()
        {
            return this.status.status.Equals(Status.ST_APPROVED);
        }

        public bool IsRejected()
        {
            return this.status.status.Equals(Status.ST_REJECTED);
        }

        public int RequestId
        {
            get
            {
                return requestId;
            }

            set
            {
                requestId = value;
            }
        }

        public string Reference
        {
            get
            {
                return reference;
            }

            set
            {
                reference = value;
            }
        }

        public string Signature
        {
            get
            {
                return signature;
            }

            set
            {
                signature = value;
            }
        }

        public Status Status
        {
            get
            {
                return status;
            }

            set
            {
                status = value;
            }
        }

        public string TranKey
        {
            get
            {
                return tranKey;
            }

            set
            {
                tranKey = value;
            }
        }
    }
}
