namespace Models._01.Entity
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class EcommerceDbContext : DbContext
    {
        public EcommerceDbContext()
            : base("name=Ecommerce")
        {
        }

        public virtual DbSet<About> Abouts { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<Feedback> Feedbacks { get; set; }
        public virtual DbSet<GiftCode> GiftCodes { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductGroup> ProductGroups { get; set; }
        public virtual DbSet<ProductImage> ProductImages { get; set; }
        public virtual DbSet<Slide> Slides { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<About>()
                .Property(e => e.AboutMetaTitle)
                .IsUnicode(false);

            modelBuilder.Entity<About>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<About>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .Property(e => e.CategoryMetaTitle)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<GiftCode>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<GiftCode>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<GiftCode>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
                .Property(e => e.Amount)
                .HasPrecision(21, 0);

            modelBuilder.Entity<Order>()
                .Property(e => e.Total)
                .HasPrecision(21, 0);

            modelBuilder.Entity<Order>()
                .Property(e => e.OrderCode)
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<OrderDetail>()
                .Property(e => e.OrderCode)
                .IsUnicode(false);

            modelBuilder.Entity<OrderDetail>()
                .Property(e => e.ProductCode)
                .IsUnicode(false);

            modelBuilder.Entity<OrderDetail>()
                .Property(e => e.TotalProductPrice)
                .HasPrecision(21, 0);

            modelBuilder.Entity<Product>()
                .Property(e => e.ProductCode)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.ProductMetaTitle)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.Price)
                .HasPrecision(21, 0);

            modelBuilder.Entity<Product>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<ProductGroup>()
                .Property(e => e.ProductGroupMetaTitle)
                .IsUnicode(false);

            modelBuilder.Entity<ProductGroup>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<ProductGroup>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<ProductImage>()
                .Property(e => e.ProductCode)
                .IsUnicode(false);

            modelBuilder.Entity<Slide>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Slide>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.NumberPhone)
                .IsUnicode(false);
        }
    }
}
