using Books.Domain.RepositoryContract;
using Books.Infra.Persistance;
using Books.Infra.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Books.Infra.Extensions
{
    public static class InfraExtension
    {
        public static IServiceCollection AddInfra(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("BooksDb")));
            services.AddScoped<IBooksRepository, BooksRepository>();
            return services;
        }
    }
}
