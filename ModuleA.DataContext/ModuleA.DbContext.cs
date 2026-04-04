using Microsoft.EntityFrameworkCore;
using ModuleA.Contracts;

namespace ModuleA.DataContext;

internal class MyDbContext : DbContext
{
    public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
    {
        // erver=127.0.0.1;Port=5432;Database=fuszenecker;Username=fuszenecker;Password=admin;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        // Configure your entity mappings here

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("Users", "ModuleA");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Age).IsRequired();
        });
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

    // Define DbSets for your entities here
    public DbSet<User> Users { get; set; } = null!;
}