

using MediatR;
using ModuleA.Contracts;
using ModuleA.Services;

namespace ModuleA.Handlers;

internal class UserRequestHandler(IUserService userService) : IRequestHandler<UserRequest, User>
{   
    public Task<User> Handle(UserRequest request, CancellationToken cancellationToken)
    {
        return userService.GetUserAsync(request.UserId, cancellationToken);
    }
}