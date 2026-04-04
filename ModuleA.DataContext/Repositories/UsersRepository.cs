

using Microsoft.EntityFrameworkCore;
using ModuleA.Contracts;
using ModuleA.DataContext;

namespace ModuleA.DataAccess;

internal class UsersRepository(MyDbContext dbContext) : IUsersRepository
{
    public async Task<User> GetUserAsync(int userId, CancellationToken cancellationToken)
    {
        return await dbContext.Users.SingleOrDefaultAsync(u => u.Id == userId, cancellationToken)
            ?? throw new KeyNotFoundException($"User with ID {userId} not found.");
    }
}

