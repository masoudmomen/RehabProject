using Microsoft.EntityFrameworkCore;
using Rehab.Domain.Facilities;
using Rehab.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rehab.Application.Contexts
{
    public interface IDatabaseContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Facility> Facilities { get; set; }
        int SaveChanges();
        int SaveChanges(bool acceptAllChangesOnSuccess);
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
