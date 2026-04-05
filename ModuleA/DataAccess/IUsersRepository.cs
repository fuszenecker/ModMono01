using ModuleA.Contracts;

namespace ModuleA.DataAccess;

public interface IUsersRepository
{
    Task<User> GetUserAsync(int userId, CancellationToken cancellationToken);
}