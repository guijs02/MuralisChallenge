using System.ComponentModel.DataAnnotations;

namespace Muralis.Application.Dtos
{
    public class ContatoDto
    {
        [Required]
        public string Tipo { get; set; } = string.Empty;
        [Required]
        public string Texto { get; set; } = string.Empty;
    }
}
