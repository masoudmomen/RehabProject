using Rehab.Application.PaymentLinks;
using Rehab.Domain.Packages;

namespace Rehab.Application.Packages
{
    public class PackageRequestDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? CenterName { get; set; }
        public string? Message { get; set; }
        public string Email { get; set; }
        public string? PhoneNumber { get; set; }
        public PackageType PackageType { get; set; }
        public BillingType BillingType { get; set; }
        public RequestStatus RequestStatus { get; set; }
        public DateTime CreatedDate { get; set; }

        /// <summary>Latest Stripe checkout URL for this request, if a payment link exists.</summary>
        public string? PaymentCheckoutUrl { get; set; }
        public PaymentLinkDto? LastPaymentLink { get; set; }
        public ICollection<PaymentLinkDto>? PaymentLinks { get; set; }
    }
}
