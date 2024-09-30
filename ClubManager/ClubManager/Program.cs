using ClubManager.API.Configuration;
using ClubManager.API.Midlewares;
using ClubManager.Domain.Interfaces.Persistence.CachedRepositories;
using ClubManager.Infrastructure.Persistence.CachedRepositories;
using ClubManager.Ioc;
using ClubManager.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddMappingConfiguration();

builder.Services.AddAuthorizationSettings(builder.Configuration);

builder.Services.AddControllers();
builder.Services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Application dependencies
builder.Services.AddApplicationDependencies(builder.Configuration);

builder.Services.AddSwaggerConfiguration();

// Add Redis Cache
builder.Services.AddStackExchangeRedisCache(redisOptions =>
{
    string connection = builder.Configuration.GetConnectionString("Redis")!;
    redisOptions.Configuration = connection;
});

// Add Caching Repositories
builder.Services.AddScoped<IRefreshTokenCachedRepository, RefreshTokenCachedRepository>();

// Builders
WebApplication? app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.ConfigureSwagger();
}

app.UseMiddleware<RequestURLMiddleware>();
app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorizationSettings();

app.MapControllers();

app.Run();
