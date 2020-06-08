using FruitAndVegetableWarehouseManagement.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FruitAndVegetableWarehouseManagement.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Supply> Supplies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InvoiceProduct>()
                .HasKey(ip => new { ip.InvoiceID, ip.ProductID });

            modelBuilder.Entity<InvoiceProduct>()
                .HasOne(ip => ip.Invoice)
                .WithMany(i => i.InvoiceProducts)
                .HasForeignKey(ip => ip.InvoiceID);

            modelBuilder.Entity<InvoiceProduct>()
                .HasOne(ip => ip.Product)
                .WithMany(p => p.InvoiceProducts)
                .HasForeignKey(ip => ip.ProductID);

            modelBuilder.Entity<SupplyProduct>()
                .HasKey(sp => new {sp.SupplyId, sp.ProductId});

            modelBuilder.Entity<SupplyProduct>()
                .HasOne(sp => sp.Supply)
                .WithMany(s => s.SupplyProducts)
                .HasForeignKey(sp => sp.SupplyId);

            modelBuilder.Entity<SupplyProduct>()
                .HasOne(sp => sp.Product)
                .WithMany(p => p.SupplyProducts)
                .HasForeignKey(sp => sp.ProductId);

            modelBuilder.Entity<Company>()
                .HasDiscriminator<string>("CompanyType")
                .HasValue<Customer>("customer")
                .HasValue<Supplier>("supplier");

            base.OnModelCreating(modelBuilder);
        }
    }
}
