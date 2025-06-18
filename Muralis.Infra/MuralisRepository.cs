using Muralis.Domain.Entitiy;
using Muralis.Domain.Repositories;
using Muralis.Domain.Response;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Muralis.Infra.Data;
using System.Net;

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
                    Nome = cliente.Nome,
                    DataCadastro = cliente.DataCadastro.ToShortDateString(),
                    Cep = cliente.Endereco.Cep,
                    Numero = cliente.Endereco.Numero,
                    Logradouro = cliente.Endereco.Logradouro,
                    Cidade = cliente.Endereco.Cidade
                };

                context.Cliente.Add(model);
                await context.SaveChangesAsync();
                return new Resposta<bool>(true, "Cliente adicionado com sucesso", (int)HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                return new Resposta<bool>(false, $"Erro ao adicionar cliente: {ex.Message}", (int)HttpStatusCode.InternalServerError);
            }
        }

        public async Task<Resposta<bool>> AlterarAsync(Cliente cliente, int id)
        {
            try
            {
                var model = await context.Cliente.FindAsync(id);

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

        public async Task<Resposta<bool>> DeletarAsync(int id)
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
                var query = context.Cliente.AsNoTracking();

                var totalClientes = await query.CountAsync();
                var totalPaginas = (int)Math.Ceiling(totalClientes / (double)tamanhoPagina);

                var clientes = await query
                    .OrderBy(c => c.Nome)
                    .Skip((numeroPagina - 1) * tamanhoPagina)
                    .Take(tamanhoPagina)
                    .Select(c => new ListaClientePaginadaOutput(c.Nome, c.DataCadastro))
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
    }
}
