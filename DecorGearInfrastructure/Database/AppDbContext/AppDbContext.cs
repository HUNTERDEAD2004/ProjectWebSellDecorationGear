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
            optionsBuilder.UseSqlServer("Data Source=DESKTOPD-DELLIN\\SQLEXPRESS;Database=DecorationGearReborn3;Trusted_Connection=True;TrustServerCertificate=True;");

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

            //Seed OrderData
            var OrderData = new List<Order>
            {
            new Order
            {
                OrderID=1,
                UserID=1,
                VoucherID=null,
                totalQuantity=5,
                size="L",
                weight= (float)1.5,
                Status = EntityStatus.Active,
                OrderStatus=OrderStatus.Delivered,
                paymentMethod="Credit Card",
                OrderDate=DateTime.Parse("09/09/2024"),
                CreatedBy = 1,
                CreatedTime =DateTime.Parse("09/09/2024"),
                ModifiedBy = 1,
                ModifiedTime =DateTime.Parse("09/09/2024"),
                Deleted = false,
                DeletedBy = null,
                DeletedTime = null,
            },
            new Order
            {
                OrderID=2,
                UserID=2,
                VoucherID=null,
                totalQuantity=3,
                size="LF",
                weight=(float)2.0,
                Status = EntityStatus.Active,
                OrderStatus=OrderStatus.Delivered,
                paymentMethod="Cash",
                OrderDate=DateTime.Parse("09/09/2024"),
                CreatedBy = 1,
                CreatedTime =DateTime.Parse("09/09/2024"),
                ModifiedBy = 1,
                ModifiedTime =DateTime.Parse("09/09/2024"),
                Deleted = false,
                DeletedBy = null,
                DeletedTime = null,
            }
            };

            modelBuilder.Entity<Order>().HasData(OrderData);

            //Seed OrderDetailData
            var orderDetailData = new List<OrderDetail>
            {
            new OrderDetail
            {
                OrderDetailId = 1,
                OrderID=1,
                ProductID=3,
                Quantity=10,
                UnitPrice=10000000,
                Status = EntityStatus.Active,
                CreatedBy = 1,
                CreatedTime =DateTime.Parse("09/09/2024"),
                ModifiedBy = 1,
                ModifiedTime =DateTime.Parse("09/09/2024"),
                Deleted = false,
                DeletedBy = null,
                DeletedTime = null,
            },
            new OrderDetail
            {
                OrderDetailId = 2,
                OrderID=1,
                ProductID=3,
                Quantity=1,
                UnitPrice=1000000,
                Status = EntityStatus.Active,
                CreatedBy = 1,
                CreatedTime =DateTime.Parse("09/09/2024"),
                ModifiedBy = 1,
                ModifiedTime =DateTime.Parse("09/09/2024"),
                Deleted = false,
                DeletedBy = null,
                DeletedTime = null,
            },
            new OrderDetail
            {
                OrderDetailId = 3,
                OrderID=2,
                ProductID=1,
                Quantity=1000,
                UnitPrice=1000000000,
                Status = EntityStatus.Active,
                CreatedBy = 1,
                CreatedTime =DateTime.Parse("09/09/2024"),
                ModifiedBy = 1,
                ModifiedTime =DateTime.Parse("09/09/2024"),
                Deleted = false,
                DeletedBy = null,
                DeletedTime = null,
            }
            };

            modelBuilder.Entity<OrderDetail>().HasData(orderDetailData);

            // Seed Product
            var ProductData = new List<Product>
            {
                new Product
                {
                    ProductID = 1,
                    ProductName = "CHUỘT RAZER DEATHADDER ESSENTIAL",
                    ProductCode = "SP01",
                    Description = "chiếc chuột siêu bổ rẻ ",
                    SaleID = 1,
                    BrandID = 1,
                    AvatarProduct = "/media/product/250-73-vien-.jpg",
                    Status = EntityStatus.Active,
                    CreatedBy = 1,
                    CreatedTime =DateTime.Parse("09/09/2024"),
                    ModifiedBy = 1,
                    ModifiedTime =DateTime.Parse("09/09/2024"),
                    Deleted = false,
                    DeletedBy = null,
                    DeletedTime = null,
                },
                new Product
                {
                    ProductID=2,
                    ProductName="CHUỘT KHÔNG DÂY DAREU EM901",
                    ProductCode = "SP02",
                    Description="Chiếc chuột được nhiều tuyển thủ chuyên nghiệp tin dùng",
                    SaleID=null,
                    BrandID=1,
                    AvatarProduct = "/media/product/250-90-b865462f9328e9130f5c420e14e492c5.jpg",
                    Status = EntityStatus.Active,
                    CreatedBy = 1,
                    CreatedTime =DateTime.Parse("09/09/2024"),
                    ModifiedBy = 1,
                    ModifiedTime =DateTime.Parse("09/09/2024"),
                    Deleted = false,
                    DeletedBy = null,
                    DeletedTime = null,
                },
                new Product
                {
                    ProductID=3,
                    ProductCode = "SP03",
                    ProductName="BÀN PHÍM CƠ ESONNE K98",
                    Description="Một chiếc bàn phím cơ mỳ ăn liền với 3mode hotswap tầm giá 1 củ mà bạn không nên bỏ qua",
                    SaleID=null,
                    BrandID=2,
                    AvatarProduct = "/media/product/250-4027-vien1.jpg",
                    Status = EntityStatus.Active,
                    CreatedBy = 1,
                    CreatedTime =DateTime.Parse("09/09/2024"),
                    ModifiedBy = 1,
                    ModifiedTime =DateTime.Parse("09/09/2024"),
                    Deleted = false,
                    DeletedBy = null,
                    DeletedTime = null,
                }
            };

            modelBuilder.Entity<Product>().HasData(ProductData);

            //Seed Keyboard Detail
            var keyboardData = new List<KeyboardDetail>
            {
                new KeyboardDetail
                {
                    KeyboardDetailID = 1,
                    ProductID = 3,
                    Color = "WHITE",
                    Layout = "98 Phím",
                    Case = "Nhôm",
                    Switch = "BLUE SWITCH",
                    SwitchLife = 50000000,
                    Led = "LED RAINBOW nhiều chế độ",
                    KeycapMaterial = "PBT",
                    SwitchMaterial = "Kim loại",
                    SS = "QMK",
                    Stabilizes = "Stabilizer",
                    PCB = "PCB Hot-swap",
                    Price = 100000,
                    Quantity = 10,
                    BatteryCapacity= 0,
                    Weight  = 500,
                    Size = "Kích thước bàn phím : 388*139*37 (mm)",
                    View=8000,
                    Status = EntityStatus.Active,
                    CreatedBy = 1,
                    CreatedTime =DateTime.Parse("09/09/2024"),
                    ModifiedBy = 1,
                    ModifiedTime =DateTime.Parse("09/09/2024"),
                    Deleted = false,
                    DeletedBy = null,
                    DeletedTime = null,
                },
                new KeyboardDetail
                {
                    KeyboardDetailID = 2,
                    ProductID = 3,
                    Color = "RED",
                    Layout = "98 phím",
                    Case = "Nhựa",
                    Switch = "RED SWITCH",
                    SwitchLife = 60000000,
                    Led = "LED RAINBOW nhiều chế độ",
                    KeycapMaterial = "ABS",
                    SwitchMaterial = "Nhựa",
                    SS = "VIA",
                    Stabilizes = "Không",
                    PCB = "PCB tiêu chuẩn",
                    Price = 80000,
                    Quantity = 10,
                    BatteryCapacity= 3000,
                    View=1000,
                    Status = EntityStatus.Active,
                    CreatedBy = 1,
                    CreatedTime =DateTime.Parse("09/09/2024"),
                    ModifiedBy = 1,
                    ModifiedTime =DateTime.Parse("09/09/2024"),
                    Deleted = false,
                    DeletedBy = null,
                    DeletedTime = null,
                },
                new KeyboardDetail
                {
                    KeyboardDetailID = 3,
                    ProductID = 3,
                    Color = "GRAY",
                    Layout = "108 phím",
                    Case = "Nhựa",
                    Switch = "RED SWITCH",
                    SwitchLife = 60000000,
                    Led = "LED RAINBOW nhiều chế độ",
                    KeycapMaterial = "ABS",
                    SwitchMaterial = "Nhựa",
                    SS = "VIA",
                    Stabilizes = "Không",
                    PCB = "PCB tiêu chuẩn",
                    Price = 100000,
                    Quantity = 10,
                    BatteryCapacity= 3000,
                    View=1000,
                    Status = EntityStatus.Active,
                    CreatedBy = 1,
                    CreatedTime =DateTime.Parse("09/09/2024"),
                    ModifiedBy = 1,
                    ModifiedTime =DateTime.Parse("09/09/2024"),
                    Deleted = false,
                    DeletedBy = null,
                    DeletedTime = null,
                }
            };

            modelBuilder.Entity<KeyboardDetail>().HasData(keyboardData);

            //Seed MouseData
            var mice = new List<MouseDetail>
            {
                new MouseDetail
                {
                    MouseDetailID = 1,
                    ProductID = 1,
                    Color = "Đen",
                    DPI = 16000,
                    Connectivity = "USB",
                    Dimensions = "120mm x 60mm x 40mm",
                    Material = "Nhựa",
                    EyeReading = "1000Hz",
                    Button = 6,
                    LED = "Đèn LED 1 màu WHITE Hỗ trợ Razer Synapse",
                    SS = "Razer Synapse",
                    Price = 520000,
                    Quantity = 10,
                    BatteryCapacity = 1000,
                    Weight = 105,
                    View=1000,
                    Status = EntityStatus.Active,
                    CreatedBy = 1,
                    CreatedTime =DateTime.Parse("09/09/2024"),
                    ModifiedBy = 1,
                    ModifiedTime =DateTime.Parse("09/09/2024"),
                    Deleted = false,
                    DeletedBy = null,
                    DeletedTime = null,
                },
                new MouseDetail
                {
                    MouseDetailID = 2,
                    ProductID = 1,
                    Color = "Trắng",
                    DPI = 12000,
                    Connectivity = "USB",
                    Dimensions = "115mm x 58mm x 38mm",
                    Material = "Kim loại",
                    EyeReading = "500Hz",
                    Button = 5,
                    LED = "Đèn LED 1 màu WHITE Hỗ trợ Razer Synapse",
                    SS = "Razer Synapse",
                    BatteryCapacity = 2000,
                    Weight = 105,
                    Price = 520000,
                    Quantity = 10,
                    Status = EntityStatus.Active,
                    CreatedBy = 1,
                    CreatedTime =DateTime.Parse("09/09/2024"),
                    ModifiedBy = 1,
                    ModifiedTime =DateTime.Parse("09/09/2024"),
                    Deleted = false,
                    DeletedBy = null,
                    DeletedTime = null,
                },
                new MouseDetail
                {
                    MouseDetailID = 3,
                    ProductID = 1,
                    Color = "Đen",
                    DPI = 12000,
                    Connectivity = "USB",
                    Dimensions = "115mm x 58mm x 38mm",
                    Material = "Kim loại",
                    EyeReading = "500Hz",
                    Button = 5,
                    LED = null,
                    SS = "Razer Synapse REP",
                    BatteryCapacity = 1500,
                    Weight = 105,
                    Price = 190000,
                    Quantity = 10,
                    Status = EntityStatus.Active,
                    CreatedBy = 1,
                    CreatedTime =DateTime.Parse("09/09/2024"),
                    ModifiedBy = 1,
                    ModifiedTime =DateTime.Parse("09/09/2024"),
                    Deleted = false,
                    DeletedBy = null,
                    DeletedTime = null,
                },
                 new MouseDetail
                {
                    MouseDetailID = 4,
                    ProductID = 2,
                    Color = "Đen",
                    DPI = 6000,
                    Connectivity = "USB, 2.4G",
                    Dimensions = "115mm x 58mm x 38mm",
                    Material = "Nhựa",
                    EyeReading = "500Hz",
                    Button = 5,
                    LED = null,
                    SS = "Razer Synapse REP",
                    Size = "125.5*68.6*39.6mm",
                    BatteryCapacity = 930,
                    Weight = 105,
                    Price = 790000,
                    Quantity = 10,
                    Status = EntityStatus.Active,
                    CreatedBy = 1,
                    CreatedTime =DateTime.Parse("09/09/2024"),
                    ModifiedBy = 1,
                    ModifiedTime =DateTime.Parse("09/09/2024"),
                    Deleted = false,
                    DeletedBy = null,
                    DeletedTime = null,
                },
                 new MouseDetail
                {
                    MouseDetailID = 5,
                    ProductID = 2,
                    Color = "Trắng Xanh",
                    DPI = 6000,
                    Connectivity = "USB, 2.4G",
                    Dimensions = "115mm x 58mm x 38mm",
                    Material = "Nhựa",
                    EyeReading = "500Hz",
                    Button = 5,
                    LED = "LED RGB",
                    SS = "Chuột DareU EM901X RGB Superlight Wireless",
                    Size = "125.5*68.6*39.6mm",
                    BatteryCapacity = 930,
                    Weight = 105,
                    Price = 790000,
                    Quantity = 10,
                    Status = EntityStatus.Active,
                    CreatedBy = 1,
                    CreatedTime =DateTime.Parse("09/09/2024"),
                    ModifiedBy = 1,
                    ModifiedTime =DateTime.Parse("09/09/2024"),
                    Deleted = false,
                    DeletedBy = null,
                    DeletedTime = null,
                },
                  new MouseDetail
                {
                    MouseDetailID = 6,
                    ProductID = 2,
                    Color = "Trắng",
                    DPI = 6000,
                    Connectivity = "USB, 2.4G",
                    Dimensions = "115mm x 58mm x 38mm",
                    Material = "Nhựa",
                    EyeReading = "500Hz",
                    Button = 5,
                    LED = null,
                    SS = "Chuột DareU EM901X RGB Superlight Wireless",
                    Size = "125.5*68.6*39.6mm",
                    BatteryCapacity = 930,
                    Weight = 105,
                    Price = 590000,
                    Quantity = 10,
                    Status = EntityStatus.Active,
                    CreatedBy = 1,
                    CreatedTime =DateTime.Parse("09/09/2024"),
                    ModifiedBy = 1,
                    ModifiedTime =DateTime.Parse("09/09/2024"),
                    Deleted = false,
                    DeletedBy = null,
                    DeletedTime = null,
                }
            };

            modelBuilder.Entity<MouseDetail>().HasData(mice);

            //Seed ImgData
            var ImgList = new List<ImageList>
            {
                new ImageList
                {
                    ImageListID = 1,
                    MouseDetailID = 1,
                    KeyboardDetailID = null,
                    ImagePath= "/media/product/250-73-vien-.jpg",
                    Status = EntityStatus.Active
                },
                new ImageList
                {
                    ImageListID= 2,
                    MouseDetailID = 1,
                    KeyboardDetailID = null,
                    ImagePath= "/media/product/250-73-1089_chu___t_ch__i_game_razer_deathaddder_essential_2_min.jpg",
                    Status = EntityStatus.Active
                },
                new ImageList
                {
                    ImageListID= 3,
                    MouseDetailID = 1,
                    KeyboardDetailID = null,
                    ImagePath= "/media/product/250-73-untitled-3.jpg",
                    Status = EntityStatus.Active
                },
                new ImageList
                {
                    ImageListID= 4,
                    MouseDetailID = null,
                    KeyboardDetailID = 2,
                    ImagePath= "/media/product/250-88-d1470721f92bc58866c35b39f7e83f5f.jpg",
                    Status = EntityStatus.Active
                },
                new ImageList
                {
                    ImageListID= 5,
                    MouseDetailID = null,
                    KeyboardDetailID = 3,
                    ImagePath= "/media/product/250-89-69a7ff353e943ca00e99246f76d3222c.jpg",
                    Status = EntityStatus.Active
                },
                new ImageList
                {
                    ImageListID= 6,
                    MouseDetailID = 3,
                    KeyboardDetailID = null,
                    ImagePath= "/media/product/250-90-b865462f9328e9130f5c420e14e492c5.jpg",
                    Status = EntityStatus.Active
                },
                new ImageList
                {
                    ImageListID= 7,
                    MouseDetailID = 1,
                    KeyboardDetailID = null,
                    ImagePath= "/media/product/250-4027-vien1.jpg",
                    Status = EntityStatus.Active
                },
                new ImageList
                {
                    ImageListID= 8,
                    MouseDetailID = 3,
                    KeyboardDetailID = null,
                    ImagePath= "/media/product/250-4027-xanh-la-6.jpg",
                    Status = EntityStatus.Active
                },
                new ImageList
                {
                    ImageListID= 9,
                    MouseDetailID = 4,
                    KeyboardDetailID = null,
                    ImagePath= "/media/product/250-4026-vein3.jpg",
                    Status = EntityStatus.Active
                },
                new ImageList
                {
                    ImageListID= 10,
                    MouseDetailID = 6,
                    KeyboardDetailID = null,
                    ImagePath= "/media/product/250-4029-vien4.jpg",
                    Status = EntityStatus.Active
                }
            };

            modelBuilder.Entity<ImageList>().HasData(ImgList);

            base.OnModelCreating(modelBuilder);
        }

    }
}




