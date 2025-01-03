using DecorGearDomain.Data.Entities;
using DecorGearDomain.Enum;
using DecorGearInfrastructure.Extention;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

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
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<VerificationCodePw> VerificationCodePws { get; set; }
        public virtual DbSet<ProductSubCategory> ProductSubCategories { get; set; }
        #endregion

        public AppDbContext()
        {

        }
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOPD-DELLIN\\SQLEXPRESS;Database=DecorationGearReborn1;Trusted_Connection=True;TrustServerCertificate=True;");

            //optionsBuilder.UseSqlServer("Data Source=PHUC\\SQLEXPRESS;Database=DecorationGear;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            SeedingData(modelBuilder);

        }
        public void SeedingData(ModelBuilder modelBuilder)
        {
            // Seed Role data
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
                    Password = Hash.HashPassword("Admin@123"),  // Băm mật khẩu một cách an toàn
                    RoleID = 1,  // Vai trò Admin
                    Status = UserStatus.Active
                },
                new User
                {
                    UserID = 2,
                    Name = "Jane Hangminton",
                    PhoneNumber = "0987654321",
                    Email = "jane@example.com",
                    UserName = "user2",
                    Password = Hash.HashPassword("UserPassword123"),  // Băm mật khẩu một cách an toàn
                    RoleID = 2,  // Vai trò User
                    Status = UserStatus.Active
                }
            };

            modelBuilder.Entity<User>().HasData(userData);

            base.OnModelCreating(modelBuilder);
        }

    }
}




