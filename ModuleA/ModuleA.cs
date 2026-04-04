using Microsoft.Extensions.DependencyInjection;

namespace ModuleA;

public static class ModuleA
{
    extension(IServiceCollection services)
    {
        public IServiceCollection AddModuleA()
        {
            services.AddScoped<Services.IUserService, Services.UserService>();
            return services;
        }
    }
}
