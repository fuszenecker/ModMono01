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
        while (!stoppingToken.IsCancellationRequested)
        {
            var userRequest = new UserRequest { UserId = 1 };
            var user = await _mediator.Send(userRequest, stoppingToken);

            _logger.LogInformation("Worker running at: {time}, returning {user}", DateTimeOffset.Now, user);
            await Task.Delay(1000, stoppingToken);
        }
    }
}