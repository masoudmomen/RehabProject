using Microsoft.Extensions.Options;
using Rehab.Application.Stripe;
using Rehab.Domain.Packages.Enums;
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
        private readonly Dictionary<(PackageType, BillingType), StripePriceInfo> _priceMap;

        public StripeService(IOptions<StripeSettings> settings)
        {
            _stripeSettings = settings.Value;
            //Console.WriteLine("STRIPE KEY = " + _stripeSettings.SecretKey);
            //Console.WriteLine("webhook KEY = " + _stripeSettings.WebhookSecret);
            if (!string.IsNullOrEmpty(_stripeSettings.SecretKey))
                StripeConfiguration.ApiKey = _stripeSettings.SecretKey;
            var prices = settings.Value.Prices
                                ?? throw new InvalidOperationException("Stripe:Prices section is missing in configuration.");
            _priceMap = new Dictionary<(PackageType, BillingType), StripePriceInfo>
                {
                    { (PackageType.Essential, BillingType.Monthly), prices.EssentialMonthly },
                    { (PackageType.Essential, BillingType.Annually), prices.EssentialAnnual },
                    { (PackageType.Premium, BillingType.Monthly), prices.PremiumMonthly },
                    { (PackageType.Premium, BillingType.Annually), prices.PremiumAnnual }
                };
            ValidateAllPricesConfigured();
        }
        public async Task<CreateSessionResult> CreateSubscriptionSessionAsync(CreateSubscriptionSessionRequest request)
        {
            var metadata = request.Metadata ?? new Dictionary<string, string>();
            metadata["billingType"] = request.BillingType.ToString();

            var options = new SessionCreateOptions
            {
                Mode = "subscription",
                LineItems = new List<SessionLineItemOptions>
                    {
                        new SessionLineItemOptions
                        {
                            Price = request.StripePriceId,
                            Quantity = 1,
                        }
                    },
                Customer = request.StripeCustomerId,
                Metadata = metadata,
                SubscriptionData = new SessionSubscriptionDataOptions
                {
                    Metadata = metadata
                },
                SuccessUrl = request.SuccessUrl,
                CancelUrl = request.CancelUrl,
            };

            var sessionService = new SessionService();
            var session = await sessionService.CreateAsync(options);

            return new CreateSessionResult(session.Id, session.Url);
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
        public string GetPriceId(PackageType packageType, BillingType billingType)
        {
            if (!_priceMap.TryGetValue((packageType, billingType), out var priceInfo)
                || priceInfo is null
                || string.IsNullOrWhiteSpace(priceInfo.PriceId))
                throw new InvalidOperationException(
                    $"No Stripe price configured for PackageType={packageType}, BillingCycle={billingType}.");

            return priceInfo.PriceId;
        }
        private void ValidateAllPricesConfigured()
        {
            var missing = _priceMap
                .Where(kvp => kvp.Value is null || string.IsNullOrWhiteSpace(kvp.Value.PriceId))
                .Select(kvp => $"{kvp.Key.Item1}/{kvp.Key.Item2}")
                .ToList();

            if (missing.Any())
                throw new InvalidOperationException(
                    $"Missing Stripe price configuration for: {string.Join(", ", missing)}.");
        }
        public async Task<bool> CancelSubscriptionAsync(string stripeSubscriptionId)
        {
            try
            {
                var subscriptionService = new SubscriptionService();
                await subscriptionService.CancelAsync(stripeSubscriptionId);
                return true;
            }
            catch (StripeException)
            {
                return false;
            }
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
