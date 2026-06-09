using Microsoft.Extensions.Options;
using Rehab.Application.Stripe;
using Rehab.Infrastructure.Settings;
using Stripe;
using Stripe.Checkout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rehab.Infrastructure.Stripe
{
    public class StripeService : IStripeService
    {
        private readonly StripeSettings _stripeSettings;

        public StripeService(IOptions<StripeSettings> settings)
        {
            _stripeSettings = settings.Value;
            //Console.WriteLine("STRIPE KEY = " + _stripeSettings.SecretKey);
            //Console.WriteLine("webhook KEY = " + _stripeSettings.WebhookSecret);
            if (!string.IsNullOrEmpty(_stripeSettings.SecretKey))
                StripeConfiguration.ApiKey = _stripeSettings.SecretKey;
        }

        public async Task<CreateSessionResult> CreateCheckoutSessionAsync(CreateSessionRequest request)
        {
            var options = new SessionCreateOptions
            {
                Mode = "payment",
                LineItems = new List<SessionLineItemOptions>
                {
                    new()
                    {
                        PriceData = new SessionLineItemPriceDataOptions
                        {
                            Currency = request.Currency,
                            UnitAmount = (long)Math.Round(request.Amount * 100m, MidpointRounding.AwayFromZero),
                            ProductData = new SessionLineItemPriceDataProductDataOptions {
                                Name = request.Description
                            },
                        },
                        Quantity = 1,
                    }
                },
                CustomerEmail = request.CustomerEmail,
                SuccessUrl = request.SuccessUrl,
                CancelUrl = request.CancelUrl,
                Metadata = request.Metadata,
                ExpiresAt = DateTime.UtcNow.AddMinutes(30),

            };

            var service = new SessionService();
            var session = await service.CreateAsync(options);

            return new CreateSessionResult(session.Id, session.Url);
        }

        public Task<bool> ValidateWebhookAsync(string payload, string signature)
        {
            try
            {
                EventUtility.ConstructEvent(payload, signature, _stripeSettings.WebhookSecret);
                return Task.FromResult(true);
            }
            catch
            {
                return Task.FromResult(false);
            }
        }
    }
}
