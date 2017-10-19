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

        public string Periodicity { get => periodicity; set => periodicity = value; }
        public int Interval { get => interval; set => interval = value; }
        public string NextPayment { get => nextPayment; set => nextPayment = value; }
        public int MaxPeriods { get => maxPeriods; set => maxPeriods = value; }
        public string DueDate { get => dueDate; set => dueDate = value; }
        public string NotificationUrl { get => notificationUrl; set => notificationUrl = value; }
    }
}
