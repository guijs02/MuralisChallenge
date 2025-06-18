using Muralis.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muralis.Application.Services
{
    public interface ICepService
    {
        Task<Resposta<CepResult>?> BuscarPorCepAsync(string cep);
    }
    public record CepResult(
       string Cep,
       string Logradouro,
       string Cidade,
       string Estado,
       string Complemento
   );
}
