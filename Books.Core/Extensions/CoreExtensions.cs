using Books.Core.Mapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Core.Extensions
{
    public static class CoreExtensions
    {
        public static IServiceCollection AddCore(this IServiceCollection services)
        {
            services.AddAutoMapper((config) =>
            {
                config.AddMaps(typeof(BooksProfile).Assembly);
            });
            services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(CoreExtensions).Assembly));

            return services;
        }
    }
}
