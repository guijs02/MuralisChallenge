using System.ComponentModel.DataAnnotations;

namespace Muralis.Domain.Response
{
    public class ObterClienteNomeOutput
    {
        public string Nome { get; set; } = string.Empty;
        public string DataCadastro { get; set; } = string.Empty;
        public string Cep { get; set; } = string.Empty;
        public string Numero { get; set; } = string.Empty;
        public string Logradouro { get; set; } = string.Empty;
        public string Cidade { get; set; } = string.Empty;
    }
}
