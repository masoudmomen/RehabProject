using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rehab.Infrastructure.Settings
{
    public class StripeSettings
    {
        public string SecretKey { get; set; } = string.Empty;
        public string PublishableKey { get; set; } = string.Empty;
        public string WebhookSecret { get; set; } = string.Empty;

        public StripePrices Prices { get; set; } = new();

       
    }
    public class StripePrices
    {
        public StripePriceInfo EssentialMonthly { get; set; } = default!;
        public StripePriceInfo EssentialAnnual { get; set; } = default!;
        public StripePriceInfo PremiumMonthly { get; set; } = default!;
        public StripePriceInfo PremiumAnnual { get; set; } = default!;
    }
    public class StripePriceInfo
    {
        public string PriceId { get; set; } = default!;
        public decimal Amount { get; set; }
        public string Currency { get; set; } = "usd";
    }
}
