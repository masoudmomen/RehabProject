using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Rehab.EndPoint.AdminPanel.CommonService.Identity
{
    public class ApplicationDbContext: IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
        {
                
        }
    }
}
