using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Rehab.Application.Common;
using Rehab.Application.Contexts;
using Rehab.Application.Stripe;
using Rehab.Application.Subscriptions;
using Rehab.Domain.Packages;
using Rehab.Domain.Packages.Enums;

 
namespace Rehab.Infrastructure.Subscriptions
{
    public class SubscriptionService : ISubscriptionService
    {
        private readonly IDatabaseContext _context;
        private readonly IMapper _mapper;
        private readonly IStripeService _stripeService;
        public SubscriptionService(IDatabaseContext context,
            IMapper mapper, IStripeService stripeService)
        {
            _context = context;
            _mapper = mapper;
            _stripeService = stripeService;
        }

        public async Task<BaseDto<SubscriptionDto>> CreateAsync(CreateSubscriptionDto dto)
        {
            // prevent repetition - due to Webhook function
            var existing = await _context.Subscriptions
                .FirstOrDefaultAsync(s => s.StripeSubscriptionId == dto.StripeSubscriptionId);

            if (existing != null)
            {
                var existingDto = _mapper.Map<SubscriptionDto>(existing);
                return BaseDto<SubscriptionDto>.SuccessResult(existingDto, "Subscription already exists");
            }

            var subscription = new Rehab.Domain.Packages.Subscription
            {
                PackageRequestId = dto.PackageRequestId,
                StripeSubscriptionId = dto.StripeSubscriptionId,
                StripeCustomerId = dto.StripeCustomerId,
                BillingType = dto.BillingType,
                Status = dto.Status,
                CurrentPeriodStart = dto.CurrentPeriodStart,
                CurrentPeriodEnd = dto.CurrentPeriodEnd,
                CommitmentEndDate = dto.BillingType == BillingType.Annually
                    ? dto.CurrentPeriodStart.AddMonths(12)
                    : null,
                CreatedAt = DateTime.UtcNow
            };

            _context.Subscriptions.Add(subscription);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                return BaseDto<SubscriptionDto>.FailureResult($"Could not create subscription: {ex.Message}");
            }

            var resultDto = _mapper.Map<SubscriptionDto>(subscription);
            return BaseDto<SubscriptionDto>.SuccessResult(resultDto, "Subscription created successfully");
        }
        public async Task<BaseDto<SubscriptionDto>> UpdateStatusAsync(string stripeSubscriptionId, DateTime currentPeriodStart, DateTime currentPeriodEnd, SubscriptionStatus status)
        {
            var subscription = await _context.Subscriptions
                .FirstOrDefaultAsync(s => s.StripeSubscriptionId == stripeSubscriptionId);

            if (subscription == null)
            {
               
                return BaseDto<SubscriptionDto>.FailureResult("Subscription not found yet, will sync on next event");
            }

            subscription.CurrentPeriodStart = currentPeriodStart;
            subscription.CurrentPeriodEnd = currentPeriodEnd;
            subscription.Status = status;

            await _context.SaveChangesAsync();

            var resultDto = _mapper.Map<SubscriptionDto>(subscription);
            return BaseDto<SubscriptionDto>.SuccessResult(resultDto, "Subscription period updated");
        }
        public async Task<BaseDto<SubscriptionDto>> GetByPackageRequestIdAsync(int packageRequestId)
{
    var subscription = await _context.Subscriptions
        .FirstOrDefaultAsync(s => s.PackageRequestId == packageRequestId);

    if (subscription == null)
        return BaseDto<SubscriptionDto>.FailureResult("No subscription found for this package request");

    var resultDto = _mapper.Map<SubscriptionDto>(subscription);
    return BaseDto<SubscriptionDto>.SuccessResult(resultDto, "Subscription retrieved successfully");
}
        public async Task<BaseDto<SubscriptionDto>> CancelAsync(int subscriptionId, bool isAdminOverride = false)
        {
            var subscription = await _context.Subscriptions
                .FirstOrDefaultAsync(s => s.Id == subscriptionId);

            if (subscription == null)
                return BaseDto<SubscriptionDto>.FailureResult("Subscription not found");

            if (subscription.Status == SubscriptionStatus.Canceled)
                return BaseDto<SubscriptionDto>.FailureResult("Subscription is already canceled");
            // Only admin can cancel 
            if (subscription.BillingType == BillingType.Annually
                && subscription.CommitmentEndDate.HasValue
                && subscription.CommitmentEndDate.Value > DateTime.UtcNow
                && !isAdminOverride)
            {
                return BaseDto<SubscriptionDto>.FailureResult(
                    $"This subscription is committed until {subscription.CommitmentEndDate.Value:yyyy-MM-dd} and cannot be canceled.");
            }

            var stripeCancelSucceeded = await _stripeService.CancelSubscriptionAsync(subscription.StripeSubscriptionId);

            if (!stripeCancelSucceeded)
                return BaseDto<SubscriptionDto>.FailureResult("Failed to cancel subscription in Stripe. Please try again.");

 
            var resultDto = _mapper.Map<SubscriptionDto>(subscription);
            return BaseDto<SubscriptionDto>.SuccessResult(resultDto, "Cancellation requested successfully. Status will update shortly.");
        }
    }
}
