using MediatR;

using ModuleA.Contracts;
using ModuleA.Services;
using ModuleA.Entities;

namespace ModuleA.Handlers;

internal class UserRequestHandler(IUserService userService) : IRequestHandler<UserRequest, User>
{   
    public Task<User> Handle(UserRequest request, CancellationToken cancellationToken)
    {
        return userService.GetUserAsync(request.UserId, cancellationToken);
    }
}

internal class UserCountRequestHandler(IUserService userService) : IRequestHandler<UserCountRequest, int>
{
    public Task<int> Handle(UserCountRequest request, CancellationToken cancellationToken)
    {
        return userService.GetUserCountAsync(cancellationToken);
    }
}