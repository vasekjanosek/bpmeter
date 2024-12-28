using BpMeter.API.Settings;
using BpMeter.Application;
using BpMeter.Infrastructure.Database.Entites;
using BpMeter.Infrastructure.Database.PostgreSQL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<DbSettings>(builder.Configuration.GetSection("DbSettings"));

if (!bool.TryParse(builder.Configuration["DbSettings:UseInMemoryDb"], out bool useInMemoryDb))
{
    useInMemoryDb = true;
}

// Add services to the container.
builder.Services.AddDbContextPool<BpMeterDbContext>(opt =>
{
    if (!useInMemoryDb)
    {
        opt.UseNpgsql(builder.Configuration["DbSettings:ConnectionString"], b => b.MigrationsAssembly("BpMeter.API"));
    }
    else
    {
        opt.UseInMemoryDatabase("BpMeterDB");
    }

    opt.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});

builder.Services.RegisterApplication();

builder.Services.RegisterDatabase(ServiceLifetime.Scoped);

builder.Services.AddAutoMapper(typeof(DbMappingProfile));

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.MapControllers();


if (!useInMemoryDb)
{
    using (var scope = app.Services.CreateScope())
    {
        var dbContext = scope.ServiceProvider.GetRequiredService<BpMeterDbContext>();

        if ((await dbContext.Database.GetPendingMigrationsAsync()).Any())
        {
            dbContext.Database.Migrate();
        }

        await app.Services.InitializeApplicationAsync();
    }
}

app.Run();
