using Microsoft.EntityFrameworkCore;
using Rehab.Application.Contexts;
using Rehab.Domain.Accreditations;
using Rehab.Domain.Amenities;
using Rehab.Domain.Conditions;
using Rehab.Domain.Facilities;
using Rehab.Domain.Highlights;
using Rehab.Domain.Images;
using Rehab.Domain.Insurances;
using Rehab.Domain.LevelsOfCare;
using Rehab.Domain.SubstancesWeTreat;
using Rehab.Domain.Tags;
using Rehab.Domain.Treatments;
using Rehab.Domain.Users;
using Rehab.Domain.WhoWeTreat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rehab.Persistence.Contexts
{
    public class DatabaseContext: DbContext, IDatabaseContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options):base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        //DbSets : 
        public DbSet<User> Users { get; set; }
        public DbSet<Facility> Facilities { get; set; }
        public DbSet<Insurance> Insurances { get; set; }
        public DbSet<Accreditation> Accreditations { get; set; }
        public DbSet<Amenity> Amenities { get; set; }
        public DbSet<Highlight> Highlights { get; set; }
        public DbSet<Wwt> Wwts { get; set; }
        public DbSet<Loc> Locs { get; set; }
        public DbSet<Treatment> Treatments { get; set; }
        public DbSet<FacilitysImages> FacilitysImages { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Condition> Conditions { get; set; }
        public DbSet<Swt> Swts { get; set; }
    }
}
