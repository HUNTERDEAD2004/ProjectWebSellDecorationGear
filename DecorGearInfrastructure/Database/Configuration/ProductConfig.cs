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
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");
            builder.HasKey(k => k.ProductID);
            builder.HasOne(a => a.Sale)
                            .WithMany(p => p.Products)
                            .HasForeignKey(a => a.SaleID)
                            .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(a => a.Brand)
                            .WithMany(p => p.Products)
                            .HasForeignKey(a => a.BrandID)
                            .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(a => a.SubCategory)
                            .WithMany(p => p.Products)
                            .HasForeignKey(a => a.SubCategoryID)
                            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
