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
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
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
                    BrandID = Guid.Parse("0dd00f64-398a-406c-9248-65a5c029cc8b"),
                    BrandName = "Logitech",
                    Description = "Chuyên sản phẩm gaming cao cấp"
                },
                new Brand()
                 {
                     BrandID = Guid.Parse("bc9bd21f-6aea-4eb7-8a49-5b7f3ec42ca7"),
                     BrandName = "Razer",
                     Description = "Chuyên sản phẩm gaming cao cấp"
                },
                new Brand()
                {
                    BrandID = Guid.Parse("2e50c8a2-879e-46e5-8e63-1909844a5a76"),
                    BrandName = "Xing-Meng",
                    Description = "Bàn Phím cơ"
                },
                new Brand()
                {
                    BrandID = Guid.Parse("596c9f51-a7b4-4894-af33-57486bcd0ad2"),
                    BrandName = "Fl-esport",
                    Description = "Bàn Phím cơ"
                },
                new Brand()
                {
                    BrandID = Guid.Parse("d718f5fe-ae8d-49c4-be86-5507ed4b206f"),
                    BrandName = "Aula",
                    Description = "Bàn Phím cơ"
                },
                new Brand()
                {
                    BrandID = Guid.Parse("8f1fd0cf-d533-44db-b517-66d603193204"),
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
                    RoleID = Guid.Parse("a8c899ec-6d9d-4f5e-bd52-93f8ccd5fe2c"),
                    RoleName = "Admin"
                },
                new Role
                {
                    RoleID = Guid.Parse("b718035b-4570-49be-88bb-ff109e5a2a19"),
                    RoleName = "User"
                }
            };
            modelBuilder.Entity<Role>().HasData(roleData);

            // Seed users
            var userData = new List<User>
            {
                new User
                {
                    UserID = Guid.Parse("fa06b6a4-7694-4f78-8cf7-4e8dbfb6ff7b"),
                    Name = "John Smith",
                    PhoneNumber = "0524567890",
                    Email = "john@example.com",
                    UserName = "admin1",
                    Password = "hashedadminpassword",  // You should hash passwords securely!
                    RoleID = Guid.Parse("a8c899ec-6d9d-4f5e-bd52-93f8ccd5fe2c"),  // Admin Role
                    Status = UserStatus.Active
                },
                new User
                {
                    UserID = Guid.Parse("173ec5bc-ff4c-4a78-9aee-45942272ca68"),
                    Name = "Jane hangminton",
                    PhoneNumber = "0987654321",
                    Email = "jane@example.com",
                    UserName = "admin2",
                    Password = "hashedadminpassword",  // You should hash passwords securely!
                    RoleID = Guid.Parse("b718035b-4570-49be-88bb-ff109e5a2a19"),  // Admin Role
                    Status = UserStatus.Active
                }
            };

            modelBuilder.Entity<User>().HasData(userData);


            // Seed users
            var cartData = new List<Cart>
            {
                new Cart
                {
                    CartID= Guid.Parse("abebc4fa-6657-4545-8b4b-5d1d48d2f15e"), UserID=Guid.Parse("fa06b6a4-7694-4f78-8cf7-4e8dbfb6ff7b")
                },
                new Cart
                {
                   CartID = Guid.Parse("872db45e-e45a-4fca-957a-abe8ebaac097"), UserID = Guid.Parse("173ec5bc-ff4c-4a78-9aee-45942272ca68")
                },
            };

            modelBuilder.Entity<Cart>().HasData(cartData);

            // Seed cartDetail
            var cartDetailData = new List<CartDetail>
            {
                new CartDetail
                {
                    CartDetailID = Guid.NewGuid(), 
                    ProductID = Guid.Parse("0a687c3c-04f3-433b-856a-1385cd9e4e9e"), 
                    CartID = Guid.Parse("872db45e-e45a-4fca-957a-abe8ebaac097"), 
                    Quantity = 2, 
                    UnitPrice = 50, 
                    TotalPrice = 100,
                    Size = "L",
                    Weight = 25.5
                },
                new CartDetail
                {
                    CartDetailID = Guid.NewGuid(), 
                    ProductID = Guid.Parse("572ad5ee-dbef-49e4-aa74-3e7c9e217e09"), 
                    CartID = Guid.Parse("872db45e-e45a-4fca-957a-abe8ebaac097"), 
                    Quantity = 3, 
                    UnitPrice = 40, 
                    TotalPrice = 120,
                    Size = "S",
                    Weight = 3.5
                },
                new CartDetail
                {                  
                   CartDetailID = Guid.NewGuid(), 
                   ProductID = Guid.Parse("94188732-288f-46c5-8dee-aefb12127e1d"), 
                   CartID = Guid.Parse("abebc4fa-6657-4545-8b4b-5d1d48d2f15e"), 
                   Quantity = 15, 
                   UnitPrice = 75, 
                   TotalPrice = 1125,
                   Size = "L",
                   Weight = 20.5
                }
            };

            modelBuilder.Entity<CartDetail>().HasData(cartDetailData);

            // Seed category
            var categoryData = new List<Category>
            {
                new Category
                {
                   CategoryID =  Guid.Parse("a83b8346-21ae-4c5e-8751-78e3df7e2a58"), CategoryName = "Chuột"
                },
                new Category
                {
                   CategoryID =  Guid.Parse("e1b0c57f-8eb9-43ea-b1b5-b0862920a9c4"), CategoryName = "Bàn Phím"
                }
            };

            modelBuilder.Entity<Category>().HasData(categoryData);

            // Seed Subcategory
            var subCategoryData = new List<SubCategory>
            {
                new SubCategory
                {
                   SubCategoryID = Guid.Parse("274a7034-b93e-4751-9dd5-58ffe8a63501"), 
                    CategoryID =  Guid.Parse("a83b8346-21ae-4c5e-8751-78e3df7e2a58"), 
                    SubCategoryName = "Chuột Logitech"
                },
                new SubCategory
                {
                   SubCategoryID = Guid.Parse("a59da842-37d0-4415-a3e3-c369b372fc3a"), 
                    CategoryID =  Guid.Parse("e1b0c57f-8eb9-43ea-b1b5-b0862920a9c4"), 
                    SubCategoryName = "Bàn Phím Aula"
                },
                new SubCategory
                {
                   SubCategoryID = Guid.Parse("fc4d928b-1cee-4a89-bcd5-81c12a680a78"), 
                    CategoryID =  Guid.Parse("e1b0c57f-8eb9-43ea-b1b5-b0862920a9c4"), 
                    SubCategoryName = "Bàn Phím Xing-Meng"
                },
                new SubCategory
                {
                   SubCategoryID = Guid.Parse("a1f33141-f953-4b1b-9a49-ef16c72fa8bd"), 
                    CategoryID =  Guid.Parse("a83b8346-21ae-4c5e-8751-78e3df7e2a58"), 
                    SubCategoryName = "Chuột Razer"
                }
            };

            modelBuilder.Entity<SubCategory>().HasData(subCategoryData);

            // Seed Product
            var ProductData = new List<Product>
            {
                new Product
                {
                    ProductID = Guid.Parse("9fed113d-e297-46cb-ae5c-2143c08cce79"),
                    ProductName = "Chuột gaming Razer death adder v3",
                    Price = 405.8,
                    View = 1000,
                    Quantity = 100,
                    Weight = 500,
                    Description = "chiếc chuột siêu bổ rẻ ",
                    Size = "Trung bình",
                    SaleID = Guid.Parse("a83b8346-21ae-4c5e-8751-78e3df7e2a58"),
                    BrandID = Guid.Parse("bc9bd21f-6aea-4eb7-8a49-5b7f3ec42ca7"),
                    SubCategoryID = Guid.Parse("a83b8346-21ae-4c5e-8751-78e3df7e2a58")
                },
                new Product
                {
                    ProductID=Guid.Parse("bfe62974-e3a6-43e5-a22e-5d307752be32"),
                    ProductName="Chuột gaming Razor mini pro 1",
                    Price=2000000,
                    View=1000,
                    Quantity=100,
                    Weight=350,
                    Description="Chiếc chuột được nhiều tuyển thủ chuyên nghiệp tin dùng",
                    Size="Trung bình",
                    SaleID=null,
                    BrandID=Guid.Parse("bc9bd21f-6aea-4eb7-8a49-5b7f3ec42ca7"),
                    SubCategoryID=Guid.Parse("a83b8346-21ae-4c5e-8751-78e3df7e2a58")
                },
                new Product
                {
                    ProductID=Guid.Parse("f65a19bc-a333-4a87-a628-dbf9e1bcfc47"), 
                    ProductName="Bàn phím cơ AulaF75", 
                    Price=1000000, 
                    View=8000,
                    Quantity=100,
                    Weight=400, 
                    Description="Một chiếc bàn phím cơ mỳ ăn liền với 3mode hotswap tầm giá 1 củ mà bạn không nên bỏ qua", 
                    Size="75%", 
                    SaleID=Guid.Parse("bc9bd21f-6aea-4eb7-8a49-5b7f3ec42ca7"), 
                    BrandID=Guid.Parse("d718f5fe-ae8d-49c4-be86-5507ed4b206f"),
                    SubCategoryID=Guid.Parse("a59da842-37d0-4415-a3e3-c369b372fc3a")
                }
            };

            modelBuilder.Entity<Product>().HasData(ProductData);

            // Seed Favorite
            var favoriteData = new List<Favorite>
            {
                new Favorite 
                { 
                    FavoriteID = Guid.NewGuid(), 
                    UserID = Guid.Parse("fa06b6a4-7694-4f78-8cf7-4e8dbfb6ff7b"), 
                    ProductID = Guid.Parse("bfe62974-e3a6-43e5-a22e-5d307752be32") 
                },
                new Favorite 
                { 
                    FavoriteID = Guid.NewGuid(), 
                    UserID = Guid.Parse("173ec5bc-ff4c-4a78-9aee-45942272ca68"), 
                    ProductID = Guid.Parse("9fed113d-e297-46cb-ae5c-2143c08cce79")
                },
                new Favorite 
                { 
                    FavoriteID = Guid.NewGuid(), 
                    UserID = Guid.Parse("fa06b6a4-7694-4f78-8cf7-4e8dbfb6ff7b"), 
                    ProductID = Guid.Parse("f65a19bc-a333-4a87-a628-dbf9e1bcfc47")
                }
            };

            modelBuilder.Entity<Favorite>().HasData(favoriteData);

            // Seed FeedBack
            var feedbackData = new List<FeedBack>
            {
                new FeedBack 
                { 
                    FeedBackID = Guid.NewGuid(), 
                    UserID = Guid.Parse("fa06b6a4-7694-4f78-8cf7-4e8dbfb6ff7b"), 
                    ProductID = Guid.Parse("bfe62974-e3a6-43e5-a22e-5d307752be32"), 
                    Comment = "Sản phẩm rất tốt!" 
                },
                new FeedBack 
                { 
                    FeedBackID = Guid.NewGuid(), 
                    UserID = Guid.Parse("173ec5bc-ff4c-4a78-9aee-45942272ca68"), 
                    ProductID = Guid.Parse("9fed113d-e297-46cb-ae5c-2143c08cce79"), 
                    Comment = "Chất lượng bình thường." 
                },
                new FeedBack 
                { 
                    FeedBackID = Guid.NewGuid(), 
                    UserID = Guid.Parse("fa06b6a4-7694-4f78-8cf7-4e8dbfb6ff7b"), 
                    ProductID = Guid.Parse("f65a19bc-a333-4a87-a628-dbf9e1bcfc47"), 
                    Comment = "Giao hàng nhanh, sản phẩm đẹp." 
                }
            };

            modelBuilder.Entity<FeedBack>().HasData(feedbackData);

            //Seed Keyboard Detail 
            var keyboardData = new List<KeyboardDetail>
            {
                new KeyboardDetail
                {
                    KeyboardDetailID = Guid.Parse("370155b0-c511-4d9b-a593-e05328e1c8d5"),
                    ProductID = Guid.Parse("f65a19bc-a333-4a87-a628-dbf9e1bcfc47"),
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
                    KeyboardDetailID = Guid.Parse("b2fc0c65-a73b-40b8-9a06-b2b29b518e97"),
                    ProductID = Guid.Parse("f65a19bc-a333-4a87-a628-dbf9e1bcfc47"),
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
                    MouseDetailID = Guid.Parse("e61d2e54-400d-4997-978d-b78241035b89"),
                    ProductID = Guid.Parse("9fed113d-e297-46cb-ae5c-2143c08cce79"),
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
                    MouseDetailID = Guid.Parse("e679eab0-f692-4837-be8a-1440a3a0dac8"),
                    ProductID = Guid.Parse("bfe62974-e3a6-43e5-a22e-5d307752be32"),
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
                    ImageListID = Guid.NewGuid(),
                    ProductID = Guid.Parse("f65a19bc-a333-4a87-a628-dbf9e1bcfc47"),
                    ImagePath=["/images/aulaf75_img1.jpg", "/images/aulaf75_img2.jpg", "/images/aulaf75_img3.jpg"],
                    Description = "Hình ảnh của sản phẩm aulaf75"
                },
                new ImageList
                {
                    ImageListID= Guid.NewGuid(), 
                    ProductID=Guid.Parse("bfe62974-e3a6-43e5-a22e-5d307752be32"), 
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
                    MemberID= Guid.NewGuid(),
                    UserID=Guid.Parse("fa06b6a4-7694-4f78-8cf7-4e8dbfb6ff7b"),
                    Points=100,
                    ExpiryDate=DateTime.Parse("11/12/2024")
                },
                new Member 
                { 
                    MemberID= Guid.NewGuid(), 
                    UserID=Guid.Parse("173ec5bc-ff4c-4a78-9aee-45942272ca68"), 
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
                    SaleID=Guid.Parse("9fed113d-e297-46cb-ae5c-2143c08cce79"),
                    SaleName="Giảm giá mùa hè",
                    SalePercent=100,
                    Status = EntityStatus.Active
                },
                new Sale
                {
                    SaleID=Guid.Parse("bc9bd21f-6aea-4eb7-8a49-5b7f3ec42ca7"),
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
                    VoucherID=Guid.Parse("31ee7e10-df50-47ee-a475-de8333a8c80f"),
                    VoucherName="Giảm giá 30%",
                    VoucherPercent=30,
                    Status = EntityStatus.Active
                },
                new Voucher
                {
                    VoucherID=Guid.Parse("7ebbf433-5da6-416f-aec7-1e1a856c5349"),
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
                    OrderID=Guid.Parse("7ebbf433-5da6-416f-aec7-1e1a856c5349"), 
                    UserID=Guid.Parse("fa06b6a4-7694-4f78-8cf7-4e8dbfb6ff7b"), 
                    VoucherID=Guid.Parse("31ee7e10-df50-47ee-a475-de8333a8c80f"), 
                    totalQuantity=5, 
                    totalPrice=500.00, 
                    Status=OrderStatus.OrderConfirmed, 
                    paymentMethod="Credit Card", 
                    OrderDate=DateTime.Parse("16/09/2024")
                },
                new Order 
                { 
                    OrderID=Guid.Parse("1ae84276-f5a7-4cc2-950c-ebc9510da79d"), 
                    UserID=Guid.Parse("173ec5bc-ff4c-4a78-9aee-45942272ca68"), 
                    VoucherID=null, 
                    totalQuantity=3, 
                    totalPrice=300.00, 
                    Status=OrderStatus.Paid, 
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
                    OrderDetailID = Guid.Parse("cc17e300-7803-43f8-9615-ac260ea1ea6d"),
                    OrderID=Guid.Parse("1ae84276-f5a7-4cc2-950c-ebc9510da79d"),
                    ProductID=Guid.Parse("f65a19bc-a333-4a87-a628-dbf9e1bcfc47"),
                    Quantity=10,
                    UnitPrice=10000000,
                    Size = "M",
                    Weight = 4000
                },
                new OrderDetail
                {
                    OrderDetailID = Guid.Parse("75877ab6-1e90-40bc-93f8-87b2f5ac0553"),
                    OrderID=Guid.Parse("1ae84276-f5a7-4cc2-950c-ebc9510da79d"),
                    ProductID=Guid.Parse("f65a19bc-a333-4a87-a628-dbf9e1bcfc47"),
                    Quantity=1,
                    UnitPrice=1000000,
                    Size = "S",
                    Weight = 400
                },
                new OrderDetail
                {
                    OrderDetailID = Guid.Parse("1cee39e1-0d72-4626-ad70-4cb0b2c7e260"),
                    OrderID=Guid.Parse("1ae84276-f5a7-4cc2-950c-ebc9510da79d"),
                    ProductID=Guid.Parse("f65a19bc-a333-4a87-a628-dbf9e1bcfc47"),
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
