using Domain.Entities;

namespace ModuleA.Services;

internal interface IUserService
{
    Task<User> GetUserAsync(int userId, CancellationToken cancellationToken);

    Task<int> GetUserCountAsync(CancellationToken cancellationToken);
}