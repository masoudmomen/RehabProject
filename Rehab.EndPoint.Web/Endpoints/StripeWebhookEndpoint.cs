using Microsoft.Extensions.Options;
using Rehab.Application.Email;
using Rehab.Application.PaymentLinks;
using Rehab.Application.Packages;
using Rehab.Infrastructure.Settings;
using Stripe;
using Stripe.Checkout;

namespace Rehab.EndPoint.Web.Endpoints
{
    public static class StripeWebhookEndpoint
    {
        public static IEndpointRouteBuilder MapStripeWebHook(this IEndpointRouteBuilder app)
        {
            app.MapPost("/api/stripe/webhook/", async (

                HttpRequest req,
                IPaymentLinkService paymentLink,
                IPackageRequestService packageRequest,
                IEmailService email,
                IOptions<StripeSettings> stripeOptions) =>
                {
                    var payLoad = await new StreamReader(req.Body).ReadToEndAsync();
                    var signature = req.Headers["Stripe-Signature"].ToString();

                    Event stripeEvent;
                    try
                    {
                        stripeEvent = EventUtility.ConstructEvent(
                            payLoad, signature, stripeOptions.Value.WebhookSecret);
                    }
                    catch (Exception ex)
                    {
                        return Results.BadRequest($"Webhook Error: {ex.Message}");
                    }

                    if (stripeEvent.Type == "checkout.session.completed")
                    {
                        var session = (Session)stripeEvent.Data.Object;
                        var token = session.Metadata["token"];

                        var linkResult = await paymentLink.GetByTokenAsync(token);

                        if (linkResult.Success && !linkResult.Data.IsUsed)
                        {
                            var request = await packageRequest.GetByIdAsync(linkResult.Data.PackageRequestId);
                            linkResult.Data.IsUsed = true;
                            linkResult.Data.PaidAt = DateTime.UtcNow;
                            linkResult.Data.PaymentStatus = 1;
                            await paymentLink.UpdateAsync(linkResult.Data);
                            packageRequest.ChangeStatus(linkResult.Data.PackageRequestId, "Paid");
                            await email.SendEmailAsync(
                                request!.Data!.Email,
                                "Payment Confirmation",
                                $"Your payment for the package request {linkResult.Data.PackageRequestId} was successful. Thank you for your purchase!"
                            );
                         
                        }

                    }
                    return Results.Ok();
                });

            return app;
        }
    }

}
