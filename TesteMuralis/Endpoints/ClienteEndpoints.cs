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
            }).WithOpenApi();

            app.MapPut("/clientes/{id}", async ([FromServices] IMuralisService service, Guid id, [FromBody] AlterarClienteDto dto) =>
            {
                var result = await service.Alterar(dto, id);
                return Results.Json(result, statusCode: result.CodigoStatus);
            }).WithOpenApi();

            app.MapDelete("/clientes/{id}", async ([FromServices] IMuralisService service, Guid id) =>
            {
                var result = await service.Deletar(id);
                return Results.Json(result, statusCode: result.CodigoStatus);
            }).WithOpenApi();

            app.MapGet("/clientes", async ([FromServices] IMuralisService service, [FromQuery] int pagina = 1, [FromQuery] int tamanho = 10) =>
            {
                var result = await service.ObterTodosPaginadoAsync(pagina, tamanho);
                return Results.Json(result, statusCode: result.CodigoStatus);
            }).WithOpenApi();

            app.MapGet("/clientes/nome/{nome}", async ([FromServices] IMuralisService service, string nome) =>
            {
                var result = await service.ObterPorNome(nome);
                return Results.Json(result, statusCode: result.CodigoStatus);
            }).WithOpenApi();

            app.MapPost("/clientes/{id}/contatos", async ([FromServices] IMuralisService service, Guid id, [FromBody] ContatoDto dto) =>
            {
                var result = await service.AdicionarContato(id, dto);
                return Results.Json(result, statusCode: result.CodigoStatus);
            }).WithOpenApi();

            app.MapPut("/clientes/{id}/contatos/{contatoId}", async ([FromServices] IMuralisService service, Guid id, Guid contatoId, [FromBody] ContatoDto dto) =>
            {
                var result = await service.AlterarContato(id, contatoId, dto);
                return Results.Json(result, statusCode: result.CodigoStatus);
            }).WithOpenApi();

            app.MapDelete("/clientes/{id}/contatos/{contatoId}", async ([FromServices] IMuralisService service, Guid id, Guid contatoId) =>
            {
                var result = await service.DeletarContato(id, contatoId);
                return Results.Json(result, statusCode: result.CodigoStatus);
            }).WithOpenApi();
        }
    }
}
