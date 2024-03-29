using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Spaceship.Gateway.Data.Repositories;
using Spaceship.Gateway.Domain.Profiles;
using Spaceship.Gateway.Extensions.Http;
using Spaceship.Gateway.Models.Spaceship;
using Spaceship.Gateway.Services.Interfaces;
using Spaceship.Gateway.Services.Services;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Gateway API", Version = "v1" });
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});


builder.Services.AddTransient<IUserService,UserService>();
builder.Services.AddTransient<ISpaceshipService, SpaceshipService>();
builder.Services.AddTransient<IMissionService, MissionService>();
builder.Services.AddAutoMapper(typeof(SpaceshipProfiles));
builder.Services.AddScoped<HttpClientExtensions>();

var connectionStringSQL = builder.Configuration.GetConnectionString("MySQL");

builder.Services.AddDbContext<SpaceshipMySQLContext>(opts =>
{
    opts.UseMySql(connectionStringSQL,ServerVersion.AutoDetect(connectionStringSQL));
});


//builder.Services

var app = builder.Build();


// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
