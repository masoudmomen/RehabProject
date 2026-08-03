using Rehab.Domain.Packages.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rehab.Domain.Packages
{
    public class Subscription
    {
        public int Id { get; set; }

        public int PackageRequestId { get; set; }
        public PackageRequest PackageRequest { get; set; }

        public string StripeSubscriptionId { get; set; }
        public string StripeCustomerId { get; set; }

        public BillingType BillingType { get; set; }
        public SubscriptionStatus Status { get; set; }

        public DateTime CurrentPeriodStart { get; set; }
        public DateTime CurrentPeriodEnd { get; set; }
        public DateTime? CommitmentEndDate { get; set; } // فقط برای AnnualCommit پر میشه

        public DateTime CreatedAt { get; set; }
        public DateTime? CanceledAt { get; set; }
    }
    public enum SubscriptionStatus
    {
        Incomplete,
        Active,
        PastDue,
        Canceled,
        Unpaid,
        Trialing,
        IncompleteExpired
    }
}
