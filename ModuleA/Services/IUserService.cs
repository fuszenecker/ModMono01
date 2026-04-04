using ModuleA.Contracts;

namespace ModuleA.Services;

internal interface IUserService
{
    Task<User> GetUserAsync(int userId, CancellationToken cancellationToken);
}