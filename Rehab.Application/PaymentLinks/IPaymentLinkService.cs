using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Rehab.Application.Common;
using Rehab.Application.Contexts;
using Rehab.Application.Email;
using Rehab.Application.Packages;
using Rehab.Domain.Packages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rehab.Application.PaymentLinks
{
    public interface IPaymentLinkService
    {
        Task<BaseDto<PaymentLinkDto>> CreateAsync(PaymentLinkDto paymentLink);
        Task<BaseDto<PaymentLinkDto>> GetByTokenAsync(string token);
        BaseDto<PaymentLinkDto> GetByStripeSessionId(string sessionId);
        Task<BaseDto<PaymentLinkDto>> GetPaymentLinkByRequestIdAsync(int requestId);
        Task<BaseDto<PaymentLinkDto>> UpdateAsync(PaymentLinkDto paymentLink);
        Task<BaseDto<bool>> DeleteLinksByRequestId(int requestId);
    }


    public class PaymentLinkService : IPaymentLinkService
    {
        private readonly IDatabaseContext _context;
        private readonly IMapper _mapper;
        private readonly IPackageRequestService _packageRequestService;
        private readonly IEmailService _email;

        public PaymentLinkService(
            IDatabaseContext context,
            IMapper mapper,
            IPackageRequestService packageRequestService,
            IEmailService email
            )
        {
            _context = context;
            _mapper = mapper;
            _packageRequestService = packageRequestService;
            _email = email;
        }
        public async Task<BaseDto<PaymentLinkDto>> CreateAsync(PaymentLinkDto paymentLink)
        {
            if (paymentLink == null)
                return BaseDto<PaymentLinkDto>.FailureResult("The Payment Link is null!");
            
            await DeleteLinksByRequestId(paymentLink.PackageRequestId);

            var request = await _packageRequestService.GetByIdAsync(paymentLink.PackageRequestId);
           
            var token = Guid.NewGuid().ToString("N");
            paymentLink.Token = token;
            paymentLink.CreatedAt = DateTime.UtcNow;
             var entry = await _context.PaymentLinks.AddAsync(_mapper.Map<PaymentLink>(paymentLink));
            await _context.SaveChangesAsync();
            //"masoudmomen@hotmail.com",
            await _email.SendEmailAsync(
                 to: [request.Data!.Email,"maryam.s.nabavi@gmail.com", "masoudmomen@hotmail.com"],
                 subject: "Your Payment Link is Ready",
                 body: BuildPaymentEmailBody(request.Data.FirstName,
                 request.Data.PackageType.ToString(), request.Data.BillingType.ToString(),
                 token, paymentLink.Amount.ToString())
             );

            _packageRequestService.ChangeStatus(request.Data.Id, "PaymentSent");

            var resultDto = _mapper.Map<PaymentLinkDto>(entry.Entity);
            return BaseDto<PaymentLinkDto>.SuccessResult(resultDto, "The Payment Link was added succssfully!");

        }
        public async  Task<BaseDto<PaymentLinkDto>> GetByTokenAsync(string token)
        {
            if (string.IsNullOrWhiteSpace(token))
                return BaseDto<PaymentLinkDto>.FailureResult("Invalid Token");

            var paymentLink =await _context.PaymentLinks
                .FirstOrDefaultAsync(p => p.Token == token);

            if (paymentLink == null)
                return BaseDto<PaymentLinkDto>.FailureResult("The link wasn't found");

            var resultDto = _mapper.Map<PaymentLinkDto>(paymentLink);
            return BaseDto<PaymentLinkDto>.SuccessResult(resultDto, "Successfull");
        }
        public BaseDto<PaymentLinkDto> GetByStripeSessionId(string sessionId)
        {
            if (string.IsNullOrWhiteSpace(sessionId))
                return BaseDto<PaymentLinkDto>.FailureResult("Invalid Session ID");

            var paymentLink =  _context.PaymentLinks
                .FirstOrDefault(p => p.StripeSessionId == sessionId);
            if (paymentLink == null)
                return null;

            var paymentLinkDto = _mapper.Map<PaymentLinkDto>(paymentLink);
            return BaseDto<PaymentLinkDto>.SuccessResult(paymentLinkDto, "Successfull");
        }
        public async Task<BaseDto<PaymentLinkDto>> GetPaymentLinkByRequestIdAsync(int requestId)
        {
            if (requestId == null)
                return BaseDto<PaymentLinkDto>.FailureResult("Invalid request id");

            var paymentLink = await _context.PaymentLinks
                .AsNoTracking()
                .Where(p => p.PackageRequestId == requestId)
                .OrderByDescending(p => p.CreatedAt)
                .FirstOrDefaultAsync();
          
            
            Console.WriteLine($"Entity PaidAt: {paymentLink?.PaidAt}");
            if (paymentLink == null)
                return BaseDto<PaymentLinkDto>.FailureResult("No payment link found");

            var dto = _mapper.Map<PaymentLinkDto>(paymentLink);
            Console.WriteLine($"Entity PaidAt: {dto?.PaidAt}");
            return BaseDto<PaymentLinkDto>.SuccessResult(dto, "Successfull");
        }
        public async Task<BaseDto<PaymentLinkDto>> UpdateAsync(PaymentLinkDto paymentLinkDto)
        {
            if (paymentLinkDto == null)
                return BaseDto<PaymentLinkDto>.FailureResult("The Payment Link is null!");

            var existing = await _context.PaymentLinks
                .FirstOrDefaultAsync(p => p.Id == paymentLinkDto.Id);
            if (existing == null)
                return BaseDto<PaymentLinkDto>.FailureResult("The Payment Link wasn't found!");

            _mapper.Map(paymentLinkDto, existing);
            _context.PaymentLinks.Update(existing);
            await _context.SaveChangesAsync();

            var resultDto = _mapper.Map<PaymentLinkDto>(existing);
            return BaseDto<PaymentLinkDto>.SuccessResult(resultDto, "Successfull");

        }

        public async Task<BaseDto<bool>> DeleteLinksByRequestId(int requestId)
        {
            if (requestId <= 0)
            {
                return BaseDto<bool>.FailureResult("Invalid request id.");
            }

            var links = await _context.PaymentLinks
                .Where(p => p.PackageRequestId == requestId)
                .ToListAsync();
            if (links == null || links.Count == 0)
            {
                return BaseDto<bool>.SuccessResult(true, "All payment links for this request deleted");
            }

            _context.PaymentLinks.RemoveRange(links);
             _packageRequestService.ChangeStatus(requestId, "New");
            await _context.SaveChangesAsync();

            return BaseDto<bool>.SuccessResult(true, "All payment links for this request deleted");

        }


        private string BuildPaymentEmailBody(string firstName, string packageName, string billingType ,string paymentToken, string packagePrice)
        {
            string paymentUrl = "http://rehabnavigator.com/packages/pay/" + paymentToken;

            return $@"
       <!DOCTYPE html>
       <html>
       <body style='font-family: Arial, sans-serif; color: #333; max-width: 600px; margin: auto; padding: 20px;'>
           <h2 style='color: #2c7be5;'>RehabNavigator</h2>
           <p>Hi {firstName},</p>
           <p>Thank you for your interest in <strong>{packageName}</strong>.</p>
           <p>Your personalized payment link has been created and is ready for you to complete your purchase.
           Simply click the button below to proceed:</p>
           <div style='text-align: center; margin: 30px 0;'>
               <a href='{paymentUrl}'
                  style='background-color: #2c7be5; color: white; padding: 14px 28px;
                         text-decoration: none; border-radius: 6px; font-size: 16px;'>
                   Complete Your Purchase
               </a>
           </div>
           <p>⏳ <strong>Please note:</strong> This link will expire in 48 hours.</p>
           <hr style='border: none; border-top: 1px solid #eee; margin: 20px 0;' />
           <p><strong>Package Name:</strong><br/>
           •   {packageName}<br/>
           </p>
           <p><strong>Billing Type:</strong><br/>
           •   {billingType}<br/>
           </p>
           <p><strong>Price:</strong><br/>
           •   {packagePrice}<br/>
           </p>
           <p>If you have any questions or run into any issues, don't hesitate to reach out to our support team.</p>
           <p>Warm regards,<br/>
           <strong>RehabNavigator Support Team</strong></p>
       </body>
       </html>";
        }

    }

    public class PaymentLinkDto
    {
        public int Id { get; set; }
        public string Token { get; set; }
        public string? StripeSessionId { get; set; }
        public string? StripeSessionUrl { get; set; }
        public DateTime? SessionExpiredsAt { get; set; }
        public decimal Amount { get; set; }
        public bool IsUsed { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LinkExpiresAt { get; set; }
        public DateTime? PaidAt { get; set; }
        public int PaymentStatus { get; set; }
        public int PackageRequestId { get; set; }
        public PackageRequestDto? PackageRequest { get; set; }
        

    }
}
