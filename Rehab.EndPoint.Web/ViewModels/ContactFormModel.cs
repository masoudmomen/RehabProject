using System.ComponentModel.DataAnnotations;

namespace Rehab.EndPoint.Web.ViewModels
{
    public class ContactFormModel
    {
        [Required(ErrorMessage = "Please select what we can help you with.")]
        public string InquiryType { get; set; } = string.Empty;

        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Enter a valid email address.")]
        public string Email { get; set; } = string.Empty;

        public string? Phone { get; set; }

        public string? FacilityName { get; set; }

        [Required(ErrorMessage = "Please tell us how we can help.")]
        public string Message { get; set; } = string.Empty;
    }
}
