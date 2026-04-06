namespace ModuleA.DataAccess;

public interface IUsersRepository
{
    Task<ModuleA.Entities.User> GetUserAsync(int userId, CancellationToken cancellationToken);

    Task<int> GetUserCountAsync(CancellationToken cancellationToken);
}