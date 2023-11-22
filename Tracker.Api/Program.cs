using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.OpenApi.Models;
using Tracker.Api;
using Tracker.Api.Interfaces;
using Tracker.Api.Managers;
using Tracker.Data;
using Tracker.Data.Interfaces;
using Tracker.Data.Repositories;
using System.Reflection;
using System.Text.Json.Serialization;
using static System.Net.WebRequestMethods;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("LocalTrackerConnection");

builder.Services.AddDbContext<TrackerDbContext>(options =>
    options.UseSqlServer(connectionString)
        .UseLazyLoadingProxies()
        .ConfigureWarnings(x => x.Ignore(CoreEventId.LazyLoadOnDisposedContextWarning)));

builder.Services.AddControllers().AddJsonOptions(options =>
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
    {
        options.Password.RequiredLength = 8;
        options.Password.RequireNonAlphanumeric = false;
        options.User.RequireUniqueEmail = true;
    }
).AddEntityFrameworkStores<TrackerDbContext>();

builder.Services.ConfigureApplicationCookie(options =>
    {
        options.Events.OnRedirectToAccessDenied = context =>
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            return Task.CompletedTask;
        };

        options.Events.OnRedirectToLogin = context =>
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            return Task.CompletedTask;
        };
    });

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

builder.Services.AddScoped<IPersonRepository, PersonRepository>();
builder.Services.AddScoped<IMovieRepository, MovieRepository>();
builder.Services.AddScoped<IGenreRepository, GenreRepository>();
builder.Services.AddScoped<IPersonManager, PersonManager>();
builder.Services.AddScoped<IGenreManager, GenreManager>();
builder.Services.AddScoped<IMovieManager, MovieManager>();

builder.Services.AddScoped<IVehicleRepository, VehicleRepository>();
builder.Services.AddScoped<IVehicleLocationRepository, VehicleLocationRepository>();
builder.Services.AddScoped<IVehicleManager, VehicleManager>();
builder.Services.AddScoped<IVehicleLocationManager, VehicleLocationManager>();


builder.Services.AddAutoMapper(typeof(AutomapperConfigurationProfile));

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

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

using (var scope = app.Services.CreateScope())
{
    RoleManager<IdentityRole> roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

    await CreateAllRoles(roleManager);
}

app.Run();



async Task CreateAllRoles(RoleManager<IdentityRole> roleManager)
{
    FieldInfo[] constants = typeof(UserRoles)
        .GetFields(BindingFlags.Public | BindingFlags.Static)
        .Where(fieldInfo => fieldInfo.IsLiteral
            && !fieldInfo.IsInitOnly
            && fieldInfo.FieldType == typeof(string))
        .ToArray();

    string[] roles = constants
        .Select(fieldInfo => fieldInfo.GetRawConstantValue())
        .OfType<string>()
        .ToArray();

    foreach (var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
            await roleManager.CreateAsync(new IdentityRole(role));
    }
}