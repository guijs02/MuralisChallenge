using Muralis.Application.Dtos;
using Muralis.Domain.Response;

namespace Muralis.Application.Services
{
    public interface IMuralisService
    {
        public Task<Resposta<bool>> Adicionar(ClienteDto cliente);
        public Task<Resposta<bool>> Alterar(AlterarClienteDto cliente, Guid id);
        public Task<Resposta<bool>> Deletar(Guid id);
        public Task<RespostaPaginada<List<ListaClientePaginadaOutput>>> ObterTodosPaginadoAsync(int numeroPagina, int tamanhoPagina);
        public Task<Resposta<ObterClienteNomeOutput>> ObterPorNome(string nome);
        Task<Resposta<bool>> AdicionarContato(Guid clienteId, ContatoDto dto);
        Task<Resposta<bool>> AlterarContato(Guid clienteId, Guid contatoId, ContatoDto dto);
        Task<Resposta<bool>> DeletarContato(Guid clienteId, Guid contatoId);
    }
}
