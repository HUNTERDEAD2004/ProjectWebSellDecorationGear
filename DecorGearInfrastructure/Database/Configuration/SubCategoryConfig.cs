using DecorGearDomain.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
