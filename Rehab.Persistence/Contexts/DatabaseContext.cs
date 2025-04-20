using Microsoft.EntityFrameworkCore;
using Rehab.Application.Contexts;
using Rehab.Domain.Users;
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
    }
}
