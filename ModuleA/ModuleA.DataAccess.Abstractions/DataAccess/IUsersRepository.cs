namespace ModuleA.DataAccess;

public interface IUsersRepository
{
    Task<Domain.Entities.User> GetUserAsync(int userId, CancellationToken cancellationToken);

    Task<int> GetUserCountAsync(CancellationToken cancellationToken);
}