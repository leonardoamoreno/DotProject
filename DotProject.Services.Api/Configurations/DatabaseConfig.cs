using DotProject.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Equinox.Services.Api.Configurations
{
    public static class DatabaseConfig
    {
        public static void AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddDbContext<DotProjectContext>(options =>
                options.UseInMemoryDatabase("MemoryDatabase"));
                //UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddDbContext<EventStoreSqlContext>(options =>
                options.UseInMemoryDatabase("MemoryDatabase"));
        }
    }
}