using FluentValidation;
using TesteMuralis.WebApi.Validations;
using TesteMuralis.WebApi.Validations.TesteMuralis.WebApi.Validations;

namespace TesteMuralis.WebApi.Common
{
    public static class Build
    {
        public static void AddSwaggerDocumentation(this IServiceCollection service)
        {
            // Add services to the container.
            service.AddEndpointsApiExplorer(); // Explora os endpoints
            service.AddSwaggerGen();
        }
        public static void AddValidators(this IServiceCollection service)
        {
            // Add services to the container.
            service.AddValidatorsFromAssemblyContaining<ClienteDtoValidator>();
            service.AddValidatorsFromAssemblyContaining<AlterarClienteDtoValidator>();
            service.AddValidatorsFromAssemblyContaining<ContatoDtoValidator>();
        }
    }
}
