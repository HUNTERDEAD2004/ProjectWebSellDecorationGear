using DecorGearDomain.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DecorGearInfrastructure.Database.Configuration
{
    public class ImageListConfig : IEntityTypeConfiguration<ImageList>
    {
        public void Configure(EntityTypeBuilder<ImageList> builder)
        {
            builder.ToTable("ImageList");
            builder.HasKey(k => k.ImageListID);
            builder.HasOne(a => a.Product)
                            .WithMany(p => p.ImageLists)
                            .HasForeignKey(a => a.ProductID)
                            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
