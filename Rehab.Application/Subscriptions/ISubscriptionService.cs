using Rehab.Application.Common;
using Rehab.Domain.Packages;
using Rehab.Domain.Packages.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rehab.Application.Subscriptions
{
    public interface ISubscriptionService
    {
        Task<BaseDto<SubscriptionDto>> CreateAsync(CreateSubscriptionDto dto);
        //Task<BaseDto<SubscriptionDto>> GetByStripeSubscriptionIdAsync(string stripeSubscriptionId);
        Task<BaseDto<SubscriptionDto>> GetByPackageRequestIdAsync(int packageRequestId);
        Task<BaseDto<SubscriptionDto>> UpdateStatusAsync(string stripeSubscriptionId, DateTime currentPeriodStart, DateTime currentPeriodEnd, SubscriptionStatus status);
        Task<BaseDto<SubscriptionDto>> CancelAsync(int subscriptionId, bool isAdminOverride = false);

     }

    public class SubscriptionDto
    {
        public int Id { get; set; }
        public int PackageRequestId { get; set; }
        public string StripeSubscriptionId { get; set; }
        public string StripeCustomerId { get; set; }
        public BillingType BillingType { get; set; }
        public SubscriptionStatus Status { get; set; }
        public DateTime CurrentPeriodStart { get; set; }
        public DateTime CurrentPeriodEnd { get; set; }
        public DateTime? CommitmentEndDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? CanceledAt { get; set; }
    }
    public record CreateSubscriptionDto(
    int PackageRequestId,
    string StripeSubscriptionId,
    string StripeCustomerId,
    BillingType BillingType,
    SubscriptionStatus Status,
    DateTime CurrentPeriodStart,
    DateTime CurrentPeriodEnd
);
}
