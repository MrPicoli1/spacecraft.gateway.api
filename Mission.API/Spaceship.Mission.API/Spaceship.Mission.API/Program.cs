using Spaceship.Mission.API.Data;
using Spaceship.Mission.API.Extensions;
using Spaceship.Mission.API.Interfaces;
using Spaceship.Mission.API.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<HttpClientExtensions>();
builder.Services.AddTransient<IMissionService, MissionService>();
//builder.Services.AddHostedService<BackgroundMissionServise>();
//builder.Services.AddSingleton<IRabbitMQ, MessageQueue>();

var app = builder.Build();

app.MapGet("/", (IMissionService service) =>
{
    return service.CreateMission();
});

app.Run();
