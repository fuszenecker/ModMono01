

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ModuleA.Contracts;
using ModuleA.DataContext;
using ModuleA.DataContext.Contracts;

namespace ModuleA.DataAccess;

internal class UsersRepository(MyDbContext dbContext, ILogger<UsersRepository> logger) : IUsersRepository, ITestDataSeeder
{
    public async Task<User> GetUserAsync(int userId, CancellationToken cancellationToken)
    {
        return await dbContext.Users.SingleOrDefaultAsync(u => u.Id == userId, cancellationToken)
            ?? throw new KeyNotFoundException($"User with ID {userId} not found.");
    }

    public async Task<int> GetUserCountAsync(CancellationToken cancellationToken)
    {
        return await dbContext.Users.CountAsync(cancellationToken);
    }

    public async Task SeedTestDataAsync(CancellationToken cancellationToken)
    {
        var count = await dbContext.Users.CountAsync(cancellationToken);
        logger.LogInformation("Current user count: {count}", count);

        if (count == 0)
        {
            dbContext.Users.AddRange(
                new User { Id = 1, Name = "Alice", Age = 30 },
                new User { Id = 2, Name = "Bob", Age = 25 },
                new User { Id = 3, Name = "Charlie", Age = 35 },
                new User { Id = 4, Name = "Diana", Age = 28 },
                new User { Id = 5, Name = "Eve", Age = 32 }
            );

            await dbContext.SaveChangesAsync(cancellationToken);
            logger.LogInformation("Seeded initial 5 users");

            for (int i = await dbContext.Users.CountAsync(cancellationToken) + 1; i <= 5000; i++)
            {
                dbContext.Users.Add(new User { Id = i, Name = $"User {i}", Age = 20 + i });

                if (i % 1000 == 0)
                {
                    await dbContext.SaveChangesAsync(cancellationToken);
                    logger.LogInformation("Seeded {count} users", i);
                }
            }

            await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}

