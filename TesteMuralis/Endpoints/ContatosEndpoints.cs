using Microsoft.AspNetCore.Mvc;
using Muralis.Application.Dtos;
using Muralis.Application.Services;
using Muralis.Domain.Entitiy;

namespace TesteMuralis.WebApi.Endpoints
{
    public static class ContatosEndpoints
    {
        public static void MapContatosEndpoints(this IEndpointRouteBuilder app)
        {
            var contatos = app.MapGroup("/clientes/{id}/contatos")
                              .WithTags("Contatos")
                              .WithOpenApi();

            contatos.MapPost("", async ([FromServices] IMuralisService service, Guid id, [FromBody] ContatoDto dto) =>
            {
                var result = await service.AdicionarContatoAsync(id, dto);
                return Results.Json(result, statusCode: result.CodigoStatus);
            });

            contatos.MapPut("{contatoId}", async ([FromServices] IMuralisService service,
                                                   Guid id,
                                                   Guid contatoId,
                                                   [FromBody] ContatoDto dto) =>
            {
                var result = await service.AlterarContatoAsync(id, contatoId, dto);
                return Results.Json(result, statusCode: result.CodigoStatus);
            });

            contatos.MapDelete("{contatoId}", async ([FromServices] IMuralisService service, Guid id, Guid contatoId) =>
            {
                var result = await service.DeletarContatoAsync(id, contatoId);
                return Results.Json(result, statusCode: result.CodigoStatus);
            });
        }
    }
}
