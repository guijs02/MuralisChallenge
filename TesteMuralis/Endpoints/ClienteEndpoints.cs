using Microsoft.AspNetCore.Mvc;
using Muralis.Application.Dtos;
using Muralis.Application.Services;

namespace TesteMuralis.WebApi.Endpoints
{
    public static class ClienteEndpoints
    {
        public static void MapClienteEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapPost("/clientes", async ([FromServices] IMuralisService service, [FromBody] ClienteDto dto) =>
            {
                var result = await service.Adicionar(dto);
                return Results.Json(result, statusCode: result.CodigoStatus);
            });

            app.MapPut("/clientes/{id:int}", async ([FromServices] IMuralisService service, int id, [FromBody] ClienteDto dto) =>
            {
                var result = await service.Alterar(dto, id);
                return Results.Json(result, statusCode: result.CodigoStatus);
            });

            app.MapDelete("/clientes/{id:int}", async ([FromServices] IMuralisService service, int id) =>
            {
                var result = await service.Deletar(id);
                return Results.Json(result, statusCode: result.CodigoStatus);
            });

            app.MapGet("/clientes", async ([FromServices] IMuralisService service, [FromQuery] int pagina = 1, [FromQuery] int tamanho = 10) =>
            {
                var result = await service.ObterTodosPaginadoAsync(pagina, tamanho);
                return Results.Json(result, statusCode: result.CodigoStatus);
            });

            app.MapGet("/clientes/nome/{nome}", async ([FromServices] IMuralisService service, string nome) =>
            {
                var result = await service.ObterPorNome(nome);
                return Results.Json(result, statusCode: result.CodigoStatus);
            });
        }
    }
}
