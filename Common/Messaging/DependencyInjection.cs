using Microsoft.Extensions.DependencyInjection;

namespace Common.Messaging;

public static class DependencyInjectionExtensions
{
    extension(IServiceCollection services)
    {
        public IServiceCollection AddRequestHandler<TCommand, TResult, THandler>()
            where TCommand : IRequest<TResult>
            where THandler : class, IRequestHandler<TCommand, TResult>
        {
            services.AddScoped<IRequestHandler<TCommand, TResult>, THandler>();
            return services;
        }

        public IServiceCollection AddCommandHandler<TCommand, THandler>()
            where TCommand : ICommand
            where THandler : class, ICommandHandler<TCommand>
        {
            services.AddScoped<ICommandHandler<TCommand>, THandler>();
            return services;
        }

        public IServiceCollection AddStreamRequestHandler<TCommand, TResult, THandler>()
            where TCommand : IRequest<TResult>
            where THandler : class, IStreamRequestHandler<TCommand, TResult>
        {
            services.AddScoped<IStreamRequestHandler<TCommand, TResult>, THandler>();
            return services;
        }
    }
}
