using System.ComponentModel.DataAnnotations.Schema;

namespace Muralis.Infra.Models
{
    [Table("Contato")]
    public class ContatoModel
    {
        public Guid Id { get; set; }
        public string Tipo { get; set; } = string.Empty;
        public string Texto { get; set; } = string.Empty;
        public ClienteModel Cliente { get; set; } = null!;
        public Guid ClienteId { get; set; }
    }
}
