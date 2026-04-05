

using Microsoft.EntityFrameworkCore;
using ModuleA.Contracts;
using ModuleA.DataContext;
using ModuleA.DataContext.Contracts;

namespace ModuleA.DataAccess;

internal class UsersRepository(MyDbContext dbContext) : IUsersRepository, ITestDataSeeder
{
    public async Task<User> GetUserAsync(int userId, CancellationToken cancellationToken)
    {
        return await dbContext.Users.SingleOrDefaultAsync(u => u.Id == userId, cancellationToken)
            ?? throw new KeyNotFoundException($"User with ID {userId} not found.");
    }

    public Task SeedTestDataAsync(CancellationToken cancellationToken)
    {
        var count = dbContext.Users.Count();

        if (count == 0)
        {
            dbContext.Users.AddRange(
                new User { Id = 1, Name = "Alice", Age = 30 },
                new User { Id = 2, Name = "Bob", Age = 25 },
                new User { Id = 3, Name = "Charlie", Age = 35 },
                new User { Id = 4, Name = "Diana", Age = 28 },
                new User { Id = 5, Name = "Eve", Age = 32 }
            );

            return dbContext.SaveChangesAsync(cancellationToken);
        }

        return Task.CompletedTask;
    }
}

