using DecorGearDomain.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DecorGearInfrastructure.Database.Configuration
{
    public class OrderDetailConfig : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.ToTable("OrderDetail");
            builder.HasKey(x => x.OrderDetailID);
            builder.HasOne(a => a.Product)
                        .WithMany(p => p.OrderDetails)
                        .HasForeignKey(a => a.ProductID)
                        .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(a => a.Order)
                        .WithMany(p => p.OrderDetails)
                        .HasForeignKey(a => a.OrderID)
                        .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
