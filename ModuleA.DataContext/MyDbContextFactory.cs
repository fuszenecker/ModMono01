using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ModuleA.DataContext;

internal class MyDbContextFactory : IDesignTimeDbContextFactory<MyDbContext>
{
    public MyDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<MyDbContext>();
        optionsBuilder.UseNpgsql("Server=127.0.0.1;Port=5432;Database=fuszenecker;Username=fuszenecker;Password=admin;");

        return new MyDbContext(optionsBuilder.Options);
    }
}
