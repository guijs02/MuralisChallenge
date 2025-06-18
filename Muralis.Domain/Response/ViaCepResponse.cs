using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muralis.Domain.Response
{
    public class ViaCepResponse
    {
        public string? Cep { get; set; }
        public string? Logradouro { get; set; }
        public string? Localidade { get; set; }
        public string? Uf { get; set; }
        public string? Complemento { get; set; }
        public string? Erro { get; set; }
    }
}
