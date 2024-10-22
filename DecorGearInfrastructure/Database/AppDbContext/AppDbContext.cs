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
            optionsBuilder.UseSqlServer("Server=LAPTOP-K61S7AVO;Database=DecorationGear;Trusted_Connection=True;TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            SeedingData(modelBuilder);

        }
        public void SeedingData(ModelBuilder modelBuilder)
        {
            // Seed Brand data
            var brandData = new List<Brand>
            {
                new Brand
                {
                    BrandID = 1,
                    BrandName = "Razer",
                    Description = "Thương hiệu gaming gear được tin dùng các proplayer"
                },
                new Brand
                {
                    BrandID = 2,
                    BrandName = "Aula",
                    Description = "Một thương hiệu bàn phím đã quá quen thuộc với một số ae"
                },
                new Brand
                {
                    BrandID = 3,
                    BrandName = "Rainy",
                    Description = "Thương hiệu bàn phím  với một số ae"
                },
                new Brand
                {
                    BrandID = 4,
                    BrandName = "Logitech",
                    Description = "Một thương gaming gear quá quen thuộc với các proplayer"
                }
            };
            modelBuilder.Entity<Brand>().HasData(brandData);

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
                    RoleName = "Admin"
                }
            };
            modelBuilder.Entity<Role>().HasData(roleData);

            // Seed users
            var userData = new List<User>
            {
                new User
                {
                    UserID = 1,
                    Name = "John Smith",
                    PhoneNumber = "0524567890",
                    Email = "john@example.com",
                    UserName = "admin1",
                    Password = "hashedadminpassword",  // You should hash passwords securely!
                    RoleID = 1,  // Admin Role
                    Status = UserStatus.Active
                },
                new User
                {
                    UserID = 2,
                    Name = "Jane hangminton",
                    PhoneNumber = "0987654321",
                    Email = "jane@example.com",
                    UserName = "admin2",
                    Password = "hashedadminpassword",  // You should hash passwords securely!
                    RoleID = 2,  // Admin Role
                    Status = UserStatus.Active
                }
            };

            modelBuilder.Entity<User>().HasData(userData);


            modelBuilder.Entity<User>().HasData(userData);
            // Seed users
            var cartData = new List<Cart>
            {
                new Cart
                {
                    CartID= 1, UserID = 1
                },
                new Cart
                {
                   CartID = 2, UserID = 2
                },
            };

            modelBuilder.Entity<Cart>().HasData(cartData);

            // Seed category
            var categoryData = new List<Category>
            {
                new Category
                {
                   CategoryID = 1, CategoryName = "Chuột"
                },
                new Category
                {
                   CategoryID = 2, CategoryName = "Bàn Phím"
                }
            };

            modelBuilder.Entity<Category>().HasData(categoryData);

            // Seed Subcategory
            var subCategoryData = new List<SubCategory>
            {
                new SubCategory
                {
                   SubCategoryID = 1, SubCategoryName = "Chuột Razer", CategoryID = 1
                },
                new SubCategory
                {
                   SubCategoryID = 2, SubCategoryName = "Chuột logitech", CategoryID = 1
                },
                 new SubCategory
                {
                   SubCategoryID = 3, SubCategoryName = "Bàn Phím Aula", CategoryID = 2
                },
                 new SubCategory
                {
                   SubCategoryID = 4, SubCategoryName = "Bàn Phím Rainy", CategoryID = 2
                },
            };

            modelBuilder.Entity<SubCategory>().HasData(subCategoryData);

            // Seed Product
            var ProductData = new List<Product>
            {
                new Product
                {
                    ProductID = 1,
                    ProductName = "Chuột gaming Razer death adder v3",
                    Price = 405.8,
                    View = 1000,
                    Quantity = 100,
                    Weight = 500,
                    Description = "chiếc chuột siêu bổ rẻ ",
                    Size = "Trung bình",
                    SaleID = 1,
                    BrandID = 1,
                    SubCategoryID = 1
                },
                new Product
                {
                    ProductID=2,
                    ProductName="Chuột gaming Razor mini pro 1",
                    Price=2000000,
                    View=1000,
                    Quantity=100,
                    Weight=350,
                    Description="Chiếc chuột được nhiều tuyển thủ chuyên nghiệp tin dùng",
                    Size="Trung bình",
                    SaleID=null,
                    BrandID=1,
                    SubCategoryID=1
                },
                new Product
                {
                    ProductID=3, 
                    ProductName="Bàn phím cơ AulaF75", 
                    Price=1000000, 
                    View=8000,
                    Quantity=100,
                    Weight=400, 
                    Description="Một chiếc bàn phím cơ mỳ ăn liền với 3mode hotswap tầm giá 1 củ mà bạn không nên bỏ qua", 
                    Size="75%", 
                    SaleID=null, 
                    BrandID=2,
                    SubCategoryID=3
                }
            };

            modelBuilder.Entity<Product>().HasData(ProductData);

            // Seed Favorite
            var favoriteData = new List<Favorite>
            {
                new Favorite 
                { 
                    FavoriteID = 1, 
                    UserID = 1, 
                    ProductID = 1 
                },
                new Favorite 
                { 
                    FavoriteID = 2, 
                    UserID = 2, 
                    ProductID = 1
                },
                new Favorite 
                { 
                    FavoriteID = 3, 
                    UserID = 1, 
                    ProductID = 2
                }
            };

            modelBuilder.Entity<Favorite>().HasData(favoriteData);

            // Seed FeedBack
            var feedbackData = new List<FeedBack>
            {
                new FeedBack 
                { 
                    FeedBackID = 1, 
                    UserID = 1, 
                    ProductID = 1, 
                    Comment = "Sản phẩm rất tốt!" 
                },
                new FeedBack 
                { 
                    FeedBackID = 2, 
                    UserID = 1, 
                    ProductID = 2, 
                    Comment = "Chất lượng bình thường." 
                },
                new FeedBack 
                { 
                    FeedBackID = 3, 
                    UserID = 2, 
                    ProductID = 3, 
                    Comment = "Giao hàng nhanh, sản phẩm đẹp." 
                }
            };

            modelBuilder.Entity<FeedBack>().HasData(feedbackData);

            //Seed Keyboard Detail 
            var keyboardData = new List<KeyboardDetail>
            {
                new KeyboardDetail
                {
                    KeyboardDetailID = 1,
                    ProductID = 3,
                    Color = "Red",
                    Layout = "80%",
                    Case = "Nhôm",
                    Switch = "Cherry MX Red",
                    SwitchLife = 50000000,
                    Led = "RGB",
                    KeycapMaterial = "PBT",
                    SwitchMaterial = "Kim loại",
                    SS = "QMK",
                    Stabilizes = "Stabilizer",
                    PCB = "PCB Hot-swap"
                },
                new KeyboardDetail
                {
                    KeyboardDetailID = 2,
                    ProductID = 3,
                    Color = "Black",
                    Layout = "75%",
                    Case = "Nhựa",
                    Switch = "Gateron Brown",
                    SwitchLife = 60000000,
                    Led = "Đơn sắc",
                    KeycapMaterial = "ABS",
                    SwitchMaterial = "Nhựa",
                    SS = "VIA",
                    Stabilizes = "Không",
                    PCB = "PCB tiêu chuẩn"
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
                    LED = "RGB",
                    SS = "Razer Synapse"
                },
                new MouseDetail
                {
                    MouseDetailID = 2,
                    ProductID = 2,
                    Color = "Trắng",
                    DPI = 12000,
                    Connectivity = "Bluetooth",
                    Dimensions = "115mm x 58mm x 38mm",
                    Material = "Kim loại",
                    EyeReading = "500Hz",
                    Button = 5,
                    LED = "Đơn sắc",
                    SS = "Logitech G HUB"
                }
            };

            modelBuilder.Entity<MouseDetail>().HasData(mice);

            //Seed ImgData
            var ImgList = new List<ImageList>
            {
                new ImageList
                {
                    ImageListID = 1,
                    ProductID = 3,
                    ImagePath=["/images/aulaf75_img1.jpg", "/images/aulaf75_img2.jpg", "/images/aulaf75_img3.jpg"],
                    Description = "Hình ảnh của sản phẩm aulaf75"
                },
                new ImageList
                {
                    ImageListID= 2, 
                    ProductID=1, 
                    ImagePath=["/images/rzdav3_img.jpg", "/images/rzdav3_img2.jpg"], 
                    Description="Hình ảnh của sản phẩm razer deadth addzer v3"
                }
            };

            modelBuilder.Entity<ImageList>().HasData(ImgList);

            //Seed Member
            var MemData = new List<Member>
            {
                new Member
                {
                    MemberID= 1,
                    UserID= 1,
                    Points=100,
                    ExpiryDate=DateTime.Parse("11/12/2024")
                },
                new Member 
                { 
                    MemberID= 2, 
                    UserID= 2, 
                    Points=200, 
                    ExpiryDate=DateTime.Parse("26/3/2025")
                }
            };

            modelBuilder.Entity<Member>().HasData(MemData);

            //Seed SaleData
            var SaleData = new List<Sale>
            {
                new Sale
                {
                    SaleID=1,
                    SaleName="Giảm giá mùa hè",
                    SalePercent=100,
                    Status = EntityStatus.Active
                },
                new Sale
                {
                    SaleID=2,
                    SaleName="Giảm giá cuối năm",
                    SalePercent=200,
                    Status = EntityStatus.Inactive
                }
            };

            modelBuilder.Entity<Sale>().HasData(SaleData);

            //Seed voucherData
            var VoucherData = new List<Voucher>
            {
                new Voucher
                {
                    VoucherID=1,
                    VoucherName="Giảm giá 30%",
                    VoucherPercent=30,
                    Status = EntityStatus.Active
                },
                new Voucher
                {
                    VoucherID=2,
                    VoucherName="Giảm giá 50%",
                    VoucherPercent=50,
                    Status = EntityStatus.Inactive
                }
            };

            modelBuilder.Entity<Voucher>().HasData(VoucherData);

            //Seed OrderData
            var OrderData = new List<Order>
            {
                new Order 
                { 
                    OrderID=1, 
                    UserID=1, 
                    VoucherID=1, 
                    totalQuantity=5, 
                    totalPrice=500.00, 
                    Status=OrderStatus.Confirmed, 
                    paymentMethod="Credit Card", 
                    OrderDate=DateTime.Parse("16/09/2024")
                },
                new Order 
                { 
                    OrderID=2, 
                    UserID=2, 
                    VoucherID=null, 
                    totalQuantity=3, 
                    totalPrice=300.00, 
                    Status=OrderStatus.Pending, 
                    paymentMethod="Cash", 
                    OrderDate=DateTime.Parse("17/09/2024")
                }
            };

            modelBuilder.Entity<Order>().HasData(OrderData);

            //Seed OrderDetailData
            var orderDetailData = new List<OrderDetail>
            {
                new OrderDetail
                {
                    OrderDetailID = 1,
                    OrderID=1,
                    ProductID=3,
                    Quantity=10,
                    UnitPrice=10000000,
                    Size = "M",
                    Weight = 4000
                },
                new OrderDetail
                {
                    OrderDetailID = 2,
                    OrderID=1,
                    ProductID=3,
                    Quantity=1,
                    UnitPrice=1000000,
                    Size = "S",
                    Weight = 400
                },
                new OrderDetail
                {
                    OrderDetailID = 3,
                    OrderID=2,
                    ProductID=1,
                    Quantity=1000,
                    UnitPrice=1000000000,
                    Size = "L",
                    Weight = 400000
                }
            };

            modelBuilder.Entity<OrderDetail>().HasData(orderDetailData);

            base.OnModelCreating(modelBuilder);          
        }

    }
}

    


