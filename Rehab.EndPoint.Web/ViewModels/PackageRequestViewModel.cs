using Rehab.Domain.Packages;
using System.ComponentModel.DataAnnotations;

namespace Rehab.EndPoint.Web.ViewModels
{
    public class PackageRequestViewModel
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage ="The first name is required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "The last name is required")]
        public string LastName { get; set; }
        public string? CenterName { get; set; }
        public string? Message { get; set; }
        [Required(ErrorMessage = "The email is required")]
 
        public string Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string PackageType { get; set; }
        public string RequestStatus { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
