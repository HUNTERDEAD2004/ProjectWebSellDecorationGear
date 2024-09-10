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
    public class SubCategoryConfig : IEntityTypeConfiguration<SubCategory>
    {
        public void Configure(EntityTypeBuilder<SubCategory> builder)
        {
            builder.ToTable("SubCategory");
            builder.HasKey(k => k.SubCategoryID);
            builder.HasOne(a => a.Category)
                            .WithMany(p => p.SubCategories)
                            .HasForeignKey(c => c.CategoryID)
                            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
