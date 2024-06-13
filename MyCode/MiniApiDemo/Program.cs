using Microsoft.AspNetCore.Mvc;
using MiniApiDemo;
using Serilog;

var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile(path: "appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile(path:"serilog.json",optional:false, reloadOnChange:true)
    .Build();
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(configuration)
    .CreateLogger();
try
{
    Log.Information("Starting host.");
    var builder = WebApplication.CreateBuilder(args);
    builder.Host.UseAutofac();
    builder.Services.ReplaceConfiguration(builder.Configuration);
    builder.Services.AddApplication<MinimalModule>();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    var app = builder.Build();
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapGet("/hi", ([FromServices] HelloService helloService) => helloService.SayHi());

    app.InitializeApplication();
    app.Run();
}
finally
{
    Log.CloseAndFlush();
}
