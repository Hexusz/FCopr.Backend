using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using FCopr.Application.Interfaces;

namespace FCorp.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection
            services, IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];
            services.AddDbContext<FCorpDbContext>(options =>
            {
                options.UseSqlite(connectionString);
            });
            services.AddScoped<IFCorpDbContext>(provider =>
                provider.GetService<FCorpDbContext>());
            return services;
        }
    }
}
