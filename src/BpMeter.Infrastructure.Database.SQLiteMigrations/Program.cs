using BpMeter.Infrastructure.Database.PostgreSQL;
using Microsoft.EntityFrameworkCore;

namespace BpMeter.Infrastructure.Database.SQLiteMigrations
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            builder.Services.AddDbContextPool<BpMeterDbContext>(opt =>
                opt.UseSqlite("Data Source=BpSQLite.db3",
                    x => x.MigrationsAssembly("BpMeter.Infrastructure.Database.SQLiteMigrations")));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
