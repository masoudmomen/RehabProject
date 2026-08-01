using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rehab.Domain.Packages.Enums;
namespace Rehab.Application.Stripe
{
    public interface IStripeService
    {
        Task<CreateSessionResult> CreateCheckoutSessionAsync(CreateSessionRequest request);
        Task<CreateSessionResult> CreateSubscriptionSessionAsync(
                CreateSubscriptionSessionRequest request);
        Task<bool> ValidateWebhookAsync(string payload, string signature);
        Task<bool> CancelSubscriptionAsync(string stripeSubscriptionId);
        string GetPriceId(PackageType packageType, BillingType billingCycle);

    }

    public record CreateSessionRequest(
          decimal Amount,
          string Currency,
          string Description,
          string CustomerEmail,
          string SuccessUrl,
          string CancelUrl,
          Dictionary<string, string>? Metadata = null
     );
    public record CreateSubscriptionSessionRequest(
    string StripePriceId,
    BillingType BillingType,
    string StripeCustomerId,
    string SuccessUrl,
    string CancelUrl,
    Dictionary<string, string>? Metadata = null
);

    public record CreateSessionResult(
        string SessionId,
        string SessionUrl
    );

}

