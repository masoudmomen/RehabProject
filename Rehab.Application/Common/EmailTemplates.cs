using Rehab.Application.PaymentLinks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Rehab.Application.Common
{
    public static class EmailTemplates
    {
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
                    We're happy to confirm that your payment has been received and your package request is now active.
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
    }
}
