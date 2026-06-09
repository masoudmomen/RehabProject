namespace Rehab.Application.PaymentLinks
{
    public class PaymentLinksOptions
    {
        public const string SectionName = "PaymentLinks";

        /// <summary>
        /// Public base URL of the customer-facing web app (no trailing slash), e.g. https://localhost:7007
        /// </summary>
        public string PublicWebBaseUrl { get; set; } = string.Empty;
    }

    public static class PaymentLinkAddressBuilder
    {
        /// <summary>
        /// Builds the URL of the on-site payment landing page (user starts Stripe checkout from there).
        /// </summary>
        public static string BuildCustomerPayPageUrl(string? publicWebBaseUrl, string token)
        {
            if (string.IsNullOrWhiteSpace(token))
                return string.Empty;

            var path = "Packages/pay/" + token.Trim();
            var baseUrl = publicWebBaseUrl?.Trim().TrimEnd('/') ?? string.Empty;
            return string.IsNullOrEmpty(baseUrl) ? path : $"{baseUrl}/{path}";
        }
    }
}
