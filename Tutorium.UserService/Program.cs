using Microsoft.EntityFrameworkCore;
using Tutorium.UserService.Core.Users.Abstractions;
using Tutorium.UserService.Grpc;
using Tutorium.UserService.Infrastructure.Data;
using Tutorium.UserService.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

ConfigureAppSettings(builder);
ConfigureServices(builder);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy =>
        {
            policy.WithOrigins("http://localhost:3000")
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

var app = builder.Build();

ConfigureApp(app);

app.Run();

#region Setup Helpers

void ConfigureServices(WebApplicationBuilder builder)
{
    builder.Services.AddControllers();
    builder.Services.AddGrpc();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    var connectionString = builder.Configuration.GetConnectionString("DbConnection");
    builder.Services.AddDbContext<PgContext>(options => options.UseNpgsql(connectionString));

    builder.Services.AddScoped<IUserRepository, UserRepository>();
}

void ConfigureAppSettings(WebApplicationBuilder builder)
{
    builder.Configuration
       .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
       .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true);

    if (builder.Environment.IsDevelopment())
        builder.Configuration.AddJsonFile("appsettings.local.json", optional: true, reloadOnChange: true);

    builder.Configuration.AddEnvironmentVariables();
}

void ConfigureApp(WebApplication app)
{
    using (var scope = app.Services.CreateScope())
    {
        var db = scope.ServiceProvider.GetRequiredService<PgContext>();
        db.Database.Migrate(); // применяет все миграции, если их нет
    }

    app.UseCors("AllowFrontend");

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.MapGrpcService<UserGrcpServer>();
    app.UseHttpsRedirection();
    app.UseAuthorization();
    app.MapControllers();
}

#endregion Setup Helpers