using Microsoft.EntityFrameworkCore;
using Rehab.Domain.Accreditations;
using Rehab.Domain.Amenities;
using Rehab.Domain.Facilities;
using Rehab.Domain.Highlights;
using Rehab.Domain.Images;
using Rehab.Domain.Insurances;
using Rehab.Domain.LevelsOfCare;
using Rehab.Domain.Tags;
using Rehab.Domain.Treatments;
using Rehab.Domain.Users;
using Rehab.Domain.WhoWeTreat;
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
        DbSet<Insurance> Insurances { get; set; }
        DbSet<Accreditation> Accreditations { get; set; }
        DbSet<Amenity> Amenities { get; set; }
        DbSet<Highlight> Highlights { get; set; }
        DbSet<Wwt> Wwts { get; set; }
        DbSet<Loc> Locs { get; set; }
        DbSet<Treatment> Treatments { get; set; }
        DbSet<FacilitysImages> FacilitysImages { get; set; }
        DbSet<Tag> Tags { get;set; }
        int SaveChanges();
        int SaveChanges(bool acceptAllChangesOnSuccess);
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
