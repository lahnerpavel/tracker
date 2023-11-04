using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.OpenApi.Models;
using Tracker.Api;
using Tracker.Api.Interfaces;
using Tracker.Api.Managers;
using Tracker.Data;
using Tracker.Data.Interfaces;
using Tracker.Data.Repositories;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("LocalTrackerConnection");

builder.Services.AddDbContext<TrackerDbContext>(options =>
    options.UseSqlServer(connectionString)
        .UseLazyLoadingProxies()
        .ConfigureWarnings(x => x.Ignore(CoreEventId.LazyLoadOnDisposedContextWarning)));

builder.Services.AddControllers().AddJsonOptions(options =>
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
    options.SwaggerDoc("tracker", new OpenApiInfo
    {
        Version = "v1",
        Title = "Lokalizační databáze",
        Description = "Webové API pro databázi vytvořené pomocí technologie ASP.NET.",
        Contact = new OpenApiContact
        {
            Name = "Kontakt",
            Url = new Uri("https://www.seznam.cz/")
        }
    }));

builder.Services.AddScoped<IVehicleRepository, VehicleRepository>();
builder.Services.AddScoped<IVehicleLocationRepository, VehicleLocationRepository>();
builder.Services.AddScoped<IVehicleManager, VehicleManager>();
builder.Services.AddScoped<IVehicleLocationManager, VehicleLocationManager>();


builder.Services.AddAutoMapper(typeof(AutomapperConfigurationProfile));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("tracker/swagger.json", "Lokalizační databáze - v1");
    });
}

app.MapGet("/", () => "Hello buddy!");

app.MapControllers();

app.Run();