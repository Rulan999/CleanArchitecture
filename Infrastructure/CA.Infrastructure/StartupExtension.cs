using CA.Application;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CA.Infrastructure
{
    public static class StartupExtensions
    {
        private static readonly InMemoryDatabaseRoot InMemoryDatabaseRoot = new InMemoryDatabaseRoot();

        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            
            services.AddDbContext<BaseDBContext>(options => options.UseInMemoryDatabase(databaseName: "Testing", InMemoryDatabaseRoot));
           
            services.AddTransient<IReadRepository, ReadRepository>();
            services.AddTransient<IWriteRepository, WriteRepository>();

            return services;
        }
    }
}
