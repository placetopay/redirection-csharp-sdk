using PlacetoPay.Integrations.Library.CSharp.Contracts;
using System.Linq;

namespace PlacetoPay.Integrations.Library.CSharp.Entities
{
    public class Status : Entity
    {
        public const string ST_OK = "OK";
        public const string ST_FAILED = "FAILED";
        public const string ST_APPROVED = "APPROVED";
        public const string ST_APPROVED_PARTIAL = "APPROVED_PARTIAL";
        public const string ST_REJECTED = "REJECTED";
        public const string ST_PENDING = "PENDING";
        public const string ST_PENDING_VALIDATION = "PENDING_VALIDATION";
        public const string ST_REFUNDED = "REFUNDED";
        public const string ST_ERROR = "ERROR";
        public const string ST_UNKNOWN = "UNKNOWN";

        public string status { get; set; }
        private string reason;
        private string message;
        private string date;
        public static readonly string[] STATUSES = new string[] { ST_OK, ST_FAILED, ST_APPROVED, ST_APPROVED_PARTIAL, ST_REJECTED, ST_PENDING, ST_PENDING_VALIDATION, ST_REFUNDED, ST_ERROR, ST_UNKNOWN};

        public Status(string status, string reason, string message, string date)
        {
            this.status = status;
            this.reason = reason;
            this.message = message;
            this.date = date;
        }

        public string Reason
        {
            get { return reason; }
            set { reason = value; }
        }

        public string Message
        {
            get { return message; }
            set { message = value; }
        }

        public string Date
        {
            get { return date; }
            set { date = value; }
        }

        public bool IsSuccessful()
        {
            return status.Equals(ST_OK);
        }

        public bool IsApproved()
        {
            return status.Equals(ST_APPROVED);
        }

        public bool IsRejected()
        {
            return status.Equals(ST_REJECTED);
        }

        public bool IsError()
        {
            return status.Equals(ST_ERROR);
        }

        public static bool ValidStatus(string status = null)
        {
            if(status != null)
            {
                return STATUSES.Contains(status);
            }

            return false;
        }
    }
}
