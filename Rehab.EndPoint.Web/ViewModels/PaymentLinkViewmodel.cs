//using Rehab.EndPoint.AdminPanel.Viewmodels;
using System.ComponentModel.DataAnnotations;
using Rehab.Infrastructure.Settings;
namespace Rehab.EndPoint.Web.ViewModels
{
    public class PaymentLinkViewmodel
    {
        public int Id { get; set; }
        public string Token { get; set; }
        public string? StripeSessionId { get; set; }
        public string? StripeSessionUrl { get; set; }
        public DateTime? SessionExpiredsAt { get; set; }
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than 0")]
        public decimal Amount { get; set; }
        public bool IsUsed { get; set; }
        public DateTime CreatedAt { get; set; }
        [FutureAttribute]
       
        public DateTime LinkExpiresAt { get; set; } = DateTime.Today.AddDays(1);
        public DateTime? PaidAt { get; set; } = DateTime.Today.AddDays(1);
        public int PackageRequestId { get; set; }
        public int PaymentStatus { get; set; }
    }
}
