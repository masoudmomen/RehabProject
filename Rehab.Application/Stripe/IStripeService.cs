using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rehab.Application.Stripe
{
    public interface IStripeService
    {
        Task<CreateSessionResult> CreateCheckoutSessionAsync(CreateSessionRequest request);
        Task<bool> ValidateWebhookAsync(string payload, string signature);
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

    public record CreateSessionResult(
        string SessionId,
        string SessionUrl
    );

}

