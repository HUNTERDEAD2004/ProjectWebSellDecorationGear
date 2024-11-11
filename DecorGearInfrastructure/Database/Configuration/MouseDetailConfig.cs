using DecorGearDomain.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
