// See https://aka.ms/new-console-template for more information

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MediatR;
using ModuleA;
using ModuleA.DataContext;

using UserRequest = ModuleA.Contracts.UserRequest;
using Microsoft.Extensions.Configuration;

var builder = new HostApplicationBuilder();

builder.Services.AddHostedService<MyBackgroundWorker>();
builder.Services.AddModuleA();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<Program>());
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<UserRequest>());

builder.Configuration
	.AddJsonFile("appSettings.json", optional: true, reloadOnChange: true);

builder.Services.AddModuleADbContext(builder.Configuration);

var host = builder.Build();

await host.RunAsync();

