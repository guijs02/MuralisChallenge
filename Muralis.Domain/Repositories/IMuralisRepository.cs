using Muralis.Domain.Aggregates;
using Muralis.Domain.Entitiy;
using Muralis.Domain.Response;

namespace Muralis.Domain.Repositories
{
    public interface IMuralisRepository
    {
        public Task<Resposta<bool>> AdicionarAsync(Cliente cliente);
        public Task<Resposta<bool>> AlterarAsync(Cliente cliente, Guid id);
        public Task<Resposta<bool>> DeletarAsync(Guid id);
        public Task<RespostaPaginada<List<ListaClientePaginadaOutput>>> ObterTodosPaginadoAsync(int numeroPagina, int tamanhoPagina);
        public Task<Resposta<ObterClienteNomeOutput>> ObterPorNomeAsync(string nome);
        Task<Resposta<bool>> AdicionarContatoAsync(Guid clienteId, Contato dto);
        Task<Resposta<bool>> AlterarContatoAsync(Guid clienteId, Guid contatoId, Contato dto);
        Task<Resposta<bool>> DeletarContatoAsync(Guid clienteId, Guid contatoId);
    }
}
