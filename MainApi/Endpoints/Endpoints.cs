using MediatR;
using ModuleA.Contracts;

internal static class EndpointExtensions
{
    extension (WebApplication app)
    {
        public WebApplication AddEndpoints()
        {
            app.MapGet("/users/{userId}", (int userId, IMediator mediator) => 
                mediator.Send(new UserRequest { UserId = userId }));

            app.MapGet("/users/count", (IMediator mediator) => 
                mediator.Send(new UserCountRequest()));

            return app;
        }
    }
}