using System.ComponentModel.DataAnnotations.Schema;

namespace Muralis.Infra.Models
{
    [Table("Clientes")]
    public class ClienteModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string DataCadastro { get; set; } = string.Empty;
        public string Cep { get; set; } = string.Empty;
        public string Logradouro { get; set; } = string.Empty;
        public string Cidade { get; set; } = string.Empty;
        public string Numero { get; set; } = string.Empty;
        public string Complemento { get; set; } = string.Empty;
        public List<ContatoModel> Contatos { get; set; } = new List<ContatoModel>();
    }
}
