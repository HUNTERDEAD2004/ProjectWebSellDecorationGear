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
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.HasKey(k => k.UserID);
            builder.HasOne(a => a.Cart)
                            .WithOne(p => p.User)
                            .HasForeignKey<Cart>(c => c.UserID)
                            .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(a => a.Member)
                            .WithOne(p => p.User)
                            .HasForeignKey<Member>(c => c.UserID)
                            .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(a => a.Role)
                            .WithMany(p => p.Users)
                            .HasForeignKey(a => a.RoleID)
                            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
