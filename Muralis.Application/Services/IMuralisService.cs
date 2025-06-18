using Muralis.Application.Dtos;
using Muralis.Domain.Response;

namespace Muralis.Application.Services
{
    public interface IMuralisService
    {
        Task<Resposta<bool>> AdicionarClienteAsync(ClienteDto cliente);
        Task<Resposta<bool>> AlterarClienteAsync(AlterarClienteDto cliente, Guid id);
        Task<Resposta<bool>> DeletarClienteAsync(Guid id);
        Task<RespostaPaginada<List<ListaClientePaginadaOutput>>> ObterTodosPaginadoAsync(int numeroPagina, int tamanhoPagina);
        Task<Resposta<ObterClienteNomeOutput>> ObterPorNomeClienteAsync(string nome);
        Task<Resposta<bool>> AdicionarContatoAsync(Guid clienteId, ContatoDto dto);
        Task<Resposta<bool>> AlterarContatoAsync(Guid clienteId, Guid contatoId, ContatoDto dto);
        Task<Resposta<bool>> DeletarContatoAsync(Guid clienteId, Guid contatoId);
    }
}
