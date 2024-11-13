using DecorGearDomain.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DecorGearInfrastructure.Database.Configuration
{
    public class AddressConfig : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {         
            builder.HasKey(a => a.AddressId);
            builder.HasOne(a => a.User)
                .WithOne(u => u.Address)  
                .HasForeignKey<Address>(a => a.UserId)  
                .OnDelete(DeleteBehavior.Cascade);  
        }
    }
}
