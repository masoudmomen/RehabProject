using Microsoft.AspNetCore.Identity;

namespace Rehab.EndPoint.AdminPanel.CommonService.Identity
{
    public class ApplicationUser: IdentityUser
    {
        public string? Fullname { get; set; }
    }
}
