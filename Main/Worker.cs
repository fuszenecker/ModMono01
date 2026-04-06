using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Hosting;

using Common.Messaging;
using Domain.Entities;
using ModuleA.Contracts;

internal class MyBackgroundWorker : BackgroundService
{
    private readonly ILogger<MyBackgroundWorker> _logger;
    private readonly IRequestHandler<UserCountRequest, int> _userCountHandler;
    private readonly IRequestHandler<UserRequest, User> _userHandler;

    public MyBackgroundWorker(
        IRequestHandler<UserCountRequest, int> userCountHandler,
        IRequestHandler<UserRequest, User> userHandler,
        ILogger<MyBackgroundWorker> logger)
    {
        _userCountHandler = userCountHandler;
        _userHandler = userHandler;
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var rnd = new Random(DateTime.Now.Millisecond);

        while (!stoppingToken.IsCancellationRequested)
        {
            var userCount = await _userCountHandler.Handle(new UserCountRequest(), stoppingToken);
            _logger.LogInformation("Current user count: {count}", userCount);

            var userId = rnd.Next(1, userCount + 1);
            var user = await _userHandler.Handle(new UserRequest { UserId = userId }, stoppingToken);

            _logger.LogInformation("Worker running at: {time}, returning {user}", DateTimeOffset.Now, user);
            await Task.Delay(1000, stoppingToken);
        }
    }
}