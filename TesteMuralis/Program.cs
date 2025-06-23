using Muralis.Application.DIP;
using Muralis.Application.Services;
using Muralis.Infra.DIP;
using TesteMuralis.WebApi.Endpoints;
using FluentValidation;
using TesteMuralis.WebApi.Validations;
using TesteMuralis.WebApi;
using Muralis.Application.Dtos;
using TesteMuralis.WebApi.Validations.TesteMuralis.WebApi.Validations;
using TesteMuralis.WebApi.Common;


namespace TesteMuralis
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddSwaggerDocumentation();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddContext(builder.Configuration);
            builder.Services.AddValidators();
            builder.Services.AddInfraDependencies();
            builder.Services.AddServices();
            builder.Services.AddHttpClient<ICepService, CepService>();
            builder.Services.AddAuthorization();
            builder.Services.AddControllers();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.MapClienteEndpoints();

            app.MapContatosEndpoints();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
