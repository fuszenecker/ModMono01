using Common.Messaging;
using Domain.Entities;
using ModuleA.Contracts;

internal static class EndpointExtensions
{
    extension (WebApplication app)
    {
        public WebApplication AddEndpoints()
        {
            app.MapGet("/users/{userId}", (int userId, IRequestHandler<UserRequest, User> handler, CancellationToken cancellationToken) =>
                handler.Handle(new UserRequest { UserId = userId }, cancellationToken));

            app.MapGet("/users/count", (IRequestHandler<UserCountRequest, int> handler, CancellationToken cancellationToken) =>
                handler.Handle(new UserCountRequest(), cancellationToken));

            return app;
        }
    }
}