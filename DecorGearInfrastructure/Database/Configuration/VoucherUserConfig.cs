﻿using DecorGearDomain.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DecorGearInfrastructure.Database.Configuration
{
    public class VoucherUserConfig : IEntityTypeConfiguration<VoucherUser>
    {
        public void Configure(EntityTypeBuilder<VoucherUser> builder)
        {
            builder.ToTable("VoucherUser");
            builder.HasKey(x => x.VoucherUserId);
            builder.HasOne(a => a.Voucher)
                        .WithMany(p => p.VoucherUsers)
                        .HasForeignKey(a => a.VoucherID)
                        .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(a => a.User)
                        .WithMany(p => p.VoucherUsers)
                        .HasForeignKey(a => a.UserID)
                        .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
