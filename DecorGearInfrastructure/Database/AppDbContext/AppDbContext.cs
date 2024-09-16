using DecorGearApplication.DataTransferObj.Role;
using DecorGearDomain.Data.Entities;
using DecorGearDomain.Enum;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
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
            var brandData = new List<Brand>()
            {
                new Brand()
                {
                    BrandID = "B001",
                    BrandName = "Logitech",
                    Description = "Chuyên sản phẩm gaming cao cấp"
                },
                new Brand()
                 {
                     BrandID = "B002",
                     BrandName = "Razer",
                     Description = "Chuyên sản phẩm gaming cao cấp"
                },
                new Brand()
                {
                    BrandID = "B003",
                    BrandName = "Xing-Meng",
                    Description = "Bàn Phím cơ"
                },
                new Brand()
                {
                    BrandID = "B004",
                    BrandName = "Fl-esport",
                    Description = "Bàn Phím cơ"
                },
                new Brand()
                {
                    BrandID = "B005",
                    BrandName = "Aula",
                    Description = "Bàn Phím cơ"
                },
                new Brand()
                {
                    BrandID = "B006",
                    BrandName = "Zowie",
                    Description = "Chuột gaming"
                }
            };
            modelBuilder.Entity<Brand>(b => { b.HasData(brandData); });

            // Seed Role data
            var roleData = new List<Role>
            {
                new Role
                {
                    RoleID = "R001",
                    RoleName = "Admin"
                },
                new Role
                {
                    RoleID = "R002",
                    RoleName = "User"
                }
            };
            modelBuilder.Entity<Role>().HasData(roleData);

            // Seed users
            var userData = new List<User>
            {
                new User
                {
                    UserID = "U001",
                    Name = "John Smith",
                    PhoneNumber = "0524567890",
                    Email = "john@example.com",
                    UserName = "admin1",
                    Password = "hashedadminpassword",  // You should hash passwords securely!
                    RoleID = "R001",  // Admin Role
                    Status = UserStatus.Active
                },
                new User
                {
                    UserID = "U002",
                    Name = "Jane hangminton",
                    PhoneNumber = "0987654321",
                    Email = "jane@example.com",
                    UserName = "admin2",
                    Password = "hashedadminpassword",  // You should hash passwords securely!
                    RoleID = "R001",  // Admin Role
                    Status = UserStatus.Active
                }
            };

            modelBuilder.Entity<User>().HasData(userData);


            // Seed users
            var cartData = new List<Cart>
            {
                new Cart
                {
                    CartID="C001", UserID="U001", TotalQuantity=5, TotalAmount=100
                },
                new Cart
                {
                   CartID = "C002", UserID = "U002", TotalQuantity = 3, TotalAmount = 75
                },
            };

            modelBuilder.Entity<Cart>().HasData(cartData);

            // Seed cartDetail
            var cartDetailData = new List<CartDetail>
            {
                new CartDetail
                {
                    CartDetailID = 1, 
                    ProductID = "AULAF75", 
                    CartID = "C001", 
                    OrderID = 1, 
                    Quantity = 2, 
                    UnitPrice = 50, 
                    TotalPrice = 100
                },
                new CartDetail
                {
                    CartDetailID = 2, 
                    ProductID = "RZVMNP1", 
                    CartID = "C002", 
                    OrderID = 2, 
                    Quantity = 3, 
                    UnitPrice = 40, 
                    TotalPrice = 120  
                },
                new CartDetail
                {                  
                   CartDetailID = 3, 
                   ProductID = "RZDAV3", 
                   CartID = "C002", 
                   OrderID = 2, 
                   Quantity = 1, 
                   UnitPrice = 75, 
                   TotalPrice = 75
                }
            };

            modelBuilder.Entity<CartDetail>().HasData(cartDetailData);

            // Seed category
            var categoryData = new List<Category>
            {
                new Category
                {
                   CategoryID =  1, CategoryName = "Chuột"
                },
                new Category
                {
                   CategoryID =  2, CategoryName = "Bàn Phím"
                }
            };

            modelBuilder.Entity<Category>().HasData(categoryData);

            // Seed Subcategory
            var subCategoryData = new List<SubCategory>
            {
                new SubCategory
                {
                   SubCategoryID = 1, 
                    CategoryID =  1, 
                    SubCategoryName = "Chuột Logitech"
                },
                new SubCategory
                {
                   SubCategoryID = 2, 
                    CategoryID =  2, 
                    SubCategoryName = "Bàn Phím Aula"
                },
                new SubCategory
                {
                   SubCategoryID = 3, 
                    CategoryID =  2, 
                    SubCategoryName = "Bàn Phím Xing-Meng"
                },
                new SubCategory
                {
                   SubCategoryID = 4, 
                    CategoryID =  1, 
                    SubCategoryName = "Chuột Razer"
                }
            };

            modelBuilder.Entity<SubCategory>().HasData(subCategoryData);

            // Seed Product
            var ProductData = new List<Product>
            {
                new Product
                {
                    ProductID = "RZDAV3",
                    ProductName = "Chuột gaming Razer death adder v3",
                    Price = 405.8,
                    View = 1000,
                    Quantity = 100,
                    Weight = 500,
                    Description = "chiếc chuột siêu bổ rẻ ",
                    Size = "Trung bình",
                    SaleID = 1,
                    BrandID = "B002",
                    SubCategoryID = 4
                },
                new Product
                {
                    ProductID="RZVMNP1",
                    ProductName="Chuột gaming Razor mini pro 1",
                    Price=2000000,
                    View=1000,
                    Quantity=100,
                    Weight=350,
                    Description="Chiếc chuột được nhiều tuyển thủ chuyên nghiệp tin dùng",
                    Size="Trung bình",
                    SaleID=null,
                    BrandID="B002",
                    SubCategoryID=4
                },
                new Product
                {
                    ProductID="AULAF75", 
                    ProductName="Bàn phím cơ AulaF75", 
                    Price=1000000, 
                    View=8000,
                    Quantity=100,
                    Weight=400, 
                    Description="Một chiếc bàn phím cơ mỳ ăn liền với 3mode hotswap tầm giá 1 củ mà bạn không nên bỏ qua", 
                    Size="75%", 
                    SaleID=2, 
                    BrandID="B005", 
                    SubCategoryID=2
                }
            };

            modelBuilder.Entity<Product>().HasData(ProductData);

            // Seed Favorite
            var favoriteData = new List<Favorite>
            {
                new Favorite 
                { 
                    FavoriteID = 1, 
                    UserID = "U001", 
                    ProductID = "RZVMNP1"
                },
                new Favorite 
                { 
                    FavoriteID = 2, 
                    UserID = "U002", 
                    ProductID = "RZDAV3"
                },
                new Favorite 
                { 
                    FavoriteID = 3, 
                    UserID = "U001", 
                    ProductID = "AULAF75"
                }
            };

            modelBuilder.Entity<Favorite>().HasData(favoriteData);

            // Seed FeedBack
            var feedbackData = new List<FeedBack>
            {
                new FeedBack 
                { 
                    FeedBackID = 1, 
                    UserID = "U001", 
                    ProductID = "RZVMNP1", 
                    Comment = "Sản phẩm rất tốt!" 
                },
                new FeedBack 
                { 
                    FeedBackID = 2, 
                    UserID = "U002", 
                    ProductID = "RZDAV3", 
                    Comment = "Chất lượng bình thường." 
                },
                new FeedBack 
                { 
                    FeedBackID = 3, 
                    UserID = "U001", 
                    ProductID = "AULAF75", 
                    Comment = "Giao hàng nhanh, sản phẩm đẹp." 
                }
            };

            modelBuilder.Entity<FeedBack>().HasData(feedbackData);

            //Seed Keyboard Detail 
            var keyboardData = new List<KeyboardDetail>
            {
                new KeyboardDetail
                {
                    KeyboardDetailID = "KD001",
                    ProductID = "AULAF75",
                    Layout = "80%",
                    Case = "Nhôm",
                    Switch = "Cherry MX Red",
                    SwitchLife = 50000000,
                    BatteryCapacity = 4000,
                    Led = "RGB",
                    KeycapMaterial = "PBT",
                    SwitchMaterial = "Kim loại",
                    SS = "QMK",
                    Stabilizes = "Stabilizer",
                    PCB = "PCB Hot-swap"
                },
                new KeyboardDetail
                {
                    KeyboardDetailID = "KD002",
                    ProductID = "AULAF75",
                    Layout = "75%",
                    Case = "Nhựa",
                    Switch = "Gateron Brown",
                    SwitchLife = 60000000,
                    BatteryCapacity = 3000,
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
                    MouseDetailID = "MD001",
                    ProductID = "RZDAV3",
                    Color = "Đen",
                    DPI = 16000,
                    Connectivity = "USB",
                    Dimensions = "120mm x 60mm x 40mm",
                    Material = "Nhựa",
                    EyeReading = "1000Hz",
                    Button = 6,
                    BatteryCapacity = null,
                    LED = "RGB",
                    SS = "Razer Synapse"
                },
                new MouseDetail
                {
                    MouseDetailID = "MD002",
                    ProductID = "RZDAV3",
                    Color = "Trắng",
                    DPI = 12000,
                    Connectivity = "Bluetooth",
                    Dimensions = "115mm x 58mm x 38mm",
                    Material = "Kim loại",
                    EyeReading = "500Hz",
                    Button = 5,
                    BatteryCapacity = "4000mAh",
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
                    ProductID = "AULAF75",
                    ImagePath=["/images/aulaf75_img1.jpg", "/images/aulaf75_img2.jpg", "/images/aulaf75_img3.jpg"],
                    Description = "Hình ảnh của sản phẩm aulaf75"
                },
                new ImageList
                {
                    ImageListID=2, 
                    ProductID="RZDAV3", 
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
                    MemberID=1,
                    UserID="U001",
                    Points=100,
                    ExpiryDate=DateTime.Parse("11/12/2024")
                },
                new Member 
                { 
                    MemberID=2, 
                    UserID="U002", 
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

            //Seed OderData
            var OrderData = new List<Order>
            {
                new Order 
                { 
                    OderID=1, 
                    UserID="U001", 
                    VoucherID=1, 
                    totalQuantity=5, 
                    totalPrice=500.00, 
                    Status=OrderStatus.OrderConfirmed, 
                    paymentMethod="Credit Card", 
                    size="L", 
                    weight=1.5,
                    OrderDate=DateTime.Parse("16/09/2024")
                },
                new Order 
                { 
                    OderID=2, 
                    UserID="U002", 
                    VoucherID=null, 
                    totalQuantity=3, 
                    totalPrice=300.00, 
                    Status=OrderStatus.Paid, 
                    paymentMethod="Cash", 
                    size="LF", 
                    weight=2.0, 
                    OrderDate=DateTime.Parse("17/09/2024")
                }
            };

            modelBuilder.Entity<Order>().HasData(OrderData);

            base.OnModelCreating(modelBuilder);          
        }
    }
}
