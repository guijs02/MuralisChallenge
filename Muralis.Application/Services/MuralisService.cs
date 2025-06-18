using Muralis.Application.Dtos;
using Muralis.Domain.Entitiy;
using Muralis.Domain.Repositories;
using Muralis.Domain.Response;
using Muralis.Domain.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Muralis.Application.Services
{
    public class MuralisService : IMuralisService
    {
        private readonly IMuralisRepository _muralisRepository;
        private readonly ICepService _cepService;

        public MuralisService(IMuralisRepository muralisRepository, ICepService cepService)
        {
            _muralisRepository = muralisRepository;
            _cepService = cepService;
        }

        public async Task<Resposta<bool>> Adicionar(ClienteDto cliente)
        {
            
            var viaCep = await _cepService.BuscarPorCepAsync(cliente.Cep);

            if (viaCep is null || !viaCep.Sucesso || viaCep.Dados is null)
            {
                return new Resposta<bool>(false, "Erro ao buscar dados do CEP", (int)HttpStatusCode.BadRequest);
            }

            var endereco = new Endereco(
                logradouro: viaCep.Dados.Logradouro, // Ajuste conforme necessário
                numero: cliente.Numero,
                complemento: viaCep.Dados.Complemento, // Ajuste conforme necessário
                cidade: viaCep.Dados.Cidade, // Ajuste conforme necessário
                cep: viaCep.Dados.Cep
            );

            var clienteDomain = new Cliente(
                nome: cliente.Nome,
                endereco: endereco
            );

            // Validação de domínio, se necessário
            clienteDomain.Validar();

            // Chama o repositório
            return await _muralisRepository.AdicionarAsync(clienteDomain);
        }

        public async Task<Resposta<bool>> Alterar(ClienteDto cliente, int id)
        {
            var endereco = new Endereco(
              logradouro: string.Empty, // Ajuste conforme necessário
              numero: cliente.Numero,
              complemento: string.Empty, // Ajuste conforme necessário
              cidade: string.Empty, // Ajuste conforme necessário
              cep: cliente.Cep
            );

            var clienteDomain = new Cliente(
                nome: cliente.Nome,
                endereco: endereco
            );

            clienteDomain.Validar();

            return await _muralisRepository.AlterarAsync(clienteDomain, id);
        }

        public async Task<Resposta<bool>> Deletar(int id)
        {
            return await _muralisRepository.DeletarAsync(id);
        }

        public async Task<Resposta<ObterClienteNomeOutput>> ObterPorNome(string nome)
        {
            return await _muralisRepository.ObterPorNomeAsync(nome);
        }

        public async Task<RespostaPaginada<List<ListaClientePaginadaOutput>>> ObterTodosPaginadoAsync(int numeroPagina, int tamanhoPagina)
        {
            return await _muralisRepository.ObterTodosPaginadoAsync(numeroPagina, tamanhoPagina);
        }
    }
}
