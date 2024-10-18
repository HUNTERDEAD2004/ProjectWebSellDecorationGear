using DecorGearApplication.DataTransferObj.Role;
using DecorGearDomain.Data.Entities;
using DecorGearDomain.Enum;
using DecorGearInfrastructure.Extention;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DecorGearInfrastructure.Database.AppDbContext
{
    public class AppDbContext : DbContext
    {
        #region Db Set 
        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<CartDetail> CartDetails { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Favorite> Favorites { get; set; }
        public virtual DbSet<FeedBack> FeedBacks { get; set; }
        public virtual DbSet<ImageList> ImageLists { get; set; }
        public virtual DbSet<KeyboardDetail> KeyboardDetails { get; set; }
        public virtual DbSet<Member> Members { get; set; }
        public virtual DbSet<MouseDetail> MouseDetails { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Sale> Sales { get; set; }
        public virtual DbSet<SubCategory> SubCategories { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Voucher> Vouchers { get; set; }
        public virtual DbSet<VerificationCode> VerificationCodes { get; set; }
        public virtual DbSet<VerificationCodePw> VerificationCodePws { get; set; }
        #endregion

        public AppDbContext()
        {

        }
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Data Source=DESKTOPD-DELLIN\\SQLEXPRESS;Database=DecorationGear;Trusted_Connection=True;TrustServerCertificate=True;");
            // optionsBuilder.UseSqlServer("Data Source=MSI\\SQLEXPRESS;Initial Catalog=DemoGear;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");
            optionsBuilder.UseSqlServer("Data Source=LAP-CN-192\\MSSQLSERVER01;Database=DecorationGear;Trusted_Connection=True;TrustServerCertificate=True");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            SeedingData(modelBuilder);

        }
        public void SeedingData(ModelBuilder modelBuilder)
        {
            // Seed roles
            var roleData = new List<Role>
    {
        new Role
        {
            RoleID = 1,
            RoleName = "Admin"
        },
        new Role
        {
            RoleID = 2,
            RoleName = "User"
        }
    };
            modelBuilder.Entity<Role>().HasData(roleData);

            // Seed users
            var userData = new List<User>
    {
        new User
        {
            UserID = 1,
            Name = "Admin",
            PhoneNumber = "0123456789",
            Email = "admin@example.com",
            UserName = "admin",
            Password = Hash.HashPassword("Admin@123"),  
            RoleID = 1,  // Admin Role
            Status = UserStatus.Active
        },
        new User
        {
            UserID = 2,
            Name = "Jane hangminton",
            PhoneNumber = "0987654321",
            Email = "jane@example.com",
            UserName = "user2",
            Password = Hash.HashPassword("UserPassword123"),  
            RoleID = 2,  // User Role
            Status = UserStatus.Active
        }
    };

            modelBuilder.Entity<User>().HasData(userData);
        }

    }
}

    


