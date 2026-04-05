// See https://aka.ms/new-console-template for more information

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ModuleA;
using ModuleA.DataContext;
using ModuleA.Contracts;
using Microsoft.Extensions.Configuration;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
	.AddJsonFile("appSettings.json", optional: true, reloadOnChange: true);

builder.Services.AddModuleA();
builder.Services.AddModuleADbContext(builder.Configuration);

var app = builder.Build();

// host.Services.GetRequiredService<ITestDataSeeder>()
//     .SeedTestDataAsync(CancellationToken.None)
//     .GetAwaiter().GetResult();

app.MapGet("/users/{userId}", (int userId, IMediator mediator) => 
    mediator.Send(new UserRequest { UserId = userId }));

await app.RunAsync();
