using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Muralis.Domain.Repositories;
using Muralis.Infra.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muralis.Infra.DIP
{
    public static class Build
    {
        public static IServiceCollection AddContext(this IServiceCollection service, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            service.AddDbContext<MuralisAppContext>(opts => opts.UseSqlServer(connectionString));
            return service;
        }

        public static IServiceCollection AddInfraDependencies(this IServiceCollection service)
        {
            service.AddScoped<IMuralisRepository, MuralisRepository>();

            return service;
        }
    }
}
