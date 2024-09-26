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
    public class OrderDetailConfig : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.ToTable("Order");
            builder.HasKey(x => x.OrderDetailID);
            builder.HasOne(a => a.Product)
                        .WithMany(p => p.OrderDetails)
                        .HasForeignKey(a => a.OrderID)
                        .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(a => a.Order)
                        .WithMany(p => p.OrderDetails)
                        .HasForeignKey(a => a.OrderID)
                        .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
