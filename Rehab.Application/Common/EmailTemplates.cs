using NuGet.Packaging.Core;
using Rehab.Application.PaymentLinks;
using Rehab.Domain.Packages.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PackageType = Rehab.Domain.Packages.Enums.PackageType;

namespace Rehab.Application.Common
{
    public static class EmailTemplates
    {
        public static string BuildPaymentConfirmationEmailBody(string fname, string lName, string packageName, string centerName)
        {
            return $@"
        <div style='font-family: Arial, sans-serif; max-width: 600px; margin: 0 auto; padding: 20px;'>

            <h2 style='color: #4a6fa5;'>Your Package Request Has Been Submitted</h2>

            <p>Dear {fname} {lName},</p>

            <p>Thank you for your interest! Your package request has been successfully submitted.
            Our team will review your request and contact you shortly.</p>

            <div style='background-color: #f5f7fa; border-left: 4px solid #4a6fa5; padding: 15px; margin: 20px 0;'>
                <h3 style='margin-top: 0;'>Request Summary</h3>
                <p><strong>Package:</strong> {packageName}</p>
        
                <p><strong>Center Name:</strong> {centerName}</p>
                <p><strong>Submitted At:</strong> {DateTime.UtcNow:MMMM dd, yyyy HH:mm} UTC</p>
            </div>

            <p>If you need assistance in the meantime, feel free to reach out to our support team:</p>

            <p>
                <a href='https://www.rehabnavigator.com/contact-us'
                   style='display: inline-block; background-color: #4a6fa5; color: white;
                          padding: 10px 20px; text-decoration: none; border-radius: 5px;'>
                    Contact Support
                </a>
            </p>

            <p style='color: #888; font-size: 0.9em; margin-top: 30px;'>
                This is an automated confirmation email. Please do not reply to this message.
            </p>

        </div>
    ";
        }
        public static string BuildPaymentConfirmationAdminEmailBody(string fname, string lName, string packageName, string phone, string email, string centerName, string message)
        {
            return $@"
            <h2>New Package Request</h2>
            <p><strong>Name:</strong> {fname}  {lName} </p>
            <p><strong>Package:</strong> {packageName}</p>
         
            <p><strong>Center name:</strong> {centerName}</p>
            <p><strong>Phone:</strong> {phone}</p>
            <p><strong>Email:</strong> {email}</p>
            <p><strong>Message:</strong> {message}</p>
            <p><strong>Date:</strong> {DateTime.UtcNow}</p>
        ";
        }

