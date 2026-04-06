using Microsoft.Extensions.DependencyInjection;

namespace Common.Messaging;

public static class DependencyInjectionExtensions
{
    extension(IServiceCollection services)
    {
        public IServiceCollection AddCommandHandler<TCommand, TResult, THandler>()
            where TCommand : IRequest<TResult>
            where THandler : class, IRequestHandler<TCommand, TResult>
        {
            services.AddScoped<IRequestHandler<TCommand, TResult>, THandler>();
            return services;
        }

        public IServiceCollection AddStreamCommandHandler<TCommand, TResult, THandler>()
            where TCommand : IRequest<TResult>
            where THandler : class, IStreamRequestHandler<TCommand, TResult>
        {
            services.AddScoped<IStreamRequestHandler<TCommand, TResult>, THandler>();
            return services;
        }
    }
}
