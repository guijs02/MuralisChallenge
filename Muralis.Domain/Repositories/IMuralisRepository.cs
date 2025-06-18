using Muralis.Domain.Aggregates;
using Muralis.Domain.Entitiy;
using Muralis.Domain.Response;

namespace Muralis.Domain.Repositories
{
    public interface IMuralisRepository
    {
        public Task<Resposta<bool>> AdicionarClienteAsync(Cliente cliente);
        public Task<Resposta<bool>> AlterarClienteAsync(Cliente cliente, Guid id);
        public Task<Resposta<bool>> DeletarClienteAsync(Guid id);
        public Task<RespostaPaginada<List<ListaClientePaginadaOutput>>> ObterTodosPaginadoAsync(int numeroPagina, int tamanhoPagina);
        public Task<Resposta<ObterClienteNomeOutput>> ObterPorNomeClienteAsync(string nome);
        Task<Resposta<bool>> AdicionarContatoAsync(Guid clienteId, Contato dto);
        Task<Resposta<bool>> AlterarContatoAsync(Guid clienteId, Guid contatoId, Contato dto);
        Task<Resposta<bool>> DeletarContatoAsync(Guid clienteId, Guid contatoId);
    }
}
