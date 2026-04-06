using Microsoft.EntityFrameworkCore;

using ModuleA.DataContext.Entities;

namespace ModuleA.DataContext;

internal class MyDbContext : DbContext
{
    public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("users", "module_a");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Age).IsRequired();

            entity.HasMany(e => e.Addresses)
                .WithOne()
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Address>(entity =>
        {
            entity.ToTable("addresses", "module_a");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Street).IsRequired().HasMaxLength(200);
            entity.Property(e => e.City).IsRequired().HasMaxLength(100);
            entity.Property(e => e.State).IsRequired().HasMaxLength(50);
            entity.Property(e => e.ZipCode).IsRequired().HasMaxLength(20);
        });
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

    public DbSet<User> Users { get; set; } = null!;

    public DbSet<Address> Addresses { get; set; } = null!;
}