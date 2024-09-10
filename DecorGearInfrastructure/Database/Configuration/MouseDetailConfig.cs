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
    public class MouseDetailConfig : IEntityTypeConfiguration<MouseDetail>
    {
        public void Configure(EntityTypeBuilder<MouseDetail> builder)
        {
            builder.ToTable("MouseDetail");
            builder.HasKey(k => k.MouseDetailID);
            builder.HasOne(a => a.Product)
                            .WithMany(p => p.MouseDetails)
                            .HasForeignKey(a => a.ProductID)
                            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
