using DataLayer.Entities.Products;
using DataLayer.Entities.Users;
using EShopping.Core.Entities.Calculations;
using EShopping.Core.Entities.Customers;
using EShopping.Core.Entities.Ordering;
using Microsoft.EntityFrameworkCore;

namespace EShopping.Infrastructure.Context
{
    public class EShoppingDBContext : DbContext
    {
        #region constructor
        public EShoppingDBContext()
        {
            
        }
        //برای تنظیمات دیتابیس
        public EShoppingDBContext(DbContextOptions<EShoppingDBContext> options) : base(options)
        {
        }

        #endregion


        #region Account
        public DbSet<UserModel> Users { get; set; }
        #endregion
        #region Products
        public Microsoft.EntityFrameworkCore.DbSet<ProductModel> Products { get; set; }
        public DbSet<ProductCategoryModel> ProductCategories { get; set; }

        public DbSet<ProductSelectedCalculationModel> ProductSelectedCalculations { get; set; }
        #endregion
        #region Ordering
        public DbSet<OrderModel> Orders { get; set; }

        public DbSet<OrderDetailModel> OrderDetails { get; set; }

        public DbSet<WageModel> Wages { get; set; }
        #endregion

        #region Customers
        public DbSet<CustomerModel> Customers { get; set; }
        #endregion

        public DbSet<CalculationModel> Calculations { get; set; }
        #region disable cascading delete in database

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {



            //for uniqueidentifier
            //modelBuilder.Entity<Product>().Property(p => p.Id).HasDefaultValueSql("(newid())");
          //  modelBuilder.Entity<ProductModel>().Property(p => p.CreateDate).HasDefaultValueSql("(getdate())");

            
           
            //modelBuilder.Entity<ProductBoon>().HasKey(a => new { a.Id, a.OrderId });

            //modelBuilder.Entity<Message>()
            //    .HasOne(a => a.TblUserAdmin)
            //    .WithMany(b => b.TblMessagesAdmin)
            //    .HasForeignKey(a => a.AdminID);

            //modelBuilder.Entity<Message>()
            //    .HasOne(a => a.TblUserClaint)
            //    .WithMany(b => b.TblMessagesClaint)
            //    .HasForeignKey(a => a.UserID);


            //modelBuilder.Entity<ProductAsk>().HasIndex(a => a.Id)
            //    .HasDatabaseName("UK_AskId");

            //modelBuilder.Entity<ProductBoon>().HasIndex(a => a.BoonId)
            //    .HasDatabaseName("IX_BoonGroupID");

            //modelBuilder.Entity<ProductCategory>().HasIndex(a => a.ParentId)
            //    .HasDatabaseName("IX_ParrentID");

            //modelBuilder.Entity<ProductCategory>().HasIndex(a => a.Title)
            //    .HasDatabaseName("IX_Title");

            //modelBuilder.Entity<ProductComment>().HasIndex(a => a.IsRead)
            //    .HasDatabaseName("IX_Confirm");

            //modelBuilder.Entity<ProductComment>().HasIndex(a => a.IsRead)
            //   .HasDatabaseName("IX_Read");

            //modelBuilder.Entity<LoginHistory>().HasIndex(a => a.Cookie)
            //   .HasDatabaseName("IX_CookieID");

            //modelBuilder.Entity<Message>().HasIndex(a => a.IsRead)
            //   .HasDatabaseName("IX_Read");

            //modelBuilder.Entity<Notifiction>().HasIndex(a => a.CreateDate)
            //   .HasDatabaseName("IX_Date");

            //modelBuilder.Entity<Notifiction>().HasIndex(a => a.IsStatus)
            //   .HasDatabaseName("IX_Status");

            //modelBuilder.Entity<Order>().HasIndex(a => a.b)
            //   .HasDatabaseName("IX_BoonGroupID");

            //modelBuilder.Entity<Order>().HasIndex(a => a.ShoppingCartItem)
            //   .HasDatabaseName("IX_ShopingCartGroupID");

            //modelBuilder.Entity<Order>().HasIndex(a => a.IsPay)
            //   .HasDatabaseName("IX_Status");

            //modelBuilder.Entity<Order>().HasIndex(a => a.GetNumberBank)
            //  .HasDatabaseName("IX_BankGetNumber");

            //modelBuilder.Entity<Order>().HasIndex(a => a.GetNumberBank)
            //  .HasDatabaseName("IX_BankTransNumber");

            //modelBuilder.Entity<Order>().HasIndex(a => a.PostBarCode)
            //  .HasDatabaseName("IX_PostBarCode");

            //modelBuilder.Entity<ProductPrice>().HasIndex(a => a.CreateDate)
            // .HasDatabaseName("IX_Date");

            //modelBuilder.Entity<Product>().HasIndex(a => a.ProductName)
            // .HasDatabaseName("IX_ProductName");

            //modelBuilder.Entity<Product>().HasIndex(a => a.TitleEn)
            // .HasDatabaseName("IX_TitleEn");

            //modelBuilder.Entity<Product>().HasIndex(a => a.cre)
            //.HasDatabaseName("IX_Date");

            //modelBuilder.Entity<Product>().HasIndex(a => a.IsExists)
            //.HasDatabaseName("IX_Status");

            //modelBuilder.Entity<TblShopingCart>().HasIndex(a => a.ShopingCartGroupID)
            //.HasDatabaseName("IX_ShopingCartGroupID");

            //modelBuilder.Entity<TblShopingCart>().HasIndex(a => a.CookieID)
            //.HasDatabaseName("IX_CookieID");

            //modelBuilder.Entity<TblShopingCart>().HasIndex(a => a.Date)
            //    .HasDatabaseName("IX_Date");
          //  modelBuilder.Entity<Slider>().HasKey(a => new { a.Id })
              //  .HasName(nameof(Slider));
            
           // modelBuilder.Entity<Slider>().HasIndex(a => a.Sort)
               // .HasDatabaseName("IX_Sort");//برای جستجوی سریع

            //modelBuilder.Entity<TblTopic>().HasIndex(a => a.ParrentID)
            //   .HasDatabaseName("IX_ParrentID");

            //modelBuilder.Entity<TblTopic>().HasIndex(a => a.Title)
            //   .HasDatabaseName("IX_Title");
            //modelBuilder.Entity<TblMenus>().HasIndex(a => a.Title)
            //   .HasDatabaseName("IX_Title");



            var cascades = modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascades)
            {
                fk.DeleteBehavior = DeleteBehavior.Restrict;
            }

            //modelBuilder.Entity<ProductSelectedCalculationModel>()
            //    .HasKey(bc => new { bc.ProductId, bc.CalculationId });
            //modelBuilder.Entity<ProductSelectedCalculationModel>()
            //    .HasOne(bc => bc.Product)
            //    .WithMany(b => b.ProductSelectedCalculation)
            //    .HasForeignKey(bc => bc.ProductId);
            //modelBuilder.Entity<ProductSelectedCalculationModel>()
            //    .HasOne(bc => bc.Calculation)
            //    .WithMany(c => c.ProductSelectedCalculation)
            //    .HasForeignKey(bc => bc.CalculationId);


            base.OnModelCreating(modelBuilder);
        }

        #endregion
    }
}