        public static string BuildPaymentSuccessEmailBody(string fname, PaymentLinkDto paymentLink, string packageName)
        {
            return $@"
        <div style='font-family: Arial, sans-serif; max-width: 600px; margin: 0 auto; padding: 20px;'>

            <div style='background-color: #4a6fa5; padding: 24px 28px; border-radius: 8px 8px 0 0;'>
                <h2 style='margin: 0; color: white; font-size: 20px;'>Payment Successful</h2>
                <p style='margin: 6px 0 0; color: rgba(255,255,255,0.8); font-size: 13px;'>REHAB NAVIGATOR</p>
            </div>

            <div style='border: 1px solid #e0e0e0; border-top: none; border-radius: 0 0 8px 8px; padding: 28px;'>

                <div style='text-align: center; margin-bottom: 24px;'>
                    <div style='display: inline-block; background-color: #e8f5e9; border-radius: 50%; width: 56px; height: 56px; line-height: 56px; font-size: 28px;'>✓</div>
                    <p style='margin: 10px 0 0; font-size: 16px; color: #2e7d32; font-weight: bold;'>Your payment was successful!</p>
                </div>

                <p>Dear {fname} ,</p>
                <p style='color: #555; line-height: 1.7;'>
                 <b>  Welcome to RehabNavigator! </b>

                    Thank you for trusting us as your partner. We’re truly glad to have you onboard. Your provider plan is confirmed.
                    <br/>
                    Your Account Success Manager will reach out soon to help you get started and guide you through next steps. For now, there’s nothing you need to do.
                    <br/>
                    We’re excited to have you with us!
                    <br/>
                    Warm regards,
                    The RehabNavigator Team
                </p>

                <div style='background-color: #f5f7fa; border-left: 4px solid #4a6fa5; border-radius: 0 6px 6px 0; padding: 16px 20px; margin: 24px 0;'>
                    <h3 style='margin: 0 0 14px; font-size: 15px; color: #333;'>Payment Receipt</h3>
                    <table style='width: 100%; border-collapse: collapse; font-size: 14px;'>
                        <tr>
                            <td style='padding: 6px 0; color: #777;'>Order ID</td>
                            <td style='padding: 6px 0; text-align: right; color: #333; font-weight: bold;'>#{paymentLink.PackageRequestId}</td>
                        </tr>
                        <tr style='border-top: 1px solid #e0e0e0;'>
                            <td style='padding: 6px 0; color: #777;'>Package</td>
                            <td style='padding: 6px 0; text-align: right; color: #333;'>{packageName}</td>
                        </tr>
                        <tr style='border-top: 1px solid #e0e0e0;'>
                            <td style='padding: 6px 0; color: #777;'>Payment Date</td>
                            <td style='padding: 6px 0; text-align: right; color: #333;'>{paymentLink.PaidAt:MMMM dd, yyyy HH:mm} UTC</td>
                        </tr>
                        <tr style='border-top: 2px solid #4a6fa5; margin-top: 4px;'>
                            <td style='padding: 10px 0 4px; color: #333; font-weight: bold; font-size: 15px;'>Amount Paid</td>
                            <td style='padding: 10px 0 4px; text-align: right; color: #4a6fa5; font-weight: bold; font-size: 18px;'>${paymentLink.Amount:F2}</td>
                        </tr>
                    </table>
                </div>

                <p style='color: #555; line-height: 1.7;'>
                    If you have any questions about your payment or need further assistance, please don't hesitate to contact us:
                </p>

                <p>
                    <a href='https://www.rehabnavigator.com/contact-us'
                       style='display: inline-block; background-color: #4a6fa5; color: white;
                              padding: 10px 22px; text-decoration: none; border-radius: 5px; font-size: 14px;'>
                        Contact Support
                    </a>
                </p>

                <p style='color: #aaa; font-size: 12px; margin-top: 30px; border-top: 1px solid #eee; padding-top: 16px;'>
                    This is an automated email. Please do not reply to this message.
                </p>
             </div>
        </div>
    ";
        }
        public static string BuildSubscriptionSuccessEmailBody(string fname, PaymentLinkDto paymentLink, string packageName)
        {
            return $@"
        <div style='font-family: Arial, sans-serif; max-width: 600px; margin: 0 auto; padding: 20px;'>

            <div style='background-color: #4a6fa5; padding: 24px 28px; border-radius: 8px 8px 0 0;'>
                <h2 style='margin: 0; color: white; font-size: 20px;'>Payment Successful</h2>
                <p style='margin: 6px 0 0; color: rgba(255,255,255,0.8); font-size: 13px;'>REHAB NAVIGATOR</p>
            </div>

            <div style='border: 1px solid #e0e0e0; border-top: none; border-radius: 0 0 8px 8px; padding: 28px;'>

                <div style='text-align: center; margin-bottom: 24px;'>
                    <div style='display: inline-block; background-color: #e8f5e9; border-radius: 50%; width: 56px; height: 56px; line-height: 56px; font-size: 28px;'>✓</div>
                    <p style='margin: 10px 0 0; font-size: 16px; color: #2e7d32; font-weight: bold;'>Your payment was successful!</p>
                </div>

                <p>Dear {fname} ,</p>
                <p style='color: #555; line-height: 1.7;'>
                 <b>  Welcome to RehabNavigator! </b>

                    Thank you for trusting us as your partner. We’re truly glad to have you onboard. Your provider plan is confirmed.
                    <br/>
                    Your Account Success Manager will reach out soon to help you get started and guide you through next steps. For now, there’s nothing you need to do.
                    <br/>
                    We’re excited to have you with us!
                    <br/>
                    Warm regards,
                    The RehabNavigator Team
                </p>

                <div style='background-color: #f5f7fa; border-left: 4px solid #4a6fa5; border-radius: 0 6px 6px 0; padding: 16px 20px; margin: 24px 0;'>
                    <h3 style='margin: 0 0 14px; font-size: 15px; color: #333;'>Payment Receipt</h3>
                    <table style='width: 100%; border-collapse: collapse; font-size: 14px;'>
                        <tr>
                            <td style='padding: 6px 0; color: #777;'>Order ID</td>
                            <td style='padding: 6px 0; text-align: right; color: #333; font-weight: bold;'>#{paymentLink.PackageRequestId}</td>
                        </tr>
                        <tr style='border-top: 1px solid #e0e0e0;'>
                            <td style='padding: 6px 0; color: #777;'>Package</td>
                            <td style='padding: 6px 0; text-align: right; color: #333;'>{packageName}</td>
                        </tr>
                        <tr style='border-top: 1px solid #e0e0e0;'>
                            <td style='padding: 6px 0; color: #777;'>Payment Date</td>
                            <td style='padding: 6px 0; text-align: right; color: #333;'>{paymentLink.PaidAt:MMMM dd, yyyy HH:mm} UTC</td>
                        </tr>
                        <tr style='border-top: 2px solid #4a6fa5; margin-top: 4px;'>
                            <td style='padding: 10px 0 4px; color: #333; font-weight: bold; font-size: 15px;'>Amount Paid</td>
                            <td style='padding: 10px 0 4px; text-align: right; color: #4a6fa5; font-weight: bold; font-size: 18px;'>${paymentLink.Amount:F2}</td>
                        </tr>
                    </table>
                </div>

                <p style='color: #555; line-height: 1.7;'>
                    If you have any questions about your payment or need further assistance, please don't hesitate to contact us:
                </p>

                <p>
                    <a href='https://www.rehabnavigator.com/contact-us'
                       style='display: inline-block; background-color: #4a6fa5; color: white;
                              padding: 10px 22px; text-decoration: none; border-radius: 5px; font-size: 14px;'>
                        Contact Support
                    </a>
                </p>

                <p style='color: #aaa; font-size: 12px; margin-top: 30px; border-top: 1px solid #eee; padding-top: 16px;'>
                    This is an automated email. Please do not reply to this message.
                </p>
<p> If you ever need to make changes to your subscription or billing, our team is here to help. Simply contact us, and we'll be happy to assist you.</p>
            </div>
        </div>
    ";
        }
        public static string BuildPaymentSuccessAdminEmailBody(PaymentLinkDto paymentLink, string packageName, string payerFullName, string payerEmail, string payerPhone)
        {
            return $@"
<div style='font-family: Arial, sans-serif; max-width: 600px; margin: 0 auto; padding: 20px;'>

    <div style='background-color: #4a6fa5; padding: 24px 28px; border-radius: 8px 8px 0 0;'>
        <h2 style='margin: 0; color: white; font-size: 20px;'>New Payment Received</h2>
        <p style='margin: 6px 0 0; color: rgba(255,255,255,0.8); font-size: 13px;'>REHAB NAVIGATOR — ADMIN NOTIFICATION</p>
    </div>

    <div style='border: 1px solid #e0e0e0; border-top: none; border-radius: 0 0 8px 8px; padding: 28px;'>

        <div style='text-align: center; margin-bottom: 24px;'>
            <div style='display: inline-block; background-color: #e8f5e9; border-radius: 50%; width: 56px; height: 56px; line-height: 56px; font-size: 28px;'>✓</div>
            <p style='margin: 10px 0 0; font-size: 16px; color: #2e7d32; font-weight: bold;'>A new payment has been completed.</p>
        </div>

        <p style='color: #555; line-height: 1.7;'>
            A provider has successfully completed a payment on RehabNavigator. Details are below.
        </p>

        <div style='background-color: #f5f7fa; border-left: 4px solid #4a6fa5; border-radius: 0 6px 6px 0; padding: 16px 20px; margin: 24px 0;'>
            <h3 style='margin: 0 0 14px; font-size: 15px; color: #333;'>Payer Information</h3>
            <table style='width: 100%; border-collapse: collapse; font-size: 14px;'>
                <tr>
                    <td style='padding: 6px 0; color: #777;'>Name</td>
                    <td style='padding: 6px 0; text-align: right; color: #333; font-weight: bold;'>{payerFullName}</td>
                </tr>
                <tr style='border-top: 1px solid #e0e0e0;'>
                    <td style='padding: 6px 0; color: #777;'>Email</td>
                    <td style='padding: 6px 0; text-align: right; color: #333;'>{payerEmail}</td>
                </tr>
                <tr style='border-top: 1px solid #e0e0e0;'>
                    <td style='padding: 6px 0; color: #777;'>Phone</td>
                    <td style='padding: 6px 0; text-align: right; color: #333;'>{payerPhone}</td>
                </tr>
            </table>
        </div>

        <div style='background-color: #f5f7fa; border-left: 4px solid #4a6fa5; border-radius: 0 6px 6px 0; padding: 16px 20px; margin: 24px 0;'>
            <h3 style='margin: 0 0 14px; font-size: 15px; color: #333;'>Payment Receipt</h3>
            <table style='width: 100%; border-collapse: collapse; font-size: 14px;'>
                <tr>
                    <td style='padding: 6px 0; color: #777;'>Order ID</td>
                    <td style='padding: 6px 0; text-align: right; color: #333; font-weight: bold;'>#{paymentLink.PackageRequestId}</td>
                </tr>
                <tr style='border-top: 1px solid #e0e0e0;'>
                    <td style='padding: 6px 0; color: #777;'>Package</td>
                    <td style='padding: 6px 0; text-align: right; color: #333;'>{packageName}</td>
                </tr>
                <tr style='border-top: 1px solid #e0e0e0;'>
                    <td style='padding: 6px 0; color: #777;'>Payment Date</td>
                    <td style='padding: 6px 0; text-align: right; color: #333;'>{paymentLink.PaidAt:MMMM dd, yyyy HH:mm} UTC</td>
                </tr>
                <tr style='border-top: 2px solid #4a6fa5; margin-top: 4px;'>
                    <td style='padding: 10px 0 4px; color: #333; font-weight: bold; font-size: 15px;'>Amount Paid</td>
                    <td style='padding: 10px 0 4px; text-align: right; color: #4a6fa5; font-weight: bold; font-size: 18px;'>${paymentLink.Amount:F2}</td>
                </tr>
            </table>
        </div>

        <p>
            <a href='https://www.rehabnavigator.com/admin/package-requests/{paymentLink.PackageRequestId}'
               style='display: inline-block; background-color: #4a6fa5; color: white;
                      padding: 10px 22px; text-decoration: none; border-radius: 5px; font-size: 14px;'>
                View Request in Admin Panel
            </a>
        </p>

        <p style='color: #aaa; font-size: 12px; margin-top: 30px; border-top: 1px solid #eee; padding-top: 16px;'>
            This is an automated internal notification. Please do not reply to this message.
        </p>

    </div>
</div>
";
        }
        public static string BuildContactUsEmailBody(AdvertiseContactDto model)
        {

            return $@"
            <h2>Contact Us | Advertise With Us</h2>
            <p><strong>Facility:</strong> {model.FacilityName}</p>
            <p><strong>Contact:</strong> {model.ContactName}</p>
            <p><strong>Email:</strong> {model.Email}</p>
            <p><strong>Topic:</strong> {model.HelpTopic}</p>
            <p><strong>Message:</strong> {model.Message}</p>
            ";
        }
        public static string BuildAdvertiseContactConfirmationBody(string contactName)
        {
            return $@"
            <div style=""font-family:sans-serif; max-width:600px; margin:auto;"">
                <h2 style=""color:#2c3e50;"">Thank you, {contactName}!</h2>
                <p>We've received your request and will get back to you shortly.</p>
                <p>If you have any urgent questions, feel free to reply to this email.</p>
                <br/>
                <p style=""color:#888; font-size:13px;"">— The RehabNavigator Team</p>
            </div>
        ";

        }
        public static string BuildClaim(ClaimForModelDto dto)
        {
            string Row(string label, string? value) =>
                string.IsNullOrWhiteSpace(value) ? "" : $@"
                    <tr>
                        <td style=""padding:6px 12px; color:#666; font-size:13px; white-space:nowrap;"">{label}</td>
                        <td style=""padding:6px 12px; font-size:13px;"">{value}</td>
                    </tr>";

            return $@"
                <div style=""font-family:sans-serif; max-width:600px; margin:auto;"">
                    <h2 style=""color:#2c3e50;"">New Claim Request</h2>
                    <p>A new facility claim request has been submitted. Review the details below.</p>

                    <table style=""width:100%; border-collapse:collapse; margin:20px 0; background:#f9f9f9; border-radius:8px; overflow:hidden;"">
                        <thead>
                            <tr style=""background:#2c3e50;"">
                                <th colspan=""2"" style=""padding:10px 12px; color:#fff; font-size:14px; text-align:left;"">Facility Information</th>
                            </tr>
                        </thead>
                        <tbody>
                            {Row("Listed on RehabNavigator?", dto.IsFacilityListed)}
                            {Row("Facility Name", dto.FacilityName)}
                            {Row("Facility Address", dto.FacilityAddress)}
                            {Row("Facility Website", dto.FacilityWebsite)}
                            {Row("Admissions Phone", dto.AdmissionsPhone)}
                            {Row("Admissions Email", dto.AdmissionsEmail)}
                            {Row("Primary Level of Care", dto.PrimaryLevelOfCare)}
                        </tbody>
                        <thead>
                            <tr style=""background:#2c3e50;"">
                                <th colspan=""2"" style=""padding:10px 12px; color:#fff; font-size:14px; text-align:left;"">Submitted By</th>
                            </tr>
                        </thead>
                        <tbody>
                            {Row("Name", dto.ContactName)}
                            {Row("Work Email", dto.WorkEmail)}
                            {Row("Phone", dto.ContactPhone)}
                            {Row("Role", dto.RoleOrConnection)}
                        </tbody>
                    </table>

                    {(!string.IsNullOrWhiteSpace(dto.AdditionalInformation) ? $@"
                    <div style=""background:#f0f4f8; border-left:4px solid #2c3e50; padding:12px 16px; margin:20px 0; border-radius:0 6px 6px 0;"">
                        <p style=""margin:0 0 6px; font-size:13px; color:#666;"">Additional Information</p>
                        <p style=""margin:0; font-size:13px;"">{dto.AdditionalInformation}</p>
                    </div>" : "")}

                    <p style=""font-size:13px; color:#666;"">
                        To respond to this request, reply directly to 
                        <a href=""mailto:{dto.WorkEmail}"">{dto.WorkEmail}</a>.
                    </p>
                </div>";
        }
        public static string BuildClaimConfirmation(string contactName)
        {
            return $@"
    <div style=""font-family:sans-serif; max-width:600px; margin:auto;"">

        <h2 style=""color:#2c3e50;"">Thank you, {contactName}!</h2>
        <p>We've received your claim request and our team will review it shortly.</p>
        <p>Here's what happens next:</p>

        <ol style=""font-size:14px; line-height:2;"">
            <li>Our team reviews your submission</li>
            <li>We verify your connection to the facility</li>
            <li>You'll receive a follow-up email with next steps</li>
        </ol>

        <p>If you have any urgent questions, feel free to reply to this email.</p>
        <br/>
        <p style=""color:#888; font-size:13px;"">— The RehabNavigator Team</p>

    </div>";
        }
        public static string BuildSubscriptionCanceledEmailBody(string fname, string packageName, DateTime canceledAt)
        {
            return $@"
<div style='font-family: Arial, sans-serif; max-width: 600px; margin: 0 auto; padding: 20px;'>

    <div style='background-color: #4a6fa5; padding: 24px 28px; border-radius: 8px 8px 0 0;'>
        <h2 style='margin: 0; color: white; font-size: 20px;'>Subscription Canceled</h2>
        <p style='margin: 6px 0 0; color: rgba(255,255,255,0.8); font-size: 13px;'>REHAB NAVIGATOR</p>
    </div>

    <div style='border: 1px solid #e0e0e0; border-top: none; border-radius: 0 0 8px 8px; padding: 28px;'>

        <div style='text-align: center; margin-bottom: 24px;'>
            <div style='display: inline-block; background-color: #fdecea; border-radius: 50%; width: 56px; height: 56px; line-height: 56px; font-size: 28px;'>✕</div>
            <p style='margin: 10px 0 0; font-size: 16px; color: #c62828; font-weight: bold;'>Your subscription has been canceled</p>
        </div>

        <p>Dear {fname},</p>
        <p style='color: #555; line-height: 1.7;'>
            We're writing to confirm that your subscription for the <b>{packageName}</b> package has been successfully canceled.
            <br/>
            You will not be charged again going forward. If this was a mistake or you'd like to resubscribe at any time, please reach out to our support team.
            <br/>
            We're sorry to see you go, and we hope to have the opportunity to work with you again in the future.
            <br/>
            Warm regards,
            The RehabNavigator Team
        </p>

        <div style='background-color: #f5f7fa; border-left: 4px solid #4a6fa5; border-radius: 0 6px 6px 0; padding: 16px 20px; margin: 24px 0;'>
            <h3 style='margin: 0 0 14px; font-size: 15px; color: #333;'>Cancellation Details</h3>
            <table style='width: 100%; border-collapse: collapse; font-size: 14px;'>
                <tr>
                    <td style='padding: 6px 0; color: #777;'>Package</td>
                    <td style='padding: 6px 0; text-align: right; color: #333;'>{packageName}</td>
                </tr>
                <tr style='border-top: 1px solid #e0e0e0;'>
                    <td style='padding: 6px 0; color: #777;'>Canceled On</td>
                    <td style='padding: 6px 0; text-align: right; color: #333;'>{canceledAt:MMMM dd, yyyy HH:mm} UTC</td>
                </tr>
            </table>
        </div>

        <p style='color: #555; line-height: 1.7;'>
            If you have any questions about this cancellation or need further assistance, please don't hesitate to contact us:
        </p>

        <p>
            <a href='https://www.rehabnavigator.com/contact-us'
               style='display: inline-block; background-color: #4a6fa5; color: white;
                      padding: 10px 22px; text-decoration: none; border-radius: 5px; font-size: 14px;'>
                Contact Support
            </a>
        </p>

        <p style='color: #aaa; font-size: 12px; margin-top: 30px; border-top: 1px solid #eee; padding-top: 16px;'>
            This is an automated email. Please do not reply to this message.
        </p>

    </div>
</div>
";
        }
        public static string BuildGeneralContactEmailBody(ContactFormDto model)
        {
            var phoneRow = string.IsNullOrWhiteSpace(model.Phone)
                ? string.Empty
                : $"<p><strong>Phone:</strong> {model.Phone}</p>";

            var facilityRow = string.IsNullOrWhiteSpace(model.FacilityName)
                ? string.Empty
                : $"<p><strong>Facility:</strong> {model.FacilityName}</p>";

            return $@"
    <h2>Contact Us | General Inquiry</h2>
    <p><strong>Inquiry Type:</strong> {model.InquiryType}</p>
    <p><strong>Name:</strong> {model.Name}</p>
    <p><strong>Email:</strong> {model.Email}</p>
    {phoneRow}
    {facilityRow}
    <p><strong>Message:</strong> {model.Message}</p>
    ";
        }



    }


}
