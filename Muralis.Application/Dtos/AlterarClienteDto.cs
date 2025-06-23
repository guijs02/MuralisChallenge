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
        [StringLength(30, MinimumLength = 1, ErrorMessage = "Deve haver um nome")]
        public string Nome { get; set; } = string.Empty;
        [Required]
        [StringLength(maximumLength: 9, MinimumLength = 8, ErrorMessage = "O CEP deve ter pelo menos 8 caracteres.")]
        public string Cep { get; set; } = string.Empty;
        [Required]
        [StringLength(maximumLength: 9, MinimumLength = 1, ErrorMessage = "Deve haver um número")]
        public string Numero { get; set; } = string.Empty;
    }
}
