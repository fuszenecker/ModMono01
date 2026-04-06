using Common.Messaging;

using Domain.Entities;

using Microsoft.Extensions.DependencyInjection;

using ModuleA.Contracts;
using ModuleA.DataAccess;

using NSubstitute;

namespace ModuleA.Services.Tests;

public class ModuleARequestHandlerTests
{
    [Test]
    public async Task UserRequest_HandlerResolvedFromDi_ReturnsRepositoryUser()
    {
        var expectedUser = new User
        {
            Name = "Ada Lovelace",
            Age = 36,
            Addresses = []
        };
        var repository = Substitute.For<IUsersRepository>();
        var cancellationToken = new CancellationTokenSource().Token;

        repository
            .GetUserAsync(42, cancellationToken)
            .Returns(expectedUser);

        await using var serviceProvider = CreateServiceProvider(repository);
        var handler = serviceProvider.GetRequiredService<IRequestHandler<UserRequest, User>>();

        var result = await handler.Handle(new UserRequest { UserId = 42 }, cancellationToken);

        await Assert.That(result).IsNotNull();
        await Assert.That(result.Name).IsEqualTo(expectedUser.Name);
        await Assert.That(result.Age).IsEqualTo(expectedUser.Age);
        await repository.Received(1).GetUserAsync(42, cancellationToken);
    }

    [Test]
    public async Task UserCountRequest_HandlerResolvedFromDi_ReturnsRepositoryCount()
    {
        var repository = Substitute.For<IUsersRepository>();
        var cancellationToken = new CancellationTokenSource().Token;

        repository
            .GetUserCountAsync(cancellationToken)
            .Returns(11);

        await using var serviceProvider = CreateServiceProvider(repository);
        var handler = serviceProvider.GetRequiredService<IRequestHandler<UserCountRequest, int>>();

        var result = await handler.Handle(new UserCountRequest(), cancellationToken);

        await Assert.That(result).IsEqualTo(11);
        await repository.Received(1).GetUserCountAsync(cancellationToken);
    }

    private static ServiceProvider CreateServiceProvider(IUsersRepository repository)
    {
        var services = new ServiceCollection();

        services.AddScoped(_ => repository);
        services.AddModuleA();

        return services.BuildServiceProvider();
    }
}