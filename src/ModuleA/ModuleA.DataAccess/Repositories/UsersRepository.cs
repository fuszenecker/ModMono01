

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ModuleA.DataAccess.Mappings;

namespace ModuleA.DataAccess;

internal class UsersRepository(MyDbContext dbContext, ILogger<UsersRepository> logger) : IUsersRepository, ITestDataSeeder
{
    public async Task<Domain.Entities.User> GetUserAsync(int userId, CancellationToken cancellationToken)
    {
        var dbUser = await dbContext.Users
            .Include(u => u.Addresses)
            .SingleOrDefaultAsync(u => u.Id == userId, cancellationToken)
            ?? throw new KeyNotFoundException($"User with ID {userId} not found.");

        return dbUser.ToDomainEntity()!;
    }

    public async Task<int> GetUserCountAsync(CancellationToken cancellationToken)
    {
        return await dbContext.Users.CountAsync(cancellationToken);
    }

    public async Task SeedTestDataAsync(CancellationToken cancellationToken)
    {
        var rnd = new Random(DateTime.UtcNow.Millisecond);

        var count = await dbContext.Users.CountAsync(cancellationToken);
        logger.LogInformation("Current user count: {count}", count);

        if (count == 0)
        {
            for (int i = 1; i <= 5000; i++)
            {
                var addresses = new List<ModuleA.DataAccess.Entities.Address>();

                for (int j = 0; j < rnd.Next(1, 20); j++)
                {
                    addresses.Add(new ModuleA.DataAccess.Entities.Address
                    {
                        UserId = i,
                        Street = $"Street {i}-{j}",
                        City = $"City {i}-{j}",
                        State = $"State {i}-{j}",
                        ZipCode = $"Zip {i}-{j}"
                    });
                }

                dbContext.Users.Add(new ModuleA.DataAccess.Entities.User 
                { 
                    Id = i, 
                    Name = $"User {i}", 
                    Age = 20 + i,
                    Addresses = addresses
                });

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

