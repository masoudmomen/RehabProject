using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rehab.Domain.Packages
{
    public class PackageRequest
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? CenterName { get; set; }
        public string? Message { get; set; }
        public string Email { get; set; }
        public string? PhoneNumber { get; set; }
        public PackageType PackageType { get; set; }
        public RequestStatus RequestStatus { get; set; }

        public DateTime CreatedDate { get; set; }
    }

    public enum PackageType
    {
        Basic,
        Premium,
        PremiumPlus
    }
    public enum RequestStatus
    {
        New,
        Contacted,
        PaymentSent,
        Paid
    }
}
