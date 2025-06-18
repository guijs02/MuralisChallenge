using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muralis.Application.Dtos
{
    public class AlterarClienteDto
    {
        [Required]
        public string Nome { get; set; } = string.Empty;
        [Required]
        [Length(1, 8)]
        public string Cep { get; set; } = string.Empty;
        [Required]
        public string Numero { get; set; } = string.Empty;
    }
}
