using Microsoft.EntityFrameworkCore;
using Muralis.Domain.Aggregates;
using Muralis.Domain.Entitiy;
using Muralis.Domain.Repositories;
using Muralis.Domain.Response;
using Muralis.Infra.Data;
using Muralis.Infra.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Muralis.Infra
{
    public class MuralisRepository(MuralisAppContext context) : IMuralisRepository
    {
        public async Task<Resposta<bool>> AdicionarAsync(Cliente cliente)
        {
            try
            {
                var model = new Models.ClienteModel
                {
                    Id = cliente.Id,
                    Nome = cliente.Nome,
                    DataCadastro = cliente.DataCadastro.ToShortDateString(),
                    Cep = cliente.Endereco.Cep,
                    Numero = cliente.Endereco.Numero,
                    Logradouro = cliente.Endereco.Logradouro,
                    Cidade = cliente.Endereco.Cidade,
                    Complemento = cliente.Endereco.Complemento,
                };

                if (cliente.Contatos != null)
                {
                    foreach (var item in cliente.Contatos)
                    {
                        model.Contatos.Add(new Models.ContatoModel
                        {
                            Id = item.Id,
                            Texto = item.Texto,
                            Tipo = item.Tipo
                        });
                    }
                }

                context.Cliente.Add(model);
                await context.SaveChangesAsync();
                return new Resposta<bool>(true, "Cliente adicionado com sucesso", (int)HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                return new Resposta<bool>(false, $"Erro ao adicionar cliente: {ex.Message}", (int)HttpStatusCode.InternalServerError);
            }
        }

        public async Task<Resposta<bool>> AlterarAsync(Cliente cliente, Guid id)
        {
            try
            {
                var model = await context.Cliente.Where(model => model.Id == id)
                                                 .FirstOrDefaultAsync();

                if (model == null)
                    return new Resposta<bool>(false, "Cliente não encontrado", (int)HttpStatusCode.NotFound);

                model.Nome = cliente.Nome;
                model.DataCadastro = cliente.DataCadastro.ToShortDateString();
                model.Cep = cliente.Endereco.Cep;
                model.Numero = cliente.Endereco.Numero;
                model.Logradouro = cliente.Endereco.Logradouro;
                model.Cidade = cliente.Endereco.Cidade;

                await context.SaveChangesAsync();

                return new Resposta<bool>(true, "Cliente alterado com sucesso");
            }
            catch (Exception ex)
            {
                return new Resposta<bool>(false, $"Erro ao alterar cliente: {ex.Message}", (int)HttpStatusCode.InternalServerError);
            }
        }

        public async Task<Resposta<bool>> DeletarAsync(Guid id)
        {
            try
            {
                var model = await context.Cliente.FindAsync(id);
                if (model == null)
                    return new Resposta<bool>(false, "Cliente não encontrado", (int)HttpStatusCode.NotFound);

                context.Cliente.Remove(model);
                await context.SaveChangesAsync();
                return new Resposta<bool>(true, "Cliente deletado com sucesso");
            }
            catch (Exception ex)
            {
                return new Resposta<bool>(false, $"Erro ao deletar cliente: {ex.Message}", (int)HttpStatusCode.InternalServerError);
            }
        }

        public async Task<Resposta<ObterClienteNomeOutput>> ObterPorNomeAsync(string nome)
        {
            try
            {
                var model = await context.Cliente
                    .AsNoTracking()
                    .FirstOrDefaultAsync(c => c.Nome == nome);

                if (model == null)
                    return new Resposta<ObterClienteNomeOutput>(null, "Cliente não encontrado", (int)HttpStatusCode.NotFound);

                var output = new ObterClienteNomeOutput
                {
                    Nome = model.Nome,
                    DataCadastro = model.DataCadastro,
                    Cep = model.Cep,
                    Numero = model.Numero,
                    Logradouro = model.Logradouro,
                    Cidade = model.Cidade
                };

                return new Resposta<ObterClienteNomeOutput>(output);
            }
            catch (Exception ex)
            {
                return new Resposta<ObterClienteNomeOutput>(null, $"Erro ao obter cliente: {ex.Message}", (int)HttpStatusCode.InternalServerError);
            }
        }

        public async Task<RespostaPaginada<List<ListaClientePaginadaOutput>>> ObterTodosPaginadoAsync(int numeroPagina, int tamanhoPagina)
        {
            try
            {
                var query = context.Cliente.Include(s => s.Contatos);

                var totalClientes = await query.CountAsync();
                var totalPaginas = (int)Math.Ceiling(totalClientes / (double)tamanhoPagina);

                var clientes = await query
                    .OrderBy(c => c.Nome)
                    .Skip((numeroPagina - 1) * tamanhoPagina)
                    .Take(tamanhoPagina)
                    .Select(c => new ListaClientePaginadaOutput
                    {
                        Cep = c.Cep,
                        Cidade = c.Cidade,
                        DataCadastro = c.DataCadastro,
                        Logradouro = c.Logradouro,
                        Id = c.Id,
                        Nome = c.Nome,
                        Numero = c.Numero,
                        Contatos = c.Contatos.Select(s => new ContatoPaginadoOutput
                        {
                            Id = s.Id,
                            ClienteId = s.ClienteId,
                            Texto = s.Texto,
                            Tipo = s.Tipo,
                        })
                        .ToList()
                    })
                    .ToListAsync();

                return new RespostaPaginada<List<ListaClientePaginadaOutput>>(
                    clientes,
                    numeroPagina,
                    tamanhoPagina,
                    totalPaginas,
                    "Clientes paginados obtidos com sucesso"
                );
            }
            catch (Exception ex)
            {
                return new RespostaPaginada<List<ListaClientePaginadaOutput>>(
                    null,
                    numeroPagina,
                    tamanhoPagina,
                    0,
                    $"Erro ao obter clientes paginados: {ex.Message}",
                    (int)HttpStatusCode.InternalServerError
                );
            }
        }

        public async Task<Resposta<bool>> AdicionarContatoAsync(Guid clienteId, Contato entity)
        {
            var clienteDb = await context.Cliente.Include(c => c.Contatos).FirstOrDefaultAsync(c => c.Id == clienteId);
            if (clienteDb == null)
                return new Resposta<bool>(false, "Cliente não encontrado", (int)HttpStatusCode.NotFound);

            var contato = new ContatoModel
            {
                Id = Guid.NewGuid(),
                Tipo = entity.Tipo,
                Texto = entity.Texto,
                ClienteId = clienteId
            };

            context.Contato.Add(contato);
            await context.SaveChangesAsync();
            return new Resposta<bool>(true, "Contato adicionado com sucesso", (int)HttpStatusCode.Created);
        }

        public async Task<Resposta<bool>> AlterarContatoAsync(Guid clienteId, Guid contatoId, Contato entity)
        {
            var contato = await context.Contato.FirstOrDefaultAsync(c => c.Id == contatoId && c.ClienteId == clienteId);
            if (contato == null)
                return new Resposta<bool>(false, "Contato não encontrado", (int)HttpStatusCode.NotFound);

            contato.Tipo = entity.Tipo;
            contato.Texto = entity.Texto;
            await context.SaveChangesAsync();
            return new Resposta<bool>(true, "Contato alterado com sucesso");
        }

        public async Task<Resposta<bool>> DeletarContatoAsync(Guid clienteId, Guid contatoId)
        {
            var contato = await context.Contato.FirstOrDefaultAsync(c => c.Id == contatoId && c.ClienteId == clienteId);
            if (contato == null)
                return new Resposta<bool>(false, "Contato não encontrado", (int)HttpStatusCode.NotFound);

            context.Contato.Remove(contato);
            await context.SaveChangesAsync();
            return new Resposta<bool>(true, "Contato removido com sucesso");
        }
    }
}
