using Microsoft.EntityFrameworkCore;

namespace PMS.Entities.Models; 

public class PmsContext : DbContext {
    public PmsContext() {
        
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<ProductDetail> ProductDetails { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Store> Stores { get; set; }
    public DbSet<Manager> Managers { get; set; }
    public DbSet<MainPage> MainPages { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<SubCategory> SubCategories { get; set; }
    public DbSet<User> Users { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        optionsBuilder
            .UseSqlServer(
                @"Data Source=.\SQLEXPRESS;Initial Catalog=ProductStoreDb;Integrated Security=True;TrustServerCertificate=true;",
                providerOptions => { providerOptions.EnableRetryOnFailure(); });
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>()
            .HasOne(a => a.ProductDetail)
            .WithOne(b => b.Product)
            .HasForeignKey<ProductDetail>(b => b.ProductId);
    }
}