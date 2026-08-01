using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rehab.Domain.Packages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rehab.Persistence.Configurations
{
    public class SubscriptionConfiguration : IEntityTypeConfiguration<Subscription>
    {
        public void Configure(EntityTypeBuilder<Subscription> builder)
        {
            builder.HasIndex(s => s.PackageRequestId)
                .IsUnique();

            builder.HasOne(s => s.PackageRequest)
                .WithOne(pr => pr.Subscription)
                .HasForeignKey<Subscription>(s => s.PackageRequestId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(s => s.StripeSubscriptionId)
                .IsUnique();
        }
    }
}
