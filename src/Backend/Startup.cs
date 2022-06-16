using DataAccess.Context;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace Backend
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var sqliteConnection = Configuration.GetConnectionString("SQLiteDb");

            var connectionString = new SqliteConnection(@$"Data Source={sqliteConnection}");
            
            services.AddDbContext<CustomerContext>(optBuilder =>
            {
                optBuilder.UseSqlite(
                    connectionString,
                    x => x.MigrationsAssembly("DataAccess"));
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var customerContext = scope.ServiceProvider.GetRequiredService<CustomerContext>();
                customerContext.Database.Migrate();
            }
        }
    }
}
