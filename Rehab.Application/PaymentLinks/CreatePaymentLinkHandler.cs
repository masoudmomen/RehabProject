using Rehab.Application.Stripe;
using Rehab.Application.PaymentLinkService;
using Rehab.Application.Email;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rehab.Application.Packages;

namespace Rehab.Application.PaymentLinks
{
    public class CreatePaymentLinkHandler
    {
        private readonly IStripeService _stripe;
        private readonly IPaymentLinkService _paymentLinkService;
        private readonly IPackageRequestService _packageRequestService;
        private readonly IEmailService _emailService;

        public CreatePaymentLinkHandler(IStripeService stripe, IPaymentLinkService paymentLinkService, IPackageRequestService packageRequestService, IEmailService emailService)
        {
            _stripe = stripe;
            _paymentLinkService = paymentLinkService;
            _packageRequestService = packageRequestService;
            _emailService = emailService;
        }

        public async Task<string> HandleAsync(CreatePaymentLinkCommand command)
        {
            var request = _packageRequestService.GetById(command.RequestId);

            var token = Guid.NewGuid().ToString("N");

            var session = await _stripe.CreateCheckoutSessionAsync(new(
                  Amount: command.Amount,
                    Currency: "USD",
                    Description: $"Payment for package request {request.Data.Id}",
                    CustomerEmail: request.Data.Email,
                    SuccessUrl: command.SuccessUrl,
                    CancelUrl: command.CancelUrl,
                    Metadata: new Dictionary<string, string>
                    {
                        ["token"] = token,
                        ["requestId"] = command.RequestId.ToString()
                    }
                ));
            // Save the payment link details in the database
            await _paymentLinkService.CreateAsync(new PaymentLinkDto
            {
                Token = token,
                RequestId = command.RequestId,
                StripeSessionId = session.SessionId,
                StripeSessionUrl = session.SessionUrl,
                Amount = command.Amount,
                SessionExpiredsAt = DateTime.UtcNow.AddHours(1),
                IsUsed = false
            });

            await _emailService.SendEmailAsync(
                request.Data.Email,
                "Your Payment Link",
                $"https://yoursite.com/pay/{token}"
               
            );
            return token;

        }


    }
}
