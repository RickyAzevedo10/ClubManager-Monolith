using ClubManager.API.Configuration;
using ClubManager.API.Midlewares;
using ClubManager.Domain.Interfaces.Persistence.CachedRepositories;
using ClubManager.Infra.Contexts;
using ClubManager.Infrastructure.Persistence.CachedRepositories;
using ClubManager.Ioc;
using ClubManager.Middlewares;
using Microsoft.EntityFrameworkCore;

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

// Garantir que a base de dados seja criada e as migrations aplicadas
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<DataContext>();
    dbContext.Database.Migrate(); // Cria a base de dados e aplica as migrations
}

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
