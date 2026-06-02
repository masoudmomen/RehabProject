using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rehab.Domain.Packages
{
    public class PaymentLink
    {
        public int Id { get; set; }
        public int PackageRequestId { get;set; }
        public string? Token { get; set; }
        public string? StripeSessionId { get; set; }
        public string? StripeSessionUrl { get; set; }
        public DateTime? SessionExpiredsAt { get; set; }
        public decimal Amount { get; set; }
        public bool IsUsed { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? PaidAt { get; set; }
        public DateTime LinkExpiresAt { get; set; }
        public PaymentStatus PaymentStatus { get; set; } = 0;
        public PackageRequest? PackageRequest { get; set; }
    }

    public enum PaymentStatus
    {
        Pending,
        Paid,
        Faild,
    }
}
