using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muralis.Domain.Response
{
    public record ListaClientePaginadaOutput
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string DataCadastro { get; set; } = string.Empty;
        public string Cep { get; set; } = string.Empty;
        public string Numero { get; set; } = string.Empty;
        public string Logradouro { get; set; } = string.Empty;
        public string Cidade { get; set; } = string.Empty;
        public List<ContatoPaginadoOutput> Contatos { get; set; } = new List<ContatoPaginadoOutput>();
    }
    public record ContatoPaginadoOutput()
    {
        public Guid Id { get; set; }
        public string Tipo { get; set; } = string.Empty;
        public string Texto { get; set; } = string.Empty;
        public Guid ClienteId { get; set; }
    }
}
