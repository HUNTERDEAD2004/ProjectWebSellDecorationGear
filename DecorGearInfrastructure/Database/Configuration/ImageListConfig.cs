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
