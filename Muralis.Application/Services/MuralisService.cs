using Muralis.Application.Dtos;
using Muralis.Application.Mapping;
using Muralis.Domain.Aggregates;
using Muralis.Domain.Entitiy;
using Muralis.Domain.Factory;
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

        public async Task<Resposta<bool>> AdicionarClienteAsync(ClienteDto cliente)
        {
            
            var viaCep = await _cepService.BuscarPorCepAsync(cliente.Cep);

            if (viaCep is null || !viaCep.Sucesso || viaCep.Dados is null)
            {
                return new Resposta<bool>(false, "Erro ao buscar dados do CEP", (int)HttpStatusCode.BadRequest);
            }

            var clienteProps = cliente.ToClienteProps(viaCep.Dados);

            var clienteDomain = ClienteFactory.Criar(clienteProps);

            // Validação de domínio, se necessário
            clienteDomain.Validar();

            if (clienteDomain.Notification.PossuiErros())
            {
                return new Resposta<bool>(false,
                                    clienteDomain.Notification.ObterMensagens(nameof(Cliente)),
                                    (int)HttpStatusCode.BadRequest);
            }

            // Chama o repositório
            return await _muralisRepository.AdicionarClienteAsync(clienteDomain);
        }

        public async Task<Resposta<bool>> AlterarClienteAsync(AlterarClienteDto cliente, Guid id)
        {
            var viaCep = await _cepService.BuscarPorCepAsync(cliente.Cep);

            if (viaCep is null || !viaCep.Sucesso || viaCep.Dados is null)
            {
                return new Resposta<bool>(false, "Erro ao buscar dados do CEP", (int)HttpStatusCode.BadRequest);
            }

            var clienteProps = cliente.ToClienteProps(viaCep.Dados);

            var clienteDomain = ClienteFactory.Criar(clienteProps);

            clienteDomain.Validar();

            if (clienteDomain.Notification.PossuiErros())
            {
                return new Resposta<bool>(false,
                                    clienteDomain.Notification.ObterMensagens(nameof(Cliente)),
                                    (int)HttpStatusCode.BadRequest);
            }

            return await _muralisRepository.AlterarClienteAsync(clienteDomain, id);
        }

        public async Task<Resposta<bool>> DeletarClienteAsync(Guid id)
        {
            return await _muralisRepository.DeletarClienteAsync(id);
        }

        public async Task<Resposta<ObterClienteNomeOutput>> ObterPorNomeClienteAsync(string nome)
        {
            return await _muralisRepository.ObterPorNomeClienteAsync(nome);
        }

        public async Task<RespostaPaginada<List<ListaClientePaginadaOutput>>> ObterTodosPaginadoAsync(int numeroPagina, int tamanhoPagina)
        {
            return await _muralisRepository.ObterTodosPaginadoAsync(numeroPagina, tamanhoPagina);
        }
        public async Task<Resposta<bool>> AdicionarContatoAsync(Guid clienteId, ContatoDto dto)
        {
            var contato = new Contato(Guid.NewGuid(), dto.Tipo, dto.Texto, clienteId);
            return await _muralisRepository.AdicionarContatoAsync(clienteId, contato);
        }

        public async Task<Resposta<bool>> AlterarContatoAsync(Guid clienteId, Guid contatoId, ContatoDto dto)
        {
            var contato = new Contato(Guid.NewGuid(), dto.Tipo, dto.Texto, clienteId);
            return await _muralisRepository.AlterarContatoAsync(clienteId, contatoId, contato);
        }

        public async Task<Resposta<bool>> DeletarContatoAsync(Guid clienteId, Guid contatoId)
        {
            return await _muralisRepository.DeletarContatoAsync(clienteId, contatoId);
        }
    }
}
