using Muralis.Application.Dtos;
using Muralis.Domain.Response;

namespace Muralis.Application.Services
{
    public interface IMuralisService
    {
        public Task<Resposta<bool>> Adicionar(ClienteDto cliente);
        public Task<Resposta<bool>> Alterar(ClienteDto cliente, int id);
        public Task<Resposta<bool>> Deletar(int id);
        public Task<RespostaPaginada<List<ListaClientePaginadaOutput>>> ObterTodosPaginadoAsync(int numeroPagina, int tamanhoPagina);
        public Task<Resposta<ObterClienteNomeOutput>> ObterPorNome(string nome);
    }
}
