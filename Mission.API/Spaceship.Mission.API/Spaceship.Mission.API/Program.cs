using Spaceship.Mission.API.Extensions;
using Spaceship.Mission.API.Interfaces;
using Spaceship.Mission.API.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<HttpClientExtensions>();
builder.Services.AddTransient<IMissionService, MissionService>();

var app = builder.Build();

app.MapGet("/", (IMissionService service) =>
{
    return service.CreateMission();
});

app.Run();
