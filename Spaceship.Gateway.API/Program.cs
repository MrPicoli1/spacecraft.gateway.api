using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Spaceship.Gateway.Data.Repositories;
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
var app = builder.Build();


builder.Services.AddDbContext<SpaceshipMySQLContext>(opts => opts.UseMySql("Server=127.0.0.1;Port=3306;Database=DePloy;Uid=gui;Pwd=123123;", ServerVersion.AutoDetect("Server=127.0.0.1;Port=3306;Database=DePloy;Uid=gui;Pwd=123123;")));
// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
