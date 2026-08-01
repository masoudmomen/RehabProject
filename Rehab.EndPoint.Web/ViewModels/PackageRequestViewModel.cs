using Rehab.Domain.Packages.Enums;
using System.ComponentModel.DataAnnotations;

namespace Rehab.EndPoint.Web.ViewModels
{
    public class PackageRequestViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="The first name is required")]
        public string FirstName { get; set; }
        //[Required(ErrorMessage = "The last name is required")]
        public string LastName { get; set; } =string.Empty;
        public string? CenterName { get; set; }
        public string? Message { get; set; }
        [Required(ErrorMessage = "The email is required")]
 
        public string Email { get; set; }
            [RegularExpression(@"^\+?[1-9]\d{7,14}$",
        ErrorMessage = "Please enter a valid mobile number.")]
        public string? PhoneNumber { get; set; }
        public PackageType PackageType { get; set; }
        public BillingType BillingType { get; set; }
        public string RequestStatus { get; set; }

        public DateTime CreatedDate { get; set; }

        public string? PaymentCheckoutUrl { get; set; }


    }
}
