using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using ModuleA.DataAccess;

namespace ModuleA.DataContext;

public static class DbContextExtensions
{
    extension(IServiceCollection services)
    {
        public IServiceCollection AddModuleADbContext(IConfigurationManager configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new InvalidOperationException(
                    "Connection string 'DefaultConnection' was not found. Ensure appsettings.json contains ConnectionStrings:DefaultConnection.");
            }

            services.AddDbContext<MyDbContext>(options =>
                options.UseNpgsql(connectionString));

            services.AddScoped<IUsersRepository>(sp =>
            {
                var dbContext = sp.GetRequiredService<MyDbContext>();
                return new UsersRepository(dbContext);
            });

            return services;
        }
    }
}