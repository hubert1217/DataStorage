using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Infrastructure.Database.Context;

namespace Web.Infrastructure.Configuration
{
    public static class ConfigureExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddDbContext<DataStorageAppContext>(options => options.UseSqlServer(configuration.GetConnectionString("DataStorageConnectionString")));

            return services;
        }
    }
}
