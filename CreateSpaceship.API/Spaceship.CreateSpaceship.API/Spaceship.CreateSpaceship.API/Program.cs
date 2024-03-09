using Spaceship.CreateSpaceship.API.Services;
using Spaceship.CreateSpaceship.API.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<ISpaceshipService, SpaceshipService>();

var app = builder.Build();

app.MapGet("/", (ISpaceshipService service)
    =>
{
    return service.CreateSpaceships();
}
);

app.Run();
