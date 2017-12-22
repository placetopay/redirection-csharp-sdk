using PlacetoPay.Integrations.Library.CSharp.Contracts;

namespace PlacetoPay.Integrations.Library.CSharp.Entities
{
    public class Recurring : Entity
    {
        private string periodicity;
        private int interval;
        private string nextPayment;
        private int maxPeriods;
        private string dueDate;
        private string notificationUrl;

        public Recurring(string periodicity, int interval, string nextPayment, int maxPeriods, string dueDate, string notificationUrl)
        {
            this.periodicity = periodicity;
            this.interval = interval;
            this.nextPayment = nextPayment;
            this.maxPeriods = maxPeriods;
            this.dueDate = dueDate;
            this.notificationUrl = notificationUrl;
        }

        public string Periodicity
        {
            get { return periodicity; }
            set { periodicity = value; }
        }

        public int Interval
        {
            get { return interval; }
            set { interval = value; }
        }

        public string NextPayment
        {
            get { return nextPayment; }
            set { nextPayment = value; }
        }

        public int MaxPeriods
        {
            get { return maxPeriods; }
            set { maxPeriods = value; }
        }

        public string DueDate
        {
            get { return dueDate; }
            set { dueDate = value; }
        }

        public string NotificationUrl
        {
            get { return notificationUrl; }
            set { notificationUrl = value; }
        }

    }
}
