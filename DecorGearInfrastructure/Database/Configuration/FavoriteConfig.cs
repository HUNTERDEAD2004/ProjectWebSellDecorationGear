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
    public class FavoriteConfig : IEntityTypeConfiguration<Favorite>
    {
        public void Configure(EntityTypeBuilder<Favorite> builder)
        {
            builder.ToTable("Favorite");
            builder.HasKey(x => x.FavoriteID);
            builder.HasOne(a => a.User)
                .WithMany(p => p.Favorites)
                .HasForeignKey(a => a.UserID)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(a => a.Product)
                .WithMany(p => p.Favorites)
                .HasForeignKey(a => a.ProductID)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
