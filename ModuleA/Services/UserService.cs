using ModuleA.Contracts;
using ModuleA.DataAccess;

namespace ModuleA.Services;

internal class UserService(IUsersRepository usersRepository) : IUserService
{
    private readonly IUsersRepository _usersRepository = usersRepository;

    public async Task<User> GetUserAsync(int userId, CancellationToken cancellationToken)
    {
        var user = await _usersRepository.GetUserAsync(userId, cancellationToken);
        return user;
    }

    public async Task<int> GetUserCountAsync(CancellationToken cancellationToken)
    {
        var count = await _usersRepository.GetUserCountAsync(cancellationToken);
        return count;
    }
}