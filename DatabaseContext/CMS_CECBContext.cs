namespace DatabaseContext
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Model;

    public partial class CMS_CECBContext : DbContext
    {
        public CMS_CECBContext()
            : base("name=CMS_CECBContext")
        {
            this.Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Invoice> Invoice { get; set; }
        public virtual DbSet<InvoiceDetail> InvoiceDetail { get; set; }
        public virtual DbSet<Product> Product { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
               .Property(e => e.Identification)
               .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.Invoice)
                .WithRequired(e => e.Customer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Invoice>()
                .Property(e => e.InvoiceNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Invoice>()
                .Property(e => e.TotalValue)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Invoice>()
                .HasMany(e => e.InvoiceDetail)
                .WithRequired(e => e.Invoice)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<InvoiceDetail>()
                .Property(e => e.Value)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Product>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.UnitValue)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.InvoiceDetail)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        public static CMS_CECBContext Create()
        {
            return new CMS_CECBContext();
        }
    }
}
