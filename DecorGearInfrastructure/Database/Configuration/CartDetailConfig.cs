using DecorGearDomain.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DecorGearInfrastructure.Database.Configuration
{
    public class CartDetailConfig : IEntityTypeConfiguration<CartDetail>
    {
        public void Configure(EntityTypeBuilder<CartDetail> builder)
        {
            builder.ToTable("CartDetail");
            builder.HasKey(x => x.CartDetailID);
            builder.HasOne(a => a.Cart)
                   .WithMany(p => p.CartDetails)
                   .HasForeignKey(a => a.CartID)
                   .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(a => a.Product)
                       .WithMany(p => p.CartDetails)
                       .HasForeignKey(a => a.ProductID)
                       .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
