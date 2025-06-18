using Microsoft.Extensions.DependencyInjection;
using Muralis.Application.Services;

namespace Muralis.Application.DIP
{
    public static class Build
    {
        public static IServiceCollection AddServices(this IServiceCollection service)
        {
            service.AddScoped<IMuralisService, MuralisService>();

            return service;
        }
    }
}
