using Rehab.Domain.Packages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rehab.Application.Subscriptions
{
    public static class SubscriptionStatusMapper
    {
        public static SubscriptionStatus FromStripeStatus(string stripeStatus) => stripeStatus switch
        {
            "incomplete" => SubscriptionStatus.Incomplete,
            "incomplete_expired" => SubscriptionStatus.IncompleteExpired,
            "active" => SubscriptionStatus.Active,
            "past_due" => SubscriptionStatus.PastDue,
            "canceled" => SubscriptionStatus.Canceled,
            "unpaid" => SubscriptionStatus.Unpaid,
            "trialing" => SubscriptionStatus.Trialing,
            _ => throw new ArgumentOutOfRangeException(nameof(stripeStatus), $"Unknown Stripe subscription status: {stripeStatus}")
        };
    }
}
