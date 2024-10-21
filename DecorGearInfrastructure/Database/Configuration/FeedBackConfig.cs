using DecorGearDomain.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecorGearInfrastructure.Database.Configuration
{
    public class FeedBackConfig : IEntityTypeConfiguration<FeedBack>
    {
        public void Configure(EntityTypeBuilder<FeedBack> builder)
        {
            builder.ToTable("FeedBack");
            builder.HasKey(k => k.FeedBackID);
            builder.HasOne(a => a.Product)
                            .WithMany(p => p.FeedBacks)
                            .HasForeignKey(a => a.ProductID)
                            .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(a => a.User)
                            .WithMany(p => p.FeedBacks)
                            .HasForeignKey(a => a.UserID)
                            .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
