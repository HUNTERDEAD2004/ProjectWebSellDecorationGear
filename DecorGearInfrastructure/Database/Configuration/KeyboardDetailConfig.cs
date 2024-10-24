using DecorGearDomain.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DecorGearInfrastructure.Database.Configuration
{
    public class KeyboardDetailConfig : IEntityTypeConfiguration<KeyboardDetail>
    {
        public void Configure(EntityTypeBuilder<KeyboardDetail> builder)
        {
            builder.ToTable("KeyboardDetail");
            builder.HasKey(k => k.KeyboardDetailID);
            builder.HasOne(a => a.Product)
                            .WithMany(p => p.KeyboardDetails)
                            .HasForeignKey(a => a.ProductID)
                            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
