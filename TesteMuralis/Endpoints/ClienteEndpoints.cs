using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Muralis.Application.Dtos;
using Muralis.Application.Services;
using Muralis.Domain.Entitiy;
using System.ComponentModel.DataAnnotations;
using TesteMuralis.WebApi.Extension;


namespace TesteMuralis.WebApi.Endpoints
{
    public static class ClienteEndpoints
    {
        public static void MapClienteEndpoints(this IEndpointRouteBuilder app)
        {
            var clientes = app.MapGroup("/clientes")
                              .WithTags("Clientes")
                              .WithOpenApi();

            clientes.MapPost("", async ([FromServices] IMuralisService service, 
                                        [FromBody] ClienteDto dto,
                                        IValidator<ClienteDto> validador) =>
            {
                var resultadoValidador = await validador.ValidateAsync(dto);

                if (!resultadoValidador.IsValid)
                    return Results.BadRequest(resultadoValidador.FormatValidationErrors());

                var result = await service.AdicionarClienteAsync(dto);
                return Results.Json(result, statusCode: result.CodigoStatus);
            });

            clientes.MapPut("{id}", async ([FromServices] IMuralisService service, 
                                            Guid id, 
                                            [FromBody] AlterarClienteDto dto,
                                            IValidator<AlterarClienteDto> validador) =>
            {
                var resultadoValidador = await validador.ValidateAsync(dto);

                if (!resultadoValidador.IsValid)
                    return Results.BadRequest(resultadoValidador.FormatValidationErrors());

                var result = await service.AlterarClienteAsync(dto, id);
                return Results.Json(result, statusCode: result.CodigoStatus);
            });

            clientes.MapDelete("{id}", async ([FromServices] IMuralisService service, Guid id) =>
            {
                var result = await service.DeletarClienteAsync(id);
                return Results.Json(result, statusCode: result.CodigoStatus);
            });

            clientes.MapGet("", async ([FromServices] IMuralisService service, 
                                       [FromQuery] int pagina = 1,
                                       [FromQuery] int tamanho = 10) =>
            {
                var result = await service.ObterTodosPaginadoAsync(pagina, tamanho);
                return Results.Json(result, statusCode: result.CodigoStatus);
            });

            clientes.MapGet("nome/{nome}", async ([FromServices] IMuralisService service, string nome) =>
            {
                var result = await service.ObterPorNomeClienteAsync(nome);
                return Results.Json(result, statusCode: result.CodigoStatus);
            });
        }
    }
}
