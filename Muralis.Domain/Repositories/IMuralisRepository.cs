using Muralis.Domain.Entitiy;
using Muralis.Domain.Response;

namespace Muralis.Domain.Repositories
{
    public interface IMuralisRepository
    {
        public Task<Resposta<bool>> AdicionarAsync(Cliente cliente);
        public Task<Resposta<bool>> AlterarAsync(Cliente cliente, int id);
        public Task<Resposta<bool>> DeletarAsync(int id);
        public Task<RespostaPaginada<List<ListaClientePaginadaOutput>>> ObterTodosPaginadoAsync(int numeroPagina, int tamanhoPagina);
        public Task<Resposta<ObterClienteNomeOutput>> ObterPorNomeAsync(string nome);
    }
}
