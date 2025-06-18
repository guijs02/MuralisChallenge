using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muralis.Infra.Models
{
    [Table("Contato")]
    public class ContatoModel
    {
        public int Id { get; set; }
        public string Tipo { get; set; } = string.Empty;
        public string Texto { get; set; } = string.Empty;
        public ClienteModel Cliente { get; set; } = null!;
        public int ClienteId { get; set; } 
    }
}
