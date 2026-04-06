using Microsoft.Extensions.DependencyInjection;

using Common.Messaging;
using ModuleA.Contracts;

namespace ModuleA;

public static class ModuleAExtensions
{
    extension(IServiceCollection services)
    {
        public IServiceCollection AddModuleA()
        {
            // Register the request handlers for UserRequest and UserCountRequest.
            services.AddRequestHandler<UserRequest, Domain.Entities.User, Handlers.UserRequestHandler>();
            services.AddRequestHandler<UserCountRequest, int, Handlers.UserCountRequestHandler>();

            // Register the IUserService with its implementation UserService.
            services.AddScoped<Services.IUserService, Services.UserService>();

            return services;
        }
    }
}
