// See https://aka.ms/new-console-template for more information

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using ModuleA;
using ModuleA.DataContext;
using ModuleA.DataContext.Contracts;

var builder = new HostApplicationBuilder();

builder.Configuration
	.AddJsonFile("appSettings.json", optional: true, reloadOnChange: true);

builder.Services.AddHostedService<MyBackgroundWorker>();

builder.Services.AddModuleA();
builder.Services.AddModuleADbContext(builder.Configuration);

var host = builder.Build();

host.Services.GetRequiredService<ITestDataSeeder>()
    .SeedTestDataAsync(CancellationToken.None)
    .GetAwaiter().GetResult();

await host.RunAsync();
