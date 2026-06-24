using System.ComponentModel.DataAnnotations;

namespace Rehab.EndPoint.Web.ViewModels
{
    public class AdvertiseContactModel
    {
        [Required] public string FacilityName { get; set; } = "";
        [Required] public string ContactName { get; set; } = "";
        [Required, EmailAddress] public string Email { get; set; } = "";
        public string? HelpTopic { get; set; }
        public string? Message { get; set; }
    }
}
