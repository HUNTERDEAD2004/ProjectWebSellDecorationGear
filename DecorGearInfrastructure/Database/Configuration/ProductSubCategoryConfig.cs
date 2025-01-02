using DecorGearDomain.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DecorGearInfrastructure.Database.Configuration
{
    public class ProductSubCategoryConfig : IEntityTypeConfiguration<ProductSubCategory>
    {
        public void Configure(EntityTypeBuilder<ProductSubCategory> builder)
        {
            builder.ToTable("ProductSubCategory");
            builder.HasKey(ps => new { ps.ProductID, ps.SubCategoryID });

            builder.HasOne(ps => ps.Product)
                   .WithMany(p => p.ProductSubCategories)
                   .HasForeignKey(ps => ps.ProductID);

            builder.HasOne(ps => ps.SubCategory)
                   .WithMany(sc => sc.ProductSubCategories)
                   .HasForeignKey(ps => ps.SubCategoryID);
        }
    }
}
