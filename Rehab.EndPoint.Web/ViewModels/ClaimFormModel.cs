using System.ComponentModel.DataAnnotations;

namespace Rehab.EndPoint.Web.ViewModels
{
    public class ClaimFormModel
    {
        [Required(ErrorMessage = "This field is required.")]
        public string? IsFacilityListed { get; set; }

        [Required(ErrorMessage = "Facility name is required.")]
        [MaxLength(200)]
        public string? FacilityName { get; set; }

        [MaxLength(500)]
        public string? FacilityAddress { get; set; }

        [Url(ErrorMessage = "Please enter a valid URL.")]
        [MaxLength(300)]
        public string? FacilityWebsite { get; set; }

        [Phone(ErrorMessage = "Please enter a valid phone number.")]
        [MaxLength(50)]
        public string? AdmissionsPhone { get; set; }

        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        [MaxLength(200)]
        public string? AdmissionsEmail { get; set; }

        public string? PrimaryLevelOfCare { get; set; }

        [Required(ErrorMessage = "Your name is required.")]
        [MaxLength(200)]
        public string? ContactName { get; set; }

        [Required(ErrorMessage = "Work email is required.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        [MaxLength(200)]
        public string? WorkEmail { get; set; }

        public string? RoleOrConnection { get; set; }

        [Phone(ErrorMessage = "Please enter a valid phone number.")]
        [MaxLength(50)]
        public string? ContactPhone { get; set; }

        [MaxLength(1000)]
        public string? AdditionalInformation { get; set; }
    }
}
