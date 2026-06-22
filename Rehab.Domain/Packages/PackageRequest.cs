using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rehab.Domain.Packages
{
    public class PackageRequest
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? CenterName { get; set; }
        public string? Message { get; set; }
        public string Email { get; set; }
        public string? PhoneNumber { get; set; }
        public PackageType PackageType { get; set; }
        public BillingType BillingType { get; set; }
        public RequestStatus RequestStatus { get; set; }
        public DateTime CreatedDate { get; set; }
        public ICollection<PaymentLink>? PaymentLink { get; set; }
    }

    public enum PackageType
    {
        Free,
        Basic,
        Premium,
        PremiumPlus
    }
    public enum BillingType
    {
        Annually,
        Monthly
    }

    public enum RequestStatus
    {
        New,
        Pending,
        Paid,
        Faild,
        Expired,
    }

}
