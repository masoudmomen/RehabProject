using Microsoft.Extensions.Options;
using Rehab.Application.Common;
using Rehab.Application.Email;
using Rehab.Application.Packages;
using Rehab.Application.PaymentLinks;
using Rehab.Application.Subscriptions;
using Rehab.Domain.Packages;
using Rehab.Domain.Packages.Enums;
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
                IConfiguration config,
                IPaymentLinkService paymentLink,
                IPackageRequestService packageRequest,
                IEmailService email,
                ISubscriptionService subscriptionService,
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
                        if (session.Mode == "subscription")
                        {
                            var token = session.Metadata["token"];
                            var linkResult = await paymentLink.GetByTokenAsync(token);
                            if (linkResult.Success && !linkResult.Data.IsUsed)
                            {
                                var stripeSubscriptionService = new Stripe.SubscriptionService();
                                var stripeSubscription = await stripeSubscriptionService.GetAsync(session.SubscriptionId);

                                var subscriptionItem = stripeSubscription.Items.Data.First();
                                var billingType = Enum.Parse<BillingType>(session.Metadata["billingType"]);

                                var createResult = await subscriptionService.CreateAsync(new CreateSubscriptionDto(
                                    PackageRequestId: linkResult.Data.PackageRequestId,
                                    StripeSubscriptionId: stripeSubscription.Id,
                                    StripeCustomerId: stripeSubscription.CustomerId,
                                    BillingType: billingType,
                                    Status: SubscriptionStatusMapper.FromStripeStatus(stripeSubscription.Status),
                                    CurrentPeriodStart: subscriptionItem.CurrentPeriodStart,
                                    CurrentPeriodEnd: subscriptionItem.CurrentPeriodEnd
                                 ));

                                if (createResult.Success)
                                {
                                    var request = await packageRequest.GetByIdAsync(linkResult.Data.PackageRequestId);

                                    linkResult.Data.IsUsed = true;
                                    linkResult.Data.PaidAt = DateTime.UtcNow;
                                    linkResult.Data.PaymentStatus = 1;

                                    await paymentLink.UpdateAsync(linkResult.Data);
                                    packageRequest.ChangeStatus(linkResult.Data.PackageRequestId, "Paid");

                                    await email.SendEmailAsync(
                                       [request!.Data!.Email, "maryam.s.nabavi@gmail.com", "masoudmomen@hotmail.com"],
                                       "Subscription Payment Confirmation",
                                       EmailTemplates.BuildSubscriptionSuccessEmailBody(
                                           request.Data.FirstName, linkResult.Data, request.Data.PackageType.ToString())
                                    );

                                    string admin = config["Email:ToAdmin"];
                                    await email.SendEmailAsync(
                                        [admin!, "maghsoudloo.h.a@gmail.com", "maryam.s.nabavi@gmail.com", "masoudmomen@hotmail.com"],
                                        "New Subscription Payment",
                                        EmailTemplates.BuildPaymentSuccessAdminEmailBody(linkResult.Data, request.Data.PackageType.ToString(), request.Data.FirstName, request.Data.Email, request.Data.PhoneNumber)
                                     );

                                }
                            }
                        }
                        else //Payment Mode
                        {
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
                                    [request!.Data!.Email, "maryam.s.nabavi@gmail.com", "masoudmomen@hotmail.com"],
                                    "Premium Payment Confirmation",
                                    EmailTemplates.BuildPaymentSuccessEmailBody(request.Data.FirstName, linkResult.Data, request.Data.PackageType.ToString())
                                 );
                                string admin = config["Email:ToAdmin"];
                                await email.SendEmailAsync(
                                    [admin!, "maghsoudloo.h.a@gmail.com", "maryam.s.nabavi@gmail.com", "masoudmomen@hotmail.com"],
                                    "Payment Confirmation",
                                    EmailTemplates.BuildPaymentSuccessAdminEmailBody(linkResult.Data, request.Data.PackageType.ToString(), request.Data.FirstName, request.Data.Email, request.Data.PhoneNumber)
                                 );

                            }
                        }
                    }
                    else if (stripeEvent.Type == "invoice.payment_succeeded")
                    {
                        var invoice = (Invoice)stripeEvent.Data.Object;
                        var subscriptionId = invoice.Parent?.SubscriptionDetails?.SubscriptionId;
                        if (!string.IsNullOrEmpty(subscriptionId))
                        {
                            var stripeSubscriptionService = new Stripe.SubscriptionService();
                            var stripeSubscription = await stripeSubscriptionService.GetAsync(subscriptionId);

                            var subscriptionItem = stripeSubscription.Items.Data.First();

                            await subscriptionService.UpdateStatusAsync(
                                stripeSubscription.Id,
                                subscriptionItem.CurrentPeriodStart,
                                subscriptionItem.CurrentPeriodEnd,
                                SubscriptionStatusMapper.FromStripeStatus(stripeSubscription.Status)
                            );
                        }
                    }

                    else if (stripeEvent.Type == "customer.subscription.updated" || stripeEvent.Type == "customer.subscription.deleted")
                    {
                        var stripeSubscription = (Stripe.Subscription)stripeEvent.Data.Object;
                        var subscriptionItem = stripeSubscription.Items.Data.First();

                        var status = stripeEvent.Type == "customer.subscription.deleted"
                            ? SubscriptionStatus.Canceled
                            : SubscriptionStatusMapper.FromStripeStatus(stripeSubscription.Status);

                        var updateResult = await subscriptionService.UpdateStatusAsync(
                                stripeSubscription.Id,
                                subscriptionItem.CurrentPeriodStart,
                                subscriptionItem.CurrentPeriodEnd,
                                status
                            );

                        if (stripeEvent.Type == "customer.subscription.deleted" && updateResult.Success)
                        {
                            var packageRequestResult = await packageRequest.GetByIdAsync(updateResult.Data!.PackageRequestId);

                            if (packageRequestResult.Success)
                            {
                                await email.SendEmailAsync(
                                   [packageRequestResult.Data!.Email],
                                   "Subscription Canceled",
                                   EmailTemplates.BuildSubscriptionCanceledEmailBody(
                                       packageRequestResult.Data.FirstName,
                                       packageRequestResult.Data.PackageType.ToString(), DateTime.UtcNow)
                                 );
                            }
                        }
                    }
                    return Results.Ok();
                });

            return app;
        }

    }

}
