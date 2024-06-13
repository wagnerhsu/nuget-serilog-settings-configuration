using Microsoft.AspNetCore.Mvc;
using MiniApiDemo;

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
