﻿using DecorGearDomain.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecorGearInfrastructure.Database.Configuration
{
    public class OderConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Order");
            builder.HasKey(x => x.OrderID);
            builder.HasOne(a => a.Voucher)
                        .WithMany(p => p.Orders)
                        .HasForeignKey(a => a.VoucherID)
                        .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(a => a.User)
                        .WithMany(p => p.Orders)
                        .HasForeignKey(a => a.UserID)
                        .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
