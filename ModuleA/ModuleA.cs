using Microsoft.Extensions.DependencyInjection;

namespace ModuleA;

public static class ModuleA
{
    extension(IServiceCollection services)
    {
        public IServiceCollection AddModuleA()
        {
            // Register MediatR handlers from the ModuleA assembly.
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ModuleA).Assembly));

            // Register the IUserService with its implementation UserService.
            services.AddScoped<Services.IUserService, Services.UserService>();

            return services;
        }
    }
}
