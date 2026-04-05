using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Hosting;
using MediatR;

using ModuleA.Contracts;

internal class MyBackgroundWorker : BackgroundService
{
    private readonly ILogger<MyBackgroundWorker> _logger;
    private readonly IMediator _mediator;

    public MyBackgroundWorker(IMediator mediator, ILogger<MyBackgroundWorker> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var rnd = new Random(DateTime.Now.Millisecond);

        while (!stoppingToken.IsCancellationRequested)
        {
            var userCountRequest = new UserCountRequest();
            var userCount = await _mediator.Send(userCountRequest, stoppingToken);
            _logger.LogInformation("Current user count: {count}", userCount);

            var userId = rnd.Next(1, userCount + 1); // Simulate random user ID
            var userRequest = new UserRequest { UserId = userId };
            var user = await _mediator.Send(userRequest, stoppingToken);

            _logger.LogInformation("Worker running at: {time}, returning {user}", DateTimeOffset.Now, user);
            await Task.Delay(1000, stoppingToken);
        }
    }
}