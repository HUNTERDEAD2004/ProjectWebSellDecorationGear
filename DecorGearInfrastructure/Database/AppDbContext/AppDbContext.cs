using DecorGearDomain.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DecorGearInfrastructure.Database.AppDbContext
{
    public class AppDbContext : DbContext
    {
        #region Db Set 
        public virtual DbSet<Brand> Brands {  get; set; }   
        public virtual DbSet<Cart> Carts {  get; set; }   
        public virtual DbSet<CartDetail> CartDetails {  get; set; }   
        public virtual DbSet<Category> Categories {  get; set; }   
        public virtual DbSet<Favorite> Favorites {  get; set; }   
        public virtual DbSet<FeedBack> FeedBacks {  get; set; }   
        public virtual DbSet<ImageList> ImageLists {  get; set; }   
        public virtual DbSet<KeyboardDetail> KeyboardDetails {  get; set; }   
        public virtual DbSet<Member> Members {  get; set; }   
        public virtual DbSet<MouseDetail> MouseDetails {  get; set; }   
        public virtual DbSet<Order> Orders {  get; set; }  
        public virtual DbSet<Product> Products {  get; set; }  
        public virtual DbSet<Role> Roles {  get; set; }  
        public virtual DbSet<Sale> Sales {  get; set; }  
        public virtual DbSet<SubCategory> SubCategories {  get; set; }  
        public virtual DbSet<User> Users {  get; set; }  
        public virtual DbSet<Voucher> Vouchers {  get; set; }
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

        }
    }
}
