// See https://aka.ms/new-console-template for more information

using MediatR;

using ModuleA;
using ModuleA.Contracts;
using ModuleA.DataContext;
using ModuleA.DataContext.Contracts;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
	.AddJsonFile("appSettings.json", optional: true, reloadOnChange: true);

builder.Services.AddModuleA();
builder.Services.AddModuleADbContext(builder.Configuration);

var app = builder.Build();

// app.Services.GetRequiredService<ITestDataSeeder>()
//     .SeedTestDataAsync(CancellationToken.None)
//     .GetAwaiter().GetResult();

app.MapGet("/users/{userId}", (int userId, IMediator mediator) => 
    mediator.Send(new UserRequest { UserId = userId }));

await app.RunAsync();
