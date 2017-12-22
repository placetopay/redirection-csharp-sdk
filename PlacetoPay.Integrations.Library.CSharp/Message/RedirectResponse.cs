using PlacetoPay.Integrations.Library.CSharp.Contracts;
using PlacetoPay.Integrations.Library.CSharp.Entities;

namespace PlacetoPay.Integrations.Library.CSharp.Message
{
    public class RedirectResponse : Entity
    {
        private string requestId;
        private string processUrl;
        private Status status;

        public RedirectResponse(string requestId, string processUrl, Status status)
        {
            this.requestId = requestId;
            this.processUrl = processUrl;
            this.status = status;
        }

        public string RequestId
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

        public string ProcessUrl
        {
            get
            {
                return processUrl;
            }

            set
            {
                processUrl = value;
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


        public bool IsSuccessful()
        {
            return this.status.status.Equals(Status.ST_OK);
        }
    }
}